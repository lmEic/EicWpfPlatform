   M S B A M L   `   `   `  ���� N  JLm.Eic.App.Mes.View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:Lm.Eic.App.Mes.View.DailyReport.Passive'Lm.Eic.App.Mes.View.DailyReport.Passive  +    %Lm.Eic.App.Mes.View.Daily.DailyReport   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Glocal5clr-namespace:Lm.Eic.App.Mes.View.DailyReport.Passive     .���  
  Brush4#���     � RowDefinitions  �� $��40 ��� .+��� 
�������$	��0,1q�._���  �� Orientation$ 
Horizontal=�$��Right=�.+��� ���	#CCFFFFFF$��1,0,0,0q�$
��Left=�$	��2.5�����	#FFB6B6B6$	��5,0q��� $��Center=�$��Center=��� $�车间���� $	��150��$��30������ *DailyWorkShopList+ �� SelectedItem �� *DailyWorkShop+�� $��Center=�$��Center=��� $�班别���� $	��150��$��30������ *LsSources.ClassType+ �� *	ClassType+�� $��Center=�$��Center=��� $�日期��(  "System.Windows.Controls.DatePicker  $	��180��$��Center=�$��30��   SelectedDate �� *	DailyDate+�� $��获取��$
��Left=�$��70��$��30������ *GetDailyList+����  j� Stretch$ Uniform=��� $��导出日报��$
��Left=�$��30������ *ExportToExcel+�� $��1��  MyTabControlStyle1#���  .@��� $��日报整理��  MyTabItemStyle1#���  .��&   System.Windows.Controls.DataGrid  $��1��   CanUserAddRows .     AutoGenerateColumns .     SelectionMode$ Single=�   
IsReadOnly . ���� *	LsDaily+	   Columns	 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn
   Header$
 工单��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	OrderId+  $
 品名�� �� *MaterialName+  $
 规格�� �� *MaterialSpc+  $
 	总批量�� �� *MaterialNumber+  $
 班别�� �� *	ClassType+  $
 产出合计�� �� *TechnologyListSumNumber+  $
 投入工时�� �� *PutInTimeNumber+  $
 作业工时�� �� *WorkerHours+  $
 非生产工时�� �� *NotWorkerHours+  $
 得到工时�� �� *GetWorkerHours+  $
 生产效率�� �� *ProductionEfficiency+  $
 作业效率�� �� *WorkEfficiency+  $
 实际入库�� �� *PutInHouseNumber+  $
 总投入工时�� �� *SumPutInWorkHours+  $
 工单状态�� �� *OrderIDStatus+�� $��日报详情��#���  .���   �� $��40 ��� .+��� $��Right=�$��30��$��	0,15,25,0q�$	��Top=����� *TotalDailyInfo+� $��1�� � ColumnDefinitions �� �� $	��240 �.+�   .   .  $ Single=� . ���� *TotalUserDailyList+	   $
 站别�� �� *Workstation+  $
 班别�� �� *	ClassType+  $
 工号�� �� *JobNum+  $
 姓名�� �� *Name+  $
 良品总数�� �� *QtyOK+  $
 不良总数�� �� *QtyNG+  $
 总生产工时�� �� *	WorkHours+  $
 总非生产工时�� �� *NotWorkHours+  $
 平均效率�� �� *
Efficiency+   .   .  $ Single=� . $��1������ *NotWorkUserList+	   $
 工号��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100  �� *	Job_Num+  $
 姓名�� �� *Name+