using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LicenseGenerator.Core;

namespace LicenseGenerator.Core
{
    class ApplicationSettings
    {
        const string Settings_PathFile = "cfg\\settings.cfg";
        protected const string En_Decryption_Password = "mP?z#123Ay@Hij";

        public static bool Check_Settings_File_Exist()
        {
            // get settings path and file
            string _Settings_PathFile = GetApplicationFolderPath.GetFolderBetween("bin") + Settings_PathFile;


            // Check for file exist if not create one
            string _Init_LicenseDat_PathFile = "License\\license.dat";

            string[] _Passwords = new string[4];

            // temp solution - 1 day
            _Passwords[0] = "123456789";
            // temp solution - 14 days
            _Passwords[1] = "123456789";
            // temp solution - 30 days
            _Passwords[2] = "123456789";
            // temp solution - paid
            _Passwords[3] = "123456789";

            // Generate Settings file
            string _SettingsFile = $"{_Init_LicenseDat_PathFile}[License]" +
                                   $"\r\n\n{ _Passwords[0]};{ _Passwords[1]};{ _Passwords[2]};{ _Passwords[3]}[Passwords]";

            bool _WriteDoneOk = false;

            try
            {
                if (File.Exists(_Settings_PathFile + ".aes") == false)
                {
                    // Save string to .cfg 
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


        public static string Get_License_Path_Settings()
        {
            string[] License_Path = new string[2];
            try
            {
                // get settings path and file
                string _Settings_PathFile = GetApplicationFolderPath.GetFolderBetween("bin") + Settings_PathFile;

                EncryptionDecryption _insEncryptionDecryption = new EncryptionDecryption();

                _insEncryptionDecryption.FileDecrypt(_Settings_PathFile +".aes", _Settings_PathFile, En_Decryption_Password);

                StreamReader _insStreamReader = new StreamReader(_Settings_PathFile);
                string _SingleLine;
                
                while((_SingleLine = _insStreamReader.ReadLine()) != null)
                {
                    if (_SingleLine.Contains("[License]"))
                    {
                        License_Path =  _SingleLine.Split("[License]");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return License_Path[0];
        }
    }
}
