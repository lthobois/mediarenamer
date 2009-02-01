/**
 * Copyright 2009 Benjamin Schirmer
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
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
            browse.Description = "Please select folder for " + ep.series + " (Season " + ep.season + ").\n" +
                "The episode will then be moved to that location. If you cancel this dialog the file will not be moved.";
            if (browse.ShowDialog(mainForm.dialogOwner) == DialogResult.OK)
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
