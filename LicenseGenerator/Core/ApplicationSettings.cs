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

        const string Settings_PathFile = "cfg\\settings.cfg";

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
            string _SettingsFile = $"{_Init_LicenseDat_PathFile}[License]" +
                                   $"\r\n\n{ _Passwords[0]};{ _Passwords[1]};{ _Passwords[2]};{ _Passwords[3]}[Passwords]";

            bool _WriteDoneOk = false;

            try
            {
                if (File.Exists(_Settings_PathFile + ".aes") == false)
                {
                    // Save string to .cfg //
                    FileStream _insFileStream = new FileStream(_Settings_PathFile, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter _insStreamWriter = new StreamWriter(_insFileStream);
                    _insStreamWriter.BaseStream.Seek(0, SeekOrigin.End);
                    _insStreamWriter.Write(_SettingsFile);
                    _insStreamWriter.Flush();
                    _insStreamWriter.Close();
                    _WriteDoneOk = true;

                    EncryptionDecryption _insEncryptionDecryption = new EncryptionDecryption();

                    _insEncryptionDecryption.FileEncrypt(_Settings_PathFile, En_Decryption_Password);

                    File.Delete(_Settings_PathFile);
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
            string _SettingsFile = $"{Data[0]}[License]" +
                                   $"\r\n\n{Data[1]};{Data[2]};{Data[3]};{Data[4]}[Passwords]";

            bool _WriteDoneOk = false;

            try
            {
                if (File.Exists(_Settings_PathFile + ".aes"))
                {
                    File.Delete(_Settings_PathFile + ".aes");
                }                   
                
                // Save string to .cfg //     
                FileStream _insFileStream = new FileStream(_Settings_PathFile, FileMode.Create, FileAccess.Write);     
                StreamWriter _insStreamWriter = new StreamWriter(_insFileStream);
                _insStreamWriter.BaseStream.Seek(0, SeekOrigin.End);
                _insStreamWriter.Write(_SettingsFile);
                _insStreamWriter.Flush();
                _insStreamWriter.Close();
                _WriteDoneOk = true;

                EncryptionDecryption _insEncryptionDecryption = new EncryptionDecryption();

                _insEncryptionDecryption.FileEncrypt(_Settings_PathFile, En_Decryption_Password);

                File.Delete(_Settings_PathFile);

                Settings[0] = Data[0];
                Settings[1] = Data[1];
                Settings[2] = Data[2];
                Settings[3] = Data[3];
                Settings[4] = Data[4];

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

                _insEncryptionDecryption.FileDecrypt(_Settings_PathFile +".aes", _Settings_PathFile, En_Decryption_Password);

                StreamReader _insStreamReader = new StreamReader(_Settings_PathFile);
                string _SingleLine;

                Settings.Clear();

                while ((_SingleLine = _insStreamReader.ReadLine()) != null)
                {
                    string[] _Temp_Data;
                    if (_SingleLine.Contains("[License]"))
                    {
                        _Temp_Data = _SingleLine.Split("[License]");

                        Settings.Add(_Temp_Data[0]);                    }

                    if (_SingleLine.Contains("[Passwords]"))
                    {
                        _Temp_Data =  _SingleLine.Split("[Passwords]");
                        string[] _AllPasswords = _Temp_Data[0].Split(";");

                        foreach (var _Single_Passwords in _AllPasswords)
                        {
                            Settings.Add(_Single_Passwords);
                        }
                    }

                }
                _insStreamReader.Close();

                File.Delete(_Settings_PathFile);

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
