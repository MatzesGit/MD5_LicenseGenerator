   M S B A M L   `   `   `  ���� K  GLicenseGenerator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:LicenseGenerator.MVVM.ViewLicenseGenerator.MVVM.View  -    'LicenseGenerator.MVVM.View.GenerateView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     :local(clr-namespace:LicenseGenerator.MVVM.View     .���� .+��� $ ��Generate a New License Key��
�������$��28(�$
��Bold"�$
��Left=�$��0,0,0,20q��� $	��800��$	��400������   �� 
StartPoint$	  0,0&� �� EndPoint$	 1,2&�.���  � Color$ #ffffff�� � Offset$ 0Q�� $ #efefef��$ 1Q� J� Clip ��  �� RadiusX$ 5Q� �� RadiusY$ 5Q� �� Rect$ 0,0,700,400�._�� .+��� -   .+��� $6��0Please write the Pxxx number and HMI Key number.��
���   �$��15(�$��DemiBold"�$��
20,10,10,0q���  �� Orientation$ 
Horizontal=�$��0,20,0,0q�.+��� $��Pxxx number��
���   �$��17(�$
��Bold"�$	��150��$��	20,0,20,0q�� $��80��$
��Left=�.+��� 
	 J� Uid$
	 Pxxx��${�False��   ModernTextBox#��[  ���� 
 �� ElementName$
 Number_Textbox�� �� Path$
 Text��� -   $��Number_Textbox��$��7,4,7,4q�
������ $��0q�
������� �� 
CaretBrush
 ����� �� 	MaxLength$ 4���� $ 
Horizontal=�$��0,20,0,0q�.+��� $	��Key��
���   �$��17(�$
��Bold"�$	��150��$��	20,0,20,0q��� $ Vertical=�$��62��$��30��.+�	� -   $��Use_Key�� 	� 	GroupName$ Key_RadioButton��$	��Top=�$��0,5,0,0q� d� 	IsChecked$
 TrueY�  RadioButtonTheme#��[ 	� -   $��No_Key��$ Key_RadioButton��$��Bottom=�$��0,23,0,0q�#��[ �� $ Vertical=�.+�� $��80��$
��Left=�.+��� $	 12344567789��${�False��#��[  ���� $
 Key_Textbox��$
 Text��� -   $��Key_Textbox��$��7,4,7,4q�
������ $��0q�
�������
 �����$ 15���� $#��Paid license no Key nessesary��$��14(�
���   �$
��Bold"�$��Bottom=�$��0,17,0,0q��� $ 
Horizontal=�$��0,20,0,0q�.+��� $��License type��
���   �$��17(�$
��Bold"�$	��150��$��	20,0,20,0q��� $ Vertical=�$	��100��$��30��.+�	� -   $��One_Day��$ Type_RadioButton��$	��Top=�$��0,6,0,0q�$
 TrueY�#��[ 	� -   $��Fourteen_Days��$ Type_RadioButton��$��Bottom=�$��0,20,0,0q�#��[ 	� -   $��Thirty_Days��$ Type_RadioButton��$��Bottom=�$��0,20,0,0q�#��[ �� $ Vertical=�.+��� $��1 day��$��14(�
���   �$
��Bold"�$��Bottom=�$��0,3,0,0q��� $��14 days��$��14(�
���   �$
��Bold"�$��Bottom=�$��0,18,0,0q��� $��30 days��$��14(�
���   �$
��Bold"�$��Bottom=�$��0,18,0,0q��� $ 
Horizontal=�$��0,20,0,0q�.+��� $��Folder��
���   �$��17(�$
��Bold"�$	��150��$��	20,0,20,0q��� -	   $��File_button��$	��490��$�� ��  ModernFileButton#��[ �� -
   $��20��$��20��$��	-40,0,0,0q�
������ 
������ $��0q� � Cursor$
 Hand��.���� -   $��Button_Image��$
��Fill=��� $ 
Horizontal=�$��0,30,0,0q�.+��� $�� ��
���   �$��17(�$
��Bold"�$	��150��$��	20,0,20,0q��� -   $��create��$��Create��$	��100��  ModernClickButton#��[ 