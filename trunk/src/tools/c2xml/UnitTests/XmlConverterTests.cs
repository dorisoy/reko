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

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

#if DEBUG
namespace Decompiler.Tools.C2Xml.UnitTests
{
    [TestFixture]
    public class XmlConverterTests
    {
        void RunTest(string c_code, string expectedXml)
        {
            StringReader reader = null;
            StringWriter writer = null;
            try
            {
                reader = new StringReader(c_code);
                writer = new StringWriter();
                var xWriter = new XmlnsHidingWriter(writer)
                {
                    Formatting = Formatting.Indented
                };
                var xc = new XmlConverter(reader, xWriter);
                xc.Convert();
                writer.Flush();
                Assert.AreEqual(expectedXml, writer.ToString());
            }
            catch
            {
                Debug.WriteLine(writer.ToString());
                throw;
            }
            finally
            {
                if (writer != null)
                    writer.Dispose();
                if (reader != null)
                    reader.Dispose();
            }
        }

        [Test]
        public void C2X_Typedef()
        {
            var sExp =
@"<?xml version=""1.0"" encoding=""utf-16""?>
<library xmlns=""http://schemata.jklnet.org/Decompiler"">
  <Types>
    <typedef name=""INT"">
      <prim domain=""SignedInt"" size=""4"" />
    </typedef>
  </Types>
</library>";
            RunTest("typedef int INT;", sExp);
        }

        [Test]
        public void C2X_Struct()
        {
            var sExp =
@"<?xml version=""1.0"" encoding=""utf-16""?>
<library xmlns=""http://schemata.jklnet.org/Decompiler"">
  <Types>
    <struct name=""tagPoint"">
      <field offset=""0"" name=""x"">
        <prim domain=""SignedInt"" size=""4"" />
      </field>
      <field offset=""4"" name=""y"">
        <prim domain=""SignedInt"" size=""4"" />
      </field>
    </struct>
  </Types>
</library>";
            RunTest("struct tagPoint { int x; int y; };", sExp);
        }

        [Test]
        public void C2X_Selfref()
        {
            var sExp =
@"<?xml version=""1.0"" encoding=""utf-16""?>
<library xmlns=""http://schemata.jklnet.org/Decompiler"">
  <Types>
    <struct name=""link"">
      <field offset=""0"" name=""next"">
        <ptr>
          <struct name=""link"" />
        </ptr>
      </field>
    </struct>
  </Types>
</library>";
            RunTest("struct link { struct link *next; }; ", sExp);
        }

        [Test]
        public void C2X_FunctionDecl()
        {
            var sExp =
@"<?xml version=""1.0"" encoding=""utf-16""?>
<library xmlns=""http://schemata.jklnet.org/Decompiler"">
  <Types />
  <procedure name=""strlen"">
    <signature convention=""__cdecl"">
      <return>
        <type>size_t</type>
        <reg>eax</reg>
      </return>
      <arg>
        <ptr>
          <prim domain=""Character"" size=""1"" />
        </ptr>
        <stack size=""4"" />
      </arg>
    </signature>
  </procedure>
</library>";
            RunTest("size_t __cdecl strlen(const char *);", sExp);
        }

        [Test]
        public void C2X_ForwardDeclaration()
        {
            var sExp =
@"<?xml version=""1.0"" encoding=""utf-16""?>
<library xmlns=""http://schemata.jklnet.org/Decompiler"">
  <Types>
    <typedef name=""FOO"">
      <struct name=""foo"" />
    </typedef>
  </Types>
</library>";
            RunTest("typedef struct foo FOO;", sExp);
        }

        [Test]
        public void C2X_ForwardDeclaration_ThenDeclaration()
        {
            var sExp =
@"<?xml version=""1.0"" encoding=""utf-16""?>
<library xmlns=""http://schemata.jklnet.org/Decompiler"">
  <Types>
    <typedef name=""FOO"">
      <struct name=""foo"" />
    </typedef>
    <struct name=""foo"">
      <field offset=""0"" name=""x"">
        <prim domain=""SignedInt"" size=""4"" />
      </field>
      <field offset=""4"" name=""y"">
        <prim domain=""SignedInt"" size=""4"" />
      </field>
      <field offset=""8"" name=""z"">
        <prim domain=""SignedInt"" size=""4"" />
      </field>
    </struct>
  </Types>
</library>";
            RunTest(
                "typedef struct foo FOO;" +
                "struct foo { int x, y, z; };" 
                , sExp);
        }


        [Test]
        public void C2X_TypeReference()
        {
            var sExp =
@"<?xml version=""1.0"" encoding=""utf-16""?>
<library xmlns=""http://schemata.jklnet.org/Decompiler"">
  <Types>
    <struct name=""foo"">
      <field offset=""0"" name=""x"">
        <prim domain=""SignedInt"" size=""4"" />
      </field>
    </struct>
    <typedef name=""FOO"">
      <struct name=""foo"" />
    </typedef>
  </Types>
  <procedure name=""bar"">
    <signature>
      <return>
        <prim domain=""SignedInt"" size=""4"" />
        <reg>eax</reg>
      </return>
      <arg name=""pfoo"">
        <ptr>
          <type>FOO</type>
        </ptr>
        <stack size=""4"" />
      </arg>
    </signature>
  </procedure>
</library>";
            RunTest(
                "typedef struct foo { int x; } FOO;" +
                "int bar(FOO * pfoo);",
                sExp);
        }

        [Test]
        public void C2x_Variant()
        {
            var sExp =
@"<?xml version=""1.0"" encoding=""utf-16""?>
<library xmlns=""http://schemata.jklnet.org/Decompiler"">
  <Types>
    <union name=""u"">
      <alt name=""i"">
        <prim domain=""SignedInt"" size=""4"" />
      </alt>
      <alt name=""s"">
        <ptr>
          <prim domain=""Character"" size=""1"" />
        </ptr>
      </alt>
      <alt name=""f"">
        <prim domain=""Real"" size=""4"" />
      </alt>
    </union>
    <struct name=""tagVariant"">
      <field offset=""0"" name=""type"">
        <prim domain=""SignedInt"" size=""4"" />
      </field>
      <field offset=""4"">
        <union name=""u"" />
      </field>
    </struct>
    <typedef name=""Variant"">
      <struct name=""tagVariant"" />
    </typedef>
  </Types>
</library>";
            RunTest(
                "typedef struct tagVariant { " +
                    "int type;" +
                    "union u {" +
                        "int i;" + 
                        "char * s;" +
                        "float f;" +
                    "};" +
                "} Variant;",
                sExp);
        }

        [Test]
        public void C2X_SizedArray()
        {
            var sExp =
@"<?xml version=""1.0"" encoding=""utf-16""?>
<library xmlns=""http://schemata.jklnet.org/Decompiler"">
  <Types>
    <typedef name=""PunchCard"">
      <arr length=""80"">
        <prim domain=""Character"" size=""1"" />
      </arr>
    </typedef>
  </Types>
</library>";
            RunTest(
                "typedef char PunchCard[80];",
                sExp);
        }

        [Test]
        public void C2X_UnsizedArray()
        {
            var sExp =
@"<?xml version=""1.0"" encoding=""utf-16""?>
<library xmlns=""http://schemata.jklnet.org/Decompiler"">
  <Types>
    <typedef name=""PunchCard"">
      <arr length=""0"">
        <prim domain=""Character"" size=""1"" />
      </arr>
    </typedef>
  </Types>
</library>";
            RunTest(
                "typedef char PunchCard[];",
                sExp);
        }

        [Test]
        public void C2X_StructWithArray()
        {
            var sExp =
@"<?xml version=""1.0"" encoding=""utf-16""?>
<library xmlns=""http://schemata.jklnet.org/Decompiler"">
  <Types>
    <typedef name=""byte"">
      <prim domain=""UnsignedInt"" size=""1"" />
    </typedef>
    <struct name=""header"">
      <field offset=""0"" name=""signature"">
        <arr length=""16"">
          <type>byte</type>
        </arr>
      </field>
      <field offset=""16"" name=""length"">
        <prim domain=""SignedInt"" size=""4"" />
      </field>
    </struct>
  </Types>
</library>";
            RunTest(
                "typedef unsigned char byte;" +
                "typedef struct header {" +
                    "byte signature[16];" + 
                    "int length;" +
                "};",
                sExp);
        }

        [Test]
        public void C2X_TypedefEnum()
        {
            var sExp =
@"<?xml version=""1.0"" encoding=""utf-16""?>
<library xmlns=""http://schemata.jklnet.org/Decompiler"">
  <Types>
    <enum name=""eFoo"">
      <member name=""Bar"" value=""1"" />
      <member name=""Fooie"" value=""2"" />
    </enum>
    <typedef name=""Foo"">
      <enum name=""eFoo"" />
    </typedef>
  </Types>
</library>";
            RunTest(
                "typedef enum eFoo {" +
                    "Bar = 1," +
                    "Fooie" +
                "} Foo;",
                sExp);
        }

        [Test]
        public void C2X_ConvertEnum_DerivedValues()
        {
            var sExp =
@"<?xml version=""1.0"" encoding=""utf-16""?>
<library xmlns=""http://schemata.jklnet.org/Decompiler"">
  <Types>
    <enum name=""Foo"">
      <member name=""Bar"" value=""1"" />
      <member name=""Quux"" value=""1"" />
    </enum>
  </Types>
</library>";
            RunTest(
                "enum Foo {" +
                    "Bar = 1, " +
                    "Quux = Bar, " +
                "};",
                sExp);
        }

        [Test]
        public void C2X_AnonymousStruct()
        {
            var sExp =
                @"<?xml version=""1.0"" encoding=""utf-16""?>
<library xmlns=""http://schemata.jklnet.org/Decompiler"">
  <Types>
    <struct name=""struct_0"">
      <field offset=""0"" name=""x"">
        <prim domain=""SignedInt"" size=""4"" />
      </field>
    </struct>
    <struct name=""Foo"">
      <field offset=""0"" name=""a"">
        <struct name=""struct_0"" />
      </field>
    </struct>
  </Types>
</library>";
            RunTest(
                "struct Foo {" +
                    "struct { " +
                        "int x;" +
                    "} a;" +
                "};",
                sExp);

        }

        [Test]
        public void C2X_FunctionWithStackParameters()
        {
            var sExp = @"<?xml version=""1.0"" encoding=""utf-16""?>
<library xmlns=""http://schemata.jklnet.org/Decompiler"">
  <Types />
  <procedure name=""foo"">
    <signature convention=""__stdcall"">
      <return>
        <prim domain=""SignedInt"" size=""4"" />
        <reg>eax</reg>
      </return>
      <arg name=""bar"">
        <prim domain=""SignedInt"" size=""4"" />
        <stack size=""4"" />
      </arg>
      <arg name=""foo"">
        <ptr>
          <prim domain=""Character"" size=""1"" />
        </ptr>
        <stack size=""4"" />
      </arg>
    </signature>
  </procedure>
</library>";
            RunTest("int __stdcall foo(int bar, char * foo);",
                sExp);
        }

        [Test]
        public void C2X_typedef_enum()
        {
            var sExp = @"<?xml version=""1.0"" encoding=""utf-16""?>
<library xmlns=""http://schemata.jklnet.org/Decompiler"">
  <Types>
    <enum name=""_foo"">
      <member name=""Bar"" value=""1"" />
    </enum>
    <typedef name=""Foo"">
      <enum name=""_foo"" />
    </typedef>
    <typedef name=""PFoo"">
      <ptr>
        <enum name=""_foo"" />
      </ptr>
    </typedef>
  </Types>
</library>";
            RunTest("typedef enum _foo { Bar = 1 } Foo, *PFoo;", sExp);
        }

        [Test]
        public void C2x_typedef_anonymous_enum()
        {
            var sExp = @"<?xml version=""1.0"" encoding=""utf-16""?>
<library xmlns=""http://schemata.jklnet.org/Decompiler"">
  <Types>
    <enum name=""enum_0"">
      <member name=""Bar"" value=""1"" />
    </enum>
    <typedef name=""Foo"">
      <enum name=""enum_0"" />
    </typedef>
    <typedef name=""PFoo"">
      <ptr>
        <enum name=""enum_0"" />
      </ptr>
    </typedef>
  </Types>
</library>";
            RunTest("typedef enum { Bar = 1 } Foo, *PFoo;", sExp);
        }

        [Test]
        public void C2X_typedef_anonymous_struct()
        {
            var sExp = @"<?xml version=""1.0"" encoding=""utf-16""?>
<library xmlns=""http://schemata.jklnet.org/Decompiler"">
  <Types>
    <struct name=""struct_0"">
      <field offset=""0"" name=""bar"">
        <prim domain=""SignedInt"" size=""4"" />
      </field>
    </struct>
    <typedef name=""Foo"">
      <struct name=""struct_0"" />
    </typedef>
    <typedef name=""PFoo"">
      <ptr>
        <struct name=""struct_0"" />
      </ptr>
    </typedef>
  </Types>
</library>";
            RunTest("typedef struct { int bar; } Foo, *PFoo;", sExp);
        }
    }
}
#endif