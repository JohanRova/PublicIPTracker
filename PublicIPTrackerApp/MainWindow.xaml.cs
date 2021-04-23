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

namespace PublicIPTrackerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IPHandling IPHandler = new IPHandling();

        public MainWindow()
        {
            InitializeComponent();
            IPHandler.LoadFromFile();

            //testing size below
            /*const int snugContentWidth = 300;
            const int snugContentHeight = 300;

            var horizontalBorderHeight = SystemParameters.ResizeFrameHorizontalBorderHeight;
            var verticalBorderWidth = SystemParameters.ResizeFrameVerticalBorderWidth;
            var captionHeight = SystemParameters.CaptionHeight;

            Width = snugContentWidth + 2 * verticalBorderWidth;
            Height = snugContentHeight + captionHeight + 2 * horizontalBorderHeight;*/

            this.Height = (System.Windows.SystemParameters.PrimaryScreenHeight * 0.97);
            this.Width = (System.Windows.SystemParameters.PrimaryScreenWidth * 0.5);


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //IPHandler.CheckCurrentIPAsync();
            IPHandler.AddCurrentIPToList();
            //IPHandler.CheckCurrentIPAsync();
            //IPHandler.testmethod();
            //IPHandler.LoadFromFile();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            IPHandler.SaveToFile();
        }
    }
}
