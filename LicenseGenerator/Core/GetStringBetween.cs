using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace LicenseGenerator.Core
{
    class GetStringBetween
    {
        public static string GetStingBetween(string strSource, string strStart,  string strEnd)
        {

            const int _kNotFound = -1;

            var _startIdx = strSource.IndexOf(strStart);
            if (_startIdx != _kNotFound)
            {
                _startIdx += strStart.Length;
                var endIdx = strSource.IndexOf(strEnd, _startIdx);
                if (endIdx > _startIdx)
                {
                    return strSource[_startIdx..endIdx];
                }
            }
            return string.Empty;
        }
    }
}
