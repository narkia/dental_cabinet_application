   M S B A M L   `   `   `  ����J  FWpfApplication2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication2WpfApplication2  5   	   ,    &WpfApplication2.Edit_Treatments_Window   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApplication2     5   	     � Title$  Edit_Treatments_Window��5   	   $	��300��6(   $	��300��65   .��5	      � 
�������.+�5
   
   �� -   5        $&�� TextBlock_Edit_Treatments_Window��5
      
�������$��40��6P   $��0,10,10,220q�6\   �� 5   
   $��Edit Treatment info��6   
�������
�������$��3q�6W   $	��135��6k   $	��Top=�6x   $��	-2,51,2,0q�6�    J� RenderTransformOrigin$ 0.476,0.541&�6�   .��5      �  � 	Resources 5         Treatment_name_hint j� Stretch j� 
AlignmentX j� 
AlignmentY !� Visual J� Opacity��%D  &	        !� 5      $
 None=�6>   $ Center=�6M   $ Center=�6a    5      � 5      $��Center=�6#   .+�5   "   �� $��SEGOEWP)�6,   $��20(�6B   $��
ExtraBlack"�6R   $
��Left=�6j   $��Center=�6�   
�������$��Normal$�6�   $ 1Q�6�   $��	Treatment��6�   
�������6�   5      5      5      .+�5      �� -   5        $-��'txt_box_treatment_name_edit_appointment��5      $��28��6K   $��10,9,165,76q�6W   .��6l   ��5      �� 5       �� 
TargetType" ��6    .�5      �� 	 �� Property	 � ��
 �� Value

 �����6;    �� Triggers 5      �� 5   "    �� Binding 6.   ��  �� ElementName$- 'txt_box_treatment_name_edit_appointment�� �� Path$
 Text� �� Value  6�   .a�5   &   �� 	 � ��#
 [  6C   5    #   5"      .��5#   %   5$      5&      5'      �� 5)   
   -   5         ��Name$" OK_Btn_Edit_Treatment_Window��5)      $��30��67   $��Save and Exit��6C   $��21,190,171,50q�6�   �� 5*   
   -   5        $&  Cancel_Btn_Edit_Treatment_Window��5*      $��30��6;   $��Cancel��6G   $��126,190,67,0q�6�   $	��Top=�6�   $ 1.186,0.233&�6�   5/      50      