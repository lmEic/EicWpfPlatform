   M S B A M L   `   `   `  ����  Lm.Eic.App.Mes.Window     Lm.Eic.App.Mes.Window.Land   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   
     � Title$  	MaiWindow��5   	   $	��350��6   $	��400��6(   ���	#00000000 � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�6    � AllowsTransparency . $��1q�6L    � WindowStartupLocation$ CenterScreen=�6`   .��5      � ���	#a1C6C6C6 J� Opacity$ 1Q�6"    � RowDefinitions 5   
   �� 5	      $
��360* �6   .+�5   
   �� }�. $��10q�6%   $��0��61   $��0��6>   
���   �$��0q�6b    �� CornerRadius$ 0 0 7 7��6v   ._�5      � $��0��6   $��0��6    $��0q�60    5      �� 5      $��43 �6$   �� 5      $
��200* �6$   .+�5      � $��Stretch=�6   $��Stretch=�65   $��0��6Q   $��0��6^    � ColumnDefinitions 5      �� 5      $	��322 �6+   �� 5      $��32 �6+   ��5      �� 5      	 �� ImageSource$C	 =/Lm.Eic.App.Mes.Resources;Component/Images/login_title_bg.png��6%   6s   .+�5      �� -   5        
 ��Name$
 	lab_Title��5       $�� Welcome to MES��64    �� Padding$ 20 0 0 0q�6L   $��24(�6_   
�������$
��Left=�6�   $��Center=�6�   �� 5      -   5        $��	btn_close��5   �   $��0��6   $��1��6*   $��25��6:   $��25��6E   $��Center=�6Q   $��Center=�6n   ��5      �� 5      .R�5   "   �� $��
tips_close��6)   
�������$��18(�5    <   $��Center=�6J   $��Center=�6n    � Cursor$
 Hand��6�   ��5!   &   �� 5"   *   $;	 5/Lm.Eic.App.Mes.Resources;Component/Images/cancel.png��65   6{   .  (System.Windows.Interactivity.Interaction   Triggers 5%   &   /  )System.Windows.Interactivity.EventTrigger  5&   *      	EventName$ 
MouseEnter��69   .  (System.Windows.Interactivity.TriggerBase   Actions. 5'   .   6  0System.Windows.Interactivity.InvokeCommandAction     Command 6D   �� *Close_MouseEnter+   CommandParameter 6i   ��  �� ElementName$ 
tips_close��5(   +     5)   *   $ 
MouseLeave��69   . 5*   .      6D   �� *Close_MouseLeave+ 6i   �� $ 
tips_close��5+   +   5-   #   5.       51        52      $ Click��6-   . 53   "      68   �� *Close+54      56      57      � 59      $��Stretch=�6   $��1��65   $��0��6B   $��Stretch=�6R   ���	#FFededed 5:      �� 5;      $	��60* �6(   �� 5<      $	��60* �6(   �� 5=      $	��60* �6(   .+�5?      �� $��0��6   $��0��6)   $	��334��69   $��50��6E   ��5@      �� 5A      $B	 </Lm.Eic.App.Mes.Resources;Component/Images/UIDA登录_03.gif��6)   6r   .��5C      �� -   5         ��Name$ 
txb_UserID��5C   @   $��45 0 0 0q�6T   $	��280��6f   $��50��6r   $��20 0 0 0q�6~   $��Stretch=�6�   $��Center=�6�   $
��Left=�6�   $��24(�6�   $��Center=�6�   $��0q�65   � ToolTip$ 	用户名��6I  ��6#   �� *User.JobNum+��6  Z� .��6W   J� InputBindings 5D      �� 5E   "   
 �� Key$ Enter��6-    �� Command 6:   �� *UserKeyCommand+ �� CommandParameter 5F   $   �� $ txb_Password��.��5G   5   5H      5I      �� 5J      $��1��6   $��0��6)   $	��334��69   $��50��6E   ��5K      �� 5L      $B	 </Lm.Eic.App.Mes.Resources;Component/Images/UIDA登录_06.gif��6)   6r   .��5N      G� -   5         G�Name$ txb_Password��5N   '   $��45 0 0 0q�6=   $	��280��6O   $��50��6[   $��20 0 0 0q�6g   $��Stretch=�6{   $��Center=�6�   $
��Left=�6�   $��24(�6�   $��Center=�6�   $��0q�6  $ 密码��62  ��6  Z�  5O      �� 5P   "   $ Enter��6-    69   �� *PasswordKeyCommand+ 5Q   $   �� $ txb_Password��5S      5T      �� 5V      -   5        $��	btn_login��5V   +   $
 Hand��6   $ 1Q�6<   $��0��6H   $��2��6X   ���	#FF7C7C03$��50��6~   $	��320��6�   ��5W      �� 5X       �� 
TargetType" ��6.   .R�5Y   "   �� }�. $ 5��6>   ._�5Z   &   �� $��tips_for_login��6,   $��登  录��6B   $��Stretch=�6Q   $��Stretch=�6o   $��Center=�6�   $��Center=�6�   $��24(�6�   
���������5[   *   �� 5\   .   $C	 =/Lm.Eic.App.Mes.Resources;Component/Images/未标题-1_03.gif��69   6�   5^   '   5_   #   5`       5c        5d      $ Click��6-   . 5e   "      68   �� *PasswordKeyCommand+ 6_   �� $ txb_Password��5f        5g      $ 
MouseEnter��6-   . 5h   "      68   �� *Login_MouseEnter+ 6]   �� $ 	btn_login��5i        5j      $ 
MouseLeave��6-   . 5k   "      68   �� *Login_MouseLeave+ 6]   �� $ 	btn_login��5l      5n      �� 5o      $��Center=�68   $��28��6U   $��
29,83,29,0q�6a   $��1��6u   $��2��6�   $	��Top=�6�   $	��320��6�   $��14(�6�   $��Center=�6�   $��Center=�6�   
���  ����6   �� *	TipInfo+6  5p      5q      5r      5s      5t      