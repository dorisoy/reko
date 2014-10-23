<?xml version="1.0" encoding="UTF-8" ?>
<stylesheet version="1.0" xmlns="http://www.w3.org/1999/XSL/Transform" xmlns:c="urn:Decompiler.Schemata.MenuDefinitions">
  <template match="/c:menu-definitions">#region License
/* 
 * Copyright (C) 1999-2014 John Källén.
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
// This file was generated from Decompiler/GUI/decompiler-menus.xml using the Decompiler\Gui\Windows\Forms\decompiler-menus.xslt
// stylesheet. The intent of this file is to automatically generate the menus for the Windows Decompiler based on 
// the XML file. This saves developer effort when menu item verbs are added, removed, or changed.

using Decompiler.Gui;
using Decompiler.Gui.Windows.Controls;
using System;
using System.Collections;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace Decompiler.Gui.Windows.Forms
{
    public class DecompilerMenus : MenuSystem   
    {
    <for-each select="c:menu">
        <choose>
			<when test="@type='ContextMenu'">	public readonly System.Windows.Forms.ContextMenu <value-of select="@id"/>;</when>
			<when test="@type='MainMenu'">	public readonly System.Windows.Forms.MainMenu <value-of select="@id"/>;</when>
          <when test="@type='ToolStrip'">	public readonly System.Windows.Forms.ToolStrip <value-of select="@id"/>;</when>
        </choose></for-each>
    
        public DecompilerMenus(ICommandTarget target) : base(target)
        {<for-each select="c:menu">
			SortedList sl<value-of select="@id"/> = CreatePriorityList();</for-each>
			
			// Create groups
			<for-each select="c:group">
			SortedList sl<value-of select="@id"/> = CreatePriorityList();<if test="@id != @container">
			sl<value-of select="@container"/>.Add(<call-template name="priority"/>, sl<value-of select="@id"/>);</if></for-each>
    
			// Create commands in containers.
            <for-each select="c:cmd[@container]">
            CommandMenuItem sl<value-of select="@id"/> = new CommandMenuItem("<apply-templates/>", new Guid(CmdSets.<value-of select="@cmdSet"/>), CmdIds.<value-of select="@id"/>);
            sl<value-of select="@id"/>.IsDynamic = <call-template name="dynamic"/>;
            <if test="@image">sl<value-of select="@id"/>.ImageIndex = <value-of select="@image"/>;</if>
            <if test="@container != @id">sl<value-of select="@container"/>.Add(<call-template name="priority"/>, sl<value-of select="@id"/>);</if></for-each>
			
			// Create submenus
			<for-each select="c:menu[@container]">
            CommandMenuItem mi<value-of select="@id"/> = new CommandMenuItem("<apply-templates/>");
            sl<value-of select="@container"/>.Add(<call-template name="priority"/>, mi<value-of select="@id"/>);</for-each>
    
			// Place commands.
			<for-each select="c:placement">
			sl<value-of select="@container"/>.Add(<call-template name="priority"/>, sl<value-of select="@item"/>);</for-each>
    
      // Build accelerators.
      <for-each select="c:keybinding">
        AddBinding(
           "<value-of select="@editor"/>", 
          new Guid(CmdSets.<value-of select="@cmdSet"/>), 
          CmdIds.<value-of select="@id"/>, 
          Keys.<value-of select="@key1" />
        <if test="@alt1">
          , Keys.<value-of select="@alt1" />
        </if>);
      </for-each>
    <for-each select="c:menu">
		<choose>
			<when test="@container">
			BuildMenu(sl<value-of select="@id"/>, mi<value-of select="@id"/>.MenuItems);
			</when>
      <when test="@type='ContextMenu'">
				<call-template name="build-menu">
					<with-param name="menuType" select="'System.Windows.Forms.ContextMenu'"/>
          <with-param name="menuName" select="@id"/>
          <with-param name="itemCollectionName" select="'MenuItems'"/>
        </call-template>
      </when>
      <when test="@type='MainMenu'">
				<call-template name="build-menu">
					<with-param name="menuType" select="'System.Windows.Forms.MainMenu'"/>
					<with-param name="menuName" select="@id"/>
          <with-param name="itemCollectionName" select="'MenuItems'"/>
        </call-template>
      </when>
      <when test="@type='ToolStrip'">
          <call-template name="build-menu">
            <with-param name="menuType" select="'System.Windows.Forms.ToolStrip'"/>
            <with-param name="menuName" select="@id"/>
            <with-param name="itemCollectionName" select="'Items'"/>
          </call-template>
      </when>
		</choose>
	</for-each>
		}
		
		public override Menu GetMenu(int menuId)
		{	<if test="count(c:menu[@type='MainMenu'])">
			switch (menuId)
			{<for-each select="c:menu[@type='MainMenu']">
				case MenuIds.<value-of select="@id"/>: return this.<value-of select="@id"/>;</for-each>
			}
			</if>throw new ArgumentException(string.Format("There is no menu with id {0}.", menuId));
			
		}
		
		public override ContextMenu GetContextMenu(int menuId)
		{
			<if test="count(c:menu[@type='ContextMenu'])">
			switch (menuId)
			{<for-each select="c:menu[@type='ContextMenu']">
				case MenuIds.<value-of select="@id"/>: return this.<value-of select="@id"/>;</for-each>
			}
			</if>throw new ArgumentException(string.Format("There is no context menu with id {0}.", menuId));
		}
    
    public override ToolStrip GetToolStrip(int menuId)
    {
      <if test="count(c:menu[@type='ToolStrip'])">
      switch (menuId)
      {<for-each select="c:menu[@type='ToolStrip']">
        case MenuIds.<value-of select="@id"/>: return this.<value-of select="@id"/>;</for-each>
      }
      </if>throw new ArgumentException(string.Format("There is no tool strip with id {0}.", menuId));
    }

    }
    }
  </template>
  
  <template name="build-menu">
	<param name="menuType"/>
	<param name="menuName"/>
    <param name="itemCollectionName"/>
			this.<value-of select="$menuName"/> = new <value-of select="$menuType"/>();
			BuildMenu(sl<value-of select="$menuName"/>, <value-of select="$menuName"/>.<value-of select="$itemCollectionName"/>);
  </template>
  
  <template name="priority">
	<choose>
		<when test="@priority"><value-of select="@priority"/></when>
		<otherwise>0</otherwise>
	</choose>
  </template>
  
  <template name="dynamic">
	<choose>
		<when test="@dynamic-item-id">true</when>
		<otherwise>false</otherwise>
	</choose>
  </template>
	
</stylesheet>