   M S B A M L   `   `   `  ����O  KIPCameraWriteMacWiFi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:IPCameraWriteMacWiFi.ViewsIPCameraWriteMacWiFi.Views  5      +    %IPCameraWriteMacWiFi.Views.RunAllView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:IPCameraWriteMacWiFi.Views     5      
�������  � 	Resources  5
      4   .IPCameraWriteMacWiFi.Views.BrushColorConverter   
BConverter��%   &	          5   
   69   5      .��5      � .+�5   
   �� $��0,0,5,0q�6    �� TabStripPlacement$ Bottom=�6&     5       �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius ��Name �� Triggers	 P� Property
 P� Value �� 
TargetName  label_log_header��%�  '��       '�� J     &	 |    �� 5      " ��6   .�5      ��  � ��$
 Left=�6<   5      �� 5      " ��6   .�5      ��  � �� 5      �� 5      " ��6.   .R�5   "   � .+�5   &   �� $��Border��6-   $��0,0,-4,0q�6;   $��1,1,1,1q�6M   $ 2,12,0,0��6g   ._�5   *   �� $ ContentSite��6;   $��Center=�6P   $��Center=�6k   $��Header��6�   $��	12,2,12,2q�6�   ��. 6�   5   '   5   #    5    "   P� 5!   &   	 �@��
IsSelected
 . . �5"   *   ��  �@K�ZIndex$	 100��6I   �� 5#   *   $ Border��61    � �� �#43d8546[   �� 5$   *   $ Border��61    � ��$ 1,1,1,0q�6`   5%   '   P� 5&   &   	 �@��
IsSelected
 .  . �5'   *   �� $ Border��61    � �� �#FFFFFF6[   5(   '   P� 5)   &   	 �@J�IsMouseOver
 . . �5*   *   �� $ Border��61    � ��
 � ���6[   5+   '   5-      5/      50      �� 52      " ��6   .�53      ��  � ��$ 15(�61   54      56      .@�58      �� ��59      �� 5:      #��[ 6   $��Log Item��6F   .��5=      �  � ColumnDefinitions 5>      �� 5?      $��* �6+   �� 5@      $	��215 �6+   .+�5C      �� $��0,0,5,0q�6!   .+�5D      �� ��6!   �� *StartCommand+��6B   ��  �� Path$ RAM.buttonContent���5E      �� 5F   "   " ��6(   .�5G   &   ��  � ��$ 0,10,0,0q�6?   �� 5H   &    � ��$	 150��6>   �� 5I   &    � ��$ 40��6?   �� 5J   &    � ��$
 Left=�6L   �� 5K   &    � ��$ 20(�6A   �� 5L   &    � ��$ SemiBold"�6C   �� 5M   &    � {� .  6B    �� Triggers 5N   &   �� 5O   *    �� Binding 66   �� $ RAM.buttonContent� �� Value	 Start6a   .a�5P   .   ��  � {� . 6J   5Q   +   5S   #   5U      �� 5V      $��SemiBold"�6    $��20(�66   ��6D   �� $ RAM.instructionText� �� 	Converter# [  ��6�   �� $ RAM.instructionText�5X      &   System.Windows.Controls.DataGrid  5Z         AutoGenerateColumns .  
�������   CanUserAddRows .     CanUserDeleteRows .     CanUserResizeColumns .     CanUserResizeRows .     CanUserSortColumns .     CanUserReorderColumns .  "   VerticalScrollBarVisibility$
 Auto=�5]   �   $   HorizontalScrollBarVisibility$
 Auto=�6�      GridLinesVisibility$
 None=�5^         HeadersVisibility$ Column=�5_      $��0,0,0,0q�5`         SelectionUnit$ FullRow=�5a         SelectionMode$ Extended=�67   ��5Z   ?   �� *collectionResult+   	CellStyle 5c      �� 5d   "   *  $System.Windows.Controls.DataGridCell"  6(   .�5e   &   ��  � ��$ 0,0,1,1q�6H   �� 5f   &    � �� �	#FFB3B3B36D   �� 5g   &    � ��$ 13(�6A   �� 5h   &    � ��$ Normal"�6C   �� 5i   &    � ��$ 22��6?   �� 5j   &    � ��$ Center=�6Q   5k   #       ColumnHeaderStyle  5n      �� 5o   "   =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6(   .�5p   &   ��  � ��$ 13(�6A   �� 5q   &    � ��$ 40��6?   �� 5r   &    � ��$
 Bold"�6C   �� 5s   &    � �� �	#FFB3B3B36D   �� 5t   &    � ��$ 0,0,0,1q�6H   �� 5u   &    � ��$ 3,0,0,0q�6@   5v   #   !   Columns! 5y      0  *System.Windows.Controls.DataGridTextColumn  5z   "   ,  &System.Windows.Controls.DataGridColumn"   Header$ " Các bước thực hiện��65   #   Width5  /System.Windows.Controls.DataGridLengthConverter$
# 1.7* 6j   1  +System.Windows.Controls.DataGridBoundColumn$   Binding$ 6Q   �� *Name+6j     5{   "   $" 
Giá trị��65   $
# 2.5* 6`   $ 6F   �� *Value+6`     5|   "   $" Trạng thái��65   $
# 0.9* 6d   %   
FontWeight$% SemiBold"�6q   $ 6I   �� *Result+&   	CellStyle& 5}   &   �� 5~   *   "  60   .�5   .   ��  � ��$ 0,0,1,1q�6P   �� 5�   .    � �� �	#FFB3B3B36L   �� 5�   .    � ��$ 15(�6I   �� 5�   .    � ��$ Normal"�6K   �� 5�   .    � ��$ 22��6G   �� 5�   .    � ��$ Center=�6Y   �� 5�   .    � ��
 �   �6K    5�   .   �� 5�   2    6>   �� $ Result� 
Waiting...6^   .a�5�   6   ��  � ��
 � ���6S   5�   3   �� 5�   2    6>   �� $ Result�
 Passed6^   .a�5�   6   ��  � ��
 � � �6S   5�   3   �� 5�   2    6>   �� $ Result�
 Failed6^   .a�5�   6   ��  � ��
 �  ��6S   5�   3   5�   +   5�   #     5�   "   $" Thời gian(ms)��65   $# * 6j   $ 6L   �� *	totalTime+6j   '   RowStyle' 5�      �� 5�   "   )	  #System.Windows.Controls.DataGridRow" 	 6(   .�5�   &   ��  � ��
 �   �6C    5�   &   �� 5�   *    66   �� *Result+
 Failed6Q   .a�5�   .   ��  � ��
 �  ��6K   5�   +   5�   #   5�      � 5�      .+�5�      �� $��15(�6$   $��Total time:��62   �� 5�      $��15(�6$   ��62   �� $ RAM.totalTime�5�      �� 5�      $��0,-5,0,0q�6    $��15(�62   $��Total result:��6@   �� 5�      ��6    �� $ RAM.totalResult���5�      �� 5�   "   " ��6(   .�5�   &   ��  � ��$ 	0,-10,0,0q�6?   �� 5�   &    � ��$ 35(�6A   �� 5�   &    � ��$ SemiBold"�6C    5�   &   �� 5�   *    66   �� $ RAM.totalResult� 
Waiting...6_   .a�5�   .   ��  � ��
 � ���6K   5�   +   �� 5�   *    66   �� $ RAM.totalResult�
 Passed6_   .a�5�   .   ��  � ��
 � � �6K   5�   +   �� 5�   *    66   �� $ RAM.totalResult�
 Failed6_   .a�5�   .   ��  � ��
 �  ��6K   5�   +   5�   #   5�      � 5�      $��	0,-10,0,0q�6$   .+�5�      �� $��15(�6$   $
��UID:��62   �� 5�      $��15(�6$   $��SemiBold"�62   ��6H   �� $ RAM.UID�5�      � 5�      $��	0,-10,0,0q�6$   .+�5�      �� $��15(�6$   $��	Mac WiFi:��62   �� 5�      $��15(�6$   $��SemiBold"�62   ��6H   �� $ RAM.macAddress�5�      5�      �� 5�        color_border#��[ 6   $��1,0,0,0q�6I   $��1��6c   ._�5�      � ( � RowDefinitions( 5�      �� 5�   "   $��* �60   �� 5�   "   $	��100 �60   .+�5�         .  
������� .   .   .   .   .   .  $
 Auto=�5�   �   $
 Auto=�6�   $
 None=�5�      $ Column=�5�      $��0,0,0,0q�5�      #��[ 5�      $ FullRow=�5�      $ Extended=�67   ��5�   C   �� *collectionMac+ 5�   "   �� 5�   &   "  6,   .�5�   *   ��  � ��$ 0,0,1,1q�6L   �� 5�   *    � �� �	#FFB3B3B36H   �� 5�   *    � ��$ 15(�6E   �� 5�   *    � ��$ Normal"�6G   �� 5�   *    � ��$ 22��6C   �� 5�   *    � ��$ Center=�6U   5�   '     5�   "   �� 5�   &   "  6,   .�5�   *   ��  � ��$ 15(�6E   �� 5�   *    � ��$ 40��6C   �� 5�   *    � ��$
 Bold"�6G   �� 5�   *    � �� �	#FFB3B3B36H   �� 5�   *    � ��$ 0,0,0,1q�6L   �� 5�   *    � ��$ 3,0,0,0q�6D   5�   '   ! 5�   "     5�   &   $" New Mac��69   $# * 6i   $ 6J   �� *
macAddress+6i     5�   &   $	" DEC��69   $# 80 6a   $ 6F   �� *macDEC+6a   ' 5�   "   �� 5�   &   " 	 6,   .�5�   *   ��  � ��
 �   �6G    5�   *   �� 5�   .    6:   �� *Result+
 Failed6U   .a�5�   2   ��  � ��
 �  ��6O   5�   /   5�   '   5�      �� 5      $��1��6)   .+�5  "   � .+�5  &   �� $��0,-5,0,0q�6,   $��15(�6>   $��Mac start : ��6L   �� 5  &   $��0,-5,0,0q�6,   $��15(�6>   ��6L   �� $ RAM.macStart�5  #   � 5  "   .+�5  &   �� $��0,-5,0,0q�6,   $��15(�6>   $��
Mac end : ��6M   �� 5  &   $��0,-5,0,0q�6,   $��15(�6>   ��6L   �� $ 
RAM.macEnd�5  #   � 5	  "   .+�5
  &   �� $��0,-5,0,0q�6,   $��15(�6>   $��
Current : ��6M   �� 5  &   $��0,-5,0,0q�6,   $��15(�6>   ��6L   �� $ RAM.macCurrent�5  #   � 5  "   .+�5  &   �� $��0,-5,0,0q�6,   $��15(�6>   $��	Remain : ��6M   �� 5  &   $��0,-5,0,0q�6,   $��15(�6>   ��6L   �� $ RAM.macRemain�5  #   5     5     5     5     5     �� 5     ��5     �� 5     #��[ 6   $��
Log System��6F   .��5!     � ( 5"     �� 5#     $��50 �6(   �� 5$     $��* �6(   .+�5'     � $��0,10,0,0q�6    .+�5(     �� $��15(�6    $��Nhập mã uid: ��6.   �� 5)     $��SemiBold"�6"   $��15(�68   $��Center=�6F   $
��Left=�6h   $��5,0,0,0q�6�   $	��250��6�   ��6�   �� $ RAM.systemUID��� 5*     $��15(�6L   $��SemiBold"�6Z   $��10,0,0,0q�6p   $	��100��6�   $��Search��6�   ��6!   �� *SearchLogSystemCommand+6�   5+     �� 5-     -   5        ) ��Name$) Scr_LogSystem��5-  0   $��1��6#   .��5.     �� $��13(�6'   $��Normal"�65   $��Stretch=�6I   $��Stretch=�6e   . �5/     /� .T�50  "   J� .*�6,   .*�51  &   �� �6*   �� $ RAM.logSystem�* �� UpdateSourceTrigger$* PropertyChanged=�+ �� Mode$+ TwoWay=�52  #   53     54     55     56     58     �� 5;     ��5<     �� 5=     #��[ 6   $��
Log Telnet��6F   .��5@     � ( 5A     �� 5B     $��50 �6(   �� 5C     $��* �6(   .+�5F     � $��0,10,0,0q�6    .+�5G     �� $��15(�6    $��Nhập mã uid: ��6.   �� 5H     $��SemiBold"�6"   $��15(�68   $��Center=�6F   $
��Left=�6h   $��5,0,0,0q�6�   $	��250��6�   ��6�   �� $ RAM.telnetUID��� 5I     $��15(�6L   $��SemiBold"�6Z   $��10,0,0,0q�6p   $	��100��6�   $��Search��6�   ��6!   �� *SearchLogTelnetCommand+6�   5J     �� 5L     -   5        $) Scr_LogTelnet��5L  0   $��1��6#   .��5M     �� $��13(�6'   $��Normal"�65   $��Stretch=�6I   $��Stretch=�6e   . �5N     /� .T�5O  "   J� .*�6,   .*�5P  &   �� �6*   �� $ RAM.logTelnet�$* PropertyChanged=�$+ TwoWay=�5Q  #   5R     5S     5T     5U     5W     �� 5Y     ��5Z     �� 5[     #��[ 6   $��Log Data��6F   .��5^     � ( 5_     �� 5`     $��50 �6(   �� 5a     $��* �6(   .+�5d     � $��0,10,0,0q�6    .+�5e     �� $��15(�6    $��Nhập mã uid: ��6.   �� 5f     $��SemiBold"�6"   $��15(�68   $��Center=�6F   $
��Left=�6h   $��5,0,0,0q�6�   $	��250��6�   ��6�   �� $ RAM.totalUID��� 5g     $��15(�6K   $��SemiBold"�6Y   $��10,0,0,0q�6o   $	��100��6�   $��Search��6�   ��6!   �� *SearchLogTotalCommand+6�   5h       5j     $��1��6    .  
������� .   .   .   .   .   .  $
 Auto=�5m  �   $
 Auto=�6�   $
 None=�5n     $ Column=�5o     $��0,0,0,0q�5p     $ FullRow=�5q     $ Extended=�67   ��5j  H   �� *collectionTotal+ 5s     �� 5t     "  6$   .�5u  "   ��  � ��$ 0,0,1,1q�6D   �� 5v  "    � �� �	#FFB3B3B36@   �� 5w  "    � ��$ 13(�6=   �� 5x  "    � ��$ Normal"�6?   �� 5y  "    � ��$ 22��6;   �� 5z  "    � ��$ Center=�6M   5{       5~     �� 5     "  6$   .�5�  "   ��  � ��$ 13(�6=   �� 5�  "    � ��$ 40��6;   �� 5�  "    � ��$
 Bold"�6?   �� 5�  "    � �� �	#FFB3B3B36@   �� 5�  "    � ��$ 0,0,0,1q�6D   �� 5�  "    � ��$ 3,0,0,0q�6<   5�     ! 5�       5�     $" ID��61   $
# Auto 6T   $ 6=   �� *ID+6T     5�     $	" UID��61   $
# Auto 6V   $ 6>   �� *UID+6V     5�     $	" Mac��61   $
# Auto 6V   $ 6>   �� *Mac+6V     5�     $" Login��61   $
# Auto 6Z   $ 6@   �� *Login+6Z     5�     $" GetFirmware��61   $
# Auto 6f   $ 6F   �� *GetFirmware+6f     5�     $" GetUID��61   $
# Auto 6\   $ 6A   �� *GetUID+6\     5�     $" GetMac��61   $
# Auto 6\   $ 6A   �� *GetMac+6\     5�     $" SetMac��61   $
# Auto 6\   $ 6A   �� *SetMac+6\     5�     $" 	VerifyMac��61   $
# Auto 6b   $ 6D   �� *	VerifyMac+6b     5�     $" 	TotalTime��61   $
# Auto 6b   $ 6D   �� *	TotalTime+6b     5�     $" TotalResult��61   $
# Auto 6f   $ 6F   �� *TotalResult+6f     5�     $" DateTimeCreated��61   $
# Auto 6n   $ 6J   �� *DateTimeCreated+6n   5�     5�     5�     �� 5�     ��5�     �� 5�     #��[ 6   $��Log Mac��6F   .��5�     � ( 5�     �� 5�     $��50 �6(   �� 5�     $��* �6(   .+�5�     � $��0,10,0,0q�6    .+�5�     �� $��15(�6    $��Nhập mã uid: ��6.   �� 5�     $��SemiBold"�6"   $��15(�68   $��Center=�6F   $
��Left=�6h   $��5,0,0,0q�6�   $	��250��6�   ��6�   �� $ 
RAM.macUID��� 5�     $��15(�6I   $��SemiBold"�6W   $��10,0,0,0q�6m   $	��100��6   $��Search��6�   ��6!   �� *SearchLogMacCommand+6�   5�       5�     $��1��6    .  
������� .   .   .   .   .   .  $
 Auto=�5�  �   $
 Auto=�6�   $
 None=�5�     $ Column=�5�     $��0,0,0,0q�5�     $ FullRow=�5�     $ Extended=�67   ��5�  H   �� *collectionWrited+ 5�     �� 5�     "  6$   .�5�  "   ��  � ��$ 0,0,1,1q�6D   �� 5�  "    � �� �	#FFB3B3B36@   �� 5�  "    � ��$ 13(�6=   �� 5�  "    � ��$ Normal"�6?   �� 5�  "    � ��$ 22��6;   �� 5�  "    � ��$ Center=�6M   5�       5�     �� 5�     "  6$   .�5�  "   ��  � ��$ 13(�6=   �� 5�  "    � ��$ 40��6;   �� 5�  "    � ��$
 Bold"�6?   �� 5�  "    � �� �	#FFB3B3B36@   �� 5�  "    � ��$ 0,0,0,1q�6D   �� 5�  "    � ��$ 3,0,0,0q�6<   5�     ! 5�       5�     $" ID��61   $
# Auto 6T   $ 6=   �� *ID+6T     5�     $	" Mac��61   $
# Auto 6V   $ 6>   �� *Mac+6V     5�     $	" UID��61   $
# Auto 6V   $ 6>   �� *UID+6V     5�     $" DateTimeWrited��61   $
# Auto 6l   $ 6I   �� *DateTimeWrited+6l   5�     5�     5�     5�     5�     5�     