using System;
using System.Collections.Generic;
using System.IO;
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
using Newtonsoft.Json;

namespace PublicIPTrackerApp.Pages
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        Settings settings = Settings.CreateSettings();

        public SettingsPage()
        {
            InitializeComponent();
        }

        private void SaveSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            settings.HomeIP = HomeIPBox.Text;
            Int32.TryParse(IPCheckInterval.Text, out int tryParseResult);
            settings.IPCheckInterval = tryParseResult;

            string json = System.Text.Json.JsonSerializer.Serialize(settings);
            File.WriteAllTextAsync("settings.json", json);

        }
    }
}
