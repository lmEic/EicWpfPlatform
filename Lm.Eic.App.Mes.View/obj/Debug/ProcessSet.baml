   M S B A M L   `   `   `  ����b  ^Lm.Eic.App.Mes.DailyReport.Passive.View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:Lm.Eic.App.Mes.View.DailyReport.Passive'Lm.Eic.App.Mes.View.DailyReport.Passive  5      8    2Lm.Eic.App.Mes.View.DailyReport.Passive.ProcessSet   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=3.5.41019.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Glocal5clr-namespace:Lm.Eic.App.Mes.View.DailyReport.Passive     5       
  Brush4#���   5      .��5	      �   � RowDefinitions  5
   
   �� 5      $��50 �6   �� 5      ��6   �� *	EditHeigh+�� 5      .+�5   
   ��  
 Brush6#���  6   ._�5      ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   .+�5      �� $��Center=�6   工序名称6=   �� 5      -   5         ��Name$ SearchValue��5      $	��180��6/   $��Center=�6;   �� 5      $��查询��6o   $��10,0,0,0q�6}   $
��Left=�6�   $��70��6�   $��30��6�   ��6   �� *Search+��64   �� *Text+ �� ElementName$ SearchValue��5      �� 5      $��编辑��68   $��10,0,0,0q�6F   $
��Left=�6X   $��70��6s   $��30��6�   ��6   �� *
ShowEdit+5      �� 5      $��导出��6<   $��5,0,5,0q�6J   $
��Left=�6[   $��70��6v   $��30��6�   ��6   �� *ExportToExcel+5      �� 5       $��导入��6<   $��5,0,5,0q�6J   $
��Left=�6[   $��70��6v   $��30��6�   ��6   �� *InputForExcel+5"      5#      5$      �� 5&   
   $��1��6   ._�5'      � $��60��6   $
��Left=�6     � ColumnDefinitions 5(      �� 5)      $	��100 �6'   �� 5*      $	��240 �6'   �� 5+      $��80 �6'   �� 5,      $��80 �6'   �� 5-      $��80 �6'   �� 5.        50      �� 51      $��25 �6$   �� 52      $��35 �6$   �� 53      .+�55      �� $��工序编号��6   $��0��6(   $��0��65   $��Center=�6E   $��Center=�6b   �� 56      $��工序名称��6   $��0��6(   $��1��65   $��Center=�6E   $��Center=�6b   �� 57      $��标准工时��6   $��0��6(   $��2��65   $��Center=�6E   $��Center=�6b   �� 58      $��1��6[   $��0��6h   $��Center=�6x   $��Center=�6�   $��2��6�   $��	0,0,239,0q�6�   {�6   �� *IsEdit+��67   �� *SelModel.ProcessID+6�   �� 59      $��1��6V   $��1��6c   $��Center=�6s   $��Center=�6�   $��2��6�   $��1,0,78,0q�6�   {�6   �� *IsEdit+��67   �� *SelModel.Name+6�   �� 5:      $��1��6_   $��2��6l   $��Center=�6|   $��Center=�6�   $��2,0,0,0q�6�   {�6   �� *IsEdit+��67   �� *SelModel.StandardHours+6�   �� 5;      $��1��6   $ 
Horizontal=�6*   $
��Left=�6C   $��Center=�6^   $��5��6y   $��0q�6�   .+�5=      �� $��新增��67   $��10,0,0,0q�6E   $
��Left=�6W   $��70��6r   $��30��6   ��6   �� *Add+5?      �� 5A      $��编辑��68   $��10,0,0,0q�6F   $
��Left=�6X   $��70��6s   $��30��6�   ��6   �� *Edit+5C      �� 5E      $��删除��6:   $��10,0,0,0q�6H   $
��Left=�6Z   $��70��6u   $��30��6�   ��6   �� *Delete+5G      �� 5I      $��保存��68   $��10,0,0,0q�6F   $
��Left=�6X   $��70��6s   $��30��6�   ��6   �� *Sava+5K      5L      �� 5M      $��宽放比例��6   $��0��6(   $��3��65   $��Center=�6E   $��Center=�6b   �� 5N      $��1��6W   $��3��6d   $��Center=�6t   $��Center=�6�   $��0,0,2,0q�6�   {�6   �� *IsEdit+��67   �� *SelModel.Relax+6�   �� 5O      $��PCS/H��6   $��0��6)   $��4��66   $��Center=�6F   $��Center=�6c   �� 5P      $��1��6V   $��4��6c   $��Center=�6s   $��Center=�6�   {�6   �� *IsEdit+��67   �� *SelModel.PCSH+6�   5Q      5R      &   System.Windows.Controls.DataGrid  5T   
   $��2��6      CanUserAddRows .     AutoGenerateColumns .     SelectionMode$ Single=�6�   ��6!   �� *	LsProcess+ �� SelectedItem 6C   �� *
SelModel+	   Columns	 5U      0  *System.Windows.Controls.DataGridTextColumn  5V      ,  &System.Windows.Controls.DataGridColumn
   Header$
 部门��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   �� *
WorkShop+  5W      $
 序号��6%    62   �� *	ProcessID+  5X      $
 工序ID��6%    64   �� *Name+  5Y      $
 标准工时��6%    64   �� *StandardHours+  5Z      $
 宽放比例��6%    64   �� *Relax+  5[      $
 PSC/H��6%    65   �� *PCSH+  5\      $
 站别��6%    62   �� *Workstation+  5]      $
 备注��6%    62   �� *Remark+5_      5b      5c      