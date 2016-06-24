using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for Edit_Appointments_Window.xaml
    /// </summary>
    public partial class Edit_Appointments_Window : Window
    {
        public Edit_Appointments_Window()
        {
            InitializeComponent();
        }
        string path = @"MyPatientsList.txt";
        string path_appointments = @"MyAppointmentList.txt";
        string path_temporary_file = @"MyTemporaryFile.txt";
        string path_treatments_file = @"MyTreatmentsFile.txt";
        string path_medications = @"MyMedicationList1.txt";
        string path_equipments = @"MyEquipmentList.txt";

        private void Click_OK_Edit_Appointment_Window(object sender, RoutedEventArgs e)
        {
            var appointment_item = TextBlock_Edit_Appointment_Window.Text.ToString();

            if (!File.Exists(path_appointments))
            {
                MessageBox.Show(" no database for appointments found. Nothing to do here.. ", "Wrong!");
            }
            else
            {
                //first of all we have to delete the old entry, so the lines below are deleting the old entry
                string path_temporary_file = System.IO.Path.GetTempFileName();
                System.IO.StreamReader file = new System.IO.StreamReader(path_appointments);
                System.IO.StreamWriter file_temporary = new System.IO.StreamWriter(path_temporary_file);
                string line = "";
                while ((line = file.ReadLine()) != null)
                {

                    var position = line.IndexOf(appointment_item, StringComparison.InvariantCultureIgnoreCase);
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


                //second - we have to enter the new entry
                var a = txt_box_lname_edit_appointment.Text.ToString();
                var b = txt_box_fname_edit_appointment.Text.ToString();
                var c = date_picker_edit_appointment.Text.ToString();
                var d = Pick_start_hour_appointment.Text.ToString();
                var ee = Pick_stop_hour_appointment.Text.ToString();

                string appointment_edited = a + " " + b + "  |" + c + "   |" + d + " --> " + ee+ "|"+ Environment.NewLine;


                if (appointment_edited != "")
                {
                    File.AppendAllText(path_appointments, appointment_edited);
                    MessageBox.Show(" Apointment * " + a + " " + b + " * was edited!", "Correct!");
                }
            }

            this.Close();
            
        }

        private void Click_Cancel_Edit_Appointment_Window(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void clear_colors_notification_start_time_combobox_edit(object sender, MouseEventArgs e)
        {

        }

        private void Pick_start_hour_appointment_SelectionChanged_edit(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Pick_start_hour_appointment_Loaded_edit(object sender, RoutedEventArgs e)
        {

        }

        private void Pick_stop_hour_appointment_Loaded_edit(object sender, RoutedEventArgs e)
        {

        }

        private void Pick_stop_hour_appointment_SelectionChanged_edit(object sender, SelectionChangedEventArgs e)
        {

        }

        private void clear_colors_notification_stop_time_combobox_edit(object sender, MouseEventArgs e)
        {

        }
    }
}
