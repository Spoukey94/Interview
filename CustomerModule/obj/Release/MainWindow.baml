   M S B A M L   `   `   `  ���� I  ECustomerModule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:CustomerModuleCustomerModule      CustomerModule.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:CustomerModule       � 
ResizeMode$  NoResize=� � Title$ Customer Module��$	��400��$	��550��.��� .+�� $
��Left=�$	��181��$��	0,178,0,0q�$	��Top=�$	��534��.+�&   System.Windows.Controls.DataGrid  -     Name$ 
dgCustomer��$
��Left=�$	��181��$	��Top=�   
IsReadOnly . $	��522��$��10,0,0,0q�� $
��Left=�$	��121��$��10,0,0,0q�$	��Top=�$	��522��.+�� -    �Name$ grName��$
��Left=�$��62��$��	10,21,0,0q�$	��Top=�$	��238��.+��� -    ��Name$ tbName��$
��Left=�$��23��$��	10,29,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��218���� -    ��Name$ lblName��$��Name:��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��111��� -   $ grTelephone��$
��Left=�$��62��$��
274,21,0,0q�$	��Top=�$	��238��.+��� -   $ tbTelephone��$
��Left=�$��23��$��	10,29,0,0q�$
 Wrap=�$	��Top=�$	��218���� -   $ lblTelephone��$��Telephone number:��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��111��� -   $ 	grSurname��$
��Left=�$��62��$��	10,59,0,0q�$	��Top=�$	��238��.+��� -	   $ 	tbSurname��$
��Left=�$��23��$��	10,29,0,0q�$
 Wrap=�$	��Top=�$	��218���� -
   $ 
lblSurname��$��Surname:��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��111��� -   $ 	grAddress��$
��Left=�$��62��$��
274,59,0,0q�$	��Top=�$	��238��.+��� -   $ 	tbAddress��$
��Left=�$��23��$��	10,29,0,0q�$
 Wrap=�$	��Top=�$	��218���� -   $ 
lblAddress��$��Address:��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��111��� -   $ grSurname_Copy��$
��Left=�$��54��$��
10,-16,0,0q�$	��Top=�$��74��.+��� -   $
 tbID��$y�Hidden=� �� 
IsReadOnly . $
��Left=�$��23��$��10,29,-15,0q�$
 Wrap=�$	��Top=�$��53��� $
��Left=�$��52��$��
10,121,0,0q�$	��Top=�$	��522��.+��� -   	 ��Name$	 
btnRefresh��$��Reset��$
��Left=�$��0,29,0,0q�$	��Top=�$��34��$��23���� -   $	 	btnInsert��$	��Add��$
��Left=�$��
488,29,0,0q�$	��Top=�$��34��$��23���� -   $	 	btnDelete��$��Delete��$
��Left=�$��
440,29,0,0q�$	��Top=�$��43��$��23���� -   $	 	btnUpdate��$��Modify��$
��Left=�$��
392,29,0,0q�$	��Top=�$��43��$��23��