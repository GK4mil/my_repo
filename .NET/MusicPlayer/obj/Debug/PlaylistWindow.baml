   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.PlaylistWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � Title$  PlaylistWindow��5   	   $��501.05��6     � WindowStartupLocation$ Manual=�6/   $��320.93��6N   .��5	      � .+�5
   
   �� -   5        $��PlayList��5
   (   $��10,10,10,33q�6    � 	Resources 5       �� 
TargetType �� Property �� Value��%T   '��       �� 5      " ��6   .�5      ��  � ��$
 Left=�6C   5      5       �� View 5      �� 5      .P�5      �� $
��Name��6&    �� Width$	 410��64    �� DisplayMemberBinding 6@   �� *Name+�� 5      $
��Time��6%   $ 60��63    6>   �� *Time+5      5      �� 5   
   -   5        $��removebutton��5   *   $��Remove from PL��6   $��0,0,10,8q�6>   $��20��6P   $��Bottom=�6\   $��Right=�6w   $	��102��6�   6�   �� 5   
   -   5        $��TrackUp_button��5      $	��↑��6   $
��Left=�63   $��
10,257,0,0q�6N   $	��Top=�6b   $��20��6z   $��20��6�   �� 5   
   -   5        $��TrackDown_button��5      $	��↓��6   $
��Left=�66   $��
35,257,0,0q�6Q   $	��Top=�6e   $��20��6}   $��20��6�   5      5      