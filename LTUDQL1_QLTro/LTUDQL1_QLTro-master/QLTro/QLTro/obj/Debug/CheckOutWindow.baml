   M S B A M L   `   `   `  ����@  <QLTro, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:QLTroQLTro  5   	       QLTro.CheckOutWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:QLTro     5   	     � Title$  CheckOutWindow��5   	   $	��300��6    $	��300��6-   .��5	      ]� .+�5
   
   �� -   5        $��lbTitle��5
      $��20(�6   $��Center=�6-   $	��Top=�6J   .��6_   
Thông Tin6j   �� 5   
   -   5        $��spRentRoomInfo��5      $	��Top=�6+   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��5q�6   ID:6,   �� 5      -   5        $
��tbID��5      $��Center=�6(   6E   5      �� 5      $ 
Horizontal=�6   .+�5      �� $��5q�6   
Room ID:61   �� 5      -   5        $��tbRoomID��5      $��Center=�6,   6J   5      �� 5      $ 
Horizontal=�6   .+�5      �� $��5q�6   Renter Name:65   �� 5      -   5        $��tbRenterName��5      $��Center=�60   6N   5      �� 5      $ 
Horizontal=�6   .+�5      �� $��5q�6   Tel:6-   �� 5      -   5        $��tbTel��5      $��Center=�6)   6G   5      �� 5      $ 
Horizontal=�6   .+�5      �� $��5q�6   Price:6/   �� 5       -   5        $��tbPrice��5       $��Center=�6+   6I   5!      �� 5"      $ 
Horizontal=�6   .+�5#      �� $��5q�6   Date:6.   �� 5$      -   5        $��tbDate��5$      $��Center=�6*   6H   5%      �� 5&      -	   5        $��tcUSDDetails��5&      .@�5(      �� $��Used Services��6   .��5)      &   System.Windows.Controls.DataGrid  -
   5        $��dgUSDDetails��5)         AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     
IsReadOnly .    Columns 5*      0  *System.Windows.Controls.DataGridTextColumn  5+      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 1.1* 61      Header$ 
Service ID��6>   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6R   �� *sID+6l     5,      $ 2* 61   $ Times��6<   	 6K   �� *times+6g     5-      $ 2* 61   $
 Date��6<   	 6J   �� *date+6e     5.      $ 2* 61   $ Price��6<   	 6K   �� *price+6g   52      53      54      �� 55      $ 
Horizontal=�6   .+�56      �� -   5        $��tbTotalPrice��56      ���#cccccc
 �� 
IsReadOnly
 . $	��100��6U   $��5q�6a   $��5q�6l   6z   �� 57      -   5        $��btnCheckOutRentRoom��57   0   $��5q�6   $��5q�6$   .��6m   	Check Out6x   58      59      5:      5;      