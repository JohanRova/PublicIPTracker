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
        public MainPage()
        {
            InitializeComponent();

            //Testing connection
            ConnTest();
            //TestEvent();
            ConnectionTester += ConnectionEvent;

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

        private void disconnected(object s, EventArgs e)
        {

        }
    }
}
