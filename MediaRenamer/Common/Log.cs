// *******************************************************************************
//  Title:			Log.cs
//  Description:	Log class for TVShowRenamer.
//  Author:			Benjamin Schirmer (www.codename-matrix.de)
// *******************************************************************************

using System;
using System.Windows.Forms;

namespace MediaRenamer.Common
{
	/// <summary>
	/// Zusammenfassung für Log.
	/// </summary>
	public class Log
	{
		public static void Add(string text)
		{
            #if _APPLICATION
			mainForm form = (mainForm.instance as mainForm);
            if (form != null)
            {
                form.insertLog(text);
            }
            #endif
		}
	}
}
