using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using LicenseGenerator.Core;

namespace LicenseGenerator.Core
{

    public class GetSetMachineInformations
    {

        // config folder for store machine date
        private const string MachineStorageFile = "cfg\\machines.cfg ";


        static string ToMachineCfgString(string Machine_Number, string Machine_Customer, string Machine_Mac)
        {
            return $"{Machine_Number};{Machine_Customer};{Machine_Mac};";
        }


        public static bool WriteToFile(string Machine_Number, string Machine_Customer, string Machine_Mac)
        {
            // create a combined string
            string _MachineInformations = ToMachineCfgString(Machine_Number, Machine_Customer, Machine_Mac);

            // get application folder path
            string _Path = GetApplicationFolderPath.GetFolderBetween("bin");

            string _MachineStoragePathFile = _Path + MachineStorageFile;

            bool _WriteDoneOk = false;

            try
            {
                // Save string to .cfg 
                FileStream _insFileStream = new FileStream(_MachineStoragePathFile, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter _insStreamWriter = new StreamWriter(_insFileStream);
                _insStreamWriter.BaseStream.Seek(0, SeekOrigin.End);
                _insStreamWriter.Write("\r\n" + _MachineInformations);
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


        public static string[] ReadFromFile(string Machine_Number)
        {
            // get application folder path
            string _Path = GetApplicationFolderPath.GetFolderBetween("bin");

            string _MachineStoragePathFile = _Path + MachineStorageFile;

            string[] _CustomerData = new string[3]; // fixed string of 3

            // Get String from file
            try
            {
                // Read string from .cfg 
                StreamReader _insStreamReader = new StreamReader(_MachineStoragePathFile);

                string _Single_Parameter;
                while ((_Single_Parameter = _insStreamReader.ReadLine()) != null)
                {
                    if (_Single_Parameter.Contains(Machine_Number))
                    {
                        string[] _subs = _Single_Parameter.Split(';');

                        int _i = 0;

                        foreach (var _sub in _subs)
                        {
                            if (_i <= 2)
                            {
                                _CustomerData[_i] = _sub;
                            }
                            _i++;
                        }
                    }
                }
                _insStreamReader.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return _CustomerData;

        }


        public static List<List<string>> ReadAllFromFile()
        {
            // get application folder path
            string _Path = GetApplicationFolderPath.GetFolderBetween("bin");

            string _MachineStoragePathFile = _Path + MachineStorageFile;

            // Read string from .cfg 
            StreamReader _insStreamReader = new StreamReader(_MachineStoragePathFile);

            string _Single_Parameter;

            List<List<string>> _AllData = new List<List<string>>();

            while ((_Single_Parameter = _insStreamReader.ReadLine()) != null)
            {              
                string[] _SplitData = _Single_Parameter.Split(';');

                List<string> list = new List<string>();
                List<string> _Data = list;
                _Data.Add(_SplitData[0]);
                _Data.Add(_SplitData[1]);
                _Data.Add(_SplitData[2]);

                _AllData.Add(_Data);
            }

            _insStreamReader.Close();

            return _AllData;
        }


        public static bool DeleteFromeFile(string Machine_Number)
        {
            List<List<string>> _AllData = ReadAllFromFile();
            string _NewAllMachineString = "";

            foreach (var _Data in _AllData)
            {
                if (Machine_Number != _Data[0])
                {
                    if (_NewAllMachineString == "")
                    {
                        _NewAllMachineString = $"{_Data[0]};{_Data[1]};{_Data[2]};";
                    }
                    else
                    {
                        _NewAllMachineString = $"{_NewAllMachineString}\r\n{_Data[0]};{_Data[1]};{_Data[2]};";
                    }
                   
                }

            }

            // get application folder path
            string _Path = GetApplicationFolderPath.GetFolderBetween("bin");

            string _MachineStoragePathFile = _Path + MachineStorageFile;

            bool _WriteDoneOk = false;

            try
            {
                // Save string to .cfg 
                FileStream _insFileStream = new FileStream(_MachineStoragePathFile, FileMode.Create, FileAccess.Write);
                StreamWriter _insStreamWriter = new StreamWriter(_insFileStream);
                _insStreamWriter.BaseStream.Seek(0, SeekOrigin.End);
                _insStreamWriter.Write(_NewAllMachineString);
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
