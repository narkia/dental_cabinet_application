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

        private void Click_OK_Edit_Appointment_Window(object sender, RoutedEventArgs e)
        {
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
