using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Collections;
using Yaowi.Common.Serialization;

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
        WatchedFolders,
        UILanguage,
        ServicePort
                
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
            settingsFile = baseFolder + "settings.xml";
            settingsData = new Hashtable();
            if (File.Exists(settingsFile))
            {
                XmlDocument settingsXml = new XmlDocument();
                settingsXml.Load(settingsFile);
                XmlNode root = settingsXml.DocumentElement;

                SettingKeys key;
                String value;
                foreach (XmlNode node in root.ChildNodes)
                {
                    try
                    {
                        key = ParseEnum<SettingKeys>(node.Attributes["name"].Value);
                    }
                    catch (SettingKeyNotAvailableEception)
                    {
                        continue;
                    }
                    value = node.InnerText;
                    settingsData.Add(key, value);
                }
            }
        }

        ~Settings()
        {
            saveSettingsXML();
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

        private void saveSettingsXML()
        {
            XmlDocument settingsXml = new XmlDocument();
            // settingsXml.Name = "settings";
            XmlElement root = settingsXml.CreateElement("root");
            foreach (object key in settingsData.Keys)
            {
                XmlElement element = settingsXml.CreateElement("set");
                XmlAttribute attr = settingsXml.CreateAttribute("name");
                attr.Value = key.ToString();
                element.Attributes.Append(attr);
                element.InnerText = (String)getValue((SettingKeys)key);
                root.AppendChild(element);
            }
            settingsXml.AppendChild(root);
            if (!File.Exists(settingsFile))
            {
                FileStream strm = File.Create(settingsFile);
                strm.Close();
            }
            settingsXml.Save(settingsFile);
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
            if (settings.settingsData.ContainsKey(key))
            {
                return settings.settingsData[key];
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

        public static Object[] GetValueAsArray(SettingKeys key)
        {
            Settings settings = Settings.getInstance();
            String filename = (String)settings.getValue(key);
            if (filename == null) return new Object[0];
            Object[] arr = null ;
            if (filename.StartsWith("##"))
            {
                filename = filename.Replace("##", settings.baseFolder);
                FileInfo fi = new FileInfo(filename);
                if (fi.Extension.ToLower() == ".xml")
                {
                    XmlDeserializer xd = new XmlDeserializer();
                    arr = (Object[])xd.Deserialize(fi.FullName);
                }
            }
            return arr;
        }

        public static String GetValueAsString(SettingKeys key)
        {
            Settings settings = Settings.getInstance();
            return (String)settings.getValue(key);
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
            if (value is bool)
            {
                value = ((bool)value) ? "1" : "0";
            }
            if (value is int)
            {
                value = value.ToString();
            }
            if (value is ComboBox.ObjectCollection)
            {
                String serializeFile = baseFolder + key.ToString() + ".xml";
                ComboBox.ObjectCollection data = (ComboBox.ObjectCollection)value;
                Object[] arr = new Object[data.Count];
                for (int i = 0; i < data.Count; i++)
                {
                    arr[i] = data[i];
                }
                XmlSerializer xs = new XmlSerializer();
                xs.Serialize(arr, serializeFile);
                value = "##" + key.ToString() + ".xml";
            }
            if (value is Object[])
            {
                String serializeFile = baseFolder + key.ToString() + ".xml";
                XmlSerializer xs = new XmlSerializer();
                xs.Serialize(value, serializeFile);
                value = "##" + key.ToString() + ".xml";
            }

            
            if (!settingsData.ContainsKey(key))
            {
                settingsData.Add(key, (String)value);
            }
            else
            {
                settingsData[key] = (String)value;
            }

            saveSettingsXML();
        }

        public static void SetValue(SettingKeys key, object value)
        {
            Settings settings = Settings.getInstance();

            settings.setValue(key, value);
        }

    }
}
