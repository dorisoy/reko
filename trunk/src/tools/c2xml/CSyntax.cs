﻿#region License
/* 
 * Copyright (C) 1999-2013 John Källén.
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

using System;
using System.Collections.Generic;
using System.Text;

namespace Decompiler.Tools.C2Xml
{
    public abstract class CSyntax
    {
        public abstract T Accept<T>(CSyntaxVisitor<T> visitor);
    }

    public class CType : CSyntax
    {
        public Declarator Declarator;
        public List<DeclSpec> DeclSpecList;

        public override T Accept<T>(CSyntaxVisitor<T> visitor)
        {
            return visitor.VisitType(this);
        }
    }

    public class ExternalDecl : Decl
    {
    }

    public class FunctionDecl : Decl
    {
        public Decl Signature;
        public List<Stat> Body;
    }

    public class Decl : CSyntax
    {
        public List<DeclSpec> decl_specs;
        public List<InitDeclarator> init_declarator_list;

        public override T Accept<T>(CSyntaxVisitor<T> visitor)
        {
            return visitor.VisitDeclaration(this);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("(decl");
            foreach (var ds in decl_specs)
            {
                sb.Append(" ");
                sb.Append(ds);
            }
            if (init_declarator_list != null && init_declarator_list.Count > 0)
            {
                var sep = " (";
                foreach (var init in init_declarator_list)
                {
                    sb.AppendFormat("{0}{1}", sep, init);
                    sep = " ";
                }
                sb.Append(")");
            }
            sb.Append(")");
            return sb.ToString();
        }
    }

    public interface DeclSpecVisitor<T>
    {
        T VisitSimpleType(SimpleTypeSpec simpleType);
        T VisitTypedef(TypeDefName typeDefName);
        T VisitComplexType(ComplexTypeSpec complexType);
        T VisitStorageClass(StorageClassSpec storageClass);
        T VisitTypeQualifier(TypeQualifier typeQualifier);
        T VisitEnum(EnumeratorTypeSpec enumeratorTypeSpec);
    }

    public abstract class DeclSpec : CSyntax
    {
        public override T Accept<T>(CSyntaxVisitor<T> visitor)
        {
            return visitor.VisitDeclSpec(this);
        }

        public abstract T Accept<T>(DeclSpecVisitor<T> visitor);
    }

    public abstract class TypeSpec : DeclSpec
    {
    }

    public class TypeQualifier : DeclSpec
    {
        public CTokenType Qualifier;

        public override T Accept<T>(DeclSpecVisitor<T> visitor)
        {
            return visitor.VisitTypeQualifier(this);
        }
    }

    public class StorageClassSpec : DeclSpec
    {
        public CTokenType Type;

        public override T Accept<T>(DeclSpecVisitor<T> visitor)
        {
            return visitor.VisitStorageClass(this);
        }

        public override string ToString() { return Type.ToString(); }
    }

    public class SimpleTypeSpec : TypeSpec
    {
        public CTokenType Type;

        public override T Accept<T>(DeclSpecVisitor<T> visitor)
        {
            return visitor.VisitSimpleType(this);
        }

        public override string ToString() { return Type.ToString(); }
    }

    public class TypeDefName : TypeSpec
    {
        public string Name;

        public override T Accept<T>(DeclSpecVisitor<T> visitor)
        {
            return visitor.VisitTypedef(this);
        }
    }

    public class ComplexTypeSpec : TypeSpec
    {
        public CTokenType Type;
        public string Name;
        public List<StructDecl> DeclList;

        public override T Accept<T>(DeclSpecVisitor<T> visitor)
        {
            return visitor.VisitComplexType(this);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("({0} ", Type);
            if (!string.IsNullOrEmpty(Name))
                sb.AppendFormat("{0} ", Name);
            var sep = "(";
            foreach (var sd in DeclList)
            {
                sb.AppendFormat("{0}{1}", sep, sd);
                sep = " ";
            }
            sb.Append(")");
            return sb.ToString();
        }
    }

    public class EnumeratorTypeSpec : TypeSpec
    {
        public string Tag;
        public List<Enumerator> Enums;

        public override T Accept<T>(DeclSpecVisitor<T> visitor)
        {
            return visitor.VisitEnum(this);
        }
    }

    public class Enumerator : CSyntax
    {
        public string Name;
        public CExpression Value;

        public override T Accept<T>(CSyntaxVisitor<T> visitor)
        {
            return visitor.VisitEnumerator(this);
        }

        public override string ToString()
        {
            return (Value == null)
                ? string.Format("({0})", Name)
                : string.Format("({0} {1})", Name, Value);
        }
    }

    public interface DeclaratorVisitor<T>
    {
        T VisitId(IdDeclarator idDeclarator);
        T VisitArray(ArrayDeclarator array);
        T VisitField(FieldDeclarator field);
        T VisitPointer(PointerDeclarator pointer);
        T VisitFunction(FunctionDeclarator function);

    }

    public class InitDeclarator : CSyntax
    {
        public Declarator Declarator;
        public Initializer Init;

        public override T Accept<T>(CSyntaxVisitor<T> visitor)
        {
            return visitor.VisitInitDeclarator(this);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("(init-decl ");
            sb.Append(Declarator);
            if (this.Init != null)
            {
                sb.AppendFormat(" {0}", Init);
            }
            sb.Append(")");
            return sb.ToString();
        }
    }


    public abstract class Declarator
    {
        public abstract T Accept<T>(DeclaratorVisitor<T> visitor);
    }

    public class ParamDecl : CSyntax
    {
        public List<DeclSpec> DeclSpecs;
        public Declarator Declarator;

        public override T Accept<T>(CSyntaxVisitor<T> visitor)
        {
            return visitor.VisitParamDeclaration(this);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("(");
            foreach (var declspec in DeclSpecs)
            {
                sb.Append(declspec);
                sb.Append(" ");
            }
            sb.Append(Declarator);
            sb.Append(")");
            return sb.ToString();
        }
    }

    public class PointerDeclarator : Declarator
    {
        public Declarator Pointee;
        public List<TypeQualifier> TypeQualifierList;

        public override T Accept<T>(DeclaratorVisitor<T> visitor)
        {
            return visitor.VisitPointer(this);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("(ptr");
            if (TypeQualifierList != null && TypeQualifierList.Count > 0)
            {
                foreach (var tq in TypeQualifierList)
                {
                    sb.AppendFormat(" {0}", tq);
                }
            }
            sb.AppendFormat(" {0})", Pointee);
            return sb.ToString();
        }
    }

    public class IdDeclarator : Declarator
    {
        public string Name;

        public override T Accept<T>(DeclaratorVisitor<T> visitor)
        {
            return visitor.VisitId(this);
        }

        public override string ToString() { return Name; }
    }

    public class FunctionDeclarator : Declarator
    {
        public Declarator Declarator;
        public List<ParamDecl> Parameters;

        public override T Accept<T>(DeclaratorVisitor<T> visitor)
        {
            return visitor.VisitFunction(this);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("(func ");
            sb.Append(Declarator);
            var sep = " (";
            foreach (var param in Parameters)
            {
                sb.Append(sep);
                sb.Append(param);
                sep = " ";
            }
            sb.Append("))");
            return sb.ToString();
        }
    }

    public class ArrayDeclarator : Declarator
    {
        public Declarator Declarator;
        public CExpression Size;

        public override T Accept<T>(DeclaratorVisitor<T> visitor)
        {
            return visitor.VisitArray(this);
        }

        public override string ToString() { return string.Format("(arr {0} {1})", Declarator, Size); }
    }

    public class StructDecl : CSyntax
    {
        public List<DeclSpec> SpecQualifierList;
        public List<FieldDeclarator> FieldDeclarators;

        public override T Accept<T>(CSyntaxVisitor<T> visitor)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("(");
            foreach (var sq in SpecQualifierList)
            {
                sb.AppendFormat(" {0}", sq);
            }
            sb.Append(") (");
            foreach (var d in FieldDeclarators)
            {
                sb.AppendFormat(" {0}", d);
            }
            sb.Append(")");
            return sb.ToString();
        }
    }

    public class FieldDeclarator : Declarator
    {
        public Declarator Declarator;
        public CExpression FieldSize;

        public override T Accept<T>(DeclaratorVisitor<T> visitor)
        {
            return visitor.VisitField(this);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("({0}", Declarator);
            if (FieldSize != null)
                sb.AppendFormat(" {0}", FieldSize);
            sb.Append(")");
            return sb.ToString();
        }
    }

    public abstract class Initializer
    {
    }

    public class ListInitializer : Initializer
    {
        public List<Initializer> List;
    }

    public class ExpressionInitializer : Initializer
    {
        public CExpression Expression;

        public override string ToString() { return Expression.ToString(); }
    }

    #region Expressions

    public abstract class CExpression : CSyntax
    {
        public override T Accept<T>(CSyntaxVisitor<T> visitor)
        {
            return visitor.VisitExpression(this);
        }
    }

    public class ConstExp : CExpression
    {
        public object Const;
        public override string ToString() { return Const != null ? Const.ToString() : ""; }
    }

    public class CIdentifier : CExpression
    {
        public string Name;
        public override string ToString() { return Name; }
    }

    public class CUnaryExpression : CExpression
    {
        public CTokenType Operation;
        public CExpression Expression;
        public override string ToString() { return string.Format("({0} {1})", Operation, Expression); }
    }

    public class CBinaryExpression : CExpression
    {
        public CTokenType Operation;
        public CExpression Left;
        public CExpression Right;
        public override string ToString() { return string.Format("({0} {1} {2})", Operation, Left, Right); }
    }

    public class AssignExpression : CExpression
    {
        public CTokenType AssingmentOp;
        public CExpression LValue;
        public CExpression RValue;
    }

    public class CastExpression : CExpression
    {
        public CType Type;
        public CExpression Expression;
    }

    public class ConditionalExpression : CExpression
    {
        public CExpression Condition;
        public CExpression Consequent;
        public CExpression Alternative;
    }

    #endregion

    #region Statements

    public abstract class Stat : CSyntax
    {
        public override T Accept<T>(CSyntaxVisitor<T> visitor)
        {
            return visitor.VisitStatement(this);
        }
    }

    public class LabeledStat : Stat
    {
        public Label Label;
        public Stat Stat;
    }

    public class DeclStat : Stat
    {
        public Decl Declaration;
        public CExpression Initializer;
    }

    public abstract class Label
    {
    }

    public class LineLabel : Label
    {
        public string Name;

        public override string ToString() { return string.Format("label {0})", Name); }
    }

    public class CaseLabel : Label
    {
        public CExpression Value;

        public override string ToString()
        {
            if (Value == null)
                return "(default)";
            else
                return string.Format("(case {0})", Value);
        }
    }

    public class ForStat : Stat
    {
        public Stat Initializer;
        public CExpression Test;
        public CExpression Update;
        public Stat Body;
    }

    public class ReturnStat : Stat
    {
        public CExpression Expression;
    }

    public class ExprStat : Stat
    {
        public CExpression Expression;
    }

    #endregion
}
