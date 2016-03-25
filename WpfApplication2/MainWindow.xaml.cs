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
using System.Windows.Media.Imaging;


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

        string path = @"C:\Users\nars\Documents\visual studio 2015\Projects\WpfApplication2\WpfApplication2\MyTest.txt";
        string path1 = @"C:\Users\nars\Documents\visual studio 2015\Projects\WpfApplication2\WpfApplication2\MyAppointmentList.txt";
        string path_medications = @"MyMedicationList1.txt";
        string mesaj = " ";
        string search_text = "";
        int counter_fields_action_window = 0;
        Medication medication;

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


        private void buton_1_click(object sender, RoutedEventArgs e)
        {
            int flagu = 0;
                                   
            flagu++;

            add_patient_to_file();
            mesaj = "-> click pe but *Copiaza* <-";
            action_window_update(mesaj);
        }

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
        private void button_search_click(object sender, RoutedEventArgs e)
        {
            search_text = textBox_search.Text.ToString();
            int result = search_word(search_text);
            if (result != 0)
            {
                textBlock2.Text = "cuvantul * " + search_text + " *" + " a fost gasit de " + result + " ori.";
            }
            else
            {
                textBlock2.Text = search_text + " --> nu a fost gasit in fisier! ";
            }
        }

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
        private void button2_click_search_all_about(object sender, RoutedEventArgs e)
        {
            search_text = textBox_search.Text.ToString();
            textBlock2.Text = " ";// +Environment.NewLine;
            search_all_about_the_word(search_text);


        }

        private void search_all_about_the_word(string str)
        {
            var vector = new string[10];
            int i = 0;
            string tot_textul = " ";

            System.IO.StreamReader file = new System.IO.StreamReader(path);
            string line = "";
            while ((line = file.ReadLine()) != null)
            {
                var position = line.IndexOf(str, StringComparison.InvariantCultureIgnoreCase);
                if (position > -1)
                {
                    vector[i] = line;
                    i++;
                }
            }

            if (i == 0)
            {
                textBlock2.Text = "nici un pacient care sa aiba acest cuvant in descriere ";
            }
            else
            {
                while (i >= 0)
                {
                    tot_textul = tot_textul + " " + vector[i] + "\n";
                    i--;
                }
                textBlock2.Text = tot_textul;
            }
        }

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
            string cuvant = textbox_delete_word.Text.ToString();
            delete_patient_from_file(cuvant);

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
            
            System.IO.StreamReader file = new System.IO.StreamReader(path1);
            string line = "";
            while ((line = file.ReadLine()) != null)
            {
                lineindex++;
                if (lineindex > 3)
                {
                    var date_of_appointment_line = func_extract_date_of_appointment(line);
                    DateTime datetime_date_appointment = DateTime.ParseExact(date_of_appointment_line, "dd/MM/yyyy",
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

        private void click_busiest_day_of_the_year(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("in curand va fi implementat si acest feature.. putintica rabdare;) ");
            var busiest_day_in_database = func_busiest_day_of_the_year();

            MessageBox.Show("cea mai busy data din istoria cabinetului este --> "+ busiest_day_in_database);
        }

        private void click_delete_treatment(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("in curand va fi implementat si acest feature.. putintica rabdare;) ");
        }

        private void click_view_treatments(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("in curand va fi implementat si acest feature.. putintica rabdare;) ");
        }

        private void click_delete_appointment_from_database(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("in curand va fi implementat si acest feature.. putintica rabdare;) ");
        }

        private void button_add_new_equipments(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("in curand va fi implementat si acest feature.. putintica rabdare;) ");
        }

        private void click_delete_equipment(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("in curand va fi implementat si acest feature.. putintica rabdare;) ");
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
            mesaj = "->intrat in appointment tab<-";
            action_window_update(mesaj);
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
    }
}
