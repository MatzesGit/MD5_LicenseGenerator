using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using LicenseGenerator.Core;
using Microsoft.Win32;

namespace LicenseGenerator.MVVM.View
{
    /// <summary>
    /// Interaktionslogik für SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        protected string _insApplication_Path = GetApplicationFolderPath.GetFolderBetween("bin");

        public string Image_Path { get => _insApplication_Path + "Images\\file_open.png"; }

        // File Button Content
        public string FileButton_Content { get => (string)File_button.Content; set => File_button.Content = value; }

        // Folder and File where the license should be stored
        public string LicensePath = "";

        private readonly FolderButtonFunktions _insFolderButtonFunktions = new FolderButtonFunktions();


        public SettingsView()
        {
            InitializeComponent();

            PasswordSettings.Width = 0;
            PasswordSettings.Height = 0;
            PasswordSettings.Visibility = Visibility.Hidden;
            AppSettings.Width = 660;
            AppSettings.Height = 320;
            AppSettings.Visibility = Visibility.Visible;
            Button_App_Settins.IsEnabled = false;
            Show_Passwords_Panel.Visibility = Visibility.Hidden;

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(Image_Path);
            bitmap.EndInit();
            Button_Image.Source = bitmap;

            ApplicationSettings.Check_Settings_File_Exist();
            LicensePath = _insApplication_Path + ApplicationSettings.Get_License_Path();

            FileButton_Content = _insFolderButtonFunktions.ShortViewLicensePath(LicensePath, 70);
        }

        // Textboxes
        public string Textbox_Password { get => Password_Textbox.Password; }
        public string Textbox_One_Day_Password { get => One_Day_Textbox.Text; set => One_Day_Textbox.Text = value; }
        public string Textbox_Fourteen_Days_Password { get => Fourteen_Days_Textbox.Text; set => Fourteen_Days_Textbox.Text = value; }
        public string Textbox_Thirty_Days_Password { get => Thirty_Days_Textbox.Text; set => Thirty_Days_Textbox.Text = value; }
        public string Textbox_Paid_Password { get => Paid_Textbox.Text; set => Paid_Textbox.Text = value; }

        // makes Password adjusments visible
        private void Open_Password_Settings(object sender, RoutedEventArgs e)
        {
            AppSettings.Width = 0;
            AppSettings.Height = 0;
            AppSettings.Visibility = Visibility.Hidden;
            PasswordSettings.Width = 660;
            PasswordSettings.Height = 320;
            PasswordSettings.Visibility = Visibility.Visible;
            Button_Password_Settings.IsEnabled = false;
            Button_App_Settins.IsEnabled = true;

        }

        // makes App adjusments visible
        private void Open_App_Settings(object sender, RoutedEventArgs e)
        {
            PasswordSettings.Width = 0;
            PasswordSettings.Height = 0;
            PasswordSettings.Visibility = Visibility.Hidden;
            AppSettings.Width = 660;
            AppSettings.Height = 320;
            AppSettings.Visibility = Visibility.Visible;
            Button_App_Settins.IsEnabled = false;
            Button_Password_Settings.IsEnabled = true;
        }

        private void File_Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            var _insfileDialog = openFileDialog;

            _insfileDialog.InitialDirectory = LicensePath;
            _insfileDialog.Filter = "dat files (*.dat)|*.dat|All files (*.*)|*.*";
            _insfileDialog.FilterIndex = 2;
            _insfileDialog.RestoreDirectory = true;

            if (_insfileDialog.ShowDialog() == true)
            {
                //
            }

            //FileButton_Content = _insFolderButtonFunktions.ShortViewLicensePath(LicensePath, 70);
        }

        private void Check_Admin_Passwort(object sender, RoutedEventArgs e)
        {
            if (Textbox_Password != null)
            {
                string[] _Password_Fields = ApplicationSettings.Check_Admin_Passwort(Textbox_Password);

                if (_Password_Fields[0] == "true")
                {
                    Show_Password_TextBoxes(_Password_Fields);
                }
                else
                {
                    // Wrong password
                }
            }
        }

        public void Show_Password_TextBoxes(string[] _Password_Fields)
        {
            Show_Passwords_Panel.Visibility = Visibility.Visible;
            Textbox_One_Day_Password = _Password_Fields[1];
            Textbox_Fourteen_Days_Password = _Password_Fields[2];
            Textbox_Thirty_Days_Password = _Password_Fields[3];
            Textbox_Paid_Password = _Password_Fields[4];
        }


        private void App_Settings_Save_Click(object sender, RoutedEventArgs e)
        {
            string[] _Settings_Data = new string[5];

            _Settings_Data[0] = LicensePath;
            _Settings_Data[1] = Textbox_One_Day_Password;
            _Settings_Data[2] = Textbox_Fourteen_Days_Password;
            _Settings_Data[3] = Textbox_Thirty_Days_Password;
            _Settings_Data[4] = Textbox_Paid_Password;

            ApplicationSettings.Set_Settings_Data(_Settings_Data);
        }
    }
}
