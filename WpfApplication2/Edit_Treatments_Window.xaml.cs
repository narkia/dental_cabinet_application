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
    /// Interaction logic for Edit_Treatments_Window.xaml
    /// </summary>
    public partial class Edit_Treatments_Window : Window
    {
        public Edit_Treatments_Window()
        {
            InitializeComponent();
        }

        private void Click_OK_Edit_Treatment_Window(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Click_Cancel_Edit_Treatment_Window(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
