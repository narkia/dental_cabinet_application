   M S B A M L   `   `   `  ����J  FWpfApplication2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication2WpfApplication2  5   	   -    'WpfApplication2.Edit_Medications_Window   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApplication2     5   	     � Title$  Edit_Medications_Window��5   	   $	��300��6)   $	��300��66   .��5	      � 
�������.+�5   
   �� -   5        $&�� TextBlock_Edit_Medication_Window��5      
�������$��40��6P   $��0,10,10,220q�6\   �� 5   
   $��Edit Medication info��6   
�������
�������$��3q�6X   $	��174��6l   $	��Top=�6y   $��0,50,0,0q�6�    J� RenderTransformOrigin$ 0.476,0.541&�6�   .��5      � $��	0,0,0,-41q�6    � 	Resources 5         Medication_name_hint j� Stretch j� 
AlignmentX j� 
AlignmentY !� Visual J� Opacity  Medication_provider_hint  Medication_cost_hint  Medication_quantity_hint & "Medication_manufacturing_date_hint(  "System.Windows.Controls.DatePicker   Text # Medication_aquisition_date_hint��%�  &	        &	 =    &	 y    &	 �    &	 �    &	     !� 5      $
 None=�6?   $ Center=�6N   $ Center=�6b    5      � 5      $��Center=�6#   .+�5   "   �� $��SEGOEWP)�6,   $��20(�6B   $��
ExtraBlack"�6R   $
��Left=�6j   $��Center=�6�   
�������$��Normal$�6�   $ 1Q�6�   $��Name        ��6�   
�������6�   5      5      !� 5      $
 None=�6C   $ Center=�6R   $ Center=�6f    5      � 5      $��Center=�6#   .+�5   "   �� $��SEGOEWP)�6,   $��20(�6B   $��	ExtraBold"�6R   $
��Left=�6i   $��Center=�6�   
�������$��Normal$�6�   $ 1Q�6�   $��Provider    ��6�   
�������6�   5      5!      !� 5#      $
 None=�6?   $ Center=�6N   $ Center=�6b    5%      � 5&      $��Center=�6#   .+�5'   "   �� $��SEGOEWP)�6,   $��20(�6B   $��	ExtraBold"�6R   $
��Left=�6i   $��Center=�6�   
�������$��Normal$�6�   $ 1Q�6�   $��Cost   ��6�   
�������6�   5(      5*      !� 5,      $
 None=�6C   $ Center=�6R   $ Center=�6f    5-      � 5.      $��Center=�6#   .+�5/   "   �� $��SEGOEWP)�6,   $��20(�6B   $��	ExtraBold"�6R   $
��Left=�6i   $��Center=�6�   
�������$��Normal$�6�   $ 1Q�6�   $	��Qty��6�   
�������6�   50      52      !� 54      $
 None=�6M   $ Center=�6\   $ Center=�6p    55      � 56      $��Center=�6#   .+�57   "     $��SEGOEWP)�6-   $��20(�6C   $��	ExtraBold"�6S   $
��Left=�6j   $��Center=�6�   
�������$��Normal$�6�   $ 1Q�6�   $ 
Mfntg date��6�   
�������6�   58      5:      !� 5<      $
 None=�6J   $ Center=�6Y   $ Center=�6m    5=      � 5>      $��Center=�6#   .+�5?   "     $��SEGOEWP)�6-   $��20(�6C   $��	ExtraBold"�6S   $
��Left=�6j   $��Center=�6�   
�������$��Normal$�6�   $ 1Q�6�   $ Aqistn date��6�   
�������6�   5@      5B      5D      .+�5E      �� -   5        $��medication_name_textBox��5E   T   $��26��6   $
��Left=�6&   $��	10,10,0,0q�6A   $	��Top=�6t   $	��105��6�   $��16(�6�   $��SEGOEWP)�6�   $��
ExtraBlack"�6�   
���   �.��6�   ��5F      �� 5G      	 �� 
TargetType"	 ��6    .�5H      �� 
 �� Property
 � �� �� Value
 �����6;    �� Triggers 5I      �� 5J   "    �� Binding 6.   ��  �� ElementName$ medication_name_textBox�� �� Path$
 Text� �� Value  6p   .a�5K   &   �� 
 � ��# [  6C   5L   #   5N      .��5O   %   5P      �� 5R      -   5        $!��medication_provider_textBox��5R   U   $��26��6   $
��Left=�6&   $��
120,10,0,0q�6A   $	��Top=�6y   $	��102��6�   $��16(�6�   $��SEGOEWP)�6�   $��
ExtraBlack"�6�   
���   �.��6�   ��5S      �� 5T      "	 ��6    .�5U      �� 
 � ��
 �����6;    5V      �� 5W   "    6.   �� $! medication_provider_textBox��$
 Text�  6u   .a�5X   &   �� 
 � ��# [ 6C   5Y   #   5[      .��5\   %   5]      �� 5^      -   5        $��medication_cost_textBox��5^   :   $��26��6   $��
227,10,8,0q�6&   $	��Top=�6Y   $ 0.622,0.438&�6q   $��16(�6�   $��SEGOEWP)�6�   $��
ExtraBlack"�6�   
���   �.��6�   ��5_      �� 5`      "	 ��6    .�5a      �� 
 � ��
 �����6;    5b      �� 5c   "    6.   �� $ medication_cost_textBox��$
 Text�  6p   .a�5d   &   �� 
 � ��# [ 6C   5e   #   5g      .��5h   %    � ToolTip 5i      _� 5j      $��medication cost in RON��6"   .��5k   '   5l        5m      -   5        $.��(medication_manufacturing_date_datepicker��5m      $
��Left=�6M   $��26��6h   $��	10,41,0,0q�6t   $	��Top=�6�   $	��105��6�   ��5n      �� 5o      "	  6    .�5p      �� 
 � ��
 �����6;    5q      �� 5r   "    6.   �� $. (medication_manufacturing_date_datepicker��$ DatePicker.TextChanged�  6�   .a�5s   &   �� 
 � ��# [ 6C   5t   #   5v       5x      _� 5y      $7��1insert here the medication date of manufacturing!��6"   5{        5}      -   5        $+��%medication_aquisition_date_datepicker��5}      $
��Left=�6J   $��26��6e   $��
120,41,0,0q�6q   $	��Top=�6�   $	��105��6�   ��5~      �� 5      "	  6    .�5�      �� 
 � ��
 �����6;    5�      �� 5�   "    6.   �� $. (medication_manufacturing_date_datepicker��$ DatePicker.TextChanged�  6�   .a�5�   &   �� 
 � ��# [ 6C   5�   #   5�       5�      _� 5�      $4��.insert here the medication date of aquisition!��6"   5�      �� 5�      -   5        $!��medication_quantity_textbox��5�   U   $��26��6   $��Right=�6&   $��	0,41,10,0q�6B   $	��Top=�6x   $��33��6�   $ 8.55,-0.406&�6�   .��6�   ��5�      �� 5�      "	 ��6    .�5�      �� 
 � ��
 �����6;    5�      �� 5�   "    6.   �� $! medication_quantity_textbox��$
 Text�  6u   .a�5�   &   �� 
 � ��# [ 6C   5�   #   5�      .��5�   %    5�      _� 5�      $-��'medication quantity in number of pieces��6"   .��5�   '   5�      �� 5�      $��Manufacturing date��6   $��3,70,165,103q�66   $��12(�6L   $��SEGOEWP)�6Z   $��
ExtraBlack"�6o   
����ح�6�   �� 5�      $��Aquisition date��6   $��120,70,63,103q�63   $��12(�6J   $��SEGOEWP)�6X   $��
ExtraBlack"�6m   
����ح�6�   5�      5�      �� 5�   
   -   5         ��Name$# OK_Btn_Edit_Medication_Window��5�      $��30��68   $��Save and Exit��6D   $��10,230,182,10q�6�   �� 5�   
   -	   5        $' !Cancel_Btn_Edit_Medication_Window��5�      $��30��6<   $��Cancel��6H   $��115,230,78,0q�6�   $	��Top=�6�   $ 1.186,0.233&�6�   5�      5�      