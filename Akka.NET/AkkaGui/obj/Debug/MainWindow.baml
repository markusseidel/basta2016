   M S B A M L   `   `   `  ����B  >AkkaGui, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:AkkaGuiAkkaGui  5   	       AkkaGui.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:AkkaGui     5   	   J FPixelLab.Common, Version=6.0.1.0, Culture=neutral, PublicKeyToken=nullAlib7http://schemas.thinkpixellab.com/2011/xaml/presentation  5   	   -   5          � Title$  
MainWindow��5	   	   $	��600��6   $	��800��6)    � 	Resources 5       �� 
TargetType �� Property �� Value*  $PixelLab.Common.RoundDoubleConverter   RoundDoubleConverter �� DataType��%_  '��       &	  G     '�� Z     (�� �     5      *,��+)�� 5   
   " ��6   .�5      ��  � ��$ 5q�6'   5        5   
   6#   �� 5   
   " ��6   .�5      ��  � ��$ 1q�6'   �� 5       �@��TextAlignment$ Right=�6.   5      �� 5   
   " ��6   .R�5      �� $��5q�6)   ��6   �� 6)   5      5      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $
��Auto �6   .+�5!   
   ]� .+�5#      �� .+�5$      ��  �� Orientation$ 
Horizontal=�6   .+�5%      �� -   5        $��itemCountTb��5%   >   $��80��6   $��20��6)   $��4��65   $��Center=�6Q   $��Center=�5&      �� 5'      -   5        $	��Add��5'      $��5q�6B    �� 	IsDefault . 6M   �� 5(      $��
Item _Size��6I   $��0��6^   	 �� Target	 6   �� 
 �� ElementName$
 m_textBoxSize��6^   �� 5)      -   5        $��_sliderSize��5*   <    � Minimum$ 10Q�5)       � Maximum$	 400Q�6*   $	��150��68   $��Center=�6D   $��5q�6_    � SmallChange$ 25Q�5*       � LargeChange$	 100Q�6*    � Value$ 30Q�5+      �� 5,      -   5        $��	StartNext��5,      $��	StartNext��6.   $��5q�6C   6N   �� 5-      -   5        $��StopCurrent��5-      $��StopCurrent��60   $��5q�6G   6R   �� 5.      -   5        $��Reset��5.      $��Reset��6*   $��5q�6;   6F   52      9� 53      .��54      �� .+�55      �� $ 
Horizontal=�6%   .+�56      �� -   5        $��
StartTask1��56   %   $��Process Serial��67   $��5q�6P   6[   �� 57      -	   5        $��
StartTask2��57   %   $��Process Parallel.Foreach��67   $��5q�6Z   6e   �� 59      -
   5        $��
StartTask4��59   %   $��Process Actor��67   $��5q�6O   6Z   �� 5:      -   5        $��
StartTask5��5:   %   $��Use Actor Pool��67   $��5q�6P   6[   �� 5<      -   5        $��
poolSizeTb��5<   F   $��50��6&   $��20��61   $��1��6=   $��Center=�6X   $��Center=�5=      �� 5>      -   5        $��
StartTask6��5>   <   $y�	Collapsed=�6%   $��Run Pool��6N   $��5q�6a   6l   �� 5?      -   5        $��StopProcessing��5?   %   $��Stop Processing��6;   $��20 5 5 5q�6V   6h   5@      �� 5B      $ 
Horizontal=�6%   $y�	Collapsed=�6>   .+�5C      �� -   5        $��failCbx��5C   '   $��Center=�66   $��5q�6S   �� 5D      $��Be ready to Fail��6%   $��0��6@   5F      5G      5I      �� 5K      -   5        $��m_itemsControl��5K      |�.      AkkaGui.AnimatingTilePanel   
ItemHeight 5L      �� $
 _sliderSize�� �� Path$ Value�   	ItemWidth 5M      �� $
 _sliderSize��$ Value���5N      �� 5O      .R�5P        5Q      5S      5T      5U      �� 5X   
   $ 
Horizontal=�6   $��1��6.   .+�5Y      �� $��Actor Count: ��6   $��5q�6,   �� 5Z      -   5        $��actorCountLbl��5Z      $��0��6)   $��5q�65   5\      5_      5`      