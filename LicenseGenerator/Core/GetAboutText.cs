using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LicenseGenerator.Core
{

    class GetAboutText
    {

        // config folder for store machine date
        private const string Readme_File = "readme.txt ";


        public enum About_Text_Enum
        {
            Title_Text = 0,
            Version_Text = 1,
            Headline_Text = 2,
            Description_Text = 3
        };

        public static string[] Items_Text()
        {

            string[] _Text_items = new string[4];

            // get application folder path
            string _Path = GetApplicationFolderPath.GetFolderBetween("bin");

            string _Readme_PathFile = _Path + Readme_File;

            // Read string from .cfg 
            StreamReader _insStreamReader = new StreamReader(_Readme_PathFile);

            string _Single_Line;

            int _i = 0;

            while ((_Single_Line = _insStreamReader.ReadLine()) != null)
            {
                if (_Single_Line.Contains("[Title]"))
                {
                    _i = ((int)About_Text_Enum.Title_Text);
                    _Single_Line = "";
                }
                else if (_Single_Line.Contains("[Version]"))
                {
                    _i = ((int)About_Text_Enum.Version_Text);
                    _Single_Line = "";
                }
                else if (_Single_Line.Contains("[Headline]"))
                {
                    _i = ((int)About_Text_Enum.Headline_Text);
                    _Single_Line = "";
                }
                else if (_Single_Line.Contains("[Description]"))
                {
                    _i = ((int)About_Text_Enum.Description_Text);
                    _Single_Line = "";
                }

                if (_Text_items[_i] == "")
                {
                    _Text_items[_i] = _Single_Line;
                }
                else
                {
                    _Text_items[_i] = $"{ _Text_items[_i]}{_Single_Line}";
                }

            }
            _insStreamReader.Close();

            return _Text_items;
        }
    }
}
