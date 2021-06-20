using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using LicenseGenerator.Core;
using Microsoft.Win32;

namespace LicenseGenerator.MVVM.View
{
    /// <summary>
    /// Interaktionslogik für GenerateView.xaml
    /// </summary>
    public partial class GenerateView : UserControl
    {
        // This Variable prevents nullreferenceexception at Xaml and already checking Xaml items
        protected bool Xaml_IsEnabledSuccessfully;

        protected string _insApplication_Path = GetApplicationFolderPath.GetFolderBetween("bin");

        public string Image_Path { get => _insApplication_Path + "Images\\file_open.png"; }

        private readonly FolderButtonFunktions _insFolderButtonFunktions = new FolderButtonFunktions();

        // Folder and File where the license should be stored
        public string LicensePath = "";


        public GenerateView()
        {
            Xaml_IsEnabledSuccessfully = false;

            InitializeComponent();

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(Image_Path);
            bitmap.EndInit();
            Button_Image.Source = bitmap;

            // initial License.dat path
            string _LicenseFolder = @"License\";
            string _LicenseFile   = "License.dat";
            LicensePath = $"{ _insApplication_Path}{_LicenseFolder}{_LicenseFile}";

            FileButton_Content = _insFolderButtonFunktions.ShortViewLicensePath(LicensePath , 70);
        }


        // Textboxes
        public string Machine_Number { get => Number_Textbox.Text; set => Number_Textbox.Text = value; }
        public string Key_Number { get => Key_Textbox.Text; set => Key_Textbox.Text = value;  }

        // File Button Content
        public string FileButton_Content { get => (string)File_button.Content; set => File_button.Content = value; }

        // RadionButton Value Group Key_RadioButton
        public int Key_RadioButton_IsChecked = 1; // number of prechecked button

        // RadionButton Value Group Type_RadioButton
        public int Type_RadioButton_IsChecked = 1; // number of prechecked button


        private void File_Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            var _insfileDialog = openFileDialog;

            _insfileDialog.InitialDirectory = _insFolderButtonFunktions.Split_Path_From_File(LicensePath);
            _insfileDialog.Filter = "dat files (*.dat)|*.dat|All files (*.*)|*.*";
            _insfileDialog.FilterIndex = 2;
            _insfileDialog.RestoreDirectory = true;

            if (_insfileDialog.ShowDialog() == true)
            {
                LicensePath = _insfileDialog.FileName;
            }

            FileButton_Content = _insFolderButtonFunktions.ShortViewLicensePath(LicensePath, 70);
        }


        private void Key_RadioButton_CheckChanged(object sender, RoutedEventArgs e)
        {

            // Get RadioButton reference.
            var Radio_Button = sender as RadioButton;
            if (Radio_Button.Name == "Use_Key" && Xaml_IsEnabledSuccessfully)
            {
                One_Day.IsEnabled = true;
                Fourteen_Days.IsEnabled = true;
                Thirty_Days.IsEnabled = true;
                Key_RadioButton_IsChecked = 1;
            }
            else if (Radio_Button.Name == "No_Key" && Xaml_IsEnabledSuccessfully)
            {
                One_Day.IsEnabled = false;
                Fourteen_Days.IsEnabled = false;
                Thirty_Days.IsEnabled = false;
                Key_RadioButton_IsChecked = 2;
            }
        }


        private void Type_RadioButton_CheckChanged(object sender, RoutedEventArgs e)
        {
            // Get RadioButton reference.
            var _Radio_Button = sender as RadioButton;

            if (_Radio_Button.Name == "One_Day")
            {
                Type_RadioButton_IsChecked = 1;
            }
            else if (_Radio_Button.Name == "Fourteen_Days")
            {
                Type_RadioButton_IsChecked = 2;
            }
            else if (_Radio_Button.Name == "Thirty_Days")
            {
                Type_RadioButton_IsChecked = 3;
            }
        }


        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {      
            if (Xaml_IsEnabledSuccessfully)
            {
                // Get machine data out of database
                string[] _CustomerData = GetSetMachineInformations.ReadFromFile(Machine_Number);

                // Get interal license passwords - needs some work on settings
                string[] _Passwords = new string[4];

                string _Password_Key = "";

                string _LicenseKey_String = "";

                int _License_Type;

                // temp solution - 1 day
                _Passwords[0] = "X67ADs+5";
                // temp solution - 14 days
                _Passwords[1] = "Wsea14o2";
                // temp solution - 30 days
                _Passwords[2] = "D6ASf%8p";
                // temp solution - paid
                _Passwords[3] = "I6rz90x";

                if (Key_RadioButton_IsChecked == 1)
                {
                    _License_Type = 1;

                    // Check which day license should be created
                    if (Type_RadioButton_IsChecked == 1)
                    {
                        _Password_Key = _Passwords[0];
                    }
                    if (Type_RadioButton_IsChecked == 2)
                    {
                        _Password_Key = _Passwords[1];
                    }
                    if (Type_RadioButton_IsChecked == 3)
                    {
                        _Password_Key = _Passwords[2];
                    }
                }
                else
                {
                    _License_Type = 2;
                }

                if (_License_Type == 1)
                {
                    _LicenseKey_String = $"{_CustomerData[2]} {Key_Number} {_Password_Key}";
                }
                else if (_License_Type == 2)
                {
                    _LicenseKey_String = $"{_CustomerData[2]} {_Password_Key}";
                }
                else
                {
                    // Error Creation
                }

                string LicenseKey_Hash = CreateMD5Hash.CreateMD5(_LicenseKey_String);
                bool _WriteDoneOk = GenerateLicenseFile.GenerateLicense(LicenseKey_Hash, LicensePath);
                Console.WriteLine(LicenseKey_Hash);

                string _message;
                string _caption = "Add Machine";

                if (_WriteDoneOk)
                {
                    _message = "License key is sucessfully created!";

                    Machine_Number = "";
                    Key_Number = "";
                }
                else
                {
                    // Error writing license
                    _message = "Error writing license,\r\n please check whether folder exist!";
                }

                MessageBoxButton buttons = MessageBoxButton.OK;
                _ = MessageBox.Show(_message, _caption, buttons);

            }

        }

  
        private void Xamal_IsLoaded(object sender, RoutedEventArgs e)
        {
            Xaml_IsEnabledSuccessfully = true;
        }

    }
}
