// *******************************************************************************
//  Title:			i18n.cs
//  Description:	Translation class. Designed for easy static calls
//  Author:			Benjamin Schirmer (www.codename-matrix.de)
// *******************************************************************************

using System;
using System.Text;
using System.IO;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MediaRenamer
{
	/// <summary>
	/// Zusammenfassung für i18n.
	/// </summary>
	public class i18n
	{
		public static String lngFile = null;
		public static String lngBackup = null;

		public i18n() 
		{
			
		}

		[DllImport("kernel32", EntryPoint="GetPrivateProfileStringA",
			 CharSet=CharSet.Ansi)]
		private static extern int GetPrivateProfileString(
			string sectionName,
			string keyName,
			string defaultValue,
			StringBuilder returnbuffer,
			Int32 bufferSize,
			string fileName); 

		public static String t(String keyName, params object[] args)
		{
			if (lngFile == null)
			{
				// Log.Add("Loading file for translation");
				String path = "";
				RegistryKey key;
				key = Registry.CurrentUser.OpenSubKey(@"Software\MediaRenamer");
				path = (String)key.GetValue("path");
				if (path == null) 
				{
					path = Application.StartupPath;
				}

				String lang;
				lang = (String)key.GetValue(@"locale");
				lngFile = path+@"\Language\"+lang+".ini";
				lngBackup = path+@"\Language\en.ini";
				FileInfo lngtest = new FileInfo(lngFile);
				if (!lngtest.Exists) 
				{
					lang = "en";
				}
				lngFile = path+@"\Language\"+lang+".ini";
			}

			StringBuilder buffer = new StringBuilder (1024);
			String section = "language";
			String defaultValue = "untranslated";
			Int32 returnValue;
			String result = "";

			returnValue = GetPrivateProfileString(section, keyName, defaultValue,
				buffer, 1024, lngFile);
			result = buffer.ToString();

			if (result == defaultValue)
			{
				returnValue = GetPrivateProfileString(section, keyName, defaultValue,
					buffer, 1024, lngBackup);
				result = buffer.ToString();
			}

			result = String.Format(result, args);
			result = result.Replace("%t", "\t");
			return result;
		}
	}
}
