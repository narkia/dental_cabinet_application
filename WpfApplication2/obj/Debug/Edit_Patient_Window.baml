   M S B A M L   `   `   `  ����J  FWpfApplication2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication2WpfApplication2  5   	   )    #WpfApplication2.Edit_Patient_Window   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApplication2     5   	     � Title$  Edit_Patient_Window��5   	   $	��300��6%   $��329.316��62   .��5	      � 
�������.+�5   
   �� -   5        $#��TextBlock_Edit_Patient_Window��5      
�������$��40��6M   $��0,10,10,220q�6Y   �� 5   
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
�������6�   5:      5<      5?      .+�5A      �� -   5        $ ��txt_box_fname_edit_patient��5A      $��28��6=   $��106,10,103,75q�6I   .��6`   ��5C      �� 5D       �� 
TargetType" ��6    .�5E      �� 	 �� Property	 � ��
 �� Value

 �����6;    �� Triggers 5F      �� 5G   "    �� Binding 6.   ��  �� ElementName$  txt_box_fname_edit_patient�� �� Path$
 Text� �� Value  6s   .a�5H   &   �� 	 � ��#
 [ 6C   5I   #   5K      .��5L   %   5M      �� 5N      -   5        $ ��txt_box_lname_edit_patient��5N      $��28��6>   $��5,10,208,75q�6J   .��6_   ��5O      �� 5P      " ��6    .�5Q      �� 	 � ��

 �����6;    5R      �� 5S   "    6.   �� $  txt_box_lname_edit_patient��$
 Text�  6s   .a�5T   &   �� 	 � ��#
 [  6C   5U   #   5W      .��5X   %   5Y      �� 5Z      -   5        $"��txt_box_country_edit_patient��5Z      $��28��6?   $��76,43,149,42q�6K   $ 0.984,0.536&�6a   .��6�   ��5[      �� 5\      " ��6    .�5]      �� 	 � ��

 �����6;    5^      �� 5_   "    6.   �� $" txt_box_country_edit_patient��$
 Text�  6u   .a�5`   &   �� 	 � ��#
 [ 6C   5a   #   5c      .��5d   %   5e      �� 5f      -   5        $��txt_box_city_edit_patient��5f      $��28��6<   $��10,43,251,42q�6H   .��6^   ��5g      �� 5h      " ��6    .�5i      �� 	 � ��

 �����6;    5j      �� 5k   "    6.   �� $ txt_box_city_edit_patient��$
 Text�  6r   .a�5l   &   �� 	 � ��#
 [ 6C   5m   #   5o      .��5p   %   5q      �� 5r      -   5        $!��txt_box_street_edit_patient��5r      $��28��6>   $��206,10,45,75q�6J   .��6`   ��5s      �� 5t      " ��6    .�5u      �� 	 � ��

 �����6;    5v      �� 5w   "    6.   �� $! txt_box_street_edit_patient��$
 Text�  6t   .a�5x   &   �� 	 � ��#
 [ 6C   5y   #   5{      .��5|   %   5}      �� 5~      -   5        $$��txt_box_street_nr_edit_patient��5~      $��28��6A   $��269,9,10,76q�6M   .��6b   ��5      �� 5�      " ��6    .�5�      �� 	 � ��

 �����6;    5�      �� 5�   "    6.   �� $$ txt_box_street_nr_edit_patient��$
 Text�  6w   .a�5�   &   �� 	 � ��#
 [ 6C   5�   #   5�      .��5�   %   5�      (  "System.Windows.Controls.DatePicker  5�      -   5        $��date_picker_edit_patient��5�      $
��Left=�6=   $��28��6X   $��
188,42,0,0q�6d   $	��Top=�6x   $	��111��6�   5�      5�      �� 5�   
   -	   5         ��Name$  OK_Btn_Edit_Patient_Window��5�      $��30��65   $��Save and Exit��6A   $��21,190,191,50q�6~   �� 5�   
   -
   5        $$ Cancel_Btn_Edit_Patient_Window��5�      $��30��69   $��70��6E   $��Cancel��6P   $��135,190,116,50q�6�   5�      5�      5�      