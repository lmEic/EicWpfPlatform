   M S B A M L   `   `   `  ����b  ^Lm.Eic.App.Mes.DailyReport.Passive.View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:Lm.Eic.App.Mes.View.DailyReport.Passive'Lm.Eic.App.Mes.View.DailyReport.Passive  5      9    3Lm.Eic.App.Mes.View.DailyReport.Passive.DailyReport   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=3.5.41019.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Glocal5clr-namespace:Lm.Eic.App.Mes.View.DailyReport.Passive     5      .��5	      �  
  Brush4#���   6     � RowDefinitions  5
   
   �� 5      $��40 �6   �� 5      .+�5   
   �� 
�������$	��0,1q�6%   ._�5      ��  �� Orientation$ 
Horizontal=�6   $��Right=�63   .+�5      �� ���	#CCFFFFFF$��1,0,0,0q�61   $
��Left=�6K   $	��2.5��6h   ���	#FFB6B6B6$	��5,0q�6�   �� 5      $��Center=�6   $��Center=�67   �� 6U   $�车间��6Y   6f   �� 5      $	��150��6l   $��30��6x   ��6   �� *DailyWorkShopList+ �� SelectedItem 6E   �� *DailyWorkShop+6x   �� 5      $��Center=�6   $��Center=�67   �� 6U   $�班别��6Y   6f   �� 5      $	��150��6j   $��30��6v   ��6   �� *LsSources.ClassType+ 6G   �� *	ClassType+6v   �� 5      $��Center=�6   $��Center=�67   �� 6U   $�日期��6Y   6f   (  "System.Windows.Controls.DatePicker  5      $	��180��6@   $��Center=�6L   $��30��6g      SelectedDate 6   �� *	DailyDate+6g   �� 5      $��获取��6:   $
��Left=�6G   $��70��6b   $��30��6o   ��6   �� *GetDailyList+��5      �� 5       j� Stretch$ Uniform=�6&   5      �� 5      $��导出日报��6;   $
��Left=�6J   $��30��6f   ��6   �� *ExportToExcel+5      5       5!      �� 5"   
   $��1��6     MyTabControlStyle1#���  6#   .@�5#      �� $��日报整理��6     MyTabItemStyle1#���  6$   .��5$      &   System.Windows.Controls.DataGrid  $��1��6;      CanUserAddRows .     AutoGenerateColumns .     SelectionMode$ Single=�6{      
IsReadOnly . ��6   �� *	LsDaily+	   Columns	 5%      0  *System.Windows.Controls.DataGridTextColumn  5&      ,  &System.Windows.Controls.DataGridColumn
   Header$
 工单��6.   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *	OrderId+  5'      $
 品名��6.    6:   �� *MaterialName+  5(      $
 规格��6.    6:   �� *MaterialSpc+  5)      $
 	总批量��6.    6;   �� *MaterialNumber+  5*      $
 班别��6.    6:   �� *	ClassType+  5+      $
 产出合计��6.    6<   �� *TechnologyListSumNumber+  5,      $
 投入工时��6.    6<   �� *PutInTimeNumber+  5-      $
 作业工时��6.    6<   �� *WorkerHours+  5.      $
 非生产工时��6.    6=   �� *NotWorkerHours+  5/      $
 得到工时��6.    6<   �� *GetWorkerHours+  50      $
 生产效率��6.    6<   �� *ProductionEfficiency+  51      $
 作业效率��6.    6<   �� *WorkEfficiency+  52      $
 实际入库��6.    6<   �� *PutInHouseNumber+  53      $
 总投入工时��6.    6=   �� *SumPutInWorkHours+  54      $
 工单状态��6.    6<   �� *OrderIDStatus+56      57      �� 58      $��日报详情��6   #���  6$   .��59      �   5:      �� 5;      $��40 �6(   �� 5<      .+�5>      �� $��Right=�6A   $��30��6]   $��	0,15,25,0q�6i   $	��Top=�6|   ��6    �� *TotalDailyInfo+6|   � 5?      $��1��6    � ColumnDefinitions 5@      �� 5A      �� 5B      $	��240 �6/   .+�5D         .   .  $ Single=�6�    . ��6#   �� *TotalUserDailyList+	 5E        5F   "   $
 站别��65    6C   �� *Workstation+  5G   "   $
 班别��65    6C   �� *	ClassType+  5H   "   $
 工号��65    6C   �� *JobNum+  5I   "   $
 姓名��65    6C   �� *Name+  5J   "   $
 良品总数��65    6E   �� *QtyOK+  5K   "   $
 不良总数��65    6E   �� *QtyNG+  5L   "   $
 总生产工时��65    6F   �� *	WorkHours+  5M   "   $
 总非生产工时��65    6G   �� *NotWorkHours+  5N   "   $
 平均效率��65    6E   �� *
Efficiency+5P        5R       .   .  $ Single=�6�    . $��1��6�   ��6#   �� *NotWorkUserList+	 5S        5T   "   $
 工号��65      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6_    6C   �� *	Job_Num+6_     5U   "   $
 姓名��65    6C   �� *Name+5W      5Y      5Z      5[      5\      5^      5_      