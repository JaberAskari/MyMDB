   M S B A M L   `   `   `  ����>  :MDB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:MDB.ViewMDB.View  5          MDB.View.Login   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:MDB.View     5      V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  Login��5
      .��5      � -   5         �Name$ grdMain��5      $	��750��6   $	��950��6)   $��0q�65   .+�5   
   � $��
50 20 50 0q�6    � RowDefinitions 5      �� 5      $��2* �6    �� 5      $��1* �6    �� 5      $��1* �6    �� 5      $��1* �6    �� 5      $��1* �6    �� 5      $��1* �6    .+�5      �� -   5         ��Name$ 
txtwelcome��5      $��Welcome��6,   $��WrapWithOverflow=�6;   $��20(�6[   $
��bold"�6i   ���	#FF226A96$��0��6�   $��0��6�   $��Center=�6�   $��Center=�6�   $��0 0 0 0q�6�   �� 5      $.��(Please insert your username and password��6   $	��300��6H   $��WrapWithOverflow=�6W   $��16(�6w   $
��bold"�6�   ���	#FF226A96$��0��6�   $��0��6�   $
��Left=�6�   $��Center=�6�   $��280 120 0 0q�6  �� 5      $��Email: ��6   $��15(�6'   ���	#FF226A96$��1��6L   $��0��6Y   $
��Left=�6i   $��	280 0 0 0q�6�   �� 5      -   5         ��Name$ txbEmail��5      $�� ��6(   $��15(�60   $��0��6>   $��1��6N   $��5 5 5 5q�6[   $��Center=�6m   $��Center=�6�   ���	#FF226A96$��35��6�   $	��300��6�   ���	#FFCCDFE66�   �� 5"      $��
Password: ��6   $��15(�6*   ���	#FF226A96$��2��6O   $��0��6\   $
��Left=�6l   $��	280 0 0 0q�6�   G� 5#      -   5         G�Name$ txbPassword��5#      $��15(�60   $��0��6>   $��2��6N   $��15 5 5 5q�6\   $��Center=�6o   $��Center=�6�   ���	#FF226A96$��35��6�   $	��300��6�   ���	#FFCCDFE66�   �� 5&      -   5         ��Name$ 	btnSignIn��5&         MyButton#��[  6(   $��0��6J   $��3��6Z   $��35��6g   $	��300��6s   $��Center=�6   $��0 0 0 0q�6�   ���	#FF226A96
�������.��5'      ��  �� Orientation$ 
Horizontal=�6   $��Center=�66   $��Center=�6Q   .+�5(      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]   Kind$ Login=�6.   $��30��6;   $��30��6G   $
��Left=�6R   6p   �� 5)      $��SIGN IN��6    $��16(�6/   $
��Bold"�6=   	 �� Padding$	 5q�6O   $��5 0 0 0q�6[   5*      5+      �� 5.      $H��BYou do not have an account! Click on Sign Up button to create one.��6   $	��300��6b   $��WrapWithOverflow=�6q   $��16(�6�   $
��Bold"�6�   ���	#FF226A96$��0��6�   $��4��6�   $
��Left=�6�   $	��Top=�6   $��	280 5 0 0q�6  �� 5/      -   5        $ 	btnSignUp��5/      #��[  6(   $��0��6J   $��4��6Z   $��35��6g   $	��300��6s   $��Bottom=�6   $��0 0 0 0q�6�   ���	#FF226A96
�������.��50      �� $ 
Horizontal=�6   $��Center=�66   $��Center=�6Q   .+�51        $ Create=�6.   $��30��6<   $��30��6H   $
��Left=�6S   6q   �� 52      $��SIGN UP��6    $��16(�6/   $
��Bold"�6=   $	 5q�6O   $��5 0 0 0q�6[   53      54      � 57      $��0��6   $��10 0 0 0q�6!   $	��Top=�63   .+�58      �� ���	#FF3FA556$	 0q�63   $
��Left=�6?   $��	280 0 0 0q�6Z     59      $ Tv=�6.   $��80��68   $	��100��6D   6R   5:      �� 5;      $��MyMDB��6   $
��Left=�6*   $	 0q�6F   $��	375 0 0 0q�6R   $	��170��6e   $
��auto��6q   $
��Bold"�6   ���	#FF3FA556$��Center=�5<   1   $��40(�6M   $��Stencil)�6[   5=      �� 5?      -   5        $ 
txtMessage��5?      $��5��6=   
���  ��$��15(�6[   $��Center=�6i   $��Center=�6�   ��6,   �� 6�   5A      5D      5E      