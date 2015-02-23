﻿#region License
/* 
 * Copyright (C) 1999-2015 John Källén.
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
using Decompiler.Core.Serialization;
using Decompiler.Core.Types;
using Decompiler.Loading;
using NUnit.Framework;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;

namespace Decompiler.UnitTests.Core.Serialization
{
    [TestFixture]
    public class ProjectSerializerTests
    {
        private MockRepository mr;
        private ILoader loader;

        [SetUp]
        public void Setup()
        {
            mr = new MockRepository();
            loader = mr.Stub<ILoader>();
        }
        
        [Test]
        public void Ps_Load()
        {
            var bytes = new byte[100];
            loader.Stub(l => l.LoadImageBytes(null, 0)).IgnoreArguments().Return(bytes);
            loader.Stub(l => l.LoadExecutable(null, null, null)).IgnoreArguments().Return(new Program());
            mr.ReplayAll();

            var ps = new ProjectLoader("", loader);
            var proj = ps.LoadProject(FileUnitTester.MapTestPath("fragments/multiple/termination.xml"));

            Assert.AreEqual(1, proj.Programs[0].UserProcedures.Count);
        }

        [Test]
        public void Ps_Load_v1()
        {
            var bytes = new byte[100];
            loader.Stub(l => l.LoadImageBytes(null, 0)).IgnoreArguments().Return(bytes);
            loader.Stub(l => l.LoadExecutable(null, null, null)).IgnoreArguments().Return(new Program());
            mr.ReplayAll();

            var sp = new Project_v1
            {
                Input = new DecompilerInput_v1
                {
                    Filename = "f.exe",
                },
                UserProcedures = {
                    new Procedure_v1 {
                        Name = "Fn",
                        Decompile = true,
                        Characteristics = new ProcedureCharacteristics
                        {
                            Terminates = true,
                        },
                        Address = "113300",
                        Signature = new SerializedSignature {
                            ReturnValue = new Argument_v1 {
                                Type = new PrimitiveType_v1(Domain.SignedInt, 4),
                            },
                            Arguments = new Argument_v1[] {
                                new Argument_v1
                                {
                                    Name = "a",
                                    Kind = new StackVariable_v1(),
                                    Type = new PrimitiveType_v1(Domain.Character, 2)
                                },
                                new Argument_v1
                                {
                                    Name = "b",
                                    Kind = new StackVariable_v1(),
                                    Type = new PointerType_v1 { DataType = new PrimitiveType_v1(Domain.Character, 2) }
                                }
                            }
                        }
                    }
                }
            };
            var ps = new ProjectLoader("", loader);
            var p = ps.LoadProject(sp);
            Assert.AreEqual(1, p.Programs.Count);
            var inputFile = p.Programs[0]; 
            Assert.AreEqual(1, inputFile.UserProcedures.Count);
            Assert.AreEqual("Fn", inputFile.UserProcedures.First().Value.Name);
        }
    }
}
