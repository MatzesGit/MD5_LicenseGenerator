using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.IO;

namespace LicenseGenerator.Core
{
    class EncryptionDecryption
    {

        //  Call this function to remove the key from memory after use for security //
        [DllImport("KERNEL32.DLL", EntryPoint = "RtlZeroMemory")]
        public static extern bool ZeroMemory(IntPtr Destination, int Length);


        // Creates a random salt that will be used to encrypt your file. This method is required on FileEncrypt. //

        public static byte[] GenerateRandomSalt()
        {
            byte[] data = new byte[32];

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                for (int i = 0; i < 10; i++)
                {
                    // Fille the buffer with the generated data //
                    rng.GetBytes(data);
                }
            }

            return data;
        }

        // Encrypts a file from its path and a plain password. //

        public void FileEncrypt(string Path_File, string Input_Text, string password)
        {
            //generate random salt //
            byte[] salt = GenerateRandomSalt();

            //create output file name //
            FileStream fsCrypt = new FileStream(Path_File, FileMode.Create);

            //convert password string to byte arrray //
            byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);

            //Set Rijndael symmetric encryption algorithm //
            RijndaelManaged AES = new RijndaelManaged
            {
                KeySize = 256,
                BlockSize = 128,
                Padding = PaddingMode.PKCS7
            };

            //"What it does is repeatedly hash the user password along with the salt." High iteration counts. //
            var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);

            //Cipher modes: //
            AES.Mode = CipherMode.ECB;

            // write salt to the begining of the output file, so in this case can be random every time //
            fsCrypt.Write(salt, 0, salt.Length);

            CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateEncryptor(), CryptoStreamMode.Write);

            var Input_Text_Bytes = Encoding.UTF8.GetBytes(Input_Text);

            try
            {
                cs.Write(Input_Text_Bytes, 0, Input_Text_Bytes.Length);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                cs.Close();
            }
        }

        // Decrypts an encrypted file with the FileEncrypt method through its path and the plain password. //
        public string FileDecrypt(string Path_File, string password)
        {
            byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);
            byte[] salt = new byte[32];

            FileStream fsCrypt = new FileStream(Path_File, FileMode.Open);
            fsCrypt.Read(salt, 0, salt.Length);

            RijndaelManaged rijndaelManaged = new RijndaelManaged();
            RijndaelManaged AES = rijndaelManaged;
            AES.KeySize = 256;
            AES.BlockSize = 128;
            var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);
            AES.Padding = PaddingMode.PKCS7;
            AES.Mode = CipherMode.ECB;

            CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateDecryptor(), CryptoStreamMode.Read);

            int read;
            byte[] buffer = new byte[1048576];

            var _Output_Text_Bytes = "";

            try
            {
                while ((read = cs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    _Output_Text_Bytes =  Encoding.UTF8.GetString(buffer, 0, read);
                }
            }
            catch (CryptographicException ex_CryptographicException)
            {
                Console.WriteLine("CryptographicException error: " + ex_CryptographicException.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            try
            {
                cs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error by closing CryptoStream: " + ex.Message);
            }
            finally
            {
                fsCrypt.Close();
            }

            return _Output_Text_Bytes;
        }
    }
}
