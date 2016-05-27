using System;
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


namespace WpfApplication2
{
    public partial class MainWindow : Window
    {



        /*************************************************************************************
        * ***********************************************************************************
        * Function name:       button_set_new_appointments()
        * Type:                void()
        * Input parameters:    no  
        * Output parameters:   no
        * Description:         set a new appointment in the databse.
        * ***********************************************************************************
        *************************************************************************************/
        private void button_set_new_appointments(object sender, RoutedEventArgs e)
        {
            add_new_appointment();
        }

        private void add_new_appointment()
        {

            // This text is added only once to the file. 
            if (!File.Exists(path1))
            {
                // Create a file to write to. 
                string createText = "_________________________________________________________________________" + Environment.NewLine;
                // File.WriteAllText(path1, createText);
                string createText1 = "Last name     First Name  |" + "    Date   | Time frame hh:mm --> hh:mm | " + Environment.NewLine;
                //File.WriteAllText(path1, createText1);
                string createText2 = "_________________________________________________________________________" + Environment.NewLine;
                string allText = createText + createText1 + createText2;
                File.WriteAllText(path1, allText);
            }
             string appendText = textBox_appointments_patient.Text.ToString() + " " + textbox_firstname_appointment.Text.ToString() + "  |" + datepicker_date_appointment.Text.ToString() + "   |" + Pick_start_hour_appointment.Text.ToString() + " --> " + Pick_stop_hour_appointment.Text.ToString() + "|" + Environment.NewLine;
            string name_patient = textBox_appointments_patient.Text.ToString() + " " + textbox_firstname_appointment.Text.ToString();

            var start_time = Pick_start_hour_appointment.Text.ToString();
            if (start_time == "")
            {
                start_time = "08:00";
            }
            var stop_time = Pick_stop_hour_appointment.Text.ToString();
            var start_time_char_array = start_time.ToCharArray();
            var stop_time_char_array = stop_time.ToCharArray();
            var data_appointment = datepicker_date_appointment.Text.ToString();

            var result_check_date_textbox = 0;
            if (data_appointment != "")
            {
                result_check_date_textbox = 1;
            }
            else
            {
                result_check_date_textbox = 0;
                datepicker_date_appointment.BorderThickness = new Thickness(5.0);
                datepicker_date_appointment.BorderBrush = Brushes.Red;
            }

            // compare the start and stop hour.. appointments cannot be set if the hours are equal OR the stop time is earlier than start time..
            var correct_start_and_stop_time = compare_two_arrays_of_char_with_same_length(start_time_char_array, stop_time_char_array);

            var result_check_names_textboxes = func_check_appointment_input_format_names_in_textboxes();
            //verify if the datas inserted in textboxes is as expected: date dd.mm.yyyy; names only letters; start hour and stop hour in format --> hh:mm
            if ((result_check_date_textbox == 1) && (result_check_names_textboxes == 0) && (correct_start_and_stop_time != false))
            {
    
                //in case the appoinment date is today or a day after today - the processing is done
                var possible_appointment = func_verify_if_possible_appointment_date(data_appointment, start_time);
                if (possible_appointment == 0)//if the appoinment date is today or a day after today - the processing is done
                {
                    var res = func_verify_if_possible_appointment_start_time(start_time, stop_time, data_appointment);
                    if (res == 0)
                    {
                        File.AppendAllText(path1, appendText);
                        //MessageBox.Show(" o noua programare pentru pacientul * " + name_patient + " * a fost introdusa!");
                        MessageBox.Show(" o noua programare pentru pacientul * " + name_patient + " * a fost introdusa!", "Correct!");
    
                    }
                    else if (res == 1)
                    {
                        string all_appointments_on_selected_date = func_get_all_lines_with_today_date(data_appointment);
                        //MessageBox.Show("Timeframe you've chosen : " + start_time + "-" + stop_time + ", is not available! You should choose other timeframe! All the appointments in the day " + data_appointment + " are:\n\n" + all_appointments_on_selected_date + "\n Please choose other timeframe different than the above listed ones!");
                        MessageBox.Show("Timeframe you've chosen : " + start_time + "-" + stop_time + ", is not available! You should choose other timeframe! All the appointments in the day " + data_appointment + " are:\n\n" + all_appointments_on_selected_date + "\n Please choose other timeframe different than the above listed ones!", "Attention!");
                    }
                    else
                    {
                        //do nothing
                    }
                }
                else //if the appointment date is in a day before today, we cannot set an appointment
                {
                    MessageBox.Show("Sorry, the appointment date * " + data_appointment + " " + start_time + " * you entered is in the past, so we cannot travel in time to set an appointment. Here we are in real life not in Star Trek! Please enter a valid appointment!", "Attention!");
                }
            }
            else
            {
                if (correct_start_and_stop_time == false)
                {
                    Pick_start_hour_appointment.BorderThickness = new Thickness(10.0);
                    Pick_start_hour_appointment.BorderBrush = Brushes.Red;
                    Pick_stop_hour_appointment.BorderThickness = new Thickness(10.0);
                    Pick_stop_hour_appointment.BorderBrush = Brushes.Red;
                }
                MessageBox.Show("Names shall be set AND shall contain only letters AND the date shall be valid! This appointment cannot be set because of incorrect date OR names.", "Attention!");
            }


        }
        public Boolean compare_two_arrays_of_char_with_same_length(Char[]a, Char[]b)
        {
            Boolean res = true;
            
            var int_a_1 = (int)Char.GetNumericValue(a[0]);
            var int_a_2 = (int)Char.GetNumericValue(a[1]);
            var int_b_1 = (int)Char.GetNumericValue(b[0]);
            var int_b_2 = (int)Char.GetNumericValue(b[1]);

            var int_a_4 = (int)Char.GetNumericValue(a[3]);
            var int_a_5 = (int)Char.GetNumericValue(a[4]);
            var int_b_4 = (int)Char.GetNumericValue(b[3]);
            var int_b_5 = (int)Char.GetNumericValue(b[4]);

            var a_1_2_4_5 = int_a_1*1000 + int_a_2*100 + int_a_4*10 + int_a_5;
            var b_1_2_4_5 = int_b_1 * 1000 + int_b_2 * 100 + int_b_4 * 10 + int_b_5;
                               
            if (a_1_2_4_5 >= b_1_2_4_5)
            {
                res = res & false;
            }
            else if (a_1_2_4_5 < b_1_2_4_5)
            {
                res = res & true;
            }
            else
            {
                //lasa asa
            }
            
            return res;
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
        private void button_write_all_appointments_in_textbox(object sender, RoutedEventArgs e)
        {
            write_appointements_from_file_to_textblock();
        }

        private void write_appointements_from_file_to_textblock()
        {
            string readText = File.ReadAllText(path1);
            textBlock_all_appointments.Text = readText;

        }

        /*************************************************************************************
        * ***********************************************************************************
        * Function name:       button_write_appointments_of_today_in_textblock()
        * Type:                void()
        * Input parameters:    no  
        * Output parameters:   no
        * * Description:       gets all of the booked appointments for today and shows them in a textblock.  
        * ***********************************************************************************
        *************************************************************************************/
        private void button_write_appointments_of_today_in_textblock(object sender, RoutedEventArgs e)
        {
            write_appointments_of_today_from_file_to_textblock();
        }

        private void write_appointments_of_today_from_file_to_textblock()
        {
            var today_date = DateTime.Now.ToString("dd.MM.yyyy");
            string all_appointments_for_today = func_get_all_lines_with_today_date(today_date);
            textBlock_appointments_of_today.Text = all_appointments_for_today;
        }

        /*************************************************************************************
        * ***********************************************************************************
        * Function name:       func_get_all_lines_with_today_date()
        * Type:                void()
        * Input parameters:    string current_date  
        * Output parameters:   no
        * * Description:       gets all of the booked appointments for today and returns one string 
        * ******************** containing all today's appointments.  
        * ***********************************************************************************
        *************************************************************************************/
        private string func_get_all_lines_with_today_date(string data_curenta)
        {
            string result_lines = "";

            System.IO.StreamReader file = new System.IO.StreamReader(path1);
            string line = "";
            while ((line = file.ReadLine()) != null)
            {

                var position = line.IndexOf(data_curenta, StringComparison.InvariantCultureIgnoreCase);
                if (position > -1)
                {
                    result_lines = result_lines + line;
                    result_lines = result_lines + Environment.NewLine;
                }
            }
            file.Close();
            return result_lines;
        }
        /*************************************************************************************
        * ***********************************************************************************
        * Function name:       button_func_all_appointments_of_today_welcome_page()
        * Type:                void()
        * Input parameters:    no  
        * Output parameters:   no
        * * Description:       gets all of the booked appointments for today and shows them in a textblock in welcome page.  
        * ***********************************************************************************
        *************************************************************************************/
        private void button_func_all_appointments_of_today_welcome_page(object sender, RoutedEventArgs e)
        {
            var today_date = DateTime.Now.ToString("dd.MM.yyyy");
            string all_appointments_for_today = func_get_all_lines_with_today_date(today_date);
            textBlock_welcome_appointments_of_today.Text = all_appointments_for_today;
        }

        /*************************************************************************************
        * ***********************************************************************************
        * Function name:       func_extract_start_time_of_appointment()
        * Returned Type:       string
        * Input parameters:    string  
        * Output parameters:   
        * * Description:       extract the start time of an appointment from a line.  
        * ***********************************************************************************
        *************************************************************************************/
        public string func_extract_start_time_of_appointment(string line)
        {
            string start_time = "";
            int i = 0, j = 0;// k = 0;
            char[] a = line.ToCharArray();
            char[] b = new char[5];

            while (a[i] != '>')
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
                    j = 0;
                }

                i++;
            }

            start_time = new string(b);

            return start_time;
        }

        /*************************************************************************************
        * ***********************************************************************************
        * Function name:       func_extract_stop_time_of_appointment()
        * Returned Type:       string
        * Input parameters:    string  
        * Output parameters:   
        * * Description:       extract the stop time of an appointment from a line.  
        * ***********************************************************************************
        *************************************************************************************/
        public string func_extract_stop_time_of_appointment(string line)
        {
            string start_time = "";
            int i = 0, j = 0;// k = 0;
            char[] a = line.ToCharArray();
            char[] b = new char[5];

            while (j >= 0)
            {
                if (a[i] == '>')
                {
                    j++;
                }

                if (j == 1)
                {
                    b[0] = a[i + 2];
                    b[1] = a[i + 3];
                    b[2] = a[i + 4];
                    b[3] = a[i + 5];
                    b[4] = a[i + 6];
                    j = -1;
                }

                i++;
            }

            start_time = new string(b);

            return start_time;
        }


        /*************************************************************************************
        * ***********************************************************************************
        * Function name:       func_convert_appointment_timeframe_to_date()
        * Returned Type:       void
        * Input parameters:    string start_time, string stop_time  
        * Output parameters:   
        * * Description:       convert the start time and stop time of an appointment to date.  
        * ***********************************************************************************
        *************************************************************************************/
        private void func_convert_appointment_timeframe_to_date(string s1, string s2)
        {
            DateTime dt = Convert.ToDateTime(s1);
            DateTime dtt = Convert.ToDateTime(s2);

        }

        private int func_verify_if_possible_appointment_start_time(string start_time, string stop_time, string date)
        {
            int res = 0;
            System.IO.StreamReader file = new System.IO.StreamReader(path1);
            string line = "";

            while ((line = file.ReadLine()) != null)
            {
                //see if the date from textbox is present in the line extracted; if YES then CONTINUE 
                var position = line.IndexOf(date, StringComparison.InvariantCultureIgnoreCase);

                if (position > -1)
                {
                    // the date from textbox is present in the line extracted. We will continue to process the line
                    var pos = line.IndexOf(start_time, StringComparison.InvariantCultureIgnoreCase);
                    if (pos > -1)
                    {
                        // in this case the start hour is the same as another appointment start hour
                        res = 1;
                        break;
                    }
                    else
                    {
                        //if the new appointment start hour is not the same as the existing ones
                        DateTime dt_start = Convert.ToDateTime(start_time);
                        DateTime dt_stop = Convert.ToDateTime(stop_time);
                        var start_time_line = func_extract_start_time_of_appointment(line);
                        var stop_time_line = func_extract_stop_time_of_appointment(line);
                        DateTime dt_start_line = Convert.ToDateTime(start_time_line);
                        DateTime dt_stop_line = Convert.ToDateTime(stop_time_line);
                        var interval_start = (dt_start - dt_start_line).TotalMinutes;
                        var interval_stop = (dt_stop - dt_stop_line).TotalMinutes;

                        var interval_start_inverse = (dt_start_line - dt_start).TotalMinutes;
                        var interval_stop_inverse = (dt_stop_line - dt_stop).TotalMinutes;

                        // #1: start time and stop time very close to another existing appointment start time
                        if (((interval_start < 30) && (interval_stop < 30)) && ((interval_start_inverse < 30) && (interval_stop_inverse < 30)))
                        {
                            // the start time is too close to another one
                            //the stop time is too close to another one
                            res = 1;
                            break;
                        }
                        else
                        {
                            res = 0;
                        }

                        // #2: start time or stop time very close to another existing appointment stop time
                        if (((interval_start < 30) || (interval_stop < 30)) && ((interval_start_inverse < 30) || (interval_stop_inverse < 30)))
                        {
                            // the start time is too close to another one
                            res = 1;
                            break;
                        }
                        else
                        {
                            res = 0;
                        }
                    }



                }
            }
            file.Close();


            return res;

        }
        /*************************************************************************************
        * ***********************************************************************************
        * Function name:       func_verify_if_possible_appointment_date()
        * Returned Type:       void
        * Input parameters:    string date_appointment, string start_hour_appointment  
        * Output parameters:   int result
        * * Description:       check if the date and the hour of appointment is not in the past (having the NOW system time).  
        * ***********************************************************************************
        *************************************************************************************/
        private int func_verify_if_possible_appointment_date(string date_appointment, string hour_appointment)
        {
            int result = 0;
            string date_appointment_complete = date_appointment + " " + hour_appointment;
            DateTime date_appointment_converted = Convert.ToDateTime(date_appointment_complete);
            var current_date = DateTime.Now;
            var interval_days = (date_appointment_converted - current_date).TotalDays;
            var interval_hours = (date_appointment_converted - current_date).TotalHours;
            var interval_minutes = (date_appointment_converted - current_date).TotalMinutes;
            var interval_seconds = (date_appointment_converted - current_date).TotalSeconds;

            if (((interval_days >= 0) && (interval_hours >= 0)) && (interval_minutes >= 0))
            {
                result = 0;
            }
            else if (((interval_days < 0) || (interval_hours < 0)) || (interval_minutes < 0))
            {
                result = 1;
            }
            else
            {
                //do nothing
            }

            return result;
        }

        /*************************************************************************************
        * ***********************************************************************************
        * Function name:       func_check_appointment_input_format_timeframe_in_textboxes()
        * Returned Type:       int 
        * Input parameters:    void
        * Output parameters:   int result
        * * Description:       check if the date,hour,minutes,names format of appointment is as expected.  
        * ***********************************************************************************
        *************************************************************************************/
        private int func_check_appointment_input_format_timeframe_in_textboxes()
        {
            int result = 0;
            
            // check textboxes for correct format .etc..
            var start_time_char_array = Pick_start_hour_appointment.Text.ToCharArray();
            var stop_time_char_array = Pick_stop_hour_appointment.Text.ToCharArray();
            result = 1;
            return result;
        }

        /*************************************************************************************
        * ***********************************************************************************
        * Function name:       func_check_appointment_input_format_date_in_textboxes()
        * Returned Type:       int 
        * Input parameters:    void
        * Output parameters:   int result
        * * Description:       check if the date format of appointment is as expected.  
        * ***********************************************************************************
        *************************************************************************************/
        private int func_check_appointment_input_format_date_in_textboxes()
        {
            int result = 0;
            int result_day = 0, result_delimiter = 0, result_months = 0, result_years = 0;

            // check textboxes for correct format .etc..
            var date_char_array = datepicker_date_appointment.Text.ToCharArray();
            //datepicker_date_appointment


            // date format check
            int zi_calc = (int)Char.GetNumericValue(date_char_array[0]) * 10;
            zi_calc = zi_calc + (int)Char.GetNumericValue(date_char_array[1]);
            if ((zi_calc >= 0) && (zi_calc <= 31))
            {
                result_day = 1;
            }

            var delimiter1 = date_char_array[2];
            var delimiter2 = date_char_array[5];
            if ((delimiter1 == '.') && (delimiter2 == '.'))
            {
                result_delimiter = 1;
            }

            int month_calc = (int)Char.GetNumericValue(date_char_array[3]) * 10;
            month_calc = month_calc + (int)Char.GetNumericValue(date_char_array[4]);
            if ((month_calc >= 0) && (month_calc <= 12))
            {
                result_months = 1;
            }

            int year_calc = (int)Char.GetNumericValue(date_char_array[6]) * 1000;
            year_calc = year_calc + (int)Char.GetNumericValue(date_char_array[7]) * 100;
            year_calc = year_calc + (int)Char.GetNumericValue(date_char_array[8]) * 10;
            year_calc = year_calc + (int)Char.GetNumericValue(date_char_array[9]);
            if ((year_calc >= 0) && (year_calc <= 2100))
            {
                result_years = 1;
            }


            if (result_day == 1)
            {
                if (result_months == 1)
                {
                    if (result_years == 1)
                    {
                        if (result_delimiter == 1)
                        {
                            result = 1;
                        }
                    }
                }

            }

            return result;
        }

        /*************************************************************************************
        * ***********************************************************************************
        * Function name:       func_check_appointment_input_format_names_in_textboxes()
        * Returned Type:       int 
        * Input parameters:    void
        * Output parameters:   int result
        * * Description:       check if the names formats of appointment is as expected.  
        * ***********************************************************************************
        *************************************************************************************/
        private int func_check_appointment_input_format_names_in_textboxes()
        {
            int result = 0, i;
            int result_lastname = 0, result_firstname = 0;

            // check textboxes for correct format .etc..
            var lastname_char_array = textBox_appointments_patient.Text.ToCharArray();
            var firstname_char_array = textbox_firstname_appointment.Text.ToCharArray();

            if ((lastname_char_array.Length == 0) || (firstname_char_array.Length == 0) )
            {
                result_lastname = 1;
                result_firstname = 1;

                textBox_appointments_patient.BorderThickness = new Thickness(5.0);
                textBox_appointments_patient.BorderBrush = Brushes.Red;
                textbox_firstname_appointment.BorderThickness = new Thickness(5.0);
                textbox_firstname_appointment.BorderBrush = Brushes.Red;
               

            }

            // lastname format check
            for (i = 0; i < lastname_char_array.Length; i++)
            {
                if (!Char.IsLetter(lastname_char_array[i]))
                {
                    result_lastname = 1;
                    textBox_appointments_patient.BorderThickness = new Thickness(5.0);
                    textBox_appointments_patient.BorderBrush = Brushes.Red;
                    break;
                }
            }

            // firstname format check
            for (i = 0; i < firstname_char_array.Length; i++)
            {
                if (!Char.IsLetter(firstname_char_array[i]))
                {
                    result_firstname = 1;
                    textbox_firstname_appointment.BorderThickness = new Thickness(5.0);
                    textbox_firstname_appointment.BorderBrush = Brushes.Red;
                    break;
                }
            }

            if ((result_lastname == 1) || (result_firstname == 1))
            {
                result = 1;
            }

            return result;
        }


    }
}
