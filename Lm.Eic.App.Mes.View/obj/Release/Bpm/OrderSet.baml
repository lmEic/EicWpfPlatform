   M S B A M L   `   `   `  ���� N  JLm.Eic.App.Mes.View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Lm.Eic.App.Mes.View.BpmLm.Eic.App.Mes.View.Bpm  &     Lm.Eic.App.Mes.View.Bpm.OrderSet   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     7local%clr-namespace:Lm.Eic.App.Mes.View.Bpm      
  Brush4#���     � DataContext  �� *OrderSetViewModel+  Locator �� Source# [ .���  � RowDefinitions �� $��40 ��� $	��170 ��� .+��� $��40�� 
 Brush6#���  ._��� $��0q� �� Orientation$ 
Horizontal=�$��Center=�$��Right=�.+��� $��Center=�工单号：�� -    ��Name$ txb_OrderID��$	��180������ *	OrderID+.�� J� InputBindings �� 
 �� Key$ Enter�� �� Command �� *GetModelCommand+ �� CommandParameter �� *Text+	 �� ElementName$	 txb_OrderID��.���� $	��105��
 �� SelectedItem
 �� *Order.State+���� *LsSources.OrderState+�� $��加载��$��10,0,0,0q�$
��Left=�$��70��  Buttonlist2#���  $��30������ *GetModelCommand+���� *Text+$	 txb_OrderID������  �� ImageSource$A ;/Lm.Eic.App.Mes.Resources.Image;Component/ImageList/get.png�� j� Stretch$ Uniform=��� $��保存��$��10,0,0,0q�$
��Left=�$��70��#���  $��30������ *SaveOrderCommand+���� $B </Lm.Eic.App.Mes.Resources.Image;Component/ImageList/save.png��$ Uniform=��� $��重载��$��10,0,0,0q�$
��Left=�$��70��#���  $��30������ *OverrideOrderCommand+���� $G A/Lm.Eic.App.Mes.Resources.Image;Component/ImageList/heavyload.png��$ Uniform=�� $��1�� �� $��40 ��� $��40 ��� $��40 ��� $��40 ��� $��40 ���  � ColumnDefinitions �� $��60 ��� $	��180 ��� $��5 ��� $	��100 ��� $	��150 ��� $	��100 ��� $	��150 ��� $	��100 ��� $	��150 ��� .+��� $��PN：��$��Center=�$��18(�$��1��$��Right=�$��	0,10,16,7q�$��29���� $��PO：��$��2��$��Center=�$��18(�$��Right=�$��	0,10,16,7q�$��29���� $��Qty：��$��3��$��Center=�$��18(�$��Right=�$��	0,10,16,7q�$��33���� $��36��$��1��$��Center=�$��0,4,0,0q�$��1������ *
Order.PN+�� $��2��$��36��$��Center=�$��0,3,0,1q�$��1������ *
Order.PO+�� $��3��$��36��$��Center=�$��0,4,0,0q�$��1������ *	Order.Qty+3   -Lm.Eic.App.Mes.View.Bpm.UserControl_OrderInfo  $��3��$��1��$��3��$	��750��$
��Left=�$��6��$��6,0,0,0q� 
 Brush8#���    �� *Order.Detailed+�� $��	客户：��$��Center=�$��18(�$��Right=��� $��35��$��Center=�$��1�� �� 
IsEditable . $ �� IsSynchronizedWithCurrentItem$ FalseY����� *LsSources.Client+
 �� *Order.ClientName+�� $��生产中心：��$��Center=�$��18(�$��Right=�$��3���� $��35��$��Center=�$��4������ *LsSources.Department+
 �� *Order.WorkDepartment+�� $��生产车间：��$��Center=�$��18(�$��Right=�$��5���� $��35��$��Center=�$��6������ *LsSources.WorkShop+
 �� *Order.WorkShop+�� $��宽放比例：��$��Center=�$��18(�$��Right=�$��6��$��2���� $��35��$��Center=�$��8������ *Order.Relax+�� $��2��  Background_2#���  .@��� $��附加工单��.���  �� $��40 ��� .+��� $ 
Horizontal=�.+��� $��工单单号：��$��Center=�$��Center=�
���   ��� $	��200��$��Center=����� *1/OrderRelevanceVm.OrderRelevance.AdditionalOrder+�� $��	批量：��$��Center=�$��Center=�
���   �$��5,0,0,0q��� $��80��$��Center=����� *%#OrderRelevanceVm.OrderRelevance.Qty+�� $��保存��$��10,0,0,0q�$
��Left=�$��70��#���  $��30������ *OrderRelevanceVm.AddCommand+���� $A ;/Lm.Eic.App.Mes.Resources.Image;Component/ImageList/Add.png��$ Uniform=�&   System.Windows.Controls.DataGrid  $��1��   CanUserAddRows .     AutoGenerateColumns .     SelectionMode$ Single=����� *%#OrderRelevanceVm.OrderRelevanceList+
 �� *'%OrderRelevanceVm.SelectOrderRelevance+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 制令单号��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *AdditionalOrder+  $ 品名�� �� *ProductName+  $ 规格�� �� *Spec+  $ 批量�� �� *Qty+ � ContextMenu �� .@�m� $��删除�� m� Command �� * OrderRelevanceVm.DeleteCommand+�� $��条码管理��.���  �� $	��450 ��� .+��� $��配置��.��� $��0q� �� $	��110 ��� $	��160 ��� $��80 ��� $��80 ��� $	��120 � �� $��40 ��� $��40 ��� $��40 ��� $��40 ��� $��40 ��� $��50 ��� .+��� -    ��Name$ 
textBlock1��$
��Wrap=�$��数量��$��Center=� J� RenderTransformOrigin$ -1.088,0.522&�$��2��$��Right=�$��1���� -   $ textBlock1_Copy2��$
��Wrap=�$��配组设置��$��Center=�$ -1.088,0.522&�$��Right=�$��0,7,5,17q��� -   $ textBox��$��1�� �� TextWrapping$
 Wrap=�$��10��$��Center=�$��3��$��30��$	��0,5q�$��Right=�$��80���� $��Center=�$��1��$��30��$��0,0,0,10q�$��3������ *SerialNumberVm.SnOption+�� -   $ textBlock1_Copy3��$
��Wrap=�$��Pigtail起始码��$��Center=�$ -1.088,0.522&�$��Right=�$��1��$��0,0,5,0q��� -   $ textBox_Copy��$��1��$
 Wrap=�$��10��$��Center=�$��1��$��30��$	��0,5q��� -   $ textBlock1_Copy5��$��Right=�$
��Wrap=�$��	标识位��$��Center=�$ -1.088,0.522&�$��3��$��0,0,5,0q��� -   $ textBlock1_Copy6��$��Right=�$
��Wrap=�$��接头��$��Center=�$ -1.088,0.522&�$��4��$��0,0,5,0q��� -	   $ textBox_Copy4��$��30��$��3��$
 Wrap=�$��10��$��Center=�$��1��$��3��$	��0,5q��� -
   $ textBox_Copy5��$��30��$��4��$
 Wrap=�$��10��$��Center=�$��1��$��3��$	��0,5q��� $��生成��$��2��$��Center=�$��30��$��5��$��Center=�$��80������ *$"SerialNumberVm.CreateSnListCommand+�� $��保存��$��3��$��Center=�$��30��$��5��$��Center=�$��80��$
��0,10q�$ 
0.15,0.967&��� -   $ textBlock1_Copy��$
��Wrap=�$��数量��$��Center=�$ -1.088,0.522&�$��2��$��Right=�$��2���� -   $ textBox_Copy1��$��2��$
 Wrap=�$��10��$��Center=�$��3��$��30��$	��0,5q��� -   $ textBlock1_Copy1��$
��Wrap=�$��Client起始码��$��Center=�$ -1.088,0.522&�$��Right=�$��2��$��0,0,5,0q��� -   $ textBox_Copy3��$��2��$
 Wrap=�$��10��$��Center=�$��30��$��0,4,0,6q�$��1��  -     Name$ 	dataGrid2��$��1������ *SerialNumberVm.SnList+�� $��检测设置��.��� $��1�� �� $��35 ���  �� $	��500 ��� .+��� $��1��$
��Left=�$��
10,10,0,10q�$
��Wrap=�$!��为接头指定测试标准��$��Center=��� $ 
Horizontal=�.+��� $��Center=�检测标准:�� $	��200��$��30������ *)'InspectStandardVm.InspectSetValue.Title+�� ���� *InspectStandardVm.Sava+.��保存�� $�� ��$��1��.���  �� $��60 ��� $��60 ��� $��60 ��� $��60 ��� $��60 ��� $��60 ��� $��60 ��� $��60 ���  �� $��35 ��� $��35 ��� $��35 ��� $��5 ��� .+��� $��Center=�$��1��$
��Wrap=�$	��Min��$��Center=�$��14(�$
��Bold"��� $��Center=�$��2��$
��Wrap=�$	��Max��$��Center=�$��14(�$
��Bold"��� $��1��$��Center=�$	��RCO��$��Center=��� $��2��$��Center=�$��AO��$��Center=��� $��3��$��Center=�$��FH��$��Center=��� $��4��$��Center=�$��AE��$��Center=��� $��6��$��Center=�$��IL��$��Center=��� $��7��$��Center=�$��RL��$��Center=��� $��1��$��1��$
 Wrap=�$��Center=�$��30��$	��5,0q����� **(InspectStandardVm.InspectSetValue.RcoMin+�� $��1��$��2��$
 Wrap=�$��Center=�$��30��$	��5,0q����� **(InspectStandardVm.InspectSetValue.RcoMax+�� $��2��$��1��$
 Wrap=�$��Center=�$��30��$	��5,0q����� *)'InspectStandardVm.InspectSetValue.AoMin+�� $��2��$��2��$
 Wrap=�$��Center=�$��30��$	��5,0q����� *)'InspectStandardVm.InspectSetValue.AoMax+�� $��3��$��1��$
 Wrap=�$��Center=�$��30��$	��5,0q����� *)'InspectStandardVm.InspectSetValue.FhMin+�� $��3��$��2��$
 Wrap=�$��Center=�$��30��$	��5,0q����� *)'InspectStandardVm.InspectSetValue.FhMax+�� $��4��$��1��$
 Wrap=�$��Center=�$��30��$	��5,0q����� *)'InspectStandardVm.InspectSetValue.AeMin+�� $��4��$��2��$
 Wrap=�$��Center=�$��30��$	��5,0q����� *)'InspectStandardVm.InspectSetValue.AeMax+�� $��6��$��1��$
 Wrap=�$��Center=�$��30��$	��5,0q����� *)'InspectStandardVm.InspectSetValue.IlMin+�� $��6��$��2��$
 Wrap=�$��Center=�$��30��$	��5,0q����� *)'InspectStandardVm.InspectSetValue.IlMax+�� $��7��$��1��$
 Wrap=�$��Center=�$��30��$	��5,0q����� *)'InspectStandardVm.InspectSetValue.RlMin+�� $��7��$��2��$
 Wrap=�$��Center=�$��30��$	��5,0q����� *)'InspectStandardVm.InspectSetValue.RlMax+  -   $ 	dataGrid1��$��0q�$��4��$��8��$	��480������ **(InspectStandardVm.OrderInspectConfigList+  $��1��$��1���� -    ��Name$ button1��$��保存��$��1��$��Right=�$��0,0,10,0q�$��Center=�$��75���� $��打印设置��.���  �� $��40 ���  �� $	��500 ��� $	��400 ��� .+��� $ 
Horizontal=�$��2��.+��� $��Center=�打印类型�� $	��150��$��30��$��Center=��� $��Center=�模板选择�� $	��150��$��30��$��Center=��� $��Center=�触发数量�� $��80��$��30���� .��生成预览�� .��保存�� $
��Left=�$C��=/Lm.Eic.App.Mes.Resources.Image;Component/ImageList/Nopic.png��$
��Fill=�$	��Top=�$	��400��$	��400��$��1��$��0,4,0,0q�$��1��     SelectionUnit$ CellOrRowHeader=� .   .  $��0q�$��1��      
IsReadOnly . $
 Name�� �� *Name+ �� Mode$ TwoWay=�  �� UpdateSourceTrigger$  PropertyChanged=�  $ Value��!   Width5  /System.Windows.Controls.DataGridLengthConverter$	! 340  �� *Value+$ TwoWay=�$  PropertyChanged=��� $��批号管理��.���  �� $	��350 ��� .+��� -   " ��Name$" groupBox��$��批号设置��.���  �� $��40 ��� $��40 ��� $��40 ��� $��50 ���  �� $��80 ��� .+��� -   $ 	textBlock��$��Right=�$
��Wrap=�$��批号:��$��Center=��� -   $ textBlock_Copy��$��Right=�$
��Wrap=�$��出货日期:��$��Center=�$��0,10,0,9q�$��1���� -   $ textBlock_Copy1��$��Right=�$
��Wrap=�$��数量:��$��Center=�$��0,10,0,9q�$��2���� $��1��$��30��$
 Wrap=�$��Center=�$��0,0,10,0q����� *PackLotVm.PactLot.PackLot+�� $��1��$��30��$
 Wrap=�$��Center=�$��2��$��0q�$
��Left=�$	��100������ *PackLotVm.PactLot.Qty+(  "System.Windows.Controls.DatePicker  $��1��$��1��$��Center=�$��30��$��0,0,10,0q�#   SelectedDate# �� * PackLotVm.PactLot.DeliveryDate+�� $��1��$��3��$ 
Horizontal=�$��Right=�$��0,0,10,0q�.+��� -   $ button��$��添加��$��60��$��Center=�$��Center=��� -   $ button_Copy��$��编辑��$��60��$��Center=�$��Center=��� -   $ button_Copy1��$��删除��$��60��$��Center=�$��Center=��� -   $ button_Copy2��$��保存��$��60��$��Center=�$��Center=�  $��1������ *PackLotVm.PackLotList+