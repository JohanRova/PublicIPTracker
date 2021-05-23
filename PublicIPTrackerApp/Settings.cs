using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicIPTrackerApp
{
    public class Settings
    {
        public string HomeIP { get; set; }
        public int IPCheckInterval { get; set; }

        public Settings()
        {
            
        }
        public static Settings CreateSettings()
        {
            try
            {
                string json = File.ReadAllTextAsync("settings.json").Result;
                if (json != "")
                {
                    Settings lol = JsonConvert.DeserializeObject<Settings>(json);
                    return lol;
                }
            }
            catch (Exception e)
            {
                //TODO: Error handling
                File.Create("settings.json");
                return null;
            }
            return null;
        }
    }

}
