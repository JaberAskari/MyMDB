   M S B A M L   `   `   `  ����>  :MDB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:MDB.ViewMDB.View  5          MDB.View.AddMovie   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      "localclr-namespace:MDB.View  5        N� Title$  AddMovie��5
      .��5      � -   5         �Name$ grdMain��5      $	��750��6   $	��950��6)   $��0q�65   
�������.+�5   
   � $��Right=�6   $	��300��6+   $	��750��67   .+�5      �� -   5         ��Name$ 	imgPoster��5      $
��Left=�6'   $	��330��6B   $��35 10q�6O   $	��Top=�6^   $	��230��6v   $��../photos/movie.png��6�   �� 5      -   5         ��Name$ txtNameM��5      $��45��6*   $��5q�66    �� Padding$ 5q�6A   $��Title : ��6M   $��14(�6]   $
��Bold"�6k   $
��Wrap=�6}   �� 5      $
��Auto=�6   $	��350��6>   $�� 0 0 0 0q�6K   $��Bottom=�6]   .��5      �� -   5        $ txtDescription��5      $��Description��64   $��14(�6G   $ 20 20 20 20q�6U   $
��auto��6k   $��10 10 10 30q�6y   $��WrapWithOverflow=�6�   $��Stretch=�6�   5      5      � 5   
   $
��Left=�6   $	��Top=�6*   $
��650 ��6B   $	��750��6O   ���	#FFBCCBD6$��0 0 0 0q�6s   $��2��6�   .+�5      ��  �� Orientation$ Vertical=�6   $	��Top=�60   $��	10 30 0 0q�6H   .+�5      �� $A��;Search the movie name that you want to add to your database��6   $��WrapWithOverflow=�6_   $��14(�6   $	��300��6�   $
��Left=�6�   ���	#FF404040$��45 0 0 0q�6�   �� 5      $ 
Horizontal=�6   $��Center=�66   .+�5      �� -   5         ��Name$ 
txbKeyword��5      $	��300��64   $��30��6@   $��5q�6L   $
��20 0q�6X   6f   �� 5       -   5         ��Name$ 	btnSearch��5          MyButton#��[  60   $��30��6R   $	��200��6^   $��Center=�6j   $
��20 0q�6�   ���	#FF226A96
�������.��5!      �� $ 
Horizontal=�6%   $��Center=�6>   $��Center=�6Y   .+�5"      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]   Kind$ Search=�66   $��30��6D   $��30��6P   $
��Left=�6[   6y   �� 5#      $��Search��6(   $��16(�66   $
��Bold"�6D   $ 0q�6V   $��3q�6b   5$      5%      5&      �� 5(      $`��ZSelect the movie from result list and click on Add button to add it to your movie databse.��6   $��WrapWithOverflow=�6~   $��14(�6�   $	��300��6�   $
��Left=�6�   ���	#FF404040$��	45 20 0 0q�6�   �� 5)      $ 
Horizontal=�6   $��Center=�66   .+�5+      �� -   5        $ txtSelectedMovie��5+       $	��300��6<   $��30��6H   $ 5q�6T   $��	20 0 20 0q�6`   
�������6s   �� 5-      -   5        $ btnAdd��5-      #��[  6-   $��30��6O   $	��200��6[   $��Center=�6g   $
��20 0q�6�   ���	#FF226A96
�������.��5.      �� $ 
Horizontal=�6%   $��Center=�6>   $��Center=�6Y   .+�5/        $	 Add=�66   $��30��6A   $��30��6M   $
��Left=�6X   6v   �� 50      $��Add to My Movies��6(   $��16(�6@   $
��Bold"�6N   $ 0q�6`   $��3q�6l   51      52      53      �� 55      -	   5        $ 
txtMessage��55      $��Search Results: ��60   $��30��6H   $��14(�6T   $
 25 5q�6b   $��0 35 0 0q�6q   57      &   System.Windows.Controls.DataGrid  5=      -
   5        	  Name$	 dgMovies��5=      $��
0 250 0 80q�6A   $
��Auto��6U   
   
IsReadOnly
 . ��6)   �� 6�   �� 5@      $ 
Horizontal=�6   $��Bottom=�62   $��80��6N   $��Center=�6Z   .+�5B      �� -   5        $ btnPrevious��5B      #��[  6.   ���	#FF226A96���	#FFBCCBD6{�.  $��30��6�   $��30��6�   .��5C        $ ArrowLeftBoldBoxOutline=�6.   $��30��6M   $��30��6Y   6f   5D      �� 5F      -   5        $ txtPageNumLast��5F      $��0��64   $��12(�6=   $��Center=�6L   ���	#FF226A96$��10 0 0 0q�6~   $y�Hidden=�6�   �� 5G      -   5        $ txtPageNumCur��5G      $��1��63   $��16(�6<   $
��Bold"�6J   $��Center=�6\   ���	#FF226A96$
��10 0q�6�   �� 5H      -   5        $ txtPageNumNext��5H      $��2��64   $��12(�6=   $��Center=�6L   ���	#FF226A96$
��0 0 q�6~   �� 5I      -   5        $ txtPageNumMax��5I      $��14(�64   $��Center=�6C   ���	#FF226A96$��10 0 q�6u   �� 5L      -   5        $ btnNext��5L      #��[  6*   ���	#FF226A96���	#FFBCCBD6$��30��6z   $��30��6�   .��5M        $ ArrowRightBoldBoxOutline=�6.   $��30��6N   $��30��6Z   6g   5N      5O      5Q      5R      5S      