   M S B A M L   `   `   `  ����O  KIPCameraWriteMacWiFi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:IPCameraWriteMacWiFi.ViewsIPCameraWriteMacWiFi.Views  5      (    "IPCameraWriteMacWiFi.Views.LogView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:IPCameraWriteMacWiFi.Views     5      
�������  � 	Resources  5
       �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value��%�  '	�       �� 5   
   " 	�6   .�5      ��  � ��$ 15(�6)   �� 5       � ��$ Normal"�6+   �� 5       � ��
 �   �6+   �� 5       � ��$ 30��6'   �� 5       � ��$ 30,0,0,0q�6'   �� 5       � ��$ Center=�69    5      P� 5       �@d�	IsChecked$
 TrueY�60   . �5      ��  � ��
 �  ��63   �� 5       � ��$ SemiBold"�63   5      5      5      .��5      �� $��5,5,5,5q�6   .+�5   
   �� $��15(�6   $;��5Vui lòng chọn loại dữ liệu cần truy vấn:��6   	� 5   
   $��Log file��6j    d� 	IsChecked 6   ��  �� Path$ Log.isSelectLogFile�	 �� UpdateSourceTrigger$	 PropertyChanged=�6j   	� 5   
   $��Setting file��6n    6   �� $ Log.isSelectSettingFile�$	 PropertyChanged=�6n   	� 5   
   $,��&Tài liệu hướng dẫn sử dụng��6l    6   �� $ Log.isSelectUserGuide�$	 PropertyChanged=�6l   �� 5!   
   $��0,10,0,0q�6/   $	��120��6A   $��40��6M   $��22(�6Y   $
��Left=�6g   $��Go��6�   ��6   �� *	GoCommand+6�   5#      5%      