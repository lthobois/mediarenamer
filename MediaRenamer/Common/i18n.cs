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

namespace MediaRenamer.Common
{
    public class i18nLang
    {
        public String shortName;
        public String longName;
        public i18nLang(String sn, String ln)
        {
            shortName = sn;
            longName = ln;
        }
        public override string ToString()
        {
            return longName;
        }
    }
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
                String baseFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + Application.ProductName + @"\";
                if (!Directory.Exists(baseFolder))
                {
                    Directory.CreateDirectory(baseFolder);
                }

				String lang;
				lang = Settings.GetValueAsString(SettingKeys.UILanguage);
                lngFile = baseFolder + @"Language\" + lang + ".ini";
                lngBackup = baseFolder + @"Language\en.ini";
				if (!File.Exists(lngFile))
				{
					lang = "en";
				}
                lngFile = baseFolder + @"Language\" + lang + ".ini";
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
                Log.Add(String.Format("Key {0} is not in language File", keyName));
				returnValue = GetPrivateProfileString(section, keyName, defaultValue,
					buffer, 1024, lngBackup);
				result = buffer.ToString();
			}
            if (result == defaultValue)
            {
                //Log.Add(String.Format("Key {0} is not in backup language File", keyName));
                TextWriter tw = new StreamWriter( lngBackup, true );
                tw.WriteLine(keyName + "=");
                tw.Close();
                result = keyName;
            }

			result = String.Format(result, args);
			result = result.Replace("%t", "\t");
			return result;
		}
	}
}
