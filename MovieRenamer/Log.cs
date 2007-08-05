// *******************************************************************************
//  Title:			Log.cs
//  Description:	Log class for MovieRenamer
//  Author:			Benjamin Schirmer (www.codename-matrix.de)
// *******************************************************************************

using System;
using System.Windows.Forms;

namespace MovieRenamer
{
	/// <summary>
	/// Zusammenfassung für Log.
	/// </summary>
	public class Log
	{
		public static void Add(String text)
		{
			mainForm f1 = mainForm.instance;
			if (f1 != null)
			{
				f1.infoLog.Items.Insert(0, text.Replace("%25", "&"));
				f1.infoLog.Update();
			}
		}
	}
}
