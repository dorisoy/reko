#region License
/* 
 * Copyright (C) 1999-2011 John K�ll�n.
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2, or (at your option)
 * any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; see the file COPYING.  If not, write to
 * the Free Software Foundation, 675 Mass Ave, Cambridge, MA 02139, USA.
 */
#endregion

using Decompiler.Core;
using Decompiler.Core.Code;
using Decompiler.Core.Expressions;
using Decompiler.Core.Operators;
using Decompiler.Core.Types;
using System;
using System.Collections.Generic;

namespace Decompiler.Core
{
	/// <summary>
	/// Builds a function application from a call site and a callee.
	/// </summary>
    /// <summary>
    /// <remarks>
    /// liveIn registers that are passed in and out are marked as 'out arguments'
    ///
    /// If there is only one 'out' argument, then it is returned as the return value of the
    /// function. If there are several return values:
    ///   If one and only one of them is a flag register, it becomes the return value.
    ///   If more registers are returned, they all become out registers and the function
    ///    is declared void, unless flags are returned.
    /// </remarks>
    //$TODO: make this a StorageVisitor and move teh Storage.BindFormaArgumentToFrame method here
    public class ApplicationBuilder : StorageVisitor<Expression>
	{
        private IProcessorArchitecture arch;
        private Frame frame;
        private CallSite site;
        private Expression callee;
        private ProcedureSignature sigCallee;

        public ApplicationBuilder(IProcessorArchitecture arch, Frame frame, CallSite site, Expression callee, ProcedureSignature sigCallee)
        {
			if (sigCallee == null || !sigCallee.ArgumentsValid)
				throw new InvalidOperationException("No signature available; application cannot be constructed.");

            this.arch = arch;
            this.site = site;
            this.frame = frame;
            this.callee = callee;
            this.sigCallee = sigCallee;
        }

        private List<Expression> BindArguments(Frame frame, CallSite cs, ProcedureSignature sigCallee)
        {
            var actuals = new List<Expression>();
            for (int i = 0; i < sigCallee.FormalArguments.Length; ++i)
            {
                var formalArg = sigCallee.FormalArguments[i];
                var actualArg = formalArg.Storage.Accept(this);
                if (formalArg.Storage is OutArgumentStorage)
                {
                    actuals.Add(new UnaryExpression(UnaryOperator.AddrOf, frame.FramePointer.DataType, actualArg));
                }
                else
                {
                    actuals.Add(actualArg);
                }
            }
            return actuals;
        }

        private Identifier FindReturnValue(CallSite cs, ProcedureSignature sigCallee)
        {
            Identifier idOut = null;
            if (sigCallee.ReturnValue != null)
            {
                idOut = (Identifier) Bind(sigCallee.ReturnValue, cs);
            }
            return idOut;

        }

		public Expression Bind(Identifier id, CallSite cs)
		{
            return id.Storage.Accept(this);
		}

        public Instruction CreateInstruction()
        {
            var idOut = FindReturnValue(site, sigCallee);
            List<Expression> actuals = BindArguments(frame, site, sigCallee);
            var appl = new Application(
                callee,
                (idOut == null ? PrimitiveType.Void : idOut.DataType),
                actuals.ToArray());

			if (idOut == null)
			{
                return new SideEffect(appl);
			}
			else
			{
                return new Assignment(idOut, appl);
			}
        }

        #region StorageVisitor<Expression> Members

        public Expression VisitFlagGroupStorage(FlagGroupStorage grf)
        {
            return frame.EnsureFlagGroup(grf.FlagGroup, grf.Name, PrimitiveType.Byte);		//$REVIEW: PrimitiveType.Byte is hard-wired here.
        }

        public Expression VisitFpuStackStorage(FpuStackStorage fpu)
        {
            return frame.EnsureFpuStackVariable(fpu.FpuStackOffset - site.FpuStackDepthBefore, fpu.DataType);
        }

        public Expression VisitMemoryStorage(MemoryStorage global)
        {
            throw new NotSupportedException(string.Format("A {0} can't be used as a formal parameter.", global.GetType().FullName));
        }

        public Expression VisitStackLocalStorage(StackLocalStorage local)
        {
            throw new NotSupportedException(string.Format("A {0} can't be used as a formal parameter.", local.GetType().FullName));
        }

        public Expression VisitOutArgumentStorage(OutArgumentStorage arg)
        {
            return arg.OriginalIdentifier.Storage.Accept(this);
        }

        public Expression VisitRegisterStorage(RegisterStorage reg)
        {
			return frame.EnsureRegister(reg.Register);
        }

        public Expression VisitSequenceStorage(SequenceStorage seq)
        {
            var h = seq.Head.Storage.Accept(this);
            var t = seq.Tail.Storage.Accept(this);
            var idHead = h as Identifier;
            var idTail = t as Identifier;
            if (idHead != null && idTail != null)
                return frame.EnsureSequence(idHead, idTail, PrimitiveType.CreateWord(idHead.DataType.Size + idTail.DataType.Size));
            throw new NotImplementedException("Handle case when stack parameter is passed.");
        }

        public Expression VisitStackArgumentStorage(StackArgumentStorage stack)
        {
            return arch.CreateStackAccess(frame, stack.StackOffset - sigCallee.ReturnAddressOnStack, stack.DataType);
        }

        public Expression VisitTemporaryStorage(TemporaryStorage temp)
        {
            throw new NotSupportedException(string.Format("A {0} can't be used as a formal parameter.", temp.GetType().FullName));
        }

        #endregion
    }
}
