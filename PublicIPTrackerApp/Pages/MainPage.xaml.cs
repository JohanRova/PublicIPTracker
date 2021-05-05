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
            //SetTextBox("lol", CurrentIPText);
            //CurrentIPText.Text = $"Your current IP is: {IPHandler.CheckCurrentIPAsync().ToString()}";
            CurrentIPBox.Text = IPHandler.CheckCurrentIPAsync().Result;
            //ListOfIps.Items.Add(IPHandler.FormatIntoListbox(IPHandler.IPList[0]));
            AddSeveraltoListbox(ListOfIps, IPHandler.FormatIntoListbox(IPHandler.IPList));
            
            //IPHandler.AddCurrentIPToList();
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

        public void AddSeveraltoListbox(ListBox listbox, List<ListBoxItem> ListboxItems)
        {
            if(ListboxItems != null && ListboxItems.Count != 0)
            {
                foreach(ListBoxItem item in ListboxItems)
                {
                    listbox.Items.Add(item);
                }
            }
            else
            {
                StackPanel stackpanel = new StackPanel() { Orientation = Orientation.Horizontal };
                stackpanel.Children.Add(new TextBlock() { Text = "No savefile found or empty!", Foreground = Brushes.Red});
                listbox.Items.Add(stackpanel);
            }
        }

        private void DebugSaveToFile_Click(object sender, RoutedEventArgs e)
        {
            IPHandler.SaveToFile();
        }

        private void DebugLoadFromFile_Click(object sender, RoutedEventArgs e)
        {
            IPHandler.LoadFromFile();
        }

        private async void DebugAddIPToList_Click(object sender, RoutedEventArgs e)
        {
            await IPHandler.AddCurrentIPToList();
        }
    }
}
