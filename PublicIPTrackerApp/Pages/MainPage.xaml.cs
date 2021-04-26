using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PublicIPTrackerApp.Models;

namespace PublicIPTrackerApp.Pages
{

    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        IPHandling IPHandler = new IPHandling();

        public MainPage()
        {
            InitializeComponent();
            //Testing connection
            //ConnTest();
            //TestEvent();
            //ConnectionTester += ConnectionEvent;
            AddToListbox(IPHandler.IPList[0]);


        }
        public event EventHandler ConnectionTester
        {
            add
            {
                //TODO: Logic here
            }
            remove
            {
                //TODO: Logic here too
            }
        }

        public void TestEvent()
        {
            ConnectionTester += ConnectionEvent;
            ConnectionTester -= ConnectionEvent;
        }
        public void ConnectionEvent(object sender, EventArgs e)
        {
        }

        public void ConnTest()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    using (client.OpenRead("http://www.google.com/"))
                    {
                        // success
                    }
                }
            }
            catch
            {
                // Raise an event
                // you might want to check for consistent failures 
                // before signalling the Internet is down
                
            }
        }

        //Test adding to listbox
        void AddToListbox(IPInformation ipinfo)
        {
            //ListOfIps.Items.Add(new ListBoxItem() { Content = new TextBox { Text = "lmao" }});
            StackPanel stackpanel = new StackPanel() { Orientation = Orientation.Horizontal };
            stackpanel.Children.Add(new Rectangle() { Fill = Brushes.Green, Width = 10, Height = 10 });
            stackpanel.Children.Add(new TextBlock() { Text = "IP: ", Margin = new Thickness { Left = 5 } });
            stackpanel.Children.Add(new TextBox() { Text = "lmao" });
            stackpanel.Children.Add(new TextBlock() { Text = "Timestamp: ", Margin = new Thickness { Left = 5 } });
            stackpanel.Children.Add(new TextBox() { Text = "lmao2" });
            ListOfIps.Items.Add(new ListBoxItem() { Content = stackpanel });
        }


        /*void AddToListbox(IPInformation ipinfo)
        {
            ListOfIps.Items.Add(new ListBoxItem() { Content = $"{ipinfo.publicIP} TIMESTAMP: {ipinfo.IPTimeStamp.ToShortDateString()}", Background = Brushes.Green});
        }*/
        void AddToListbox(List<IPInformation> ipinfos)
        {
            foreach(IPInformation infos in ipinfos)
            {
                ListOfIps.Items.Add(new ListBoxItem() { Content = $"{infos.publicIP} TIMESTAMP: {infos.IPTimeStamp.ToShortDateString()}" });
            }
        }
    }
}
