   M S B A M L   `   `   `  ���� K  GLicenseGenerator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:LicenseGenerator.MVVM.ViewLicenseGenerator.MVVM.View  3    -LicenseGenerator.MVVM.View.ManageMachinesView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     :local(clr-namespace:LicenseGenerator.MVVM.View     .���� .+��� $��Manage Machines��
�������$��28(�$
��Bold"�$
��Left=�$��0,0,0,20q��� $	��800��$	��400������   �� 
StartPoint$	  0,0&� �� EndPoint$	 1,2&�.���  � Color$ #ffffff�� � Offset$ 0Q�� $ #efefef��$ 1Q� J� Clip ��  �� RadiusX$ 5Q� �� RadiusY$ 5Q� �� Rect$ 0,0,700,400�._�� .+���  �� Orientation$ Vertical=�.+��� $ 
Horizontal=�$��	20,20,0,0q�.+��� -   $��Button_Add_Machines��$��Add Machines��$	��150��   ModernClickButton#��[  �� -   $��Button_Manage_Machines��$��Manage Machines��$	��150��$��20,0,0,0q�#��[  �� $��
0,10,100,0q�.+��� ���#353340$	��660��  MenuLine#��[ �� -   $��AddMachines��$	��330��$	��660��$��Bottom=�$
��Left=�$��20,0,0,0q�$��0q�
������ $y�Visible=�._��� .+��� $Y��SPlease write the Pxxx number, the customer name and mac address in the lines below.��
���   �$��15(�$��DemiBold"�$��0,0,10,0q��� $ 
Horizontal=�$��0,20,0,0q�.+��� $��Pxxx number��
���   �$��17(�$
��Bold"�$	��150��$��0,0,20,0q�� $��80��$
��Left=�.+��� 
	 J� Uid$
	 Pxxx��${�False��  ModernTextBox#��[ ���� 
 �� ElementName$
 Number_Textbox�� �� Path$
 Text��� -   $��Number_Textbox��$��7,4,7,4q�
������ $��0q�
������� �� 
CaretBrush
 ����� �� 	MaxLength$ 4���� $ 
Horizontal=�$��0,20,0,0q�.+��� $��Customer name��
���   �$��17(�$
��Bold"�$	��150��$��0,0,20,0q�� $	��300��$
��Left=�.+��� $	 Customer��${�False��#��[ ���� $
 Customer_Textbox��$
 Text��� -   $��Customer_Textbox��$��7,4,7,4q�
������ $��0q�
�������
 �����$ 50���� $ 
Horizontal=�$��0,20,0,0q�.+��� $��Mac Address��
���   �$��17(�$
��Bold"�$	��150��$��0,0,20,0q�� $	��200��$
��Left=�.+��� $	 MAC Address��${�False��#��[ ���� $
 Mac_Textbox��$
 Text��� -   $��Mac_Textbox��$��7,4,7,4q�
������ $��0q�
�������
 �����$ 20���� $ 
Horizontal=�$��0,30,0,0q�.+��� $�� ��
���   �$��17(�$
��Bold"�$	��150��$��0,0,20,0q��� -   $��submit��$��Submit��$	��100��#��[  �� -   $��clear��$��Clear��$	��100��#��[  $��20,0,0,0q��� -	   $��ManageMachines��$	��330��$	��660��$��Bottom=�$
��Left=�$��20,0,0,0q�$��0q�
������ $y�Visible=�$��Visible=�._��� .+��� $,��&Here you will find all stored machines��
���   �$��15(�$��DemiBold"�$��0,0,10,0q��� $H��BBy clicking on the line with the machine number you can delete it.��
���   �$��13(�$��DemiBold"�$��20��$��0,10,0,0q��� $��2q����#353340 �� CornerRadius$ 7��$��0,10,0,0q�$	��240��._��� $��
10,10,0,10q�.+��� $��1��$��Disabled=�$��Visible=�$	��240��.���� -
   $��All_MachinesView��$ 
Horizontal=�.+��� -   $��MachineDetails��$��0q�
������ 
������ $��13(�$
��Bold"�����  �� View �� -   All_Data_List��  GridViewColumnHeaderStyle! �� ColumnHeaderContainerStyle# [ .P��� -   Pxxx_Number��$��Pxxx Number�� �� Width$	 100�� �� DisplayMemberBinding �� $ Pxxx_Data_List��� -   Customer��$��Customer��$	 378�� �� $ Customer_Data_List��� -   Mac_Address��$��Mac Address��$	 137�� �� $ Mac_Data_List�