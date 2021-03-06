using System;
using System.Collections.Generic;
using System.Linq;
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
using PublicIPTrackerApp.Pages;

namespace PublicIPTrackerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            //For initial size
            this.Height = (System.Windows.SystemParameters.PrimaryScreenHeight * 0.97);
            this.Width = (System.Windows.SystemParameters.PrimaryScreenWidth * 0.5);

            //For debug only
            //IPHandler.AddCurrentIPToList();
            //Frame.Content = new MainPage();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MainPageNav_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new MainPage();
        }

        private void SettingsPageNav_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new SettingsPage();
        }
    }
}
