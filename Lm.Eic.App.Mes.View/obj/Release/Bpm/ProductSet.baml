   M S B A M L   `   `   `  ���� N  JLm.Eic.App.Mes.View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:Lm.Eic.App.Mes.View.DailyReport.Passive'Lm.Eic.App.Mes.View.DailyReport.Passive  (    "Lm.Eic.App.Mes.View.Bpm.ProductSet   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Glocal5clr-namespace:Lm.Eic.App.Mes.View.DailyReport.Passive     .���   � RowDefinitions  �� $��40 ��� $��80 ��� .+���  
  Brush6#���   ._���  �� Orientation$ 
Horizontal=�$��Right=�.+��� $��Center=�$��Center=�.��工单单号:�� $	��180��$��35������ *	OrderID+�� $��载入��$
��Left=�$��70��$��30������ *GetInfoForDbCommand+�� $��新增��$
��Left=�$��70��$��30���� $��编辑��$
��Left=�$��70��$��30���� $��删除��$
��Left=�$��70��$��30���� $��保存��$
��Left=�$��70��$��30���� $��1�� 
 Brush4#���  ._��� $��80�� 
 Brush8#���  ���� *ProductInfo+�� $��2��  MyTabControlStyle1#���  .@��� $��工序设置��  MyTabItemStyle1#���  .��� #���    �� $��35 ��� .+��� $��Right=�$��40��$��0,2.5,10,2.5q�$��Center=�$	��200��$��Center=����� *ProcessTemplateNameList+ �� SelectedItem �� *ProcessTemprateName+�� -    ��Name$ 	textBlock��$��Right=�$��	0,0,210,0q�$
��Wrap=�$��模板名称��$��Center=�&   System.Windows.Controls.DataGrid  $��1������ *ProcessList+�� $��检测设置��#���  .��� #���    �� $	��300 ��� .+��� $��条码设置��$��0q�.���  � ColumnDefinitions �� �� $	��200 �.+��� -    ��Name$ listBox��$��1��$��0,0,5,0q�$��3��$	��Top=�� $��0q� �� $	��110 ��� $	��110 ��� $	��110 ��� $	��110 ���   �� $	��43* ��� $	��50* ��� $
��185* �.+��� -   $ 
textBlock1��$��Center=�$
��Wrap=�$��条码长度��$��Center=� J� RenderTransformOrigin$ -1.088,0.522&��� -   $ textBlock1_Copy��$��Center=�$
��Wrap=�$��标志位设置��$��Center=�$ -1.088,0.522&�$��1���� -   $ textBlock1_Copy1��$��Center=�$
��Wrap=�$��接头设置��$��Center=�$ -1.088,0.522&�$��2���� -   $ textBlock1_Copy2��$��Center=�$
��Wrap=�$��配组设置��$��Center=�$ -1.088,0.522&�$��3���� -    ��Name$ textBox��$��Center=�$��30��$��1�� �� TextWrapping$
 Wrap=�$��10��$��Center=�$	��100���� -   $ textBox_Copy��$��Center=�$��30��$��1��$
 Wrap=�$��TextBox��$��Center=�$	��100��$��1���� -	   $ textBox_Copy1��$��Center=�$��30��$��1��$
 Wrap=�$��TextBox��$��Center=�$	��100��$��2���� -
   	 ��Name$	 textBox_Copy2��$��Center=�$��30��$��1��
 �� Text$
 TextBox��$��Center=�$	��100��$��3���� -   $ listBox1��$��1��$��2��$	��5,0q��� -   $ listBox1_Copy��$��2��$��2��$	��5,0q��� -    ��Name$ groupBox��$��检测设置��$��0,10,0,0q�$��1���� $��标签设置��#���  .��� #���   �� $	��200 ��� $��80 ��� $	��160 ��� $��40 ���   �� $	��41* ��� $	��53* ��� $
��316* �.+��� -   $ 
textBlock2��$
��Left=�$��19��$��	12,10,0,0q�$
��Wrap=�$��标签��$	��Top=�$��69���� -   $ textBlock2_Copy��$
��Left=�$��19��$��	10,10,0,0q�$
��Wrap=�$��触发数量��$	��Top=�$��69��$��1���� -   $ textBlock2_Copy1��$
��Left=�$��19��$��	23,10,0,0q�$
��Wrap=�$��打印类型��$	��Top=�$��69��$��2���� -   $	 comboBox��$
��Left=�$��33��$��	12,10,0,0q�$��1��$	��Top=�$	��178���� -   $	 comboBox_Copy��$
��Left=�$��33��$��	10,10,0,0q�$��1��$	��Top=�$	��150��$��2���� -   $ textBox1��$��1��$
��Left=�$��25��$��9,10,0,0q�$��1��$
 Wrap=�$��TextBox��$	��Top=�$��61��  -     Name$ dataGrid��$��4��$��0,0,5,0q�$��2���� -    ��Name$ image��$��4��$
��Left=�$��97��$��28,8,0,0q�$��2��$	��Top=�$	��198�� 
 Brush1 J� OpacityMask# �  �� -    ��Name$ button��$��Button��$��3��$
��Left=�$��19��$��9,16,0,0q�$��1��$	��Top=�$��31��