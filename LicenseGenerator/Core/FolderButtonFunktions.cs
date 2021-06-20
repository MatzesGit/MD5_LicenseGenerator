using System;
using System.Collections.Generic;
using System.Text;

namespace LicenseGenerator.Core
{
    class FolderButtonFunktions
    {
        // short the path and folder, if nessesary for showing the text inside button in correct length
        public string ShortViewLicensePath(string _LicensePath, int _MaxLength)
        {

            // Reverse string for cut
            static string ReverseString(string _InputString)
            {
                string _ReverseString = "";
                int _StringLength;

                _StringLength = _InputString.Length - 1;

                while (_StringLength >= 0)
                {
                    _ReverseString = $"{_ReverseString}{_InputString[_StringLength]}";
                    _StringLength--;

                }
                return _ReverseString;
            }

            // call reverse string method
            string _ReverseString = ReverseString(_LicensePath);

            // Split string in parts and cut the rest
            string[] _Subs = _ReverseString.Split('\\');
            string _NewString = "";

            bool StopWriting = false;

            foreach (var _Sub in _Subs)
            {
                if (_NewString == "")
                {
                    _NewString = _Sub;
                }
                else if ((_NewString.Length + _Sub.Length) < _MaxLength - 3 && StopWriting == false)
                {
                    _NewString = $"{_NewString}\\{_Sub}";
                }
                else if (StopWriting == false)
                {
                    _NewString = $"{_NewString}\\...";
                    StopWriting = true;
                }
                else if (_Sub.Contains(":"))
                {
                    // Drive name - eg C:
                    _NewString = $"{_NewString}\\{_Sub}";
                }
            }

            // call reverse string method
            return ReverseString(_NewString);
        }


        // Create path out of path and file string - is used for the file open windwos template
        public string Split_Path_From_File(string FileButton_Content)
        {
            string[] _Subs = FileButton_Content.Split('\\');
            string _Path_Only = "";

            foreach (var _Sub in _Subs)
            {
                if (_Sub.Contains(".") == false)
                {
                    if (_Path_Only == "")
                    {
                        _Path_Only = _Sub;
                    }
                    else
                    {
                        _Path_Only = $"{_Path_Only}\\{_Sub}";
                    }

                }
            }
            return _Path_Only;
        }
    }
}
