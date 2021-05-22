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
        IPInformation CurrentIP;

        public MainPage()
        {
            InitializeComponent();
            CurrentIP = IPHandler.CreateIPInformation().Result;
            CurrentIPBox.Text = CurrentIP.publicIP;
            IPHandler.IPList.Add(CurrentIP);
            IPHandler.AddSeveraltoListbox(ListOfIps, IPHandler.FormatIntoListbox(IPHandler.IPList));
            IPHandler.SaveToFile();
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
            IPInformation currentIP = await IPHandler.AddCurrentIPToList();
            ListOfIps.Items.Add(IPHandler.FormatIntoListbox(currentIP));
        }
    }
}
