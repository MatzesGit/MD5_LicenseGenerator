   M S B A M L   `   `   `  ���� K  GLicenseGenerator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:LicenseGenerator.MVVM.ViewLicenseGenerator.MVVM.View  -    'LicenseGenerator.MVVM.View.SettingsView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     :local(clr-namespace:LicenseGenerator.MVVM.View     .���� .+��� $��Settings��
�������$��28(�$
��Bold"�$
��Left=�$��0,0,0,20q��� $	��800��$	��400������   �� 
StartPoint$	  0,0&� �� EndPoint$	 1,2&�.���  � Color$ #ffffff�� � Offset$ 0Q�� $ #efefef��$ 1Q� J� Clip ��  �� RadiusX$ 5Q� �� RadiusY$ 5Q� �� Rect$ 0,0,700,400�._�� .+���  �� Orientation$ Vertical=�.+��� $ 
Horizontal=�$��	20,20,0,0q�.+��� -   $��Button_App_Settins��$��App Settings��$	��150��   ModernClickButton#��[  �� -   $��Button_Password_Settings��$��Password Settings��$	��150��$��20,0,0,0q�#��[  �� $��
0,10,100,0q�.+��� ���#353340$	��660��  MenuLine#��[ �� -   $��AppSettings��$	��330��$	��660��$��Bottom=�$
��Left=�$��20,0,0,0q�$��0q�
������ $y�Hidden=�._��� .+��� .+��� $H��BHere you can change the standard storage path for the license.dat.��
���   �$��15(�$��DemiBold"�$��0,0,10,0q��� $ 
Horizontal=�$��0,20,0,0q�.+��� $��Folder��
���   �$��17(�$
��Bold"�$	��150��$��0,0,20,0q��� -   $��File_button��$	��490��$�� ��  ModernFileButton#��[ �� -   $��20��$��20��$��	-40,0,0,0q�
������ 
������ $��0q�	 � Cursor$
	 Hand��.���� -   $��Button_Image��$
��Fill=��� $ 
Horizontal=�$��0,30,0,0q�.+��� $�� ��
���   �$��17(�$
��Bold"�$	��150��$��0,0,20,0q��� -   $��App_Settings_Save��$
��Save��$	��100��#��[  �� -   $��PasswordSettings��$	��330��$	��660��$��Bottom=�$
��Left=�$��20,0,0,0q�$��0q�
������ $y�Visible=�$��Visible=�._��� .+��� $G��APlease type in the Admin password for changing License passwords.��
���   �$��15(�$��DemiBold"��� $ 
Horizontal=�$��0,20,0,0q�.+��� $��Admin Password��
���   �$��17(�$
��Bold"�$	��150��$��0,0,20,0q�� $	��150��$
��Left=�.+��� 

 J� Uid$
  ��${�False��  ModernTextBox#��[ ����  �� ElementName$ Password_Textbox�� �� Path$ Password�G� -	   $��Password_Textbox��$��7,4,7,4q� G� PasswordChar$ *��
������ $��0q�
������� G� 
CaretBrush
 ����� G� 	MaxLength$ 15���� -
   $��Password_OK��$��OK��$��30��$��10,0,0,0q�#��[  �� -   $��Show_Passwords_Panel��$y�Hidden=�.+��� $��0,20,0,0q�.+��� ���#353340$	��660��#��[ �� $ 
Horizontal=�$��0,20,0,0q�.+��� $��Password 1 day��
���   �$��17(�$
��Bold"�$	��150��$��0,0,20,0q�� $	��150��$
��Left=�.+��� $
 1 day��${�False��#��[ ���� $ One_Day_Textbox��$
 Text��� -   $��One_Day_Textbox��$��7,4,7,4q�
������ $��0q�
������� �� 
CaretBrush
 ����� �� 	MaxLength$ 50���� $ 
Horizontal=�$��0,10,0,0q�.+��� $��Password 14 days��
���   �$��17(�$
��Bold"�$	��150��$��0,0,20,0q�� $	��150��$
��Left=�.+��� $
 14 days��${�False��#��[ ���� $ Fourteen_Days_Textbox��$
 Text��� -   $��Fourteen_Days_Textbox��$��7,4,7,4q�
������ $��0q�
�������
 �����$ 50���� $ 
Horizontal=�$��0,10,0,0q�.+��� $��Password 30 days ��
���   �$��17(�$
��Bold"�$	��150��$��0,0,20,0q�� $	��150��$
��Left=�.+��� $
 30 days��${�False��#��[ ���� $ Thirty_Days_Textbox��$
 Text��� -   $��Thirty_Days_Textbox��$��7,4,7,4q�
������ $��0q�
�������
 �����$ 50���� $ 
Horizontal=�$��0,10,0,0q�.+��� $��Password paid��
���   �$��17(�$
��Bold"�$	��150��$��0,0,20,0q�� $	��150��$
��Left=�.+��� $
 
fully paid��${�False��#��[ ���� $ Paid_Textbox��$
 Text��� -   $��Paid_Textbox��$��7,4,7,4q�
������ $��0q�
�������
 �����$ 50���� $ 
Horizontal=�$��0,30,0,0q�.+��� $�� ��
���   �$��17(�$
��Bold"�$	��150��$��0,0,20,0q��� -   $��Password_Settings_Change��$��Change��$	��100��#��[  