/* 
 * Copyright (C) 1999-2007 John K�ll�n.
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

using System;
using System.ComponentModel.Design;

namespace Decompiler.Gui
{
	/// <summary>
	/// An ICommandTarget handles the issuing of commands. It is inspired by IOleCommandTarget.
	/// </summary>
	public interface ICommandTarget
	{
		/// <summary>
		/// Sets or rests the visibility flags of the command. 
		/// </summary>
		/// <param name="cmd"></param>
		/// <returns>false if the command is not supported, true if it is.</returns>
		bool GetCommandStatus(MenuCommand cmd);

		/// <summary>
		/// Executes the specified command.
		/// </summary>
		/// <param name="cmd"></param>
		void ExecuteCommand(MenuCommand cmd);
	}
}
