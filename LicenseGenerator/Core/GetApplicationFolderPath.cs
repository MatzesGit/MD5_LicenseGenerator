using System;
using System.Reflection;
using System.Windows.Forms;


// this class is used for get the correct path for file and images //

namespace LicenseGenerator.Core
{
    class GetApplicationFolderPath
    {
        // Get Application folder //
        public static string GetFolderBetween(string strEnd)
        {
            string _strStart = "";

            // get String between start and end string //
            string strSource = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            const int kNotFound = -1;

            var _startIdx = strSource.IndexOf(_strStart);
            if (_startIdx != kNotFound)
            {
                _startIdx += _strStart.Length;
                var _endIdx = strSource.IndexOf(strEnd, _startIdx);
                if (_endIdx > _startIdx)
                {
                    return strSource[_startIdx.._endIdx];
                }
            }
            return string.Empty;
        }

    }
}
