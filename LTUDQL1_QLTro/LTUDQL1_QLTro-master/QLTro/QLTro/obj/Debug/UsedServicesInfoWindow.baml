   M S B A M L   `   `   `  ����@  <QLTro, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:QLTroQLTro  5   	   /clr-namespace:QLTro.validateQLTro.validate  5   	   "    QLTro.UsedServicesInfoWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:QLTro     5   	   1validateclr-namespace:QLTro.validate     5   	     � Title$  UsedServicesInfoWindow��5	   	   $	��400��6(   $	��300��65   .��5
      ]� .+�5   
   �� -   5        $��lbTitle��5      $��20(�6   $��Center=�6-   $	��Top=�6J   .��6_   Used Services Info6s   �� 5   
   -   5        $��spUsedServicesInfo��5      $	��Top=�6/   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��5q�6   ID:6,   �� 5      -   5        $
��tbID��5      $��Center=�6(   6E   5      �� 5      $ 
Horizontal=�6   .+�5      �� $��5q�6   Rent Room ID:66   �� 5      -   5        $��tbRentRoomID��5      $��Center=�60   6N   5      �� 5      $ 
Horizontal=�6   .+�5      �� $��5q�6   	Status:60   �� 5      -   5        $��tbStatus��5      $��Center=�6,   6J   5      �� 5      $ 
Horizontal=�6   .+�5      �� $��5q�6   Date:6.   �� 5      -   5        $��tbDate��5      $��Center=�6*   6H   5       ]� 5!      .+�5"      �� 
�������$��Bottom=�64   $��25��6L   $ 
Horizontal=�6X   .+�5#      �� $ 
Horizontal=�6!   .+�5$      �� -   5         ��Name$ btnPreviousPageUSDDetails��5$   !   $
��Prev��6l   $��
0,0,0,-0.2q�6{   �� 5%      $ 
Horizontal=�6%   $��5q�6>   $��Center=�6I   $��Center=�6f   .+�5&      �� -   5         ��Name$ tbxCurrentPageUSDDetails��5&   &   $��25��6H   6S   �� 5'      $�� 5,0,5,0q�6(   �� 6;   $�/��6?   6K   �� 5(      -	   5         ��Name$ tbTotalPageUSDDetails��5(   (   $��25��6G   5+      �� 5,      -
   5        $ btnNextPageUSDDetails��5,   !   $
��Next��6d   5.      5/      �� 50      .+�57      �� -   5        $��tcUSDDetails��57   !   .@�59      �� $��Used Services��6"   .��5:      &   System.Windows.Controls.DataGrid  -   5        $��dgUSDDetails��5:   '      AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     
IsReadOnly . 	   Columns	 5;   "   0  *System.Windows.Controls.DataGridTextColumn  5<   &   ,  &System.Windows.Controls.DataGridColumn
   Width5  /System.Windows.Controls.DataGridLengthConverter$

 1.1* 69      Header$ 
Service ID��6F   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6Z   �� *sID+6t     5=   &   $
 2* 69   $ Times��6D    6S   �� *times+6o     5>   &   $
 2* 69   $
 Date��6D    6R   �� *date+6m     5?   &   $
 2* 69   $ Price��6D    6S   �� *price+6o      RowStyle 5B   "   �� 5C   &    �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6,   .�5D   *   -   5        5E   '   5G      5H      5I      5J      5K      �� 5L      $ 
Horizontal=�6   .+�5M      �� -   5        $��btnAddDetails��5M   0   $��5q�6   $��5q�6$   .��6a   
Add Detail6m   �� 5O      -   5        $��btnEditUsedServices��5O   0   $��5q�6   $��5q�6$   .��6m   Edit6s   �� 5P      -   5        $��btnDeleteUsedServices��5P   0   $��5q�6   $��5q�6$   .��6q   Delete6y   5Q      5R      �� 5V   
   -   5        $��spUsedServicesAE��5V      $	��Top=�6-   .+�5W      �� $ 
Horizontal=�6   .+�5X      �� $��5q�6   $	��100��6'   ID:68   �� 5Y      -   5        $��tbxID��5Y   A   ���#cccccc �� 
IsReadOnly . $��Center=�6N   $	��150��6i      errorTextBox#��[  5Z        validationTemplate =� ErrorTemplate# [ 6@   .��6   ��5[      �� 5\       �� Path$ id�6"    �� UpdateSourceTrigger$ PropertyChanged=�6,    �� ValidationRules 5]      %  QLTro.validate.NumberValidation  5^   "   6?   5`      .��5a   $   5b      5c      �� 5d      $ 
Horizontal=�6   .+�5e      �� $��5q�6   $	��100��6'   Rent Room ID:6C   �� 5f      -   5        $��tbxRentRoomID��5f      $��Center=�6/   $	��150��6K   6Y   5g      �� 5i      $ 
Horizontal=�6   .+�5j      �� $��5q�6   $	��100��6'   	status:6<   �� 5k      -   5        $��	tbxStatus��5k      $��Center=�6+   $	��150��6H   #��[  5l      # [ 67   .��6v   ��5m      �� 5n      $ status�6"   $ PropertyChanged=�60    5o        5p   "   6?   5r      .��5s   $   5t      5u      �� 5v      $ 
Horizontal=�6   .+�5w      �� $��5q�6   $	��100��6'   Date:6:   (  "System.Windows.Controls.DatePicker  5x      -   5        $��dpDate��5x         SelectedDateFormat$ Short=�6+      FirstDayOfWeek$ Monday=�5z      6+   5{      �� 5~      $ 
Horizontal=�6   .+�5      �� -   5        $��btnAddUsedServices��5   0   $��5q�6   $��5q�6$   .��6k   Add6p   �� 5�      -   5        $��btnSaveUsedServices��5�   0   $��5q�6   $��5q�6$   .��6m   Save6s   �� 5�      -   5        $��btnCancelUsedServices��5�   0   $��5q�6   $��5q�6$   .��6q   Cancel6y   5�      �� 5�      .+�5�      �� -   5        $��tbErrorMessage��5�      
���  ��6F   5�      5�      5�      5�      