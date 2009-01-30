using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Collections;
using JsonExSerializer;

namespace MediaRenamer.Common
{
    public enum SettingKeys
    {
        SysTrayIcon,
        DisplayDropTarget,
        WindowsStart,
        MovieFormat,
        SeriesFormat,
        MoviePaths,
        SeriesPaths,
        SeriesLocations,
        UILanguage,
        StartMinimized,
        MovieLocation,
        MoveMovies,
        SeriesData
                
    }
    public class SettingKeyNotAvailableEception : Exception
    {
        public SettingKeyNotAvailableEception()
        {
        }
        public SettingKeyNotAvailableEception(string message)
            : base(message)
        {
        }
        public SettingKeyNotAvailableEception(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    class Settings
    {
        private static Settings instance = null;
        private String settingsFile = "";
        private String baseFolder = "";
        private Hashtable settingsData;

        private Settings()
        {
            baseFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\"+Application.ProductName+@"\";
            if (!Directory.Exists(baseFolder))
            {
                Directory.CreateDirectory(baseFolder);
            }
            settingsFile = baseFolder + "settings.json";
            settingsData = new Hashtable();
            if (File.Exists(settingsFile))
            {
                string jsonText = File.ReadAllText(settingsFile);
                Serializer serializer = new Serializer(typeof(Hashtable));
                settingsData = (Hashtable)serializer.Deserialize(jsonText);
            }
        }

        ~Settings()
        {
            saveSettings();
            settingsData.Clear();
        }

        /// <summary>
        /// Convert String back to Enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ParseEnum<T>(string value) where T : struct
        {
            try
            {
                return (T)Enum.Parse(typeof(T), value, true);
            }
            catch
            {
                throw new SettingKeyNotAvailableEception(String.Format("Missing Key {0}", value));
            }
        }

        private void saveSettings()
        {
            if (!File.Exists(settingsFile))
            {
                FileStream strm = File.Create(settingsFile);
                strm.Close();
            }

            Serializer serializer = new Serializer(typeof(Hashtable));
            string jsonText = serializer.Serialize(this.settingsData);
            File.WriteAllText(settingsFile, jsonText);
        }


        public static Settings getInstance()
        {
            if (Settings.instance == null)
            {
                Settings.instance = new Settings();
            }
            return Settings.instance;
        }

        private object getValue(SettingKeys key)
        {
            Settings settings = Settings.getInstance();
            String keyName = key.ToString();
            if (settings.settingsData.ContainsKey(keyName))
            {
                return settings.settingsData[keyName];
            }
            else
            {
                return null;
            }
        }

        public static object GetValue(SettingKeys key)
        {
            Settings settings = Settings.getInstance();
            return settings.getValue(key);
        }

        public static T GetValueAsObject<T>(SettingKeys key)
        {
            Settings settings = Settings.getInstance();
            String filename = (String)settings.getValue(key);
            if (filename != null && filename.StartsWith("##"))
            {
                filename = filename.Replace("##", settings.baseFolder);
                FileInfo fi = new FileInfo(filename);
                if (fi.Extension.ToLower() == ".json" && File.Exists(filename))
                {
                    string jsonText = File.ReadAllText(filename);
                    Serializer serializer = new Serializer(typeof(T));
                    return (T)serializer.Deserialize(jsonText);
                }
            }
            Object e = null;
            return (T)(e);
        }

        public static String GetValueAsString(SettingKeys key)
        {
            Settings settings = Settings.getInstance();
            String str = (String)settings.getValue(key);
            if (str == null)
            {
                str = String.Empty;
            }
            return str;            
        }

        public static bool GetValueAsBool(SettingKeys key)
        {
            Settings settings = Settings.getInstance();
            String val = (String)settings.getValue(key);
            return (val == "1") ? true : false;
        }

        public static int GetValueAsInt(SettingKeys key)
        {
            Settings settings = Settings.getInstance();
            int val = int.Parse( (String)settings.getValue(key));
            return val;
        }

        private void setValue(SettingKeys key, object value)
        {
            String keyName = key.ToString();
            if (value is bool)
            {
                value = ((bool)value) ? "1" : "0";
            }
            else if (value is int)
            {
                value = value.ToString();
            }
            else if (value is string)
            {
            }
            else if (value is Object)
            {
                String serializeFile = baseFolder + keyName + ".json";
                Serializer serializer = new Serializer(value.GetType());
                string jsonText = serializer.Serialize(value);
                File.WriteAllText(serializeFile, jsonText);
                value = "##" + keyName + ".json";
            }


            if (!settingsData.ContainsKey(keyName))
            {
                settingsData.Add(keyName, (String)value);
            }
            else
            {
                settingsData[keyName] = (String)value;
            }

            saveSettings();
        }

        public static void SetValue(SettingKeys key, object value)
        {
            Settings settings = Settings.getInstance();
            settings.setValue(key, value);
        }

    }
}
