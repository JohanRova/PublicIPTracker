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
            try
            {
                string json = File.ReadAllTextAsync("settings.json").Result;
                if (json != "")
                {
                    var lol  = JsonConvert.DeserializeObject<Settings>(json);
                }
            }
            catch (Exception e)
            {
                //TODO: Error handling
                File.Create("settings.json");
            }
        }
    }

}
