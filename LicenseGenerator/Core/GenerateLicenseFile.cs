using System;
using System.IO;

namespace LicenseGenerator.Core
{
    class GenerateLicenseFile
    {      
        public static bool GenerateLicense(string MD5Hash_String, string FolderFile_Path)
        {
            bool _WriteDoneOk = false;

            try
            {
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
