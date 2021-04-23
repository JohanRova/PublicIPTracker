﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace PublicIPTrackerApp.Models
{
    class IPHandling
    {
        public List<IPInformation> IPList= new List<IPInformation>();

        public async Task<string> CheckCurrentIPAsync()
        {
            HttpClient httpClient = new HttpClient();
            string ip = await httpClient.GetStringAsync("https://api.ipify.org");
            return ip;
        }

        public async Task AddCurrentIPToList()
        {
            var ip = await CheckCurrentIPAsync();
            DateTime timeStamp = DateTime.Now;
            IPList.Add(new IPInformation(ip, timeStamp));
        }

        public void SaveToFile()
        {
            string json = JsonSerializer.Serialize(IPList);
            File.WriteAllTextAsync("ipListing.json", json);
            
        }
        public void LoadFromFile()
        {
            try 
            {
                string json = File.ReadAllTextAsync("ipListing.json").Result;
                IPList = JsonSerializer.Deserialize<List<IPInformation>>(json);
            }
            catch(Exception e)
            {
                //Do some error shit here
                File.Create("ipListing.json");
            }

        }

    }
}
