using System;
using System.Collections.Generic;
using System.Text;

namespace LicenseGenerator.Core
{
    class CreateMD5Hash
    {
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using System.Security.Cryptography.MD5 _md5 = System.Security.Cryptography.MD5.Create();
            byte[] _inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] _hashBytes = _md5.ComputeHash(_inputBytes);

            // Convert the byte array to hexadecimal string
            StringBuilder sb = new StringBuilder();
            for (int _i = 0; _i < _hashBytes.Length; _i++)
            {
                sb.Append(_hashBytes[_i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
