   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	   -   5          � Title$  MusicPlayerGawek��5   	   $	��178��6"   $��584.5��6/    � 
ResizeMode$ CanMinimize=�6=   $	��Top=�6V    � WindowStartupLocation$ CenterScreen=�6n   .��5	      � $��0,0,2,0q�6    � ColumnDefinitions 5
   
   �� 5      .+�5   
   �� -   5        $��StartButton��5       $
��Play��6   $
��Left=�63   $��	90,81,0,0q�6N   $��76��6a    J� RenderTransformOrigin$ 
-0.368,0.6&�6l   $��20��6�   $	��Top=�6�   �� 5   
   -   5        $��
StopButton��5       $
��Stop��6   $��
250,81,0,0q�62   $ 0.224,0.525&�6F   $
��Left=�6j   $��76��6�   $��20��6�   $	��Top=�6�   �� 5   
   -   5        $��PauseButton��5   !   $��Pause��6   $��
171,81,0,0q�64   $
��Left=�6H   $��74��6c   $��20��6n   $	��Top=�6z   6�   o� 5   
   $	��Top=�6   .@�5      m� $
��Plik��6   .@�5      m� -   5        $��open_button��5      $��Otwórz��6.   6>   m� 5      -   5        $��open_treeView��5      $��Otwórz w przeglądarce��60   6O   m� 5      -   5        $��openFromURL_button��5      $��Otwórz z URL��65   6K   �� 5      m� 5      -   5        $��close_button��5      $��Zamknij��6/   6@   5      m� 5      -	   5        $��playList_button��5      $��	Playlista��6.   6A   m� 5      $��Steruj��6   .@�5      m� -
   5        $��previous_button1��5      $��Previous��63   6E   m� 5      -   5        $��play_button1��5      $
��Play��6/   6=   m� 5      -   5        $��Pause_button1��5      $��Pause��60   6?   m� 5      -   5        $��Stop_button1��5      $
��Stop��6/   6=   m� 5      -   5        $��Next_button1��5      $
��Next��6/   6=   m� 5      -   5        $��Loop_button1��5      $��Loop OFF��6/   6A   5       m� 5!      -   5        $��	tagbutton��5!      $	��Tag��6(   65   5$      �� 5%   
   -   5        $��Next_button��5%       $
��Next��6   $
��Left=�63   $��
331,81,0,0q�6N   $��75��6b   $��20��6m   $	��Top=�6y   6�   �� 5&   
   -   5        $��Previous_button��5&   $   $��Previous��6   $
��Left=�6;   $��	10,81,0,0q�6V   $��75��6i   $��20��6t   $	��Top=�6�   6�   �� 5'   
   $��	0,106,0,0q�6   $ 	0.49,0.29&�6'   .@�5(      �� -   5        $��NameOfFileText��5(   .   $
��Wrap=�6   $��-��6D   �� 5)      -   5        $��Status_text��5)   5   $
��Wrap=�6   $��-��6,   65   �� 5*      -   5        $��	TimeBlock��5*   ,   $
��Wrap=�6   $��65��6=   $��-��6H   �� 5+      -   5        $��	SizeBlock��5+   =   $
��Wrap=�6   $��	TextBlock��6,   6=   5,      �� 5-   
   -   5        $��
LoopButton��5-   $   $��Loop OFF��6   $
��Left=�66   $��
411,81,0,0q�6Q   $	��Top=�6e   $��75��6}   6�   �� 5.   
   -   5        $��Shuffle_button��5.   =   $��Button��6   $
��Left=�6"   $��
491,81,0,0q�6S   $	��Top=�6g   $��75��6   6�   �� 5/   
   -   5        $��
SeekSlider��5/   z   $
��Left=�6_   $��	10,45,0,0q�6�   $	��Top=�6�   $	��556��6�   50      51      