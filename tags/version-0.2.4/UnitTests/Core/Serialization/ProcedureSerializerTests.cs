#region License
/* 
 * Copyright (C) 1999-2013 John K�ll�n.
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

using Decompiler.Arch.X86;
using Decompiler.Core;
using Decompiler.Core.Expressions;
using Decompiler.Core.Serialization;
using Decompiler.Core.Types;
using NUnit.Framework;
using System;
using System.Xml;
using System.Xml.Serialization;

namespace Decompiler.UnitTests.Core.Serialization
{
    [TestFixture]
    public class ProcedureSerializerTests
    {
        private IntelArchitecture arch = new IntelArchitecture(ProcessorMode.ProtectedFlat);

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            ProcedureSerializer ser = new ProcedureSerializer(arch, "stdapi");
            ProcedureSignature sig = new ProcedureSignature(
                new Identifier("qax", 0, PrimitiveType.Word32, Registers.eax),
                new Identifier[] {
                    new Identifier("qbx", 0, PrimitiveType.Word32, Registers.ebx)
                });
                
            SerializedSignature ssig = ser.Serialize(sig);
            Assert.IsNotNull(ssig.ReturnValue);
            Assert.AreEqual("qax", ssig.ReturnValue.Name);
            SerializedRegister sreg = (SerializedRegister) ssig.ReturnValue.Kind;
            Assert.AreEqual("eax", sreg.Name);
        }

        [Test]
        public void SsigSerializeAxBxCl()
        {
            ProcedureSerializer ser = new ProcedureSerializer(arch, "stdapi");
            SerializedSignature ssig = ser.Serialize(SerializedSignatureTests.MkSigAxBxCl());
            Verify(ssig, "Core/SsigSerializeAxBxCl.txt");
        }

        [Test]
        public void SsigSerializeSequence()
        {
            Identifier seq = new Identifier("es_bx", 0, PrimitiveType.Word32, new SequenceStorage(
                new Identifier(Registers.es.Name, 0, Registers.es.DataType, Registers.es),
                new Identifier(Registers.bx.Name, 1, Registers.bx.DataType, Registers.bx)));
            ProcedureSerializer ser = new ProcedureSerializer(arch, "stdapi");
            SerializedSignature ssig = ser.Serialize(new ProcedureSignature(seq, new Identifier[0]));
            Verify(ssig, "Core/SsigSerializeSequence.txt");

        }

        [Test]
        public void SerializeProcedure()
        {
            Procedure proc = new Procedure("foo", arch.CreateFrame());
            Address addr = new Address(0x12345);
            ProcedureSerializer ser = new ProcedureSerializer(arch, "stdapi");
            SerializedProcedure sproc =  ser.Serialize(proc, addr);
            Assert.AreEqual("foo", sproc.Name);
            Assert.AreEqual("00012345", sproc.Address);
        }

        [Test]
        public void SerializeProcedureWithSignature()
        {
            Procedure proc = new Procedure("foo", arch.CreateFrame());
            proc.Signature = new ProcedureSignature(
                new Identifier("eax", 0, PrimitiveType.Word32, Registers.eax),
                new Identifier[] {
                    new Identifier("arg00", 0, PrimitiveType.Word32, new StackArgumentStorage(0, PrimitiveType.Word32))
                });
            
            Address addr = new Address(0x567A0C);
            ProcedureSerializer ser = new ProcedureSerializer(arch, "stdapi");
            SerializedProcedure sproc = ser.Serialize(proc, addr);
            Assert.AreEqual("eax", sproc.Signature.ReturnValue.Name);
        }

        [Test]
        public void DeserializeFpuStackargument()
        {
            var ssig = new SerializedSignature
            {
                Convention = "stdapi",
                ReturnValue = new SerializedArgument {
                    Type = "int", 
                    Kind = new SerializedRegister { Name = "eax" },
                },
                Arguments = new SerializedArgument[] {
                    new SerializedArgument {
                        Type = "double", 
                        Kind = new SerializedFpuStackVariable {
                            ByteSize = 8
                        }
                    }
                }
            };
            var ps = new ProcedureSerializer(arch, "stdapi");
            var sig = ps.Deserialize(ssig, arch.CreateFrame());
            Assert.AreEqual(-1, sig.FpuStackDelta);
        }

        [Test]
        public void DeserializeFpuStackReturnValue()
        {
            var ssig = new SerializedSignature
            {
                Convention = "stdapi",
                ReturnValue = new SerializedArgument
                {
                    Type = "double",
                    Kind = new SerializedFpuStackVariable { ByteSize = 8 },
                }
            };
            var ps = new ProcedureSerializer(arch, "stdapi");
            var sig = ps.Deserialize(ssig, arch.CreateFrame());
            Assert.AreEqual(1, sig.FpuStackDelta);
        }
    

        private void Verify(SerializedSignature ssig, string outputFilename)
        {
            using (FileUnitTester fut = new FileUnitTester(outputFilename))
            {
                XmlTextWriter x = new FilteringXmlWriter(fut.TextWriter);
                x.Formatting = Formatting.Indented;
                XmlSerializer ser = new XmlSerializer(ssig.GetType());
                ser.Serialize(x, ssig);
                fut.AssertFilesEqual();
            }
        }
    }
}
