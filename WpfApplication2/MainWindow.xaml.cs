﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Resources;
using System.Net.Mail;




namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
            

        }

        string path = @"MyPatientsList.txt";
        string path_appointments = @"MyAppointmentList.txt";
        string path_temporary_file = @"MyTemporaryFile.txt";
        string path_treatments_file = @"MyTreatmentsFile.txt";
        string path_medications = @"MyMedicationList1.txt";
        string path_equipments = @"MyEquipmentList.txt";
        string mesaj = " ";
        string search_text = "";
        int counter_fields_action_window = 0;
        Medication medication;
        
        List<string> data_appointments_hours = new List<string>()
        {
            "00:00","00:15","00:30","00:45","01:00","01:15","01:30","01:45",
            "02:00","02:15","02:30","02:45","03:00","03:15","03:30","03:45",
            "04:00","04:15","04:30","04:45","05:00","05:15","05:30","05:45",
            "06:00","06:15","06:30","06:45","07:00","07:15","07:30","07:45",
            "08:00","08:15","08:30","08:45","09:00","09:15","09:30","09:45",
            "10:00","10:15","10:30","10:45","11:00","11:15","11:30","11:45",
            "12:00","12:15","12:30","12:45","13:00","13:15","13:30","13:45",
            "14:00","14:15","14:30","14:45","15:00","15:15","15:30","15:45",
            "16:00","16:15","16:30","16:45","17:00","17:15","17:30","17:45",
            "18:00","18:15","18:30","18:45","19:00","19:15","19:30","19:45",
            "20:00","20:15","20:30","20:45","21:00","21:15","21:30","21:45",
            "22:00","22:15","22:30","22:45","23:00","23:15","23:30","23:45"
        };

        private void mouse_enter_button1(object sender, MouseEventArgs e)
        {

            mesaj = "-> mouse-ul pe button *Copiaza* <-";
            action_window_update(mesaj);

        }

        private void mouse_enter_button2(object sender, MouseEventArgs e)
        {
            mesaj = "-> mouse-ul pe button <-";
            action_window_update(mesaj);
        }


        //private void buton_1_click(object sender, RoutedEventArgs e)
        //{
        //    int flagu = 0;
        //                           
        //    //string text = textbox_1.Text.ToString();
    
        //    flagu++;

        //    add_patient_to_file();
        //    mesaj = "-> click pe but *Copiaza* <-";
        //    action_window_update(mesaj);
        //}

/*************************************************************************************
* ***********************************************************************************
* Function name:       add_patient_to_file()
* Type:                void()
* Input parameters:    no  
* Output parameters:   no
* Description:         add a new patient in patient database.
* ***********************************************************************************
*************************************************************************************/
        private void add_patient_to_file()
        {

            // This text is added only once to the file. 
            if (!File.Exists(path))
            {
                // Create a file to write to.
                string first_line = "__________________________________________________________________________" + Environment.NewLine;
                File.WriteAllText(path, first_line);
                string createText = "Nume  |" + "Prenume |" + " Data nasterii  |" + "      Adresa Strada |   Nr  |  City  | Country " + Environment.NewLine;
                File.AppendAllText(path, createText);
                File.AppendAllText(path, first_line);
            }

            string appendText = textbox_patient_firstname.Text.ToString() + " | " + textbox_patient_lastname.Text.ToString() + " | " + byrthday_date_datepicker.Text.ToString() + " | " + textBox_patient_adress_street.Text.ToString() + " | " + textBox_patient_adresa_street_number.Text.ToString() + " | " + textBox_patient_city.Text.ToString() + " | " + textBox_patient_country.Text.ToString() + Environment.NewLine;
            string appendText_for_search = textbox_patient_firstname.Text.ToString() + " | " + textbox_patient_lastname.Text.ToString() + " | " + byrthday_date_datepicker.Text.ToString() + " | " + textBox_patient_adress_street.Text.ToString()+ " " + textBox_patient_adresa_street_number.Text.ToString()+" | "+ textBox_patient_city.Text.ToString()+" | "+ textBox_patient_country.Text.ToString();
            int res = search_line_redundant(appendText_for_search);
            if (res == 2)
            {
                File.AppendAllText(path, appendText);
            }
            else if (res == 1)
            {
                MessageBox.Show("pacientul pe care vrei sa il adaugi, exista deja in baza de date!! Pacientul nu va mai fi adaugat inca o data ");
            }
            else
            {
                //do nothing
            }

        }

        private int search_line_redundant(string line_to_be_added)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            string line = "";
            int ret = 0;
            while ((line = file.ReadLine()) != null)
            {
                var position = line.IndexOf(line_to_be_added, StringComparison.InvariantCultureIgnoreCase);
                if (position > -1)
                {
                    ret = 1;
                    break;
                }
                else if (position <= -1)
                {
                    ret = 2;
                }
            }
            file.Close();
            return ret;
        }

        private void buton_3_click(object sender, RoutedEventArgs e)
        {
            write_from_file_to_textblock();
            mesaj = "-> am afisat toti pacientii <-";
            action_window_update(mesaj);
        }

        private void write_from_file_to_textblock()
        {
            string readText = File.ReadAllText(path);
            textblock_1.Text = readText;

        }

        private void buton_4_click(object sender, RoutedEventArgs e)
        {
            textblock_1.Text = "----am sters afisajul------baza de date e nealterata--------";
            mesaj = "-> sters afis toti pacientii <-";
            action_window_update(mesaj);

        }
        private void action_window_update(string str)
        {
            if (counter_fields_action_window < 65)
            {
                //action_window.Text = action_window.Text + DateTime.Now.Minute + ':' + DateTime.Now.Second + str + Environment.NewLine;
                development_messages_textBlock.Text = development_messages_textBlock.Text + DateTime.Now.Hour+':'+ DateTime.Now.Minute + ':' + DateTime.Now.Second + str + Environment.NewLine;
            }
            else
            {
                //action_window.Text = "" + '\n';
                development_messages_textBlock.Text = "" + '\n';
                counter_fields_action_window = 0;
            }

            counter_fields_action_window++;
        }

/*************************************************************************************
* ***********************************************************************************
* Function name:       button_search_click()
* Type:                void()
* Input parameters:    no  
* Output parameters:   no
* Description:         search the number of matches for a word in patient database.
* ***********************************************************************************
*************************************************************************************/
        //private void button_search_click(object sender, RoutedEventArgs e)
        //{
        //    search_text = textBox_search.Text.ToString();
        //    int result = search_word(search_text);
        //    if (result != 0)
        //    {
        //        textBlock2.Text = "cuvantul * " + search_text + " *" + " a fost gasit de " + result + " ori.";
        //    }
        //    else
        //    {
        //        textBlock2.Text = search_text + " --> nu a fost gasit in fisier! ";
        //    }
        //}

        private int search_word(string str)
        {
            //string AllText = File.ReadAllText(path);

            System.IO.StreamReader file = new System.IO.StreamReader(path);
            string line = "";
            int counter = 0;
            while ((line = file.ReadLine()) != null)
            {
                var position = line.IndexOf(str, StringComparison.InvariantCultureIgnoreCase);
                if (position > -1)
                {
                    counter++;
                }
            }

            return counter;
        }

/*************************************************************************************
* ***********************************************************************************
* Function name:       button2_click_search_all_about()
* Type:                void()
* Input parameters:    no  
* Output parameters:   no
* Description:         search all lines in patient database and show the results in textblock
* ***********************************************************************************
*************************************************************************************/
        //private void button2_click_search_all_about(object sender, RoutedEventArgs e)
        //{
        //    search_text = textBox_search.Text.ToString();
        //    textBlock2.Text = " ";// +Environment.NewLine;
        //    search_all_about_the_word(search_text);


        //}

        //private void search_all_about_the_word(string str)
        //{
        //    var vector = new string[10];
        //    int i = 0;
        //    string tot_textul = " ";

        //    System.IO.StreamReader file = new System.IO.StreamReader(path);
        //    string line = "";
        //    while ((line = file.ReadLine()) != null)
        //    {
        //        var position = line.IndexOf(str, StringComparison.InvariantCultureIgnoreCase);
        //        if (position > -1)
        //        {
        //            vector[i] = line;
        //            i++;
        //        }
        //    }

        //    if (i == 0)
        //    {
        //        textBlock2.Text = "nici un pacient care sa aiba acest cuvant in descriere ";
        //    }
        //    else
        //    {
        //        while (i >= 0)
        //        {
        //            tot_textul = tot_textul + " " + vector[i] + "\n";
        //            i--;
        //        }
        //        textBlock2.Text = tot_textul;
        //    }
        //}

/*************************************************************************************
* ***********************************************************************************
* Function name:       Click_delete_patient_from_file()
* Type:                void()
* Input parameters:    no  
* Output parameters:   no
* Description:         delete a patient from patient database.
* ***********************************************************************************
*************************************************************************************/
        private void Click_delete_patient_from_file(object sender, RoutedEventArgs e)
        {
            //string cuvant = textbox_delete_word.Text.ToString();
            //delete_patient_from_file(cuvant);
            
                        //string cuvant = listbox_patients_to_be_deleted.SelectedItem.ToString();
            //delete_patient_from_file(cuvant);
            if (File.Exists(path))
            {
                if (listbox_patients_to_be_deleted.HasItems)
                {
                    string item_selectat_din_listbox = listbox_patients_to_be_deleted.SelectedItem.ToString();
                    int index_de_sters = listbox_patients_to_be_deleted.SelectedIndex;

                    //aici stergem pe bune din fisier..
                    string path_temporary_file = System.IO.Path.GetTempFileName();
                    System.IO.StreamReader file = new System.IO.StreamReader(path);
                    System.IO.StreamWriter file_temporary = new System.IO.StreamWriter(path_temporary_file);
                    string line = "";
                    while ((line = file.ReadLine()) != null)
                    {

                        var position = line.IndexOf(item_selectat_din_listbox, StringComparison.InvariantCultureIgnoreCase);
                        if (position > -1)
                        {
                            // daca data selectata se afla in linie, nu copiem acea linie in fisierul temporar 
                            line = "asa da - ceva am gasit";
                        }
                        else
                        {
                            //data selectata nu se gaseste in linia asta, deci linia asta tre sa ramana in fisier
                            file_temporary.WriteLine(line);
                        }
                    }

                    file.Close();
                    file_temporary.Close();
                    File.Delete(path);
                    File.Move(path_temporary_file, path);

                    //la final vreau sa si sterg itemul selectat din listbox

                    listbox_patients_to_be_deleted.Items.RemoveAt(index_de_sters);
                }
                else
                {
                    MessageBox.Show("You must search a patient first! After that you can delete it!", "Attention!");
                }
            }
            else
            {
                MessageBox.Show(" There is no patient set in database yet. You have nothing to delete!", "Atention!");
            }

            


            mesaj = "-> apasat buton *Sterge* <-";
            action_window_update(mesaj);
        }

        private void delete_patient_from_file(string cuvant)
        {
            string message1 = " esti sigur ca vrei sa stergi toate liniile care contin * ";
            message1 = message1 + cuvant;
            string message2 = " * ?";
            string message3 = message1 + message2;
            string title_message_box = "esti tu sigur de ce vrai sa fashi?";
            var lista_numar_linie = new List<int>();
            int i = 0;
            int numar_linie = 0;
            MessageBoxResult result = 0;
            string str_temp = "";
            int j = 1;
            string line_to_delete = "";
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            //string nu_sterge_linia_asta = "Nume  Prenume  Data nasterii        Adresa";

            while ((line_to_delete = file.ReadLine()) != null)
            {
                var position = line_to_delete.IndexOf(cuvant, StringComparison.InvariantCultureIgnoreCase);
                if (position > -1)
                {
                    lista_numar_linie.Add(numar_linie);
                    i++;
                }
                else
                {
                    //
                }
                numar_linie++;

            }

            lista_numar_linie.Reverse();
            var lista_numar_linie_inversata = lista_numar_linie;
            int[] vector_numar_linie = lista_numar_linie_inversata.ToArray();
            file.Close();

            if (i > 0)
            {
                result = MessageBox.Show(message3, title_message_box, MessageBoxButton.YesNo, MessageBoxImage.Question);
            }
            else
            {
                MessageBox.Show("there are no fields to contain * " + cuvant + " *!", "fii fara de grija ;)");
            }
            // If the no button was pressed ...
            if (result == MessageBoxResult.No)
            {
                // nu stergem nimic
            }
            else if (result == MessageBoxResult.Yes)
            {
                //line_to_delete.Remove(0, 100);
                while (i >= 0)
                {
                    j = i;
                    i--;
                    if (j > 0)
                    {
                        str_temp = str_temp + "linia -->" + vector_numar_linie[j - 1] + ",";
                        j--;
                    }
                }

                delete_lines_from_file_by_number(vector_numar_linie);
                MessageBox.Show(str_temp + "... am sters toate campurile ce contin *" + cuvant + " * !");
            }
            else
            {
                //do nothing - nu mai exista un alt result la message box
            }

            mesaj = "-> apasat buton *Sterge* <-";
            action_window_update(mesaj);


        }

        private void delete_lines_from_file_by_number(int[] vector)
        {
            int i = 0;
            var linesList = File.ReadAllLines(path).ToList();
            int vector_length = vector.Length;
            while (i < vector_length)
            {
                linesList.RemoveAt(vector[i]);
                i++;
            }

            File.WriteAllLines(path, linesList.ToArray());
        }

        private void functie_logare(object sender, SelectionChangedEventArgs e)
        {
            
        }

/*************************************************************************************
* ***********************************************************************************
* Function name:       verifica_pacient_database()
* Type:                void()
* Input parameters:    no  
* Output parameters:   no
* Description:         verify if a patient is present in patient database.
* ***********************************************************************************
*************************************************************************************/
        private int verifica_pacient_database(string nume_pacient)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            string line = "";
            int flagul = 0;
            ListBox box_list = new ListBox();
            while ((line = file.ReadLine()) != null)
            {
                //var result = search_name_in_line(nume_pacient, line);

                var position = line.IndexOf(nume_pacient, StringComparison.InvariantCultureIgnoreCase);
                if (position > -1)
                {
                    flagul = 1;
                }
            }

            if (flagul == 0)
            {
                MessageBox.Show("nu exista nici un pacient cu numele asta... Pas 1. Introduceti pacientul in baza de date; Pas 2. Programati din nou o data valida pentru acest nou pacient");
            }
            else if (flagul == 1)
            {
                MessageBox.Show("pacientul " + nume_pacient + " exista in database si putem face o programare pentru el");
                //box_list.
            }
            //!!!!!!!! nars - aici mai am de lucrat.. sa vada daca exista exact numele in database.... cu Contain...
            return flagul;
        }

        private int search_name_in_line(string name, string line)
        {
            //while(line);
            return 1;
        }

        private void functie_data_schimbata(object sender, SelectionChangedEventArgs e)
        {
            //var text_date = datePicker1.Text.ToString();
            //MessageBox.Show("am schimbat data -->" + text_date);
        }

/*************************************************************************************
* ***********************************************************************************
* Function name:       func_extract_date_of_appointment()
* Returned Type:       string
* Input parameters:    string  
* Output parameters:   
* * Description:       extract the start time of an appointment from a line.  
* ***********************************************************************************
*************************************************************************************/
        private string func_extract_date_of_appointment(string line)
        {
            string date_appointment = "";
            int i = 0, j = 0;// k = 0;
            char[] a = line.ToCharArray();
            char[] b = new char[10];

            while (a[i] != '>')
            {
                if (a[i] == '|')
                {
                    j++;
                }

                if (j == 1)
                {
                    b[0] = a[i + 1];
                    b[1] = a[i + 2];
                    b[2] = a[i + 3];
                    b[3] = a[i + 4];
                    b[4] = a[i + 5];
                    b[5] = a[i + 6];
                    b[6] = a[i + 7];
                    b[7] = a[i + 8];
                    b[8] = a[i + 9];
                    b[9] = a[i + 10];
                    j = 2;
                }

                i++;
            }

            date_appointment = new string(b);

            return date_appointment;
        }

                private string func_extract_date_of_birth_for_patient(string line)
        {
            string date_appointment = "";
            int i = 0, j = 0;// k = 0;
            char[] a = line.ToCharArray();
            char[] b = new char[10];

            while (a[i] != '/')
            {
                if (a[i] == '|')
                {
                    j++;
                }

                if (j == 2)
                {
                    b[0] = a[i + 1];
                    b[1] = a[i + 2];
                    b[2] = a[i + 3];
                    b[3] = a[i + 4];
                    b[4] = a[i + 5];
                    b[5] = a[i + 6];
                    b[6] = a[i + 7];
                    b[7] = a[i + 8];
                    b[8] = a[i + 9];
                    j = 3;
                }

                i++;
            }

            date_appointment = new string(b);

            return date_appointment;
        }

        public int func_position_of_maxim_value_in_array(int[] vector)
        {
            int pos_array = 0;
            int max = 0;

            for(int i = 0; i< vector.Length;i++)
            {
                if(max < vector[i])
                {
                    max = vector[i];
                    pos_array = i;
                }
            }

            return pos_array;
        }

        public string func_busiest_day_of_the_year()
        {

            //string o_data = DateTime.Now.ToString("dd/MM/yyyy");
            var zile_an = new int[365];
            int lineindex = 0;

            System.IO.StreamReader file = new System.IO.StreamReader(path_appointments);
            string line = "";
            while ((line = file.ReadLine()) != null)
            {
                lineindex++;
                if (lineindex > 3)
                {
                    var date_of_appointment_line = func_extract_date_of_appointment(line);
                    DateTime datetime_date_appointment = DateTime.ParseExact(date_of_appointment_line, "dd.MM.yyyy",
                                       System.Globalization.CultureInfo.InvariantCulture);
                    //var datetime_date_appointment = Convert.ToDateTime(date_of_appointment_line);
                    var zi_an = datetime_date_appointment.DayOfYear;
                    zile_an[zi_an] = zile_an[zi_an] + 1;
                }
                                
            }
            file.Close();

            var pos_max = func_position_of_maxim_value_in_array(zile_an);                    
            int year = DateTime.Now.Year; //Or any year you want
            DateTime theDate = new DateTime(year, 1, 1).AddDays(pos_max - 1);
            string b = theDate.ToString("dd/MM/yyyy");   // The date in requested format

            return b;

        }
        private void delete_statistics_graphics_button(object sender, RoutedEventArgs e)
        {
            delete_statistics_graphic();
        }

        private void click_busiest_day_of_the_year(object sender, RoutedEventArgs e)
        {
            var busiest_day_in_database = func_busiest_day_of_the_year();
            MessageBox.Show("The busiest day in clinique history is --> "+ busiest_day_in_database);
        }

        private void click_delete_treatment(object sender, RoutedEventArgs e)
        {
            if (File.Exists(path_treatments_file))
            {
                if (listbox_treatments_to_be_deleted.HasItems)
                {
                    string item_selectat_din_listbox = listbox_treatments_to_be_deleted.SelectedItem.ToString();
                    int index_de_sters = listbox_treatments_to_be_deleted.SelectedIndex;

                    //aici stergem pe bune din fisier..
                    string path_temporary_file = System.IO.Path.GetTempFileName();
                    System.IO.StreamReader file = new System.IO.StreamReader(path_treatments_file);
                    System.IO.StreamWriter file_temporary = new System.IO.StreamWriter(path_temporary_file);
                    string line = "";
                    while ((line = file.ReadLine()) != null)
                    {

                        var position = line.IndexOf(item_selectat_din_listbox, StringComparison.InvariantCultureIgnoreCase);
                        if (position > -1)
                        {
                            // daca data selectata se afla in linie, nu copiem acea linie in fisierul temporar 
                            line = "asa da - ceva am gasit";
                        }
                        else
                        {
                            //data selectata nu se gaseste in linia asta, deci linia asta tre sa ramana in fisier
                            file_temporary.WriteLine(line);
                        }
                    }

                    file.Close();
                    file_temporary.Close();
                    File.Delete(path_treatments_file);
                    File.Move(path_temporary_file, path_treatments_file);

                    //la final vreau sa si sterg itemul selectat din listbox

                    listbox_treatments_to_be_deleted.Items.RemoveAt(index_de_sters);
                }
                else
                {
                    MessageBox.Show("You must search an treatment first! After that you can delete it!", "Attention!");
                }
            }
            else
            {
                MessageBox.Show(" There is no treatment set in database yet. You have nothing to delete!", "Atention!");
            }

        }

       

        /*************************************************************************************
        * ***********************************************************************************
        * Function name:       button_write_all_appointments_in_textbox()
        * Type:                void()
        * Input parameters:    no  
        * Output parameters:   no
        * Description:         gets all of the booked appointments and shows them in a textblock... for development purpose. 
        * ***********************************************************************************
        *************************************************************************************/
        private void button_write_all_a_in_textbox(object sender, RoutedEventArgs e)
        {
            if (File.Exists(path_appointments))
            {
                write_appointements_from_file_to_textblock();
            }
            else
            {
                MessageBox.Show("There is no appointment set in database. Nothing to show yet!", "Atention!");
            }


        }

        private void write_treatments_from_file_to_textblock()
        {
            string readText = File.ReadAllText(path_treatments_file);
            all_treatments_textBlock.Text = readText;

        }


        private void write_medications_from_file_to_textblock()
        {
            string readText = File.ReadAllText(path_medications);
            all_medications_textBlock.Text = readText;

        }


        private void click_delete_appointment_from_database(object sender, RoutedEventArgs e)
        {
            if (File.Exists(path_appointments))
            {
                if (listbox_appointments_to_be_deleted.HasItems)
                {
                    string item_selectat_din_listbox = listbox_appointments_to_be_deleted.SelectedItem.ToString();
                    string date_to_be_deleted = func_extract_date_of_appointment(item_selectat_din_listbox);
                    int index_de_sters = listbox_appointments_to_be_deleted.SelectedIndex;

                    //aici stergem pe bune din fisier..
                    string path_temporary_file = System.IO.Path.GetTempFileName();
                    System.IO.StreamReader file = new System.IO.StreamReader(path_appointments);
                    System.IO.StreamWriter file_temporary = new System.IO.StreamWriter(path_temporary_file);
                    string line = "";
                    while ((line = file.ReadLine()) != null)
                    {

                        var position = line.IndexOf(item_selectat_din_listbox, StringComparison.InvariantCultureIgnoreCase);
                        if (position > -1)
                        {
                            // daca data selectata se afla in linie, nu copiem acea linie in fisierul temporar 
                            line = "asa da - ceva am gasit";
                        }
                        else
                        {
                            //data selectata nu se gaseste in linia asta, deci linia asta tre sa ramana in fisier
                            file_temporary.WriteLine(line);
                        }
                    }

                    file.Close();
                    file_temporary.Close();
                    File.Delete(path_appointments);
                    File.Move(path_temporary_file, path_appointments);

                    //la final vreau sa si sterg itemul selectat din listbox

                    listbox_appointments_to_be_deleted.Items.RemoveAt(index_de_sters);
                }
                else
                {
                    MessageBox.Show("You must search an appointment first! After that you can delete it!","Attention!");
                }
            }
            else
            {
                MessageBox.Show(" There is no appointment set in database yet. You have nothing to delete!","Atention!");
            }

        }

        private void button_add_new_equipments(object sender, RoutedEventArgs e)
        {
            add_new_equipment();
        }

        private void add_new_equipment()
        {

            // This text is added only once to the file. 
            if (!File.Exists(path_equipments))
            {
                // Create a file to write to. 
                string createText = "____________________________________________________________________________________________________________________________________________________________________________________________________________________________" + Environment.NewLine;
                // File.WriteAllText(path_appointments, createText);
                string createText1 = "Serial Number |"+ " Eq. name |" + "  Provider |"+" Size |"+" Weight |"+" Material |"+" Date of manufacturing |"+ " Date of aquisition |"+ " Quantity(pieces) |" + " Price(country(where application is used) currency ) |" + Environment.NewLine;
                //File.WriteAllText(path_appointments, createText1);
                string createText2 = "___________________________________________________________________________________________________________________________________________________________________________________________________________________________" + Environment.NewLine;
                string allText = createText + createText1 + createText2;
                File.WriteAllText(path_equipments, allText);
            }

            string name_equipment = textBox_Equipment_Serial_Number.Text.ToString() + " | " + add_new_equipment_name_textBox.Text.ToString() + " | " + textBox_Equipment_Provider.Text.ToString() + " | " + textBox_Equipment_Size.Text.ToString() + " | " + textBox_Equipment_Weight.Text.ToString() + " | " + textBox_Equipment_Material.Text.ToString() + " | " + datepicker_Manufacturing_date_equipment.Text.ToString() + " | " + datepicker_Aquisition_date_equipment.Text.ToString() + " | " + textBox_Equipment_Quantity.Text.ToString() + " | " + textBox_Equipment_Price.Text.ToString() + Environment.NewLine;
            if (name_equipment != "")
            {
                File.AppendAllText(path_equipments, name_equipment);
                MessageBox.Show(" new equipment * " + add_new_equipment_name_textBox.Text.ToString() + " * was added!", "Correct!");
            }
            else
            {
                MessageBox.Show(" no equipment to be added", "Wrong!");
            }
        }

        private void click_delete_equipment(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("in curand va fi implementat si acest feature.. putintica rabdare;) ");
        }


        private void mouse_enter_appointment_tab(object sender, MouseEventArgs e)
        {
            MessageBox.Show("acuma am deschis tab de appointmenturi ;) !!");
        }

        private void welcome_tab_mouseup(object sender, MouseButtonEventArgs e)
        {
            mesaj = "->intrat in welcome tab<-";
            action_window_update(mesaj);
        }

        private void patient_tab_mouseup(object sender, MouseButtonEventArgs e)
        {
            mesaj = "->intrat in patient tab<-";
            action_window_update(mesaj);
        }

        private void appointments_tab_mouseup(object sender, MouseButtonEventArgs e)
        {
            //mesaj = "->intrat in appointment tab<-";
            //action_window_update(mesaj);
        }

        private void treatments_tab_mouseup(object sender, MouseButtonEventArgs e)
        {
            mesaj = "->intrat in treatments tab<-";
            action_window_update(mesaj);
        }

        private void medications_tab_mouseup(object sender, MouseButtonEventArgs e)
        {
            mesaj = "->intrat in medications tab<-";
            action_window_update(mesaj);
        }

        private void equipments_tab_mouseup(object sender, MouseButtonEventArgs e)
        {
            mesaj = "->intrat in equipments tab<-";
            action_window_update(mesaj);
        }

        private void statistics_tab_mouseup(object sender, MouseButtonEventArgs e)
        {
            mesaj = "->intrat in statistics tab<-";
            action_window_update(mesaj);
        }

/*************************************************************************************
* ***********************************************************************************
* Function name:       func_datepicker_check_text_no_empty()
* Type:                bool
* Input parameters:    DatePicker object  
* Output parameters:   bool return
* Description:         make sure that a datepicker textbox is not empty.. so  the user  choose a valid date.
* ***********************************************************************************
*************************************************************************************/
        public bool func_datepicker_check_text_no_empty(DatePicker datepicker)
        {
            bool ret = false;

            if(datepicker.Text == "")
            {
                ret = true;
            }
           
            return ret;
        }

/*************************************************************************************
* ***********************************************************************************
* Function name:       func_textbox_check_text_no_empty()
* Type:                bool
* Input parameters:    TextBox object  
* Output parameters:   bool return
* Description:         make sure that a textbox is not empty.. so  the user add a valid medication to database.
* ***********************************************************************************
*************************************************************************************/
        public bool func_textbox_check_text_no_empty(TextBox textbox)
        {
            bool ret = false;

            if (textbox.Text == "")
            {
                ret = true;
            }

            return ret;
        }

        private void button_add_medication(object sender, RoutedEventArgs e)
        {
            DateTime ee, f;
            string a ="", b="";
            int c = 0;
            int d = 0;
            mesaj = "->apasat add medication button<-";
            action_window_update(mesaj);

            var rett1 = func_textbox_check_text_no_empty(medication_name_textBox);
            var rett2 = func_textbox_check_text_no_empty(medication_provider_textBox);
            var rett3 = func_textbox_check_text_no_empty(medication_quantity_textbox);
            var rett4 = func_textbox_check_text_no_empty(medication_cost_textBox);
            var rett5 = func_datepicker_check_text_no_empty(medication_manufacturing_date_datepicker);
            var rett6 = func_datepicker_check_text_no_empty(medication_aquisition_date_datepicker);
            rett1 = rett1 | rett2;
            rett1 = rett1 | rett3;
            rett1 = rett1 | rett4;
            rett1 = rett1 | rett5;
            rett1 = rett1 | rett6;
            var rett7 = rett1;//use this to know if all the textboxes are filled with values.. so the textboxes are not empty


            if (rett6 == false)
            { 
                a = medication_name_textBox.Text.ToString();
                b = medication_provider_textBox.Text.ToString();
                c = Convert.ToInt32(medication_quantity_textbox.Text);
                d = Convert.ToInt32(medication_cost_textBox.Text);
            }
                    
            if (func_datepicker_check_text_no_empty(medication_manufacturing_date_datepicker) == false)
            {
                ee = Convert.ToDateTime(medication_manufacturing_date_datepicker.Text);
            }
            else
            {
                //MessageBox.Show("You must enter a valid date.. The manufacturing date textbox is empty OR the medication name/provider/cost/quantity is not set!");
                ee = DateTime.Now;
            }

            if ( func_datepicker_check_text_no_empty(medication_aquisition_date_datepicker) == false)
            {
                f = Convert.ToDateTime(medication_aquisition_date_datepicker.Text);
            }
            else
            {
                //MessageBox.Show("You must enter a valid date of aquisition..the aquisition date textbox is empty!");
                f = DateTime.Now;
            }

            //now call the constructor for the Medication class
            medication = new Medication(a,b,c,d,ee,f);
            
            //here is the piece of code which inserts a new medication to medications database
            if (!File.Exists(path_medications))
            {
                // Create a file to write to. 
                string createText = "Medication name    " + "Provider " + "  Manufacturing date    " + " Aquisition date      " + " Quantity  " + "      Cost " + Environment.NewLine;
                File.WriteAllText(path_medications, createText);
                string delimiter = "________________________________________________________________________________________________________________________"+ Environment.NewLine;
                File.AppendAllText (path_medications, delimiter);
            }

            var ret1 = medication.Medication_verify_date_of_aquisition_accepted();
            var ret2 = medication.Medication_verify_date_of_manufacturing_accepted();
            var ret3 = medication.Medication_verify_price();
            var ret4 = medication.Medication_verify_quantity();

            if (rett7 == false)//all the texboxes are filled with something)
            {
                if (ret1 == false)
                {
                    if (ret2 == false)
                    {
                        if (ret3 == false)
                        {
                            if (ret4 == false)
                            {
                                string medication_class_text = medication.medication_name + " | " + medication.medication_provider + " | " + medication.date_of_manufacturing + " | " + medication.date_of_aquisition + " | " + medication.quantity + " | " + medication.cost + Environment.NewLine;
                                File.AppendAllText(path_medications, medication_class_text);
                                MessageBox.Show("A new medication was inserted with success in Medication database!", "Successfull process!");
                            }
                            else
                            {
                                MessageBox.Show("please enter a new *quantity* value! the quantity you inserted is a negative value. Please enter a value > 0!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("please enter a new *price* value! the price you entered is not a positive one. Please enter value > 0!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("please enter a new *manufacturing date* value! the date of manufacturing should be newer than 01.01.2015! Otherwise, the medication is already expired!");
                    }
                }
                else
                {
                    MessageBox.Show("please enter a new *aquisition date* value! the date of aquisition should be newer than date of manufacturing!");
                }
            }
            else
            {
                MessageBox.Show("please enter valid values for name/provider/cost/quantity/aquisition date/manufacturing date.. these fields seems to be empty..so, no medication is added until you fill the fields. ");
            }
            
        }

        private void push_and_new_window_appears(object sender, RoutedEventArgs e)
        {
            Window fereastra_noua = new Window();
            fereastra_noua.Content = "asta e o noua fereastra";
            fereastra_noua.Title = "fereastra noua";
            Canvas canvas_noua = new Canvas();
            Polyline polyline_nou = new Polyline();
            SolidColorBrush blackBrush = new SolidColorBrush();
            blackBrush.Color = Colors.Black;

            
            System.Windows.Point punct_nou_1 = new System.Windows.Point(10, 100);
            System.Windows.Point punct_nou_2 = new System.Windows.Point(100, 200);
            System.Windows.Point punct_nou_3 = new System.Windows.Point(200, 30);
            System.Windows.Point punct_nou_4 = new System.Windows.Point(50, 330);
            System.Windows.Point punct_nou_5 = new System.Windows.Point(330, 60);

            polyline_nou.StrokeThickness = 5;
            polyline_nou.Stroke = blackBrush;

            PointCollection polygonPoints = new PointCollection();
            polygonPoints.Add( punct_nou_1 );
            polygonPoints.Add( punct_nou_2 );
            polygonPoints.Add( punct_nou_3 );
            polygonPoints.Add(punct_nou_4);
            polygonPoints.Add(punct_nou_5);

            /*polyline_nou.Points.Add(punct_nou_1);
            polyline_nou.Points.Add(punct_nou_2);
            polyline_nou.Points.Add(punct_nou_3);
            */

            polyline_nou.Points = polygonPoints;
            
            canvas_noua.Children.Add(polyline_nou);

            //fereastra_noua.Content = canvas_noua;
            var Statistics_2 = new Statistics();
            //var textbun = medication.date_of_manufacturing.ToString();
            Statistics_2.textblock_statistics_window.Text = medication_manufacturing_date_datepicker.Text.ToString();

            Statistics_2.ShowDialog();
            
        }

        private void button_delete_all_appointments_in_textblock(object sender, RoutedEventArgs e)
        {
            textBlock_all_appointments.Text = "----am sters afisajul------baza de date e nealterata--------";
        }
        private void graphic_2D_works_ok(object sender, RoutedEventArgs e)
        {
            var years = get_vector_years();
            var appointments = get_vector_appointments();
            show_graphic_2D_works_ok(years, appointments);
            //MessageBox.Show("ceva nu merge bine cu datele appointmenturilor....lucreaza la Statistics");
        }

        

        
        private void show_graph_nr_of_appointments_per_month(object sender, RoutedEventArgs e)
        {
            var years = get_vector_years();
            //var appointments = get_vector_appointments_per_month();//asta merge
            var appointments_matrix = get_matrix_appointments_per_month();
            //show_graphic_2D_works_appointments_per_months(years, appointments);
            //show_graphic_2D_works_ok_matrix(years, appointments_matrix);
            show_graphic_2D_works_appointments_per_months_matrix(years, appointments_matrix);
            
            //MessageBox.Show("ceva nu merge bine cu datele appointmenturilor....lucreaza la Statistics");
        }

        private void delete_graphic(object sender, RoutedEventArgs e)
        {
            delete_statistics_graphic();
        }
        
        
        private void Pick_start_hour_appointment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;

            Pick_stop_hour_appointment.ItemsSource = data_appointments_hours;
            var string_stop_hour = Pick_stop_hour_appointment.SelectedItem.ToString();
            var valoarea_selectata_acum_start_hour = comboBox.SelectionBoxItem;
            var index_selectat_acum_start_hour = comboBox.SelectedIndex;
            var string_start_hour = valoarea_selectata_acum_start_hour.ToString();
              if (string_start_hour == "")
            {
                string_start_hour = "09:00";
            }
            DateTime dt_start_hour = Convert.ToDateTime(string_start_hour);
            DateTime dt_stop_hour = Convert.ToDateTime(string_stop_hour);

            var interval_start = (dt_start_hour - dt_stop_hour).TotalMinutes;
            var interval_start_inverse = (dt_stop_hour - dt_start_hour).TotalMinutes;
                     
            Pick_stop_hour_appointment.SelectedIndex = index_selectat_acum_start_hour + 4;                    


        }

        private void Pick_start_hour_appointment_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>();


            //as vrea aici sa apara doar orele disponibile din start.. cumva intervalele orare care nu mai sunt disponibile
            //sa nu mai apara din start in lista
            
            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = data_appointments_hours;
            comboBox.SelectedIndex = 32;
                        
        }

        private void button_set_new_treatment(object sender, RoutedEventArgs e)
        {

        }
        
               private void Pick_stop_hour_appointment_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>();

            //as vrea aici sa apara doar orele disponibile din start.. cumva intervalele orare care nu mai sunt disponibile
            //sa nu mai apara din start in lista

            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = data_appointments_hours;
            comboBox.SelectedIndex = 36;
        }

        private void Pick_stop_hour_appointment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            
            Pick_start_hour_appointment.ItemsSource = data_appointments_hours;
            var string_start_hour = Pick_stop_hour_appointment.SelectedItem.ToString();
            var valoarea_selectata_acum_stop_hour = comboBox.SelectionBoxItem;
            var index_selectat_acum_stop_hour = comboBox.SelectedIndex;
            var string_stop_hour = valoarea_selectata_acum_stop_hour.ToString();
                        
            //Pick_start_hour_appointment.SelectedIndex = index_selectat_acum_stop_hour - 4;              

        }

        private void appointment_delete_date_colors_notification(object sender, MouseEventArgs e)
        {
            datepicker_date_appointment.BorderThickness = new Thickness(1.0);
            datepicker_date_appointment.BorderBrush = Brushes.Gray;
        }

        private void appointments_delete_colorss_notification_first_name(object sender, MouseEventArgs e)
        {
            textBox_appointments_patient.BorderThickness = new Thickness(1.0);
            textBox_appointments_patient.BorderBrush = Brushes.Gray;
        }

        private void appointments_delete_colorss_notification_last_name(object sender, MouseEventArgs e)
        {
            textbox_firstname_appointment.BorderThickness = new Thickness(1.0);
            textbox_firstname_appointment.BorderBrush = Brushes.Gray;
        }

               
        private void clear_colors_notification_start_time_combobox(object sender, MouseEventArgs e)
        {
            Pick_start_hour_appointment.BorderThickness = new Thickness(1.0);
            Pick_start_hour_appointment.BorderBrush = Brushes.LightGray;

        }

        private void clear_colors_notification_stop_time_combobox(object sender, MouseEventArgs e)
        {
            Pick_stop_hour_appointment.BorderThickness = new Thickness(1.0);
            Pick_stop_hour_appointment.BorderBrush = Brushes.LightGray;
        }

        private void selectie_o_linie_din_listbox(object sender, SelectionChangedEventArgs e)
        {
            
        }
        
                private void keyUP_lastname_focus_search_appointments(object sender, KeyEventArgs e)
        {
            List<string> lines = new List<string>();
            
            /* cod bun de folosit !!!!!!! */
            //aici vreau sa caut lastname sau data si instant sa se populeze listboxul...
            /******************************************************************************************/
            //func_search_last_name_in_appointments_db(appointment_last_name_delete_textBox.Text.ToString());
            //func_search_first_name_in_appointments_db(appointment_first_name_delete_textBox.Text.ToString());
            int scenariu = 100;
            var data_app = datepicker_date_appointment_for_clear.Text.ToString();
            var last_name = appointment_last_name_delete_textBox.Text.ToString();
            var first_name = appointment_first_name_delete_textBox.Text.ToString();

            //delete the listbox complete
            listbox_appointments_to_be_deleted.Items.Clear();

            if (last_name != "")
            {
                scenariu = 1;
            }
            if (first_name != "")
            {
                scenariu = 2;
            }
            if (data_app != "")
            {
                scenariu = 3;
            }
            if ((last_name != "") && (first_name != ""))
            {
                scenariu = 4;
            }
            if ((last_name != "") && (first_name != "") && (data_app != ""))
            {
                scenariu = 5;
            }

            switch (scenariu)
            {
                case 1:
                    {
                        var toata_cautarea = func_get_all_lines_with_today_date_in_list(last_name);
                        foreach (var item in toata_cautarea)
                        {
                            listbox_appointments_to_be_deleted.Items.Add(item);
                            listbox_appointments_to_be_deleted.Background = Brushes.LightPink;
                        }
                        break;
                    }
                case 2:
                    {
                        var toata_cautarea = func_get_all_lines_with_today_date_in_list(first_name);
                        foreach (var item in toata_cautarea)
                        {
                            listbox_appointments_to_be_deleted.Items.Add(item);
                        }
                        break;
                    }
                case 3:
                    {
                        data_app = Convert.ToDateTime(data_app).ToString("dd.MM.yyyy");
                        //func_search_date_of_appointment_in_db(data_app);
                        var toata_cautarea = func_get_all_lines_with_today_date_in_list(data_app);
                        foreach (var item in toata_cautarea)
                        {
                            listbox_appointments_to_be_deleted.Items.Add(item);
                        }
                        break;
                    }
                case 4:
                    {
                        var lastname_and_firstname = last_name + " " + first_name;
                        var toata_cautarea = func_get_all_lines_with_today_date_in_list(lastname_and_firstname);
                        foreach (var item in toata_cautarea)
                        {
                            listbox_appointments_to_be_deleted.Items.Add(item);
                        }
                        break;
                    }
                case 5:
                    {
                        data_app = Convert.ToDateTime(data_app).ToString("dd.MM.yyyy");
                        var lastname_and_firstname_and_date = last_name + " " + first_name + "  |" + data_app;
                        var toata_cautarea = func_get_all_lines_with_today_date_in_list(lastname_and_firstname_and_date);
                        foreach (var item in toata_cautarea)
                        {
                            listbox_appointments_to_be_deleted.Items.Add(item);
                        }
                        break;
                    }
            }
        }

        
        private void KeyUP_firstname_search_appointments(object sender, KeyEventArgs e)
        {
            List<string> lines = new List<string>();
            
            /* cod bun de folosit !!!!!!! */
            //aici vreau sa caut lastname sau data si instant sa se populeze listboxul...
            /******************************************************************************************/
            //func_search_last_name_in_appointments_db(appointment_last_name_delete_textBox.Text.ToString());
            //func_search_first_name_in_appointments_db(appointment_first_name_delete_textBox.Text.ToString());
            int scenariu = 100;
            var data_app = datepicker_date_appointment_for_clear.Text.ToString();
            var last_name = appointment_last_name_delete_textBox.Text.ToString();
            var first_name = appointment_first_name_delete_textBox.Text.ToString();

            //delete the listbox complete
            listbox_appointments_to_be_deleted.Items.Clear();

            if (last_name != "")
            {
                scenariu = 1;
            }
            if (first_name != "")
            {
                scenariu = 2;
            }
            if (data_app != "")
            {
                scenariu = 3;
            }
            if ((last_name != "") && (first_name != ""))
            {
                scenariu = 4;
            }
            if ((last_name != "") && (first_name != "") && (data_app != ""))
            {
                scenariu = 5;
            }

            switch (scenariu)
            {
                case 1:
                    {
                        var toata_cautarea = func_get_all_lines_with_today_date_in_list(last_name);
                        foreach (var item in toata_cautarea)
                        {
                            listbox_appointments_to_be_deleted.Items.Add(item);
                            listbox_appointments_to_be_deleted.Background = Brushes.LightPink;
                        }
                        break;
                    }
                case 2:
                    {
                        var toata_cautarea = func_get_all_lines_with_today_date_in_list(first_name);
                        foreach (var item in toata_cautarea)
                        {
                            listbox_appointments_to_be_deleted.Items.Add(item);
                        }
                        break;
                    }
                case 3:
                    {
                        data_app = Convert.ToDateTime(data_app).ToString("dd.MM.yyyy");
                        //func_search_date_of_appointment_in_db(data_app);
                        var toata_cautarea = func_get_all_lines_with_today_date_in_list(data_app);
                        foreach (var item in toata_cautarea)
                        {
                            listbox_appointments_to_be_deleted.Items.Add(item);
                        }
                        break;
                    }
                case 4:
                    {
                        var lastname_and_firstname = last_name + " " + first_name;
                        var toata_cautarea = func_get_all_lines_with_today_date_in_list(lastname_and_firstname);
                        foreach (var item in toata_cautarea)
                        {
                            listbox_appointments_to_be_deleted.Items.Add(item);
                        }
                        break;
                    }
                case 5:
                    {
                        data_app = Convert.ToDateTime(data_app).ToString("dd.MM.yyyy");
                        var lastname_and_firstname_and_date = last_name + " " + first_name + "  |" + data_app;
                        var toata_cautarea = func_get_all_lines_with_today_date_in_list(lastname_and_firstname_and_date);
                        foreach (var item in toata_cautarea)
                        {
                            listbox_appointments_to_be_deleted.Items.Add(item);
                        }
                        break;
                    }
            }
        }

        private void KeyUP_date_appointment_search_appointments(object sender, KeyEventArgs e)
        {
            List<string> lines = new List<string>();
            
            /* cod bun de folosit !!!!!!! */
            //aici vreau sa caut lastname sau data si instant sa se populeze listboxul...
            /******************************************************************************************/
            //func_search_last_name_in_appointments_db(appointment_last_name_delete_textBox.Text.ToString());
            //func_search_first_name_in_appointments_db(appointment_first_name_delete_textBox.Text.ToString());
            int scenariu = 100;
            var data_app = datepicker_date_appointment_for_clear.Text.ToString();
            var last_name = appointment_last_name_delete_textBox.Text.ToString();
            var first_name = appointment_first_name_delete_textBox.Text.ToString();

            //delete the listbox complete
            listbox_appointments_to_be_deleted.Items.Clear();

            if (last_name != "")
            {
                scenariu = 1;
            }
            if (first_name != "")
            {
                scenariu = 2;
            }
            if (data_app != "")
            {
                scenariu = 3;
            }
            if ((last_name != "") && (first_name != ""))
            {
                scenariu = 4;
            }
            if ((last_name != "") && (first_name != "") && (data_app != ""))
            {
                scenariu = 5;
            }

            switch (scenariu)
            {
                case 1:
                    {
                        var toata_cautarea = func_get_all_lines_with_today_date_in_list(last_name);
                        foreach (var item in toata_cautarea)
                        {
                            listbox_appointments_to_be_deleted.Items.Add(item);
                            listbox_appointments_to_be_deleted.Background = Brushes.LightPink;
                        }
                        break;
                    }
                case 2:
                    {
                        var toata_cautarea = func_get_all_lines_with_today_date_in_list(first_name);
                        foreach (var item in toata_cautarea)
                        {
                            listbox_appointments_to_be_deleted.Items.Add(item);
                        }
                        break;
                    }
                case 3:
                    {
                        data_app = Convert.ToDateTime(data_app).ToString("dd.MM.yyyy");
                        //func_search_date_of_appointment_in_db(data_app);
                        var toata_cautarea = func_get_all_lines_with_today_date_in_list(data_app);
                        foreach (var item in toata_cautarea)
                        {
                            listbox_appointments_to_be_deleted.Items.Add(item);
                        }
                        break;
                    }
                case 4:
                    {
                        var lastname_and_firstname = last_name + " " + first_name;
                        var toata_cautarea = func_get_all_lines_with_today_date_in_list(lastname_and_firstname);
                        foreach (var item in toata_cautarea)
                        {
                            listbox_appointments_to_be_deleted.Items.Add(item);
                        }
                        break;
                    }
                case 5:
                    {
                        data_app = Convert.ToDateTime(data_app).ToString("dd.MM.yyyy");
                        var lastname_and_firstname_and_date = last_name + " " + first_name + "  |" + data_app;
                        var toata_cautarea = func_get_all_lines_with_today_date_in_list(lastname_and_firstname_and_date);
                        foreach (var item in toata_cautarea)
                        {
                            listbox_appointments_to_be_deleted.Items.Add(item);
                        }
                        break;
                    }
            }
        }
        
                private void keyUP_lastname_focus_search_appointments1(object sender, KeyEventArgs e)
        {
            if (File.Exists(path_appointments))
            {

                List<string> lines = new List<string>();
                
                /* cod bun de folosit !!!!!!! */
                //aici vreau sa caut lastname sau data si instant sa se populeze listboxul...
                /******************************************************************************************/
                //func_search_last_name_in_appointments_db(appointment_last_name_delete_textBox.Text.ToString());
                //func_search_first_name_in_appointments_db(appointment_first_name_delete_textBox.Text.ToString());
                int scenariu = 100;
                var data_app = datepicker_date_appointment_for_clear.Text.ToString();
                var last_name = appointment_last_name_delete_textBox.Text.ToString();
                var first_name = appointment_first_name_delete_textBox.Text.ToString();

                //delete the listbox complete
                listbox_appointments_to_be_deleted.Items.Clear();

                if (last_name != "")
                {
                    scenariu = 1;
                }
                if (first_name != "")
                {
                    scenariu = 2;
                }
                if (data_app != "")
                {
                    scenariu = 3;
                }
                if ((last_name != "") && (first_name != ""))
                {
                    scenariu = 4;
                }
                if ((last_name != "") && (first_name != "") && (data_app != ""))
                {
                    scenariu = 5;
                }

                switch (scenariu)
                {
                    case 1:
                        {
                            var toata_cautarea = func_get_all_lines_with_today_date_in_list(last_name);
                            foreach (var item in toata_cautarea)
                            {
                                listbox_appointments_to_be_deleted.Items.Add(item);
                                listbox_appointments_to_be_deleted.Background = Brushes.LightPink;
                            }
                            break;
                        }
                    case 2:
                        {
                            var toata_cautarea = func_get_all_lines_with_today_date_in_list(first_name);
                            foreach (var item in toata_cautarea)
                            {
                                listbox_appointments_to_be_deleted.Items.Add(item);
                            }
                            break;
                        }
                    case 3:
                        {
                            data_app = Convert.ToDateTime(data_app).ToString("dd.MM.yyyy");
                            //func_search_date_of_appointment_in_db(data_app);
                            var toata_cautarea = func_get_all_lines_with_today_date_in_list(data_app);
                            foreach (var item in toata_cautarea)
                            {
                                listbox_appointments_to_be_deleted.Items.Add(item);
                            }
                            break;
                        }
                    case 4:
                        {
                            var lastname_and_firstname = last_name + " " + first_name;
                            var toata_cautarea = func_get_all_lines_with_today_date_in_list(lastname_and_firstname);
                            foreach (var item in toata_cautarea)
                            {
                                listbox_appointments_to_be_deleted.Items.Add(item);
                            }
                            break;
                        }
                    case 5:
                        {
                            data_app = Convert.ToDateTime(data_app).ToString("dd.MM.yyyy");
                            var lastname_and_firstname_and_date = last_name + " " + first_name + "  |" + data_app;
                            var toata_cautarea = func_get_all_lines_with_today_date_in_list(lastname_and_firstname_and_date);
                            foreach (var item in toata_cautarea)
                            {
                                listbox_appointments_to_be_deleted.Items.Add(item);
                            }
                            break;
                        }
                }
            }
            else
            {
                MessageBox.Show("No appointments in database yet. Nothing to search for!", "Attention");
            }
        }

        private void KeyUP_firstname_search_appointments1(object sender, KeyEventArgs e)
        {
            if (File.Exists(path_appointments))
            {

                List<string> lines = new List<string>();
                
                /* cod bun de folosit !!!!!!! */
                //aici vreau sa caut lastname sau data si instant sa se populeze listboxul...
                /******************************************************************************************/
                //func_search_last_name_in_appointments_db(appointment_last_name_delete_textBox.Text.ToString());
                //func_search_first_name_in_appointments_db(appointment_first_name_delete_textBox.Text.ToString());
                int scenariu = 100;
                var data_app = datepicker_date_appointment_for_clear.Text.ToString();
                var last_name = appointment_last_name_delete_textBox.Text.ToString();
                var first_name = appointment_first_name_delete_textBox.Text.ToString();

                //delete the listbox complete
                listbox_appointments_to_be_deleted.Items.Clear();

                if (last_name != "")
                {
                    scenariu = 1;
                }
                if (first_name != "")
                {
                    scenariu = 2;
                }
                if (data_app != "")
                {
                    scenariu = 3;
                }
                if ((last_name != "") && (first_name != ""))
                {
                    scenariu = 4;
                }
                if ((last_name != "") && (first_name != "") && (data_app != ""))
                {
                    scenariu = 5;
                }

                switch (scenariu)
                {
                    case 1:
                        {
                            var toata_cautarea = func_get_all_lines_with_today_date_in_list(last_name);
                            foreach (var item in toata_cautarea)
                            {
                                listbox_appointments_to_be_deleted.Items.Add(item);
                                listbox_appointments_to_be_deleted.Background = Brushes.LightPink;
                            }
                            break;
                        }
                    case 2:
                        {
                            var toata_cautarea = func_get_all_lines_with_today_date_in_list(first_name);
                            foreach (var item in toata_cautarea)
                            {
                                listbox_appointments_to_be_deleted.Items.Add(item);
                            }
                            break;
                        }
                    case 3:
                        {
                            data_app = Convert.ToDateTime(data_app).ToString("dd.MM.yyyy");
                            //func_search_date_of_appointment_in_db(data_app);
                            var toata_cautarea = func_get_all_lines_with_today_date_in_list(data_app);
                            foreach (var item in toata_cautarea)
                            {
                                listbox_appointments_to_be_deleted.Items.Add(item);
                            }
                            break;
                        }
                    case 4:
                        {
                            var lastname_and_firstname = last_name + " " + first_name;
                            var toata_cautarea = func_get_all_lines_with_today_date_in_list(lastname_and_firstname);
                            foreach (var item in toata_cautarea)
                            {
                                listbox_appointments_to_be_deleted.Items.Add(item);
                            }
                            break;
                        }
                    case 5:
                        {
                            data_app = Convert.ToDateTime(data_app).ToString("dd.MM.yyyy");
                            var lastname_and_firstname_and_date = last_name + " " + first_name + "  |" + data_app;
                            var toata_cautarea = func_get_all_lines_with_today_date_in_list(lastname_and_firstname_and_date);
                            foreach (var item in toata_cautarea)
                            {
                                listbox_appointments_to_be_deleted.Items.Add(item);
                            }
                            break;
                        }
                }
            }
            else
            {
                MessageBox.Show("No appointments in database yet. Nothing to search for!", "Attention");
            }

        }

        private void KeyUP_date_appointment_search_appointments1(object sender, KeyEventArgs e)
        {
            if (File.Exists(path_appointments))
            {

                List<string> lines = new List<string>();
                
                /* cod bun de folosit !!!!!!! */
                //aici vreau sa caut lastname sau data si instant sa se populeze listboxul...
                /******************************************************************************************/
                //func_search_last_name_in_appointments_db(appointment_last_name_delete_textBox.Text.ToString());
                //func_search_first_name_in_appointments_db(appointment_first_name_delete_textBox.Text.ToString());
                int scenariu = 100;
                string data_app = datepicker_date_appointment_for_clear.Text.ToString();
                string last_name = appointment_last_name_delete_textBox.Text.ToString();
                string first_name = appointment_first_name_delete_textBox.Text.ToString();

                //delete the listbox complete
                listbox_appointments_to_be_deleted.Items.Clear();

                if (last_name != "")
                {
                    scenariu = 1;
                }
                if (first_name != "")
                {
                    scenariu = 2;
                }
                if (data_app != "")
                {
                    scenariu = 3;
                }
                if ((last_name != "") && (first_name != ""))
                {
                    scenariu = 4;
                }
                if ((last_name != "") && (first_name != "") && (data_app != ""))
                {
                    scenariu = 5;
                }

                switch (scenariu)
                {
                    case 1:
                        {
                            var toata_cautarea = func_get_all_lines_with_today_date_in_list(last_name);
                            foreach (var item in toata_cautarea)
                            {
                                listbox_appointments_to_be_deleted.Items.Add(item);
                                listbox_appointments_to_be_deleted.Background = Brushes.LightPink;
                            }
                            break;
                        }
                    case 2:
                        {
                            var toata_cautarea = func_get_all_lines_with_today_date_in_list(first_name);
                            foreach (var item in toata_cautarea)
                            {
                                listbox_appointments_to_be_deleted.Items.Add(item);
                            }
                            break;
                        }
                    case 3:
                        {
                            data_app = Convert.ToDateTime(data_app).ToString("dd.MM.yyyy");
                            //func_search_date_of_appointment_in_db(data_app);
                            var toata_cautarea = func_get_all_lines_with_today_date_in_list(data_app);
                            foreach (var item in toata_cautarea)
                            {
                                listbox_appointments_to_be_deleted.Items.Add(item);
                            }
                            break;
                        }
                    case 4:
                        {
                            var lastname_and_firstname = last_name + " " + first_name;
                            var toata_cautarea = func_get_all_lines_with_today_date_in_list(lastname_and_firstname);
                            foreach (var item in toata_cautarea)
                            {
                                listbox_appointments_to_be_deleted.Items.Add(item);
                            }
                            break;
                        }
                    case 5:
                        {
                            data_app = Convert.ToDateTime(data_app).ToString("dd.MM.yyyy");
                            var lastname_and_firstname_and_date = last_name + " " + first_name + "  |" + data_app;
                            var toata_cautarea = func_get_all_lines_with_today_date_in_list(lastname_and_firstname_and_date);
                            foreach (var item in toata_cautarea)
                            {
                                listbox_appointments_to_be_deleted.Items.Add(item);
                            }
                            break;
                        }
                }
            }
            else
            {
                MessageBox.Show("No appointments in database yet. Nothing to search for!","Attention");
            }

        }

        private void add_new_patient_click(object sender, RoutedEventArgs e)
        {
            int flagu = 0;

            //string text = textbox_1.Text.ToString();

            flagu++;

            add_patient_to_file();
            mesaj = "-> click pe but *Copiaza* <-";
            action_window_update(mesaj);
        }

        private void buton_1_click(object sender, RoutedEventArgs e)
        {

        }
        
                private void selectie_o_linie_din_patient_listbox_to_delete(object sender, SelectionChangedEventArgs e)
        {

        }

        private void keyUp_delete_patient_name_textbox(object sender, KeyEventArgs e)
        {
            if (File.Exists(path))
            {
                List<string> lines = new List<string>();
                string first_name = textbox_delete_word.Text.ToString();

                //delete the listbox complete
                listbox_patients_to_be_deleted.Items.Clear();

                if (first_name != "")
                {
                    var toata_cautarea = func_get_all_lines_with_patient_name_in_list(first_name);
                    foreach (var item in toata_cautarea)
                    {
                        listbox_patients_to_be_deleted.Items.Add(item);
                    }
                }                             
            }
            else
            {
                MessageBox.Show("No patients in database yet. Nothing to search for!", "Attention");
            }
        }

        private void send_e_mail_with_attachments(object sender, RoutedEventArgs e)
        {

            if (File.Exists(path))
            {
                try
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                    mail.From = new MailAddress("narcis.scirlatache@gmail.com");
                    mail.To.Add("narcis.scirlatache@gmail.com");
                    mail.Subject = "dental application - patient, appointments, treatments, medication lists";
                    mail.Body = "mail with *MyPatientsList* attachments.. in case of losing of files";

                    System.Net.Mail.Attachment attachment;
                    attachment = new System.Net.Mail.Attachment("MyPatientsList.txt");
                    mail.Attachments.Add(attachment);
                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("narcis.scirlatache", "mavrocordat");
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);
                    MessageBox.Show("Mail sent with success to narcis.scirlatache@gmail.com! ;)");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    MessageBox.Show(ex.ToString());
                }
            }
            else

            {
                MessageBox.Show("No such a file *MyPatientsList.txt* found. You have to create it before to send it!", "Attention!");
            }

            if (File.Exists(path_appointments))
            {
                try
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                    mail.From = new MailAddress("narcis.scirlatache@gmail.com");
                    mail.To.Add("narcis.scirlatache@gmail.com");
                    mail.Subject = "dental application - patient, appointments, treatments, medication lists";
                    mail.Body = "mail with *MyAppointmentList.txt* attachments.. in case of losing of files";

                    System.Net.Mail.Attachment attachment;
                    attachment = new System.Net.Mail.Attachment("MyAppointmentList.txt");
                    mail.Attachments.Add(attachment);
                    attachment = new System.Net.Mail.Attachment("MyPatientsList.txt");
                    mail.Attachments.Add(attachment);
                    attachment = new System.Net.Mail.Attachment("MyMedicationList1.txt");
                    mail.Attachments.Add(attachment);
                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("narcis.scirlatache", "mavrocordat");
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);
                    MessageBox.Show("Mail sent with success to narcis.scirlatache@gmail.com! ;)");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("No such a file *MyAppointmentList.txt* found. You have to create it before to send it!", "Attention!");
            }

            {
                MessageBox.Show("No such a file *MyPatientsList.txt* found. You have to create it before to send it!", "Attention!");
            }

            if (File.Exists(path_appointments))
            {
                try
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                    mail.From = new MailAddress("narcis.scirlatache@gmail.com");
                    mail.To.Add("narcis.scirlatache@gmail.com");
                    mail.Subject = "dental application - patient, appointments, treatments, medication lists";
                    mail.Body = "mail with *MyAppointmentList.txt* attachments.. in case of losing of files";

                    System.Net.Mail.Attachment attachment;
                    attachment = new System.Net.Mail.Attachment("MyAppointmentList.txt");
                    mail.Attachments.Add(attachment);
                    attachment = new System.Net.Mail.Attachment("MyPatientsList.txt");
                    mail.Attachments.Add(attachment);
                    attachment = new System.Net.Mail.Attachment("MyMedicationList1.txt");
                    mail.Attachments.Add(attachment);
                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("narcis.scirlatache", "mavrocordat");
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);
                    MessageBox.Show("Mail sent with success to narcis.scirlatache@gmail.com! ;)");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("No such a file *MyAppointmentList.txt* found. You have to create it before to send it!", "Attention!");
            }


            if (File.Exists(path_treatments_file))
            {
                try
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                    mail.From = new MailAddress("narcis.scirlatache@gmail.com");
                    mail.To.Add("narcis.scirlatache@gmail.com");
                    mail.Subject = "dental application - patient, appointments, treatments, medication lists";
                    mail.Body = "mail with *Treatments list file* in attachments.. in case of losing of files";

                    System.Net.Mail.Attachment attachment;
                    attachment = new System.Net.Mail.Attachment("MyTreatmentsList.txt");
                    mail.Attachments.Add(attachment);
                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("narcis.scirlatache", "mavrocordat");
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);
                    MessageBox.Show("Mail sent with success to narcis.scirlatache@gmail.com! ;)");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("No such a file *MyTreatmentsFile.txt* found. You have to create it before to send it!", "Attention!");
            }

            if (File.Exists(path_medications))
            {
                try
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                    mail.From = new MailAddress("narcis.scirlatache@gmail.com");
                    mail.To.Add("narcis.scirlatache@gmail.com");
                    mail.Subject = "dental application - patient, appointments, treatments, medication lists";
                    mail.Body = "mail with *Medications list* attachments.. in case of losing of files";

                    System.Net.Mail.Attachment attachment;
                    attachment = new System.Net.Mail.Attachment("MyMedicationList1.txt");
                    mail.Attachments.Add(attachment);
                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("narcis.scirlatache", "mavrocordat");
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);
                    MessageBox.Show("Mail sent with success to narcis.scirlatache@gmail.com! ;)");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("No such a file *MyMedicationList1.txt* found. You have to create it before to send it!", "Attention!");
            }
        

        }

        private void Click_edit_patient_from_file(object sender, RoutedEventArgs e)
        {
            var newWindow = new Edit_Patient_Window();           
            newWindow.RaiseCustomEvent += new EventHandler<CustomEventArgs>(newWindow_RaiseCustomEvent);
            newWindow.TextBlock_Edit_Patient_Window.Text = listbox_patients_to_be_deleted.SelectedItem.ToString();
            //newWindow.txt_box_lname_edit_patient = 
            //newWindow.txt_box_fname_edit_patient = 
            //newWindow.txt_box_street_edit_patient = 
            //newWindow.txt_box_street_nr_edit_patient = 
            //newWindow.txt_box_city_edit_patient = 
            //newWindow.txt_box_country_edit_patient = 
            var txt =  func_extract_date_of_birth_for_patient(listbox_patients_to_be_deleted.SelectedItem.ToString());
            var txt_converted = Convert.ToDateTime(txt).ToString("dd/MM/yyyy");
            newWindow.date_picker_edit_patient.Text = txt_converted;
            //newWindow.date_picker_edit_patient.Text = func_extract_date_of_birth_for_patient(listbox_patients_to_be_deleted.SelectedItem.ToString());

            
            newWindow.ShowDialog();
                        
            
            //newWindow.Show();
        }

        void newWindow_RaiseCustomEvent(object sender, CustomEventArgs e)
        {
            this.textBox_patient_adress_street.Text = e.Message.ToString();
        }

        public void Click_CancelButton_dynamic_edit_patient()
        {
            MessageBox.Show("haida de");
            this.Close();
        }

        private void Click_edit_appointment_from_file(object sender, RoutedEventArgs e)
        {
            var newWindow = new Edit_Appointments_Window();           
            //newWindow.RaiseCustomEvent += new EventHandler<CustomEventArgs>(newWindow_RaiseCustomEvent);
            newWindow.TextBlock_Edit_Appointment_Window.Text = listbox_appointments_to_be_deleted.SelectedItem.ToString();
            //newWindow.txt_box_lname_edit_patient = 
            //newWindow.txt_box_fname_edit_patient = 
            //newWindow.txt_box_street_edit_patient = 
            //newWindow.txt_box_street_nr_edit_patient = 
            //newWindow.txt_box_city_edit_patient = 
            //newWindow.txt_box_country_edit_patient = 
            //var txt =  func_extract_date_of_birth_for_patient(listbox_patients_to_be_deleted.SelectedItem.ToString());
            //var txt_converted = Convert.ToDateTime(txt).ToString("dd/MM/yyyy");
            //newWindow.date_picker_edit_appointment.Text = txt_converted;
            //newWindow.date_picker_edit_patient.Text = func_extract_date_of_birth_for_patient(listbox_patients_to_be_deleted.SelectedItem.ToString());

            
            newWindow.ShowDialog();
        }

        private void click_edit_treatment(object sender, RoutedEventArgs e)
        {
            var newWindow = new Edit_Treatments_Window();
            newWindow.TextBlock_Edit_Treatments_Window.Text = listbox_treatments_to_be_deleted.SelectedItem.ToString();
            newWindow.ShowDialog();
        }

        private void button_add_new_treatment(object sender, RoutedEventArgs e)
        {
            add_new_treatment();
        }
        private void add_new_treatment()
        {

            // This text is added only once to the file. 
            if (!File.Exists(path_treatments_file))
            {
                // Create a file to write to. 
                string createText = "_________________________________________________________________________" + Environment.NewLine;
                // File.WriteAllText(path_appointments, createText);
                string createText1 = "Treatment name" + Environment.NewLine;
                //File.WriteAllText(path_appointments, createText1);
                string createText2 = "_________________________________________________________________________" + Environment.NewLine;
                string allText = createText + createText1 + createText2;
                File.WriteAllText(path_treatments_file, allText);
            }

            string name_treatment = textBox_add_treatment.Text.ToString()+ Environment.NewLine;
            if (name_treatment != "")
            {
                File.AppendAllText(path_treatments_file, name_treatment);
                //MessageBox.Show(" o noua programare pentru pacientul * " + name_patient + " * a fost introdusa!");
                MessageBox.Show(" new treatment * " + name_treatment + " * was added!", "Correct!");
            }
            else
            {
                MessageBox.Show(" no treatment to be added", "Wrong!");
            }
        }

        private void button_click_view_treatments(object sender, RoutedEventArgs e)
        {
            if (File.Exists(path_treatments_file))
            {
                write_treatments_from_file_to_textblock();
            }
            else
            {
                MessageBox.Show("There is no treatment set in database. Nothing to show yet!", "Atention!");
            }
        }

        private void click_view_medications(object sender, RoutedEventArgs e)
        {
            if (File.Exists(path_medications))
            {
                write_medications_from_file_to_textblock();
            }
            else
            {
                MessageBox.Show("There is no treatment set in database. Nothing to show yet!", "Atention!");
            }
        }

        private void keyUP_name_search_treatments(object sender, KeyEventArgs e)
        {
            if (File.Exists(path_treatments_file))
            {
                List<string> lines = new List<string>();
                var treatment_name = delete_treatment_textBox.Text.ToString();

                //delete the listbox complete
                listbox_treatments_to_be_deleted.Items.Clear();
                                
                if (treatment_name != "")
                {               
                    var toata_cautarea = func_get_all_lines_with_treatment_name_in_list(treatment_name);
                    foreach (var item in toata_cautarea)
                    {
                        listbox_treatments_to_be_deleted.Items.Add(item);
                        listbox_treatments_to_be_deleted.Background = Brushes.LightPink;
                    }
                }
            }
            else
            {
                MessageBox.Show("No treatments in database yet. Nothing to search for!", "Attention");
            }
        }
        private void click_edit_medication(object sender, RoutedEventArgs e)
        {
            var newWindow = new Edit_Medications_Window();
            newWindow.TextBlock_Edit_Medication_Window.Text = ListBox_Medications_to_be_deleted_edited.SelectedItem.ToString();
            newWindow.ShowDialog();
        }
        private void click_delete_medication(object sender, RoutedEventArgs e)
        {
            if (File.Exists(path_medications))
            {
                if (ListBox_Medications_to_be_deleted_edited.HasItems)
                {
                    string item_selectat_din_listbox = ListBox_Medications_to_be_deleted_edited.SelectedItem.ToString();
                    int index_de_sters = ListBox_Medications_to_be_deleted_edited.SelectedIndex;

                    //aici stergem pe bune din fisier..
                    string path_temporary_file = System.IO.Path.GetTempFileName();
                    System.IO.StreamReader file = new System.IO.StreamReader(path_medications);
                    System.IO.StreamWriter file_temporary = new System.IO.StreamWriter(path_temporary_file);
                    string line = "";
                    while ((line = file.ReadLine()) != null)
                    {

                        var position = line.IndexOf(item_selectat_din_listbox, StringComparison.InvariantCultureIgnoreCase);
                        if (position > -1)
                        {
                            // daca data selectata se afla in linie, nu copiem acea linie in fisierul temporar 
                            line = "asa da - ceva am gasit";
                        }
                        else
                        {
                            //data selectata nu se gaseste in linia asta, deci linia asta tre sa ramana in fisier
                            file_temporary.WriteLine(line);
                        }
                    }

                    file.Close();
                    file_temporary.Close();
                    File.Delete(path_medications);
                    File.Move(path_temporary_file, path_medications);

                    //la final vreau sa si sterg itemul selectat din listbox

                    ListBox_Medications_to_be_deleted_edited.Items.RemoveAt(index_de_sters);
                }
                else
                {
                    MessageBox.Show("You must search a medication first! After that you can delete it!", "Attention!");
                }
            }
            else
            {
                MessageBox.Show(" There is no medication set in database yet. You have nothing to delete!", "Atention!");
            }
        }
        private void keyUP_name_search_medications(object sender, KeyEventArgs e)
        {
            if (File.Exists(path_medications))
            {
                List<string> lines = new List<string>();
                var medication_name = textBox_Medication_Name_EDIT_DELETE.Text.ToString();

                //delete the listbox complete
                ListBox_Medications_to_be_deleted_edited.Items.Clear();

                if (medication_name != "")
                {
                    var toata_cautarea = func_get_all_lines_with_medication_name_in_list(medication_name);
                    foreach (var item in toata_cautarea)
                    {
                        ListBox_Medications_to_be_deleted_edited.Items.Add(item);
                        ListBox_Medications_to_be_deleted_edited.Background = Brushes.LightPink;
                    }
                }
                else
                {

                }
            }
            else
            {
                MessageBox.Show("No medications in database yet. Nothing to search for!", "Attention");
            }
        }
        private void click_edit_equipment(object sender, RoutedEventArgs e)
        {
            var newWindow = new Edit_Equipment_Window();
            newWindow.TextBlock_Edit_Equipments_Window.Text = ListBox_equipments_to_be_deleted_edited.SelectedItem.ToString();
            newWindow.ShowDialog();
        }
        private void keyUP_name_search_equipment(object sender, KeyEventArgs e)
        {
            if (File.Exists(path_equipments))
            {
                List<string> lines = new List<string>();
                var equipment_name = equipment_name_delete_edit_textbox.Text.ToString();

                //delete the listbox complete
                ListBox_equipments_to_be_deleted_edited.Items.Clear();

                if (equipment_name != "")
                {
                    var toata_cautarea = func_get_all_lines_with_equipment_name_in_list(equipment_name);
                    foreach (var item in toata_cautarea)
                    {
                        ListBox_equipments_to_be_deleted_edited.Items.Add(item);
                        ListBox_equipments_to_be_deleted_edited.Background = Brushes.LightPink;
                    }
                }
                else
                {

                }
            }
            else
            {
                MessageBox.Show("No equipments in database yet. Nothing to search for!", "Attention");
            }
        }
    }
}

