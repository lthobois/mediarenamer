using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Forms;
using MediaRenamer.Common;

namespace MediaRenamer.Series
{
    class LocationData
    {
        public String Series;
        public Hashtable locMap;

        public LocationData()
        {
            locMap = new Hashtable();
        }
    }

    class SeriesLocations
    {
        private String locationFile;
        private Hashtable locations;

        public SeriesLocations()
        {
            String baseFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + Application.ProductName + @"\";
            if (!Directory.Exists(baseFolder))
            {
                Directory.CreateDirectory(baseFolder);
            }
            locationFile = baseFolder + "seriesLocations.json";

            this.loadLocations();
        }

        private void loadLocations()
        {
            if (File.Exists(locationFile))
            {
                locations = (Hashtable)Settings.GetValueAsObject<Hashtable>(SettingKeys.SeriesLocations);
            }
            if (locations == null)
            {
                locations = new Hashtable();
            }
        }

        public void saveLocations()
        {
            Settings.SetValue(SettingKeys.SeriesLocations, locations);
        }

        public void addSeriesLocation(Episode ep)
        {
            if (ep.special) return;

            FileInfo fi = new FileInfo(ep.filename);
            String fileLocation = fi.DirectoryName;

            if (locations.ContainsKey(ep.series))
            {
                LocationData loc = (LocationData)this.locations[ep.series];
                if (!loc.locMap.ContainsKey(ep.season.ToString()))
                {
                    loc.locMap[ep.season.ToString()] = fileLocation;
                }
            }
            else
            {
                LocationData loc = new LocationData();
                loc.Series = ep.series;
                loc.locMap[ep.season] = fileLocation;
                this.locations.Add(ep.series, loc);
            }
        }

        public String getEpisodePath(Episode ep)
        {
            if (this.locations.ContainsKey(ep.series))
            {
                LocationData loc = (LocationData)this.locations[ep.series];
                if (loc.locMap.ContainsKey(ep.season.ToString()))
                {
                    return loc.locMap[ep.season.ToString()].ToString();
                }
                else if (loc.locMap.Count > 1)
                {
                    Char[] previous = null;
                    Char[] generic = null;
                    foreach (String path in loc.locMap.Values)
                    {
                        if (previous == null)
                        {
                            previous = path.ToCharArray();
                            generic = path.ToCharArray();
                        }
                        for (int i = 0; i < path.Length; ++i)
                        {
                            if (path[i].Equals(previous[i]))
                            {
                                generic[i] = path[i];
                            }
                            else
                            {
                                generic[i] = '|';
                            }
                        }
                    }
                    String seasonPath = new String(generic);
                    seasonPath = seasonPath.Replace("||", "|");
                    seasonPath = seasonPath.Replace("|", ep.season.ToString());
                    if (!Directory.Exists(seasonPath))
                    {
                        Directory.CreateDirectory(seasonPath);
                    }
                    return seasonPath;
                }
            }

            FolderBrowserDialog browse = new FolderBrowserDialog();
            browse.Description = "Please select folder for " + ep.series + " (Season " + ep.season + "):";
            if (browse.ShowDialog() == DialogResult.OK)
            {
                return browse.SelectedPath;
            }
            else
            {
                return "";
            }

        }
    }
}
