   M S B A M L   `   `   `  ����@  <QLTro, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:QLTroQLTro  5      /clr-namespace:QLTro.validateQLTro.validate  5          	QLTro.App   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      %localclr-namespace:QLTro     5      1validateclr-namespace:QLTro.validate     5        �� 	Resources  5         TabisSelect �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value  validationTemplate � OverridesDefaultStyle  errorTextBox �� Self	 �� RelativeSource
 �� Path��%�  &	        &	 �     &	     �� 5   
   " ��6$    5	      P� 5
       �@J�IsMouseOver . . �5      ��  � ��
 ����6H   5      5      �� 5   
   .R�5      ��  . .+�5!      �� 
���  ��$��1q�6+   ._�5"      �� 5#      5$      5'      �� 5(   
   " ��6%    5)      P� 5*       �@=�HasError . . �5+      ��  �@�ToolTip 60   �� #	 Z $)
 #(Validation.Errors)[0].ErrorContent�5.      50      51      52      