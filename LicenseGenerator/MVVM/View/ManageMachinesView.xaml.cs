using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
using LicenseGenerator.Core;


namespace LicenseGenerator.MVVM.View
{
    /// <summary>
    /// Interaktionslogik für AddMachinesView.xaml
    /// </summary>
    public partial class ManageMachinesView : UserControl
    {

        public static List<ListData> items = new List<ListData>();

        public ManageMachinesView()
        {
            InitializeComponent();

            ManageMachines.Width = 0;
            ManageMachines.Height = 0;
            ManageMachines.Visibility = Visibility.Hidden;
            AddMachines.Width = 660;
            AddMachines.Height = 320;
            AddMachines.Visibility = Visibility.Visible;
            Button_Add_Machines.IsEnabled = false;
        }


        public class ListData
        {
            public string Pxxx_Data_List { get; set; }

            public string Customer_Data_List { get; set; }

            public string Mac_Data_List { get; set; }
        }


        private void Add_Machines(object sender, RoutedEventArgs e)
        {
            ManageMachines.Width = 0;
            ManageMachines.Height = 0;
            ManageMachines.Visibility = Visibility.Hidden;
            AddMachines.Width = 660;
            AddMachines.Height = 320;
            AddMachines.Visibility = Visibility.Visible;
            Button_Add_Machines.IsEnabled = false;
            Button_Manage_Machines.IsEnabled = true;
        }


        private void Manage_Machines(object sender, RoutedEventArgs e)
        {
            AddMachines.Width = 0;
            AddMachines.Height = 0;
            AddMachines.Visibility = Visibility.Hidden;
            ManageMachines.Width = 660;
            ManageMachines.Height = 320;
            ManageMachines.Visibility = Visibility.Visible;
            Button_Manage_Machines.IsEnabled = false;
            Button_Add_Machines.IsEnabled = true;

            List<List<string>> _AllData = GetSetMachineInformations.ReadAllFromFile();

            MachineDetails.ItemsSource = null;
            MachineDetails.Items.Clear();
            items.Clear();

            if (_AllData != null)
            {
                foreach (var _Data in _AllData)
                {
                    items.Add(new ListData()
                    {
                        Pxxx_Data_List = _Data[0],
                        Customer_Data_List = _Data[1],
                        Mac_Data_List = _Data[2]
                    });
                }
            }

            MachineDetails.ItemsSource = items;
        }


        private void MachineDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string _Get_Selected_Machine_Number = "";

                if (MachineDetails.ItemsSource != null)
                {
                    Type t = MachineDetails.SelectedItem.GetType();

                    System.Reflection.PropertyInfo[] props = t.GetProperties();

                    _Get_Selected_Machine_Number = props[0].GetValue(MachineDetails.SelectedItem, null).ToString();

                    MessageBoxButton buttons = MessageBoxButton.OKCancel;
                    MessageBoxResult _MessageBoxResult = MessageBox.Show(_Get_Selected_Machine_Number, "Test", buttons);
                    if (_MessageBoxResult == MessageBoxResult.OK)
                    {    

                        List<List<string>> _AllData = GetSetMachineInformations.ReadAllFromFile();

                        foreach (var _Data in _AllData)
                        {
                            if (_Get_Selected_Machine_Number == _Data[0])
                            {
                                bool _WriteDoneOk = GetSetMachineInformations.DeleteFromeFile(_Get_Selected_Machine_Number);
                                if (_WriteDoneOk)
                                {
                                    // further use
                                }

                            }
                        }

                        MachineDetails.ItemsSource = null;
                        MachineDetails.Items.Clear();
                        items.Clear();

                        List<List<string>> _NewAllData = GetSetMachineInformations.ReadAllFromFile();

                        foreach (var _Data in _NewAllData)
                        {
                            items.Add(new ListData()
                            {
                                Pxxx_Data_List = _Data[0],
                                Customer_Data_List = _Data[1],
                                Mac_Data_List = _Data[2]
                            });
                        }
                        MachineDetails.ItemsSource = items;

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        // Textboxes
        public string Machine_Number { get => Number_Textbox.Text; set => Number_Textbox.Text = value; }
        public SolidColorBrush Machine_Number_Color { set => Number_Textbox.Foreground = value; }
        public string Machine_Customer { get => Customer_Textbox.Text; set => Customer_Textbox.Text = value; }
        public string Machine_Mac { get => Mac_Textbox.Text; set => Mac_Textbox.Text = value; }


        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            bool _WriteDoneOk = false;

            string _message;
            string _caption = "Add Machine";

            if (Machine_Number.Contains("P") || Machine_Number.Contains("p"))
            {
                // change small to letter to capital letter in case small letter was typed in
                if (Machine_Number.Contains("p"))
                {
                    string[] _Number = Machine_Number.Split("p");

                    string _Machine_Number = _Number[1];

                    _WriteDoneOk = GetSetMachineInformations.WriteToFile($"P{_Machine_Number}", Machine_Customer, Machine_Mac);

                }
                else
                {
                    _WriteDoneOk = GetSetMachineInformations.WriteToFile(Machine_Number, Machine_Customer, Machine_Mac);
                }

                if (_WriteDoneOk)
                {
                    _message = "Machine is sucessfully add to database!";

                    Machine_Number = "";
                    Machine_Customer = "";
                    Machine_Mac = "";
                    Machine_Number_Color = Brushes.White;
                }
                else
                {
                    _message = "Error writing machine data to datebase";
                }
            }
            else
            {
                Machine_Number_Color = Brushes.Red;
                _message = "Please check your input";
            }


            MessageBoxButton buttons = MessageBoxButton.OK;
            _ = MessageBox.Show(_message, _caption, buttons);

        }


        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            Machine_Number = "";
            Machine_Customer = "";
            Machine_Mac = "";
        }

    }
}
