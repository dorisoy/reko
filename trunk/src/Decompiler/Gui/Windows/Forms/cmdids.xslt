<?xml version="1.0" encoding="UTF-8" ?>
<stylesheet version="1.0" xmlns="http://www.w3.org/1999/XSL/Transform" xmlns:c="urn:Decompiler.Schemata.MenuDefinitions">
  <template match="/c:menu-definitions">#region License
/* 
 * Copyright (C) 1999-2012 John Källén.
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

// This file is automatically generated. DO NOT MAKE CHANGES TO IT, as they will be overwritten next time the 
// project compiles.
// This file was generated from Decompiler/GUI/decompiler-menus.xml using the Decompiler\Gui\Windows\Forms\cmdids.xslt
// stylesheet. The intent of this file is to automatically generate the numerical constants used to refer to menus 
// and their menu items.

using System;

namespace Decompiler.Gui.Windows.Forms
{
	public class CmdSets
	{
	<for-each select="c:cmdSet">	public const string <value-of select="@id"/> = "<apply-templates/>";
	</for-each>
	
	<for-each select="c:cmdSet">	public static Guid Guid<value-of select="@id"/> = new Guid("<apply-templates/>");
	</for-each>
	}
	
	public class MenuIds
	{
	<for-each select="c:menu">	public const int <value-of select="@id"/> = <value-of select="position()" />;
	</for-each>}
	
	public class GroupIds
	{
	<for-each select="c:group">	public const int <value-of select="@id"/> = <value-of select="position()"/> + 1000;
	</for-each>}
	
	public class CmdIds
	{
	<for-each select="c:cmd[not(@dynamic-item-id)]">	public const int <value-of select="@id"/> = <value-of select="position()"/> + 2000;
	</for-each>
	
	<for-each select="c:cmd[@dynamic-item-id]">	public const int <value-of select="@id"/> = <value-of select="@dynamic-item-id"/>;
	</for-each>}

}
  </template>
</stylesheet>

  