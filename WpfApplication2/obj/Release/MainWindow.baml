   M S B A M L   `   `   `  ���� J  FWpfApplication2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication2WpfApplication2       WpfApplication2.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:WpfApplication2       � Title$  Aplicatie cabinet dentar��$
��1200��$
��1429�����	#FFCE2020���	#FF936868.��� $	��988��$
��1386��.+��� $��
0,0,309,80q�.@��� -   $
��tab0��$��Welcome page��$��0��.��� ���	#FF936870 � ColumnDefinitions �� $
��120* ��� $
��947* �.+��� -   $��label0��$��Buna sa-ti fie inima!��$��25��$
��Left=�$��5,3,0,0q�$	��Top=�$	��119��$��2��&   System.Windows.Controls.Calendar  -   $��	calendar1��$	��223��$
��Left=�$��7,38,0,0q�$	��Top=�$	��210��$��2���� -   $-��'textBlock_welcome_appointments_of_today��$
��Left=�$��Bottom=�$	��272��$8��2 Here you will see all the appointments for today.��
�������$
��Auto=�$��	596,0,0,7q�$��1���� -   $��global_search_groupbox��$��global search��$��95��$
��Left=�$��
111,37,0,0q�$	��Top=�$	��230��$��1��.��� $��69��$	��197�� � 	Resources    Welcome_global_search_hint j� Stretch j� 
AlignmentX j� 
AlignmentY !� Visual J� Opacity��%�   &	        !� $
 None=�$ Center=�$ Center=� � $��Center=�.+��� $��SEGOEWP)�$��20(�$��	ExtraBold"�$
��Left=�$��Center=�
�������$��Normal$�$ 1Q�$��word           ��
������� �� $
��116* ��� $	��81* �.+��� -   $��global_search_textbox��$��26��$��	6,13,1,30q�$��16(�$��SEGOEWP)�$��
ExtraBlack"�
���   �.������  �� 
TargetType" ��.��� 	 �� Property	 � ��
 �� Value

 ����� �� Triggers ��  �� Binding ��  �� ElementName$ global_search_textbox�� �� Path$
 Text� �� Value  .a��� 	 � ��#
 [  .���� -   $��global_search_button��$��Search��$��1,9,0,0q�$��34��$	��Top=�$��1���� -   $��global_search_textblock��
�������$
��Left=�$��69,0,0,6q�$
��Auto=�$2��, Here you will see the global search result.��$��Bottom=�$	��377��$��16��$��1���� -	   $'��!important_info_for_today_groupBox��$��important info for today��$	��122��$
��Left=�$��111,139,0,0q�$	��Top=�$	��230��$��1��.��� $��97��.+��� -
   $��button7��$#��see all appointments of today��$��25��$
��Left=�$��16,0,0,0q�$	��Top=�$	��182���� -   $��button3��$��see missing medications��$��25��$
��Left=�$��	16,32,0,0q�$	��Top=�$	��182���� -   $��button4��$"��see all treatments for today��$��25��$
��Left=�$��	16,63,0,0q�$	��Top=�$	��182���� -   $"��appointments_search_groupbox��$��appointments search��$	��223��$��Right=�$��
0,37,333,0q�$	��Top=�$	��256��$��1��.��� .+��� -   $+��%all_appointments_specific_day_textbox��$��16(�$��34��$��
6,78,102,9q��� -   $*��$all_appointments_specific_day_button��$��Search��$��34��$��0,14,6,0q�$	��Top=�$��Right=�$��90���� -   $,��&all_appointments_specific_day_comboBox��$��34��$
��Left=�$��6,14,0,0q�$	��Top=�$	��118���� -   $
��tab2��$��Patients��$��2��.��� ���	#FF936870$
��1194��$	��962��.+��� $��add patient��$��5,25,861,724q�.��� $	��175�� �� $	��23* ��� $��1159* �.+��� -   $��	textbox_1��$��Prenume��$��14(�$
��Left=�$��Center=�$��	2,6,0,130q�$	��103��$��39��$��1���� -   $��textBox_adresa��$��14(�$��39��$
��Left=�$��111,6,0,130q�$��adresa Str,nr,Oras,Tara��$��Center=�$	��169��$��1���� -   $��	textbox_2��$
��Nume��$��14(�$��39��$
��Left=�$��	2,51,0,85q�$��Center=�$	��119��$��1��(  "System.Windows.Controls.DatePicker  -   $��byrthday_date_datepicker��$��1��$
��Left=�$��38��$��
135,52,0,0q�$	��Top=�$	��145��   Text$ date of birth�� � ToolTip _� $��pick your date of birth���� -   $��buton_1��$��92��$
��Left=�$��
1,101,0,35q�$��1��.��Add in database�� -   $��buton_3��$	��104��$
��Left=�$��100,101,0,35q�$��1��.��Write in textblock�� -   $��buton_4��$	��100��$��Right=�$��
0,101,0,35q�$��1��.��Delete textblock�� $��delete patient��$��14,267,861,557q�.��� $	��107��$	��297��.+��� -   $��textbox_delete_word��$��nume pacient��$��14(�$��Right=�$��Center=�$��37��$	��128��$��0,19,156,51q��� -   $��buton_2��$��95��$��Right=�$��
0,19,55,51q�.��sterge pacient _� .��ki! daca apesi acest buton o sa se stearga din databse orice field ce contine cuvantul introdus in textbox!�� -   $��textblock_1��$
��Left=�$��Bottom=�$	��664��
�������$
��Auto=�$��5,0,0,90q��� -   $��action_window��$��Right=�$��Bottom=�$	��365��$��
0,0,142,89q�
�������$��Visible=��� $��search patients��$��345,25,377,693q�.��� $	��452��.+��� -   $��button_search��$��Search nr of matches��$��Right=�$��0,9,100,169q�$	��127���� -   $��textBox_search��$��14(�$��43��$
��Left=�$��20,12,0,166q�$��Search word��$��Center=�$	��203���� -   $��search_result_window��$
��Wrap=�$
��Left=�$	��Top=�$	��410��$��	20,61,0,0q�
�������$��28���� -    $��
textBlock2��
�������$��74��$
��Left=�$��
20,141,0,0q�$	��Top=�$	��410���� -!   $��textBox2_search_all��$��14(�$��40��$
��Left=�$��
20,95,0,86q�$��	your word��$��Center=�$	��186���� -"   $��button2��$��Search all about it��$��Right=�$��0,95,122,85q�$	��113���� $��fast search��$��351,309,510,557q�.��� .+��� -#   $��textBox1��$��14(�$��40��$
��Left=�$��	6,20,0,13q�$��fast search��$��Center=�$	��173���� -$   $��button1��$��search patient��$��40��$
��Left=�$��185,20,0,13q�$	��109���� -%   $
��tab3��$��Appointments��$��3��.��� ���	#FF936870.+��� -&   $��label_programari��$��pagina de programari��$��25��$
��Left=�$��5,3,0,0q�$	��Top=�$	��200���� $��add appointment��$��44,33,741,685q�.��� $	��115��$	��265��.+��� -'   $��button_appointments_today��$"��set appointments for patient��$��26��$
��Left=�$��6,83,0,0q�$	��Top=�$	��213���� -(   $"��textBox_appointments_patient��$��	Last name��$��32��$
��Left=�$��6,6,0,0q�$	��Top=�$��97���� -)   $��textBox_date_appointment��$��
dd.mm.yyyy��$��32��$
��Left=�$��6,44,0,0q�$	��Top=�$��97���� -*   $)��#textBox_timeframe_start_appointment��$��hh:mm��$��32��$��165,44,46,0q�$	��Top=�.�� _� .��<:! start time of appointment in following format--> hh:mm !.���� -+   $#��textbox_firstname_appointment��$��
First name��$��32��$
��Left=�$��	109,6,0,0q�$	��Top=�$	��110���� -,   $(��"textBox_timeframe_stop_appointment��$��32��$��Right=�$��
0,44,106,0q�$��hh:mm��$	��Top=�$��50��.�� _� .��:8! end time of appointment in following format--> hh:mm !.���� $��show info from database��$��332,176,528,542q�.��� $	��132��.+��� --   $��button5��$%��afiseaza toate programarile jos��$��26��$
��Left=�$��5,48,0,0q�$	��Top=�$	��184���� -.   $��button6��$"��afiseaza programarile de azi��$��28��$
��Left=�$��	5,101,0,0q�$	��Top=�$	��184���� -/   $ ��textBlock_all_appointments��$
��Left=�$��Bottom=�$	��430��$/��)see here all the appointments in database��
�������$
��Auto=�$��5,0,0,0q��� -0   $%��textBlock_appointments_of_today��$
��Left=�$��Bottom=�$	��361��$,��&see here all the appointments of today��
�������$
��Auto=�$��	504,0,0,0q��� $��delete appointment��$��332,33,422,717q�.��� $��92��$	��289��.+��� -1   $��button27��$��delete appointment��$��26��$
��Left=�$��
156,50,0,0q�$	��Top=�$	��122���� -2   $��	textBox14��$��32��$
��Left=�$��6,6,0,0q�$��	Last name��$	��Top=�$	��100���� -3   $��	textBox17��$��32��$
��Left=�$��6,44,0,0q�$��
dd.mm.yyyy��$	��Top=�$��85���� -4   $��	textBox18��$��32��$
��Left=�$��
100,44,0,0q�$��hh:mm��$	��Top=�$��50���� -5   $��	textBox19��$��32��$
��Left=�$��	112,6,0,0q�$��
First name��$	��Top=�$	��100���� -6   $
��tab4��$��
Treatments��$��4��.��� ���	#FF936870.+��� -7   $��label_tratamente��$��pagina cu tratamente��$��25��$
��Left=�$��5,3,0,0q�$	��Top=�$	��200���� $��add treatment��$��22,53,764,663q�.��� $	��115��$	��265��.+��� -8   $��button8��$"��set appointments for patient��$��26��$
��Left=�$��6,83,0,0q�$	��Top=�$	��213���� -9   $��textBox2��$��32��$
��Left=�$��6,6,0,0q�$��	Last name��$	��Top=�$��97���� -:   $��textBox3��$��32��$
��Left=�$��6,44,0,0q�$��
dd.mm.yyyy��$	��Top=�$��97���� -;   $��textBox4��$��32��$��165,44,46,0q�$��hh:mm��$	��Top=�.�� _� $@��:! start time of appointment in following format--> hh:mm !��.���� -<   $��textBox5��$��32��$
��Left=�$��	109,6,0,0q�$��
First name��$	��Top=�$	��110���� -=   $��textBox6��$��32��$��Right=�$��
0,44,106,0q�$��hh:mm��$	��Top=�$��50��.�� _� $>��8! end time of appointment in following format--> hh:mm !��.���� $��delete treatment��$��371,53,416,719q�.��� $��78��$	��265��.+��� ->   $��button9��$$��delete treatment from database��$��26��$
��Left=�$��6,42,0,0q�$	��Top=�$	��181���� -?   $��delete_treatment_textBox��$��32��$
��Left=�$��6,6,0,0q�$��treatment name��$	��Top=�$	��181���� $��important info treatments��$��371,184,416,548q�.��� $	��115��$	��265��.+��� -@   $��button10��$#��show treatments from database��$��26��$
��Left=�$��6,56,0,0q�$	��Top=�$	��179���� -A   $��search_treatment_textBox��$��32��$
��Left=�$��6,6,0,0q�$��treatment name��$	��Top=�$��97���� -B   $��button11��$��search treatment��$��32��$
��Left=�$��	109,6,0,0q�$	��Top=�$	��147���� -C   $��all_treatments_textBlock��
�������$
��Left=�$��54,0,0,1q�$
��Auto=�$@��:see here all the treatments available in our dental clinic��$��Bottom=�$	��361���� -D   $
��tab5��$��Medications��$��5��.��� ���	#FF936870.+��� -E   $��label_medicamente��$��pagina cu medicamente��$��25��$
��Left=�$��5,3,0,0q�$	��Top=�$	��200���� $��add medications��$��10,53,732,666q�.��� $��	10,0,13,5q�   Medication_name_hint  Medication_provider_hint  Medication_cost_hint  Medication_quantity_hint & "Medication_manufacturing_date_hint # Medication_aquisition_date_hint��%�  &	       &	 �     &	 �    &	 K    &	     &	 �    !� $
 None=�$ Center=�$ Center=� � $��Center=�.+��� $��SEGOEWP)�$��20(�$��
ExtraBlack"�$
��Left=�$��Center=�
�������$��Normal$�$ 1Q�$��Name        ��
�������!� $
 None=�$ Center=�$ Center=� � $��Center=�.+��� $��SEGOEWP)�$��20(�$��	ExtraBold"�$
��Left=�$��Center=�
�������$��Normal$�$ 1Q�$��Provider    ��
�������!� $
 None=�$ Center=�$ Center=� � $��Center=�.+��� $��SEGOEWP)�$��20(�$��	ExtraBold"�$
��Left=�$��Center=�
�������$��Normal$�$ 1Q�$��Cost   ��
�������!� $
 None=�$ Center=�$ Center=� � $��Center=�.+��� $��SEGOEWP)�$��20(�$��	ExtraBold"�$
��Left=�$��Center=�
�������$��Normal$�$ 1Q�$	��Qty��
�������!� $
 None=�$ Center=�$ Center=� � $��Center=�.+�  $��SEGOEWP)�$��20(�$��	ExtraBold"�$
��Left=�$��Center=�
�������$��Normal$�$ 1Q�$ 
Mfntg date��
�������!� $
 None=�$ Center=�$ Center=� � $��Center=�.+�  $��SEGOEWP)�$��20(�$��	ExtraBold"�$
��Left=�$��Center=�
�������$��Normal$�$ 1Q�$ Aqistn date��
�������.+��� -F   $��medication_name_textBox��$��26��$
��Left=�$��0,7,0,0q�$	��Top=�$	��101��$��16(�$��SEGOEWP)�$��
ExtraBlack"�
���   �.������ " ��.��� 	 � ��

 ����� ��  �� $ medication_name_textBox��$
 Text�  .a��� 	 � ��#
 [ .���� -G   $��medication_cost_textBox��$��26��$��	221,7,9,0q�$	��Top=� J� RenderTransformOrigin$ 0.622,0.438&�$��16(�$��SEGOEWP)�$��
ExtraBlack"�
���   �.������ " ��.��� 	 � ��

 ����� ��  �� $ medication_cost_textBox��$
 Text�  .a��� 	 � ��#
 [ .�� _� $��medication cost in RON��.���� -H   $!��medication_provider_textBox��$��26��$
��Left=�$��	106,7,0,0q�$	��Top=�$	��102��$��16(�$��SEGOEWP)�$��
ExtraBlack"�
���   �.������ " ��.��� 	 � ��

 ����� ��  �� $! medication_provider_textBox��$
 Text�  .a��� 	 � ��#
 [ .���� -I   $!��medication_quantity_textbox��$��26��$��Right=�$��	0,44,10,0q�$	��Top=�$��33��$ 8.55,-0.406&�.������ " ��.��� 	 � ��

 ����� ��  �� $! medication_quantity_textbox��$
 Text�  .a��� 	 � ��#
 [ .�� _� $-��'medication quantity in number of pieces��.��  -J   $.��(medication_manufacturing_date_datepicker��$
��Left=�$��26��$��0,44,0,0q�$	��Top=�$	��117������ "  .��� 	 � ��

 ����� ��  �� $. (medication_manufacturing_date_datepicker��$ DatePicker.TextChanged�  .a��� 	 � ��#
 [  _� $7��1insert here the medication date of manufacturing!��  -K   $+��%medication_aquisition_date_datepicker��$
��Left=�$��26��$��
122,44,0,0q�$	��Top=�$	��117������ "  .��� 	 � ��

 ����� ��  �� $. (medication_manufacturing_date_datepicker��$ DatePicker.TextChanged�  .a��� 	 � ��#
 [  _� $4��.insert here the medication date of aquisition!���� $��Manufacturing date��$��3,70,174,41q�$��12(�$��SEGOEWP)�$��
ExtraBlack"�
����ح��� $��Aquisition date��$��138,70,63,41q�$��12(�$��SEGOEWP)�$��
ExtraBlack"�
����ح��� -L   $��add_medication_button��$ ��add medication to database��$��23��$
��Left=�$��3,94,0,0q�$	��Top=�$	��213��$ 0.512,1.375&��� $��delete medications��$��370,53,418,696q�.��� $��78��$	��265��.+��� -M   $��button13��$$��delete treatment from database��$��26��$
��Left=�$��6,42,0,0q�$	��Top=�$	��181���� -N   $��	textBox12��$��32��$
��Left=�$��6,6,0,0q�$��treatment name��$	��Top=�$	��181���� $ ��important info medications��$��10,210,779,507q�.��� $	��115��$	��265��.+��� -O   $��button14��$#��show treatments from database��$��26��$
��Left=�$��6,56,0,0q�$	��Top=�$	��179���� -P   $��	textBox13��$��32��$
��Left=�$��6,6,0,0q�$��treatment name��$	��Top=�$��97���� -Q   $��button15��$��search treatment��$��32��$
��Left=�$��	109,6,0,0q�$	��Top=�$	��147���� -R   $��all_medications_textBlock��
�������$
��Left=�$��	102,0,0,4q�$
��Auto=�$A��;see here all the medications available in our dental clinic��$��Bottom=�$	��361���� -S   $
��tab6��$��
Equipments��$��6��.��� ���	#FF936870.+��� -T   $��label_equipments��$��pagina cu echipamente��$��25��$
��Left=�$��5,3,0,0q�$	��Top=�$	��200���� $��add equipments��$��21,53,753,649q�.��� $	��115��$	��265��.+��� -U   $��add_equipment_button��$��add new equipment��$��26��$
��Left=�$��6,83,0,0q�$	��Top=�$	��213���� -V   $$��add_new_equipment_name_textBox��$��32��$
��Left=�$��6,6,0,0q�$��Equipment name��$	��Top=�$��97���� -W   $-��'add_new_equipment_serial_number_textBox��$��32��$
��Left=�$��6,44,0,0q�$��
dd.mm.yyyy��$	��Top=�$��97���� -X   $��	textBox90��$��32��$��165,44,46,0q�$��hh:mm��$	��Top=�.�� _� $@��:! start time of appointment in following format--> hh:mm !��.���� -Y   $��	textBox91��$��32��$
��Left=�$��	109,6,0,0q�$��
First name��$	��Top=�$	��110���� -Z   $��	textBox92��$��32��$��Right=�$��
0,44,106,0q�$��hh:mm��$	��Top=�$��50��.�� _� $>��8! end time of appointment in following format--> hh:mm !��.���� $��delete equipment��$��355,64,415,685q�.��� $��78��$	��265��.+��� -[   $��delete_equipment_button��$$��delete equipment from database��$��26��$
��Left=�$��6,42,0,0q�$	��Top=�$	��181���� -\   $��equipment_textbox_nou��$��32��$
��Left=�$��6,6,0,0q�$��equipment name��$	��Top=�$	��181���� -]   $
��tab7��$��
Statistics��$��7��.��� ���	#FF936870.+��� -^   $��label_statistici��$��pagina cu statistici��$��25��$
��Left=�$��5,3,0,0q�$	��Top=�$	��200���� $��general statistics��$��24,45,721,385q�.��� $	��399��$	��310��.+��� -_   $��button16��$&�� show the busiest day of the year��$��26��$
��Left=�$��	109,6,0,0q�$	��Top=�$	��188���� -`   $��button18��$'��!show the busiest week of the year��$��26��$
��Left=�$��
109,38,0,0q�$	��Top=�$	��188���� -a   $��button19��$(��"show the busiest month of the year��$��26��$
��Left=�$��
109,70,0,0q�$	��Top=�$	��188���� -b   $��button20��$(��"show the busiest year since I work��$��26��$
��Left=�$��109,102,0,0q�$	��Top=�$	��188���� -c   $��	textBox15��$��26��$
��Left=�$��6,6,0,0q�$
��yyyy��$	��Top=�$��97���� -d   $��button21��$%��show appointment graph on month��$��26��$
��Left=�$��109,134,0,0q�$	��Top=�$	��188���� -e   $��	textBox16��$��26��$
��Left=�$��	6,134,0,0q�$��mm��$	��Top=�$��97���� -f   $��button17��$$��show appointment graph on year��$��26��$��Right=�$��
0,166,13,0q�$	��Top=�$	��188���� -g   $��button22��$$��show the most used medications��$��26��$��Right=�$��
0,198,13,0q�$	��Top=�$	��188���� -h   $��button23��$"��show the most common problem��$��26��$��Right=�$��
0,230,13,0q�$	��Top=�$	��188���� -i   $��button24��$&�� show patient with max appointmts��$��26��$��Right=�$��
0,262,13,0q�$	��Top=�$	��188���� -j   $��button25��$$��show patient with max problems��$��26��$��Right=�$��
0,294,13,0q�$	��Top=�$	��188���� -k   $��button26��$#��show patient with maxim costs��$��26��$��Right=�$��
0,326,13,0q�$	��Top=�$	��188���� -l   $$��development_messages_textBlock��
�������$	��882��$
��Left=�$��1083,26,0,0q�$��dev messages��$	��Top=�$	��184��$��Visible=�$��10(�