// *******************************************************************************
//  Title:			Log.cs
//  Description:	Log class for TVShowRenamer.
//  Author:			Benjamin Schirmer (www.codename-matrix.de)
// *******************************************************************************

using System;
using System.Windows.Forms;

namespace MediaRenamer
{
	/// <summary>
	/// Zusammenfassung für Log.
	/// </summary>
	public class Log
	{
		public static void Add(String text)
		{
			#if _HAS_FORM
				TVShowRenamer.mainForm f1 = TVShowRenamer.mainForm.instance;
				if (f1 != null)
				{
					f1.infoLog.Items.Insert(0, text);
					f1.infoLog.Update();
				}
			#endif
		}
	}
}
