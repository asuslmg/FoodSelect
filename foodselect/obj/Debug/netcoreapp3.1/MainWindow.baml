   M S B A M L   `   `   `  ����  
foodselect!    FoodSelectionApp.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  今天吃点啥呢？��5   	   $	��600��6   $	��800��6&    � Icon$3 -/680702-le-brunch-des-jardins-du-faubourg.jpg��62   ��5      �� 5   
    �� ImageSource$3 -/680702-le-brunch-des-jardins-du-faubourg.jpg��6    �� Opacity$	 0.8Q�6Q    � 	Resources 5         BlueButtonStyle �� 
TargetType �� Property �� Value  GreenButtonStyle��%�   &	        &	 J     �� 5	   
   " ��6(   .�5
      ��  � ��
 ��·�6+   5      �� 5   
   " ��6)   .�5      ��  � ��
 � � �6+   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   	 �� Orientation$	 
Horizontal=�6"   $��Center=�6;   $
��0,10q�6X   $	��460��6f   .+�5      �� -   5        
 ��Name$
 reloadButton��5      $��更新列表��6+   $��5q�6V   $��90��6a   $��48��6l   $��20(�6x   #��[ 6�   $
��Bold"�6�   �� 5      -   5        $
 selectButton��5      $��随机选择��6+   $
��Bold"�6O   $��90��6a   $��48��6l   $��20(�6x   #��[  6�   $��Stretch=�6�   $��Stretch=�6�   $��	265,0,0,0q�6�   5      � 5   
   $��1��6   $��0,0,0,10q�6   $��2��6.    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5       .+�5#      �� -   5         ��Name$ foodListBox��5#      $��0��6+   $��Center=�6;   $��Center=�6_    J� Opacity$ 1Q�6�   
�������$��0q�5$   .   $��30(�6B   $��10,10,10,-9q�6P   $	��400��6e   ���	#FF23FF006q   �� 5&      -   5         ��Name$ resultTextBlock��5&      $��1��61   $
��Left=�6A   $	��Top=�6\   $��40(�5'      $
��Bold"�6&   $y�Visible=�68   ���	#FF23FF00$��129,339,0,0q�6d   �� 5)      -   5        $ countdownTextBlock��5)      $��2��64   $��Center=�6D   $	��Top=�6a   $��40(�5*      $
��Bold"�6&   ���	#FF23FF0068   5+      �� 5-   
   $��2��6   $	 
Horizontal=�6"   $��Right=�6;   $��Center=�6W   $��10q�6r   $	��350��6~   .+�5.      �� -   5         ��Name$ 	timeLabel��5.      $��24(�6'   �� 5/      -   5        $ 	dateLabel��5/      $��16(�6'   $��10,0,0,0q�65   50      51      52      