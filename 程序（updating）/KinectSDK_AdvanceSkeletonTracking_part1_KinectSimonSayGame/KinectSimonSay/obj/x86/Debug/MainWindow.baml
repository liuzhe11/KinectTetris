   M S B A M L   `   `   `  ����I  EKinectSimonSay, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:KinectSimonSayKinectSimonSay  5          KinectSimonSay.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   *cclr-namespace:KinectSimonSay     5        � Title$  
MainWindow��5   	    � WindowState$ 	Maximized=�6   .��5      (� .��5   
   � -   5         �Name$ 
LayoutRoot��5      $
��1080��6#   $
��1920��61   
�������
���   �.+�5      #   KinectSimonSay.SkeletonViewer  -   5          Name$ SkeletonViewerElement��5      �� 5	      $��	Simon Say��6   $��72(�6)   $��0,25,0,0q�67   $��Center=�6I   $	��Top=�6f   6�   �� 5
      $��Center=�6   $��Center=�66   $	��600��6Q   .+�5      �� -   5         ��Name$ GameStateElement��5      $��55(�66   $�� GAME OVER!��6D   $��Center=�6W   �� 5      -   5        $ GameInstructionsElement��5      $*��$将手放在对象上开始游戏。��6=   $��45(�6Q   $��Center=�6_    �� TextAlignment$ Center=�5      $
��Wrap=�64   $��0,20,0,0q�6H   5      �� 5      -   5         ��Name$ 
GameCanvas��5      .+�5      �� -   5         ��Name$ RedBlock��5      $	��400��6.   $	��400��6;   
���  �� �� Left$	 170��6R   
	 �� Top$	 90��6d   
 J� Opacity$	
 0.2Q�6t   �� 5      -   5        $ 	BlueBlock��5      $	��400��6/   $	��400��6<   
����  �$	 170��6T   $		 550��6f   $	
 0.2Q�6w   �� 5      -   5        $ 
GreenBlock��5      $	��400��60   $	��400��6=   
��� � �$
 1350��6V   $		 550��6i   $	
 0.2Q�6z   �� 5      -	   5        $ YellowBlock��5      $	��400��61   $	��400��6>   
��� ���$
 1350��6X   $	 90��6k   $	
 0.2Q�6{   5      �� 5      -
   5        $ ControlCanvas��5      .+�5      �� -   5         ��Name$ RightHandStartElement��5      
���  ��$	��200��6I    �� Padding$ 20q�6V   $
 1420��6c   $		 440��6v   ._�5      �� $��Images/hand.png��6   5      �� 5      -   5        $ LeftHandStartElement��5      
���  ��$	��200��6H   $ 20q�6U   $	 300��6b   $		 440��6t   ._�5      �� $��Images/hand.png��6   z�5      V� 5      .~�5   "   T�  T� X$
 -130Q�65   �� 5    "    �� ScaleX$ -1Q�61   5!      5#      5%      5&      �� 5(      -   5        $ 
HandCanvas��5(      .+�5)      �� -   5         ��Name$ RightHandElement��5)      $��Images/hand.png��62   $y�	Collapsed=�6K   $	��100��6b   $	��100��6o   �� 5*      -   5        $ LeftHandElement��5*      $��Images/hand.png��61   $y�	Collapsed=�6J   $	��100��6a   $	��100��6n   z�5+      V� 5,      .~�5-      �� $ -1Q�6-   T� 5.      $ 90Q�61   5/      51      52      53      54      56      