   M S B A M L   `   `   `  ����   Lm.Eic.App.Mes.Window     Lm.Eic.App.Mes.Window.Land   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity    � Title$  	MaiWindow��$	��350��$	��400�����	#00000000 � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � AllowsTransparency . $��1q� � WindowStartupLocation$ CenterScreen=�.��� ���	#a1C6C6C6 J� Opacity$ 1Q� � RowDefinitions �� $
��360* �.+��� }�. $��10q�$��0��$��0��
���   �$��0q� �� CornerRadius$ 0 0 7 7��._�� $��0��$��0��$��0q� �� $��43 ��� $
��200* �.+�� $��Stretch=�$��Stretch=�$��0��$��0�� � ColumnDefinitions �� $	��322 ��� $��32 ����� 	 �� ImageSource$L	 F/Lm.Eic.App.Mes.Resources.Image;Component/ImageList/login_title_bg.png��.+��� -   
 ��Name$
 	lab_Title��$�� Welcome to MES�� �� Padding$ 20 0 0 0q�$��24(�
�������$
��Left=�$��Center=��� -   $��	btn_close��$��0��$��1��$��25��$��25��$��Center=�$��Center=����� .R��� $��
tips_close��
�������$��18(�$��Center=�$��Center=� � Cursor$
 Hand������ $D	 >/Lm.Eic.App.Mes.Resources.Image;Component/ImageList/cancel.png��.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ 
MouseEnter��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *Close_MouseEnter+   CommandParameter ��  �� ElementName$ 
tips_close��  $ 
MouseLeave��.    �� *Close_MouseLeave+ �� $ 
tips_close��   $ Click��.    �� *Close+� $��Stretch=�$��1��$��0��$��Stretch=����	#FFededed �� $	��60* ��� $	��60* ��� $	��60* �.+��� $��0��$��0��$	��334��$��50������ $K	 E/Lm.Eic.App.Mes.Resources.Image;Component/ImageList/UIDA登录_03.gif��.���� -    ��Name$ 
txb_UserID��$��45 0 0 0q�$	��280��$��50��$��20 0 0 0q�$��Stretch=�$��Center=�$
��Left=�$��24(�$��Center=�$��0q� � ToolTip$ 	用户名������ *User.JobNum+��Z� .�� J� InputBindings �� 
 �� Key$ Enter�� �� Command �� *UserKeyCommand+ �� CommandParameter �� $ txb_Password��.���� $��1��$��0��$	��334��$��50������ $K	 E/Lm.Eic.App.Mes.Resources.Image;Component/ImageList/UIDA登录_06.gif��.��G� -    G�Name$ txb_Password��$��45 0 0 0q�$	��280��$��50��$��20 0 0 0q�$��Stretch=�$��Center=�$
��Left=�$��24(�$��Center=�$��0q�$ 密码����Z�  �� $ Enter�� �� *PasswordKeyCommand+ �� $ txb_Password���� -   $��	btn_login��$
 Hand��$ 1Q�$��0��$��2�����	#FF7C7C03$��50��$	��320������  �� 
TargetType" ��.R��� }�. $ 5��._��� $��tips_for_login��$��登  录��$��Stretch=�$��Stretch=�$��Center=�$��Center=�$��24(�
����������� $L	 F/Lm.Eic.App.Mes.Resources.Image;Component/ImageList/未标题-1_03.gif��   $ Click��.    �� *PasswordKeyCommand+ �� $ txb_Password��  $ 
MouseEnter��.    �� *Login_MouseEnter+ �� $ 	btn_login��  $ 
MouseLeave��.    �� *Login_MouseLeave+ �� $ 	btn_login���� $��Center=�$��28��$��
29,83,29,0q�$��1��$��2��$	��Top=�$	��320��$��14(�$��Center=�$��Center=�
���  ������ *	TipInfo+