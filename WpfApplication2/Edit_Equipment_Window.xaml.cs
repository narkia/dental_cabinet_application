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
    /// Interaction logic for Edit_Equipment_Window.xaml
    /// </summary>
    public partial class Edit_Equipment_Window : Window
    {
        public Edit_Equipment_Window()
        {
            InitializeComponent();
        }
        string path = @"MyPatientsList.txt";
        string path_appointments = @"MyAppointmentList.txt";
        string path_temporary_file = @"MyTemporaryFile.txt";
        string path_treatments_file = @"MyTreatmentsFile.txt";
        string path_medications = @"MyMedicationList1.txt";
        string path_equipments = @"MyEquipmentList.txt";
        private void Click_OK_Edit_Equipment_Window(object sender, RoutedEventArgs e)
        {
            var equipment_item = TextBlock_Edit_Equipments_Window.Text.ToString();

            if (!File.Exists(path_equipments))
            {
                MessageBox.Show(" no database for equipments found. Nothing to ", "Wrong!");
            }
            else
            {
                //first of all we have to delete the old entry, so the lines below are deleting the old entry
                string path_temporary_file = System.IO.Path.GetTempFileName();
                System.IO.StreamReader file = new System.IO.StreamReader(path_equipments);
                System.IO.StreamWriter file_temporary = new System.IO.StreamWriter(path_temporary_file);
                string line = "";
                while ((line = file.ReadLine()) != null)
                {

                    var position = line.IndexOf(equipment_item, StringComparison.InvariantCultureIgnoreCase);
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
                File.Delete(path_equipments);
                File.Move(path_temporary_file, path_equipments);


                //second - we have to enter the new entry
                var a = add_new_equipment_name_textBox.Text.ToString();
                var b = textBox_Equipment_Size.Text.ToString();
                var c = textBox_Equipment_Material.Text.ToString();
                var d = textBox_Equipment_Weight.Text.ToString();
                var ee = textBox_Equipment_Price.Text.ToString();
                var f = textBox_Equipment_Quantity.Text.ToString();
                var g = textBox_Equipment_Serial_Number.Text.ToString();
                var h = textBox_Equipment_Provider.Text.ToString();
                var i = datepicker_Manufacturing_date_equipment.Text.ToString();
                var j = datepicker_Aquisition_date_equipment.Text.ToString();

                string name_equipment_edited = g + " | " + a + " | " + h + " | " + b + " | " + d + " | " + c + " | " + i + " | " + j + " | " + f + " | " + ee +Environment.NewLine;


                if (name_equipment_edited != "")
                {
                    File.AppendAllText(path_equipments, name_equipment_edited);
                    MessageBox.Show(" Equipment * " + a + " , with Serial Number * "+g+" * was edited!", "Correct!");
                }
            }

            this.Close();

        }
        private void Click_Cancel_Edit_Equipment_Window(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
