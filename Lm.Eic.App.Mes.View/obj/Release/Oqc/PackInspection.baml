   M S B A M L   `   `   `  ���� N  JLm.Eic.App.Mes.View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Lm.Eic.App.Mes.ViewLm.Eic.App.Mes.View  ,    &Lm.Eic.App.Mes.View.Oqc.PackInspection   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3local!clr-namespace:Lm.Eic.App.Mes.View      
  Brush4#���   .���   � ColumnDefinitions  �� $	��360 ���  � RowDefinitions �� $��30 ��� .+���  
 Brush6#���  $��2��._��� $��Center=�$��21.333(�
���   �$��包装检测��� $��1��$��1��$��2�� �� $��70 ��� $	��130 ��� $��20 ��� $��0* ��� �� $��20 ��� .+��� -    ��Name$ textBlock1_Copy2��$��2��$
��Wrap=�$��3D数据��
�������$��5,5,5,0q����	#FF9DB9DD$��3��$
��Bold"���  �� Orientation$ 
Horizontal=�$	��550��$��1��$
��Left=�.+���  �� TextWrapping$
 Wrap=�$	��310��$��68��$��32(�$��Center=����	#FF2E8FAC$	��0,1q����� *SerialNumber+�� $
 Wrap=�$
��PASS��$��48(�$��68��$��Center=����	#FF2EAC3F$��Center=�$	��132�����	#FF3E3E40�� $��68��$��Center=�.+��� -    ��Name$ textBlock1_Copy1��$��30��$
 Wrap=�$��0��$��94��$��Center=����	#FF049DAA$��1��
�������$��Center=��� -    ��Name$ button��$��打印��$��30��$��94�����	#FF049DAA���	#FF049DAA
�������$��1��$��0,5,0,0q�$��Bottom=����� *null+��   Background_1#���  $��1��$��5,1,5,18q�$��2��.+��� $
��Wrap=�$��大编码：2025800001��$��24(�
�������$	��Top=��� $
��Wrap=�$"��标志号：1 3 5 9 10 15 24��$��24(�
�������$	��Top=��� $
��Wrap=�$	��3D:��$��24(�
�������$	��Top=��� $
��Wrap=�$��Exfo:��$��24(�
�������$	��Top=��� -   $ textBlock1_Copy��$��5��$
��Wrap=�$��
Exfo数据��
�������$��5,5,5,0q����	#FF9DB9DD$��2��$
��Bold"�&   System.Windows.Controls.DataGrid  $��4������ *TestData_3D+  $��6������ *TestDate_Exfo+� $��70��$��	550,0,5,0q�  �� ��  �� �� .+��� $	��0,2q�#���  
����������� *Order.Count+ �� StringFormat$ 工单总量：{0}���� $��1��$	��0,2q�#���  $��已包装：0��
��������� $��1��$	��0,2q�#���  $��本批总量：100��
��������� $��1��$��1��$	��0,2q�#���  $��已包装：0��
��������� $��1��.���  �� $��10 ��� $��40 ��� $��40 ��� $��40 ��� $��40 ��� $��40 ��� $��40 ��� $��40 ��� $��40 ��� $	��200 ��� .+��� $��1��$ 
Horizontal=�.+��� -   $ 	textBlock��$
��Left=�$��工单编号：��$��Center=��� $	��250��$��Center=�$��30������ *	OrderID+�� $��Center=�$��5,0,0,0q��� $
��Left=�$��0,10,0,0q�$��2��$
��Wrap=�$	��Top=��� $
��Left=�$��0,10,0,0q�$��4��$
��Wrap=�$	��Top=����� *Order.ProductID+$ 品号：{0}���� $
��Left=�$��0,15,0,0q�$��5��$
��Wrap=�$	��Top=����� *Order.ProductName+$ 品名：{0}���� $
��Left=�$��0,15,0,0q�$��6��$
��Wrap=�$	��Top=����� *
Order.Spec+$ 规格：{0}���� $
��Left=�$��0,10,0,0q�$��3��$
��Wrap=�$	��Top=�