   M S B A M L   `   `   `  ���� O  KFluent, Version=3.6.1.236, Culture=neutral, PublicKeyToken=3e436e32a8c5546f/$clr-namespace:Fluent;assembly=FluentFluent  T PAvalonDock, Version=1.3.3600.0, Culture=neutral, PublicKeyToken=85a1e0ada7ec13e4;,clr-namespace:AvalonDock;assembly=AvalonDock
AvalonDock N JLm.Eic.App.Mes.View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulldEclr-namespace:Lm.Eic.App.Mes.View.Config;assembly=Lm.Eic.App.Mes.ViewLm.Eic.App.Mes.View.Config  Lm.Eic.App.Mes.Window&    Lm.Eic.App.Mes.Window.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     7Fluent$clr-namespace:Fluent;assembly=Fluent     u qXceed.Wpf.AvalonDock.Themes.Office2007, Version=2.9.15603.14400, Culture=neutral, PublicKeyToken=ba83ff368b7563c6v	 rXceed.Wpf.AvalonDock.Themes.MetroAccent, Version=2.9.15603.14400, Culture=neutral, PublicKeyToken=ba83ff368b7563c6c
 _Xceed.Wpf.AvalonDock, Version=2.9.15603.14400, Culture=neutral, PublicKeyToken=ba83ff368b7563c6q mXceed.Wpf.AvalonDock.Themes.VS2010, Version=2.9.15603.14400, Culture=neutral, PublicKeyToken=ba83ff368b7563c6p lXceed.Wpf.AvalonDock.Themes.Metro, Version=2.9.15603.14400, Culture=neutral, PublicKeyToken=ba83ff368b7563c6o kXceed.Wpf.AvalonDock.Themes.Aero, Version=2.9.15603.14400, Culture=neutral, PublicKeyToken=ba83ff368b7563c6G
avalonDock,http://schemas.xceed.com/wpf/xaml/avalondock  	 
    ?ad,clr-namespace:AvalonDock;assembly=AvalonDock  	 
    Dd2http://schemas.microsoft.com/expression/blend/2008  	 
    Nmc;http://schemas.openxmlformats.org/markup-compatibility/2006  	 
    \configEclr-namespace:Lm.Eic.App.Mes.View.Config;assembly=Lm.Eic.App.Mes.View  	 
      � Title$$  Manufacturing Execution System��$	��600��$	��800��   Fluent.RibbonWindow   
DontUseDwm .    SaveWindowPosition .   � WindowState$ 	Maximized=� � WindowStartupLocation$ CenterOwner=�$��14.667(� � DataContext �� *Main+   Locator �� Source# [  .���  � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+�   Fluent.Ribbon     Menu    Fluent.Backstage     Fluent.RibbonControl	   Header$	 系统��
   Content.
     Fluent.BackstageTabControl  .@�   Fluent.BackstageTabItem     Header$ 个人信息��  $ 配置��.��.  (Lm.Eic.App.Mes.View.Config.CommonParaSet     Fluent.Button     Header$ 返回��   Icon$H B/Lm.Eic.App.Mes.Resources.Image;Component/ImageList/DailyInput.png��   Tabs. 	   Fluent.RibbonTabItem	   	  Header$ 人员管理�� 	  Groups. 
   Fluent.RibbonGroupBox
   
  Header$ 人员管理��.@�  $ 人员新增������ *'%PrimaryMenu.HrMenu.ShowAddUserCommand+  $ 请假管理��	  $ 日报管理��. 
  $ 日报管理��.@�  $ 日报录入��   	LargeIcon$H B/Lm.Eic.App.Mes.Resources.Image;Component/ImageList/DailyInput.png������ *+)PrimaryMenu.BpmMenu.ShowDailyInputCommand+  $ 日报整理��$H B/Lm.Eic.App.Mes.Resources.Image;Component/ImageList/DailyInput.png������ *,*PrimaryMenu.BpmMenu.ShowDailyReportCommand+	  $ 出货检测��. 
  $ 检测与打印��.@�  $ 出货检测��$H B/Lm.Eic.App.Mes.Resources.Image;Component/ImageList/DailyInput.png������ */-PrimaryMenu.OqcMenu.ShowPackInspectionCommand+
  $ 工单管理��.@�  $ 工单管理��$H B/Lm.Eic.App.Mes.Resources.Image;Component/ImageList/DailyInput.png������ *)'PrimaryMenu.OqcMenu.ShowOrderSetCommand+
  $ 工序与产品��.@�  $ 工序管理��$H B/Lm.Eic.App.Mes.Resources.Image;Component/ImageList/DailyInput.png������ *+)PrimaryMenu.OqcMenu.ShowProcessSetCommand+  $ 产品管理��$H B/Lm.Eic.App.Mes.Resources.Image;Component/ImageList/DailyInput.png������ *+)PrimaryMenu.OqcMenu.ShowProductSetCommand+� $��1��.+�) 
 #Xceed.Wpf.AvalonDock.DockingManager   
 Brush6#���     Theme +  %Xceed.Wpf.AvalonDock.Themes.AeroTheme     Layout. , 
 &Xceed.Wpf.AvalonDock.Layout.LayoutRoot     	RightSide 2 
 ,Xceed.Wpf.AvalonDock.Layout.LayoutAnchorSide  � 
 �Xceed.Wpf.AvalonDock.Layout.LayoutGroup`1[[Xceed.Wpf.AvalonDock.Layout.LayoutAnchorGroup, Xceed.Wpf.AvalonDock, Version=2.9.15603.14400, Culture=neutral, PublicKeyToken=ba83ff368b7563c6]]   Children. 3 
 -Xceed.Wpf.AvalonDock.Layout.LayoutAnchorGroup  � 
 �Xceed.Wpf.AvalonDock.Layout.LayoutGroup`1[[Xceed.Wpf.AvalonDock.Layout.LayoutAnchorable, Xceed.Wpf.AvalonDock, Version=2.9.15603.14400, Culture=neutral, PublicKeyToken=ba83ff368b7563c6]]   Children. 2 
 ,Xceed.Wpf.AvalonDock.Layout.LayoutAnchorable  / 
 )Xceed.Wpf.AvalonDock.Layout.LayoutContent   Title$ 隐藏消息��   Content. ��    	RootPanel. - 
 'Xceed.Wpf.AvalonDock.Layout.LayoutPanel     Orientation$ 
Horizontal=�� 
 �Xceed.Wpf.AvalonDock.Layout.LayoutGroup`1[[Xceed.Wpf.AvalonDock.Layout.ILayoutPanelElement, Xceed.Wpf.AvalonDock, Version=2.9.15603.14400, Culture=neutral, PublicKeyToken=ba83ff368b7563c6]]   Children. ; 
 5Xceed.Wpf.AvalonDock.Layout.LayoutAnchorablePaneGroup  � 
 �Xceed.Wpf.AvalonDock.Layout.LayoutPositionableGroup`1[[Xceed.Wpf.AvalonDock.Layout.ILayoutAnchorablePane, Xceed.Wpf.AvalonDock, Version=2.9.15603.14400, Culture=neutral, PublicKeyToken=ba83ff368b7563c6]]   	DockWidth$	 200 �   Orientation$ Vertical=�� 
 �Xceed.Wpf.AvalonDock.Layout.LayoutGroup`1[[Xceed.Wpf.AvalonDock.Layout.ILayoutAnchorablePane, Xceed.Wpf.AvalonDock, Version=2.9.15603.14400, Culture=neutral, PublicKeyToken=ba83ff368b7563c6]]   Children. 6 
 0Xceed.Wpf.AvalonDock.Layout.LayoutAnchorablePane  .   $ 常用工具��. �  
 Brush4#���  9 
 3Xceed.Wpf.AvalonDock.Layout.LayoutDocumentPaneGroup  � 
 �Xceed.Wpf.AvalonDock.Layout.LayoutGroup`1[[Xceed.Wpf.AvalonDock.Layout.ILayoutDocumentPane, Xceed.Wpf.AvalonDock, Version=2.9.15603.14400, Culture=neutral, PublicKeyToken=ba83ff368b7563c6]]    Children.  4 
 .Xceed.Wpf.AvalonDock.Layout.LayoutDocumentPane  -   MainDocumentPane��� 
 �Xceed.Wpf.AvalonDock.Layout.LayoutGroup`1[[Xceed.Wpf.AvalonDock.Layout.LayoutContent, Xceed.Wpf.AvalonDock, Version=2.9.15603.14400, Culture=neutral, PublicKeyToken=ba83ff368b7563c6]]!   Children.! 0 
 *Xceed.Wpf.AvalonDock.Layout.LayoutDocument  $ Welcome��. � #���  � $��0q�$��2��#���  .+��� $2��,开发负责人：张文明  电话：665722��$
��Left=�$��0q�$��Center=��� $��版本:V2.0.0��$��Center=�$��0q�$��Center=��� .+��� $��企业讯息中心(EIC)��$��Arial)�$��11(�
����  �$��2q�$��Right=��� $,��&Light Master Manufacture Excute System��$��Arial)�$��11(�$��2q�$��Right=�