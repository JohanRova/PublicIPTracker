using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using PublicIPTrackerApp.Pages;
using Newtonsoft.Json;

namespace PublicIPTrackerApp.Models
{
    class IPHandling
    {
        public List<IPInformation> IPList= new List<IPInformation>();

        private async Task<string> CheckCurrentIPAsync()
        {
            HttpClient httpClient = new HttpClient();
            string ip = await httpClient.GetStringAsync("https://api.ipify.org");
            return ip;
        }


        public async Task<IPInformation> AddCurrentIPToList()
        {
            var ip = await CheckCurrentIPAsync();
            DateTime timeStamp = DateTime.Now;
            IPInformation ipNow = new IPInformation(ip, timeStamp);
            IPList.Add(ipNow);
            return ipNow;
        }



        public void SaveToFile()
        {
            string json = System.Text.Json.JsonSerializer.Serialize(IPList);
            File.WriteAllTextAsync("ipListing.json", json);
            
        }
        public void LoadFromFile()
        {
            try 
            {
                string json = File.ReadAllTextAsync("ipListing.json").Result;
                IPList = JsonConvert.DeserializeObject<List<IPInformation>>(json);
            }
            catch (Exception e)
            {
                //TODO: Error handling
                File.Create("ipListing.json");
            }

        }
        public IPHandling()
        {
            LoadFromFile();
        }

    }
}
