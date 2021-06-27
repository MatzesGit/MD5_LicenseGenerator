using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LicenseGenerator.Core;

namespace LicenseGenerator.Core
{
    class ApplicationSettings
    {

        private readonly static List<string> Settings = new List<string>();

        const string Settings_PathFile = "bin\\settings.dat";

        protected const string En_Decryption_Password = "mP?z#123Ay@Hij";

        protected const string Admin_Password = "Vative10";



        public static string[] Check_Admin_Passwort(string Input_Password)
        {
            string[] Password_Fields = new string[5];


            if (Input_Password == Admin_Password)
            {
                if (Settings.Capacity != 0)
                {
                    Get_Settings_Data();
                }

                int _i = 0;
                foreach(string _Password in Settings)
                {
                    Password_Fields[_i] = _Password;
                    _i++;
                }

                Password_Fields[0] = "true";
            }
            else
            {
                Password_Fields[0] = "false";
            }

            return Password_Fields;
        }


        // Check if file exist if not create one at application start //
        public static bool Check_Settings_File_Exist() 
        {
            // get settings path and file //
            string _Settings_PathFile = GetApplicationFolderPath.GetFolderBetween("bin") + Settings_PathFile;


            // Check for file exist if not create one //
            string _Init_LicenseDat_PathFile = $"{GetApplicationFolderPath.GetFolderBetween("bin")}License\\license.dat";

            string[] _Passwords = new string[4];

            // Start Passwords //

            // 1 day licnese  //
            _Passwords[0] = "123456789";
            // 14 days license //
            _Passwords[1] = "123456789";
            // 30 days license //
            _Passwords[2] = "123456789";
            // paid license //
            _Passwords[3] = "123456789";

            // Generate Settings string //
            string _Settings_Text = $"{_Init_LicenseDat_PathFile}[License]" +
                                   $"{ _Passwords[0]};{ _Passwords[1]};{ _Passwords[2]};{ _Passwords[3]}[Passwords]";

            bool _WriteDoneOk = false;

            try
            {
                if (File.Exists(_Settings_PathFile) == false)
                {
                    EncryptionDecryption _insEncryptionDecryption = new EncryptionDecryption();

                    _insEncryptionDecryption.FileEncrypt(_Settings_PathFile, _Settings_Text, En_Decryption_Password);

                    _WriteDoneOk = true;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return _WriteDoneOk;
        }

        // Generate a settings after saving new parameters // 
        public static bool Set_Settings_Data(string[] Data)
        {
            // get settings path and file //
            string _Settings_PathFile = GetApplicationFolderPath.GetFolderBetween("bin") + Settings_PathFile;

            // Check for data input is empty - in this case use saved values //
            if (Data[0] == ""){ Data[0] = Settings[0]; }
            if (Data[1] == ""){ Data[1] = Settings[1]; }
            if (Data[2] == ""){ Data[2] = Settings[2]; }
            if (Data[3] == ""){ Data[3] = Settings[3]; }
            if (Data[4] == ""){ Data[4] = Settings[4]; }

            // Generate Settings string //
            string _Settings_Text = $"{Data[0]}[License]" +
                                    $"{Data[1]};{Data[2]};{Data[3]};{Data[4]}[Passwords]";

            bool _WriteDoneOk = false;

            try
            {
                if (File.Exists(_Settings_PathFile))
                {
                    File.Delete(_Settings_PathFile);
                }                   

                EncryptionDecryption _insEncryptionDecryption = new EncryptionDecryption();

                _insEncryptionDecryption.FileEncrypt(_Settings_PathFile, _Settings_Text, En_Decryption_Password);

                Settings[0] = Data[0];
                Settings[1] = Data[1];
                Settings[2] = Data[2];
                Settings[3] = Data[3];
                Settings[4] = Data[4];

                _WriteDoneOk = true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return _WriteDoneOk;
        }


        private static void Get_Settings_Data()
        {
            try
            {
                // get settings path and file //
                string _Settings_PathFile = GetApplicationFolderPath.GetFolderBetween("bin") + Settings_PathFile;

                EncryptionDecryption _insEncryptionDecryption = new EncryptionDecryption();

                string _Output_Text = _insEncryptionDecryption.FileDecrypt(_Settings_PathFile, En_Decryption_Password);

                Settings.Clear();

                string[] _Temp_Data;

                _Temp_Data = _Output_Text.Split("[License]");

                Settings.Add(_Temp_Data[0]);

                string[] _Password_Data = _Temp_Data[1].Split("[Passwords]");
                string[] _AllPasswords = _Password_Data[0].Split(";");

                foreach (var _Single_Passwords in _AllPasswords)
                {
                    Settings.Add(_Single_Passwords);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public static string Get_License_Path()
        {
            if (Settings.Capacity == 0)
            {
                Get_Settings_Data();

                return Settings[0];
            }
            else
            {
                return Settings[0];
            }
        }


        public static List<string> Get_License_Passwords()
        {
            if (Settings.Capacity == 0)
            {
                Get_Settings_Data();

                return Settings;
            }
            else
            {
                return Settings;
            }
        }
    }
}
