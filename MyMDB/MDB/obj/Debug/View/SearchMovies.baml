   M S B A M L   `   `   `  ����>  :MDB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:MDB.ViewMDB.View  5          MDB.View.SearchMovies   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
   "localclr-namespace:MDB.View  5        N� Title$  SearchMovies��5
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
��650 ��6B   $	��750��6O   ���	#FFBCCBD6$��0 0 0 0q�6s   $��2��6�   .+�5      ��  �� Orientation$ 
Horizontal=�6   $	��Top=�62   $��20 50q�6J   .+�5      �� -   5         ��Name$ cbxGenre��5      $	��120��6-   $��30��69   $��5 0 20 0q�6E   $��5q�6W   6|   �� 5      -   5        $ cbxYear��5      $	��120��6,   $��30��68   $
��20 0q�6D   $��5q�6R   6v   �� 5       -   5         ��Name$ 
txbKeyword��5       $	��120��60   $��30��6<   $��5q�6H   $
��20 0q�6T   6b   �� 5"      -   5         ��Name$ 	btnSearch��5"         MyButton#��[  6,   $��30��6N   $	��120��6Z   $��Center=�6f   $
��20 0q�6�   ���	#FF226A96
�������.��5#      �� $ 
Horizontal=�6!   $��Center=�6:   $��Center=�6U   .+�5$      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]	   Kind$	 Search=�62   $��30��6@   $��30��6L   $
��Left=�6W   6u   �� 5%      $��Search��6$   $��16(�62   $
��Bold"�6@   $ 0q�6R   $��3q�6^   5&      5'      5(      �� 5+      $ 
Horizontal=�6   $	��Top=�62   $��21 25q�6J   .+�5,      �� $��Genre��6   $��14(�6(   ���	#FF404040$��0q�6M   �� 5-      $
��year��6   $��14(�6'   ���	#FF404040$��	115 0 0 0q�6L   �� 5.      $��
Search Key��6   $��14(�6-   ���	#FF404040$��	125 0 0 0q�6R   5/      �� 51      $	��Top=�6   $��0 110q�61   .+�52      �� -	   5        $ 
txtMessage��52      $��Search Results: ��60   $��30��6H   $	��650��6T   $��14(�6`   $
 25 5q�6n   53      &   System.Windows.Controls.DataGrid  56      -
   5        
  Name$
 dgMovies��56      $��
0 140 0 80q�6A   $
��Auto��6U      
IsReadOnly . ��6)   �� 6�   �� 59      $ 
Horizontal=�6   $��Bottom=�62   $��80��6N   $��Center=�6Z   .+�5;      �� -   5        $ btnPrevious��5;      #��[  6.   ���	#FF226A96���	#FFBCCBD6{�.  $��30��6�   $��30��6�   .��5<        $	 ArrowLeftBoldBoxOutline=�6.   $��30��6M   $��30��6Y   6f   5=      �� 5?      -   5        $ txtPageNumLast��5?      $��0��64   $��12(�6=   $��Center=�6L   ���	#FF226A96$��10 0 0 0q�6~   $y�Hidden=�6�   �� 5@      -   5        $ txtPageNumCur��5@      $��1��63   $��16(�6<   $
��Bold"�6J   $��Center=�6\   ���	#FF226A96$
��10 0q�6�   �� 5A      -   5        $ txtPageNumNext��5A      $��2��64   $��12(�6=   $��Center=�6L   ���	#FF226A96$
��0 0 q�6~   �� 5B      -   5        $ txtPageNumMax��5B      $��14(�64   $��Center=�6C   ���	#FF226A96$��10 0 q�6u   �� 5E      -   5        $ btnNext��5E      #��[  6*   ���	#FF226A96���	#FFBCCBD6$��30��6z   $��30��6�   .��5F        $	 ArrowRightBoldBoxOutline=�6.   $��30��6N   $��30��6Z   6g   5G      5H      5J      5K      5L      