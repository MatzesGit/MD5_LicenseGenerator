using System;
using System.Collections.Generic;
using System.IO;

namespace LicenseGenerator.Core
{
    class GenerateLicenseFile
    {      
        public static bool GenerateLicense(int License_Type, string Machine_Numbeer, string Key_Number, string FolderFile_Path)
        {
            bool _WriteDoneOk = false;

            try
            {

                string[] _Customer_Data = GetSetMachineInformations.ReadFromFile(Machine_Numbeer);
                List<string> _Passwords = ApplicationSettings.Get_License_Passwords();

                string License_String = "";

                switch (License_Type)
                {
                    case 1:
                        // 1 day license
                        License_String = $"{_Customer_Data[2]} {Key_Number} {_Passwords[1]}";
                        break;

                    case 2:
                        // 14 days license
                        License_String = $"{_Customer_Data[2]} {Key_Number} {_Passwords[2]}";
                        break;

                    case 3:
                        // 30 days license
                        License_String = $"{_Customer_Data[2]} {Key_Number} {_Passwords[3]}";
                        break;

                    case 4:
                        // paid license
                        License_String = $"{_Customer_Data[2]} {_Passwords[4]}";
                        break;

                    default:
                        // error
                        break;

                }


                string MD5Hash_String = CreateMD5Hash.CreateMD5(License_String);


                // Save string to license.dat 
                FileStream _insFileStream = new FileStream(FolderFile_Path, FileMode.Create, FileAccess.Write);
                StreamWriter _insStreamWriter= new StreamWriter(_insFileStream);
                _insStreamWriter.BaseStream.Seek(0, SeekOrigin.End);
                _insStreamWriter.Write(MD5Hash_String);
                _insStreamWriter.Flush();
                _insStreamWriter.Close();
                _WriteDoneOk = true;
            }
            catch (Exception e)
            {           
                Console.WriteLine(e.Message);
            }

            return _WriteDoneOk;
        }
    }
}
