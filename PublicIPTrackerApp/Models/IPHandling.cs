using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using PublicIPTrackerApp.Pages;
using Newtonsoft.Json;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Shapes;

namespace PublicIPTrackerApp.Models
{
    class IPHandling
    {
        public List<IPInformation> IPList= new List<IPInformation>();

        public async Task<string> CheckCurrentIPAsync()
        {
            HttpClient httpClient = new HttpClient();
            string ip = httpClient.GetStringAsync("https://api.ipify.org").Result;
            return ip;
        }


        public async Task<IPInformation> AddCurrentIPToList()
        {
            var ip = await CheckCurrentIPAsync();
            DateTime timeStamp = DateTime.Now;
            IPInformation ipNow = new IPInformation(ip, timeStamp, UniqueCheck(ip));
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

        //Create listbox item
        public ListBoxItem FormatIntoListbox(IPInformation ipinfo)
        {
            StackPanel stackpanel = new StackPanel() { Orientation = Orientation.Horizontal };
            stackpanel.Children.Add(new Rectangle() { Fill = Brushes.Blue, Width = 10, Height = 10 });
            stackpanel.Children.Add(new TextBlock() { Text = "IP: ", Margin = new Thickness { Left = 5 } });
            stackpanel.Children.Add(new TextBox() { Text = ipinfo.publicIP });
            stackpanel.Children.Add(new TextBlock() { Text = "Timestamp: ", Margin = new Thickness { Left = 5 } });
            stackpanel.Children.Add(new TextBox() { Text = ipinfo.IPTimeStamp.ToString("yyyy/MM/dd HH:mm:ss") });
            //ListOfIps.Items.Add(new ListBoxItem() { Content = stackpanel });
            return new ListBoxItem() { Content = stackpanel };
        }

        public List<ListBoxItem> FormatIntoListbox(List<IPInformation> ipInfoList)
        {
            List<ListBoxItem> result = new List<ListBoxItem>();
            foreach(IPInformation ip in ipInfoList)
            {
                StackPanel stackpanel = new StackPanel() { Orientation = Orientation.Horizontal };
                if(ip.Unique)
                {
                    stackpanel.Children.Add(new Rectangle() { Fill = Brushes.Blue, Width = 10, Height = 10 });
                }
                else
                {
                    stackpanel.Children.Add(new Rectangle() { Fill = Brushes.Red, Width = 10, Height = 10 });
                }
                stackpanel.Children.Add(new TextBlock() { Text = "IP: ", Margin = new Thickness { Left = 5 } });
                stackpanel.Children.Add(new TextBox() { Text = ip.publicIP });
                stackpanel.Children.Add(new TextBlock() { Text = "Timestamp: ", Margin = new Thickness { Left = 5 } });
                stackpanel.Children.Add(new TextBox() { Text = ip.IPTimeStamp.ToString("yyyy/MM/dd HH:mm:ss") });
                result.Add(new ListBoxItem() { Content = stackpanel });
            }
            return result;
        }

        //Unique checking
        private bool UniqueCheck(string ip)
        {
            int uniqueness = -1;
            bool result = true;
            foreach(IPInformation item in IPList)
            {
                if(item.publicIP == ip)
                {
                    uniqueness++;
                    if(uniqueness > 0)
                    {
                        return false;
                    }
                }
            }
            return result;
        }
    }
}
