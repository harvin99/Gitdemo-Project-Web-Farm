   M S B A M L   `   `   `  ����@  <QLTro, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:QLTroQLTro  5   	   /clr-namespace:QLTro.validateQLTro.validate  5   	       QLTro.RentRoomInfoWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:QLTro     5   	   1validateclr-namespace:QLTro.validate     5   	   -   5          � Title$  RentRoomInfoWindow��5	   	   $	��300��6$   $	��300��61   .��5
      ]� .+�5   
   �� -   5        $��lbTitle��5      $��20(�6   $��Center=�6-   $	��Top=�6J   .��6_   Thông Tin Sản Phẩm6s   �� 5   
   -   5        $��spRentRoomInfo��5      $	��Top=�6+   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��5q�6    ID:61   �� 5      -   5        $
��tbID��5       $��Center=�6,   6I   5      �� 5      $ 
Horizontal=�6   .+�5      �� $��5q�6    
Room ID:65   �� 5      -   5        $��tbRoomID��5       $��Center=�60   6N   5      �� 5      $ 
Horizontal=�6   .+�5      �� $��5q�6    Renter Name:69   �� 5      -   5        $��tbRenterName��5       $��Center=�64   6R   5      �� 5      $ 
Horizontal=�6   .+�5      �� $��5q�6    Tel:61   �� 5      -   5        $��tbTel��5       $��Center=�6-   6K   5      �� 5      $ 
Horizontal=�6   .+�5       �� $��5q�6    Price:63   �� 5!      -   5        $��tbPrice��5!       $��Center=�6/   6M   5"      �� 5#      $ 
Horizontal=�6   .+�5$      �� $��5q�6    Date:62   �� 5%      -	   5        $��tbDate��5%       $��Center=�6.   6L   5&      �� 5'      $ 
Horizontal=�6   .+�5(      �� -
   5        $��btnCheckOutRentRoom��5(   0   $��5q�6   $��5q�6$   .��6m   	Check Out6x   �� 5*      -   5        $��btnEditRentRoom��5*   0   $��5q�6   $��5q�6$   .��6e   Edit6k   �� 5+      -   5        $��btnDeleteRentRoom��5+   0   $��5q�6   $��5q�6$   .��6i   Delete6q   5,      5-      �� 51   
   -   5        $��spRentRoomAE��51      $	��Top=�6)   .+�52      �� $ 
Horizontal=�6   .+�53      �� $��5q�6   $	��100��6'   ID:68   �� 54      -   5        $��tbxID��54   A   ���#cccccc �� 
IsReadOnly . $��Center=�6N   $	��150��6i      errorTextBox#��[  55        validationTemplate =� ErrorTemplate# [ 6@   .��6   ��56      �� 57       �� Path$ id�6"    �� UpdateSourceTrigger$ PropertyChanged=�6,    �� ValidationRules 58      %  QLTro.validate.NumberValidation  59   "   6?   5;      .��5<   $   5=      5>      �� 5?      $ 
Horizontal=�6   .+�5@      �� $��5q�6   $	��100��6'   
Room ID:6=   �� 5A      -   5        $��	tbxRoomID��5A      $��Center=�6+   $	��150��6G   6U   5B      �� 5C      $ 
Horizontal=�6   .+�5D      �� $��5q�6   $	��100��6'   Renter Name:6A   �� 5E      -   5        $��tbxRenterName��5E      $��Center=�6/   $	��150��6K   6Y   5F      �� 5G      $ 
Horizontal=�6   .+�5H      �� $��5q�6   $	��100��6'   Tel:69   �� 5I      -   5        $��tbxTel��5I      $��Center=�6(   $	��150��6D   #��[  5J      # [ 67   .��6v   ��5K      �� 5L      $	 tel�6"   $ PropertyChanged=�6-    5M      "  QLTro.validate.TelValidation  5N   "   
   min$ 6��69   
   max$ 8��6A   6K   5P      .��5Q   $   5R      5S      �� 5T      $ 
Horizontal=�6   .+�5U      �� $��5q�6   $	��100��6'   Price:6;   �� 5V      -   5        $��tbxPrice��5V      $��Center=�6*   $	��150��6G   #��[  5W      # [ 67   .��6v   ��5X      �� 5Y      $ price�6"   $ PropertyChanged=�6/    5Z        5[   "   6?   5]      5^   &   5_      �� 5`      $ 
Horizontal=�6   .+�5a      �� $��5q�6   $	��100��6'   Date:6:   (  "System.Windows.Controls.DatePicker  5b      -   5        $��dpDate��5b      	   SelectedDateFormat$	 Short=�6+   
   FirstDayOfWeek$
 Monday=�5d      6+   5e      �� 5h   
   $ 
Horizontal=�6   .+�5i      �� -   5        $��btnAddRentRoom��5i   0   $��5q�6   $��5q�6$   .��6c   Add6h   �� 5j      -   5        $��btnSaveRentRoom��5j   0   $��5q�6   $��5q�6$   .��6e   Save6k   �� 5k      -   5        $��btnCancelRentRoom��5k   0   $��5q�6   $��5q�6$   .��6i   Cancel6q   5l      �� 5m      .+�5n      �� -   5        $��tbErrorMessage��5n      
���  ��6F   5o      5p      5s      5t      