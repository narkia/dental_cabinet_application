   M S B A M L   `   `   `  ����J  FWpfApplication2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication2WpfApplication2  5   	   .    (WpfApplication2.Edit_Appointments_Window   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApplication2     5   	     � Title$  Edit_Appointments_Window��5   	   $	��300��6*   $��386.765��67   .��5	      � 
�������.+�5   
   �� -   5        $'��!TextBlock_Edit_Appointment_Window��5      
�������$��40��6Q   $��0,10,10,220q�6]   �� 5   
   $��Edit Patient info��6   
�������
�������$��3q�6U   $	��135��6i   $	��Top=�6v   $��	-2,51,2,0q�6�    J� RenderTransformOrigin$ 0.476,0.541&�6�   .��5      �  � 	Resources 5         Patient_lastname_hint j� Stretch j� 
AlignmentX j� 
AlignmentY !� Visual J� Opacity  Patient_firstname_hint  Patient_street_hint  Patient_streetNr_hint  Patient_city_hint  Patient_country_hint��%�  &	        &	 9    &	 s    &	 �    &	 �    &	     !� 5      $
 None=�6@   $ Center=�6O   $ Center=�6c    5      � 5      $��Center=�6#   .+�5   "   �� $��SEGOEWP)�6,   $��20(�6B   $��
ExtraBlack"�6R   $
��Left=�6j   $��Center=�6�   
�������$��Normal$�6�   $ 1Q�6�   $��Lastname��6�   
�������6�   5      5      !� 5      $
 None=�6A   $ Center=�6P   $ Center=�6d    5      � 5      $��Center=�6#   .+�5   "   �� $��SEGOEWP)�6,   $��20(�6B   $��
ExtraBlack"�6R   $
��Left=�6j   $��Center=�6�   
�������$��Normal$�6�   $ 1Q�6�   $��	Firstname��6�   
�������6�   5      5      !� 5      $
 None=�6>   $ Center=�6M   $ Center=�6a    5      � 5       $��Center=�6#   .+�5!   "   �� $��SEGOEWP)�6,   $��20(�6B   $��
ExtraBlack"�6R   $
��Left=�6j   $��Center=�6�   
�������$��Normal$�6�   $ 1Q�6�   $��Street��6�   
�������6�   5"      5$      !� 5&      $
 None=�6@   $ Center=�6O   $ Center=�6c    5'      � 5(      $��Center=�6#   .+�5)   "   �� $��SEGOEWP)�6,   $��20(�6B   $��
ExtraBlack"�6R   $
��Left=�6j   $��Center=�6�   
�������$��Normal$�6�   $ 1Q�6�   $��Nr��6�   
�������6�   5*      5,      !� 5.      $
 None=�6<   $ Center=�6K   $ Center=�6_    5/      � 50      $��Center=�6#   .+�51   "   �� $��SEGOEWP)�6,   $��20(�6B   $��
ExtraBlack"�6R   $
��Left=�6j   $��Center=�6�   
�������$��Normal$�6�   $ 1Q�6�   $
��City��6�   
�������6�   52      54      !� 56      $
 None=�6?   $ Center=�6N   $ Center=�6b    57      � 58      $��Center=�6#   .+�59   "   �� $��SEGOEWP)�6,   $��20(�6B   $��
ExtraBlack"�6R   $
��Left=�6j   $��Center=�6�   
�������$��Normal$�6�   $ 1Q�6�   $��Country��6�   
�������6�   5:      5<      5?      .+�5A      �� -   5        $$��txt_box_fname_edit_appointment��5A      $��28��6A   $��109,10,159,75q�6M   .��6d   ��5C      �� 5D       �� 
TargetType" ��6    .�5E      �� 	 �� Property	 � ��
 �� Value

 �����6;    �� Triggers 5F      �� 5G   "    �� Binding 6.   ��  �� ElementName$$ txt_box_fname_edit_appointment�� �� Path$
 Text� �� Value  6w   .a�5H   &   �� 	 � ��#
 [ 6C   5I   #   5K      .��5L   %   5M      �� 5N      -   5        $$��txt_box_lname_edit_appointment��5N      $��28��6B   $��10,9,263,76q�6N   .��6c   ��5O      �� 5P      " ��6    .�5Q      �� 	 � ��

 �����6;    5R      �� 5S   "    6.   �� $$ txt_box_lname_edit_appointment��$
 Text�  6w   .a�5T   &   �� 	 � ��#
 [  6C   5U   #   5W      .��5X   %   5Y      (  "System.Windows.Controls.DatePicker  5Z      -   5        $"��date_picker_edit_appointment��5Z      $
��Left=�6A   $��28��6\   $��	10,74,0,0q�6h   $	��Top=�6{   $	��111��6�   �� 5[      -   5        $!��Pick_start_hour_appointment��5[      $
��Left=�6>   $��29��6Y   $��
124,74,0,0q�6e   $	��Top=�6y   $��68��6�    � ToolTip 5\      _� 5]      .��6"   <:! start time of appointment in following format--> hh:mm !5_      5a      �� 5b      -   5         ��Name$  Pick_stop_hour_appointment��5b      $
��Left=�6?   $��29��6Z   $��
197,74,0,0q�6f   $	��Top=�6z   $��62��6�    5c      _� 5d      .��6"   ;9! stop time of appointment in following format--> hh:mm !5f      5h      �� 5i      $��
Start time��6   $
��Left=�6-   $��29��6H   $��
126,40,0,0q�6T   $	��Top=�6h   $��66��6�   �� 5j      $��	Stop time��6   $
��Left=�6,   $��29��6G   $��
197,40,0,0q�6S   $	��Top=�6g   $��62��6   �� 5k      $��Appointment day��6   $
��Left=�62   $��29��6M   $��5,40,0,0q�6Y   $	��Top=�6k   $	��116��6�   5m      5n      �� 5p   
   -   5         ��Name$$ OK_Btn_Edit_Appointment_Window��5p      $��30��69   $��Save and Exit��6E   $��21,190,263,50q�6�   �� 5q   
   -   5        $( "Cancel_Btn_Edit_Appointment_Window��5q      $��30��6=   $��70��6I   $��Cancel��6T   $��121,190,188,0q�6�   $	��Top=�6�   5s      5w      5x      