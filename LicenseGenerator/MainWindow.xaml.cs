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
using LicenseGenerator.Core;

namespace LicenseGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        protected string Application_Path = GetApplicationFolderPath.GetFolderBetween("bin");

        public string Image_Path { get => Application_Path + "Images\\innolas_logo.png"; }

        public MainWindow()
        {
            InitializeComponent();

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(Image_Path);
            bitmap.EndInit();
            Innolas_Logo.Source = bitmap;
;
        }
    }
}
