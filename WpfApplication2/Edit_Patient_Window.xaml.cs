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
    /// Interaction logic for Edit_Patient_Window.xaml
    /// </summary>
    public partial class Edit_Patient_Window : Window
    {
        public event EventHandler<CustomEventArgs> RaiseCustomEvent;

        public Edit_Patient_Window()
        {
            InitializeComponent();
        }

        private void Click_OK_Edit_Patient_Window(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("am apasat OK");
            RaiseCustomEvent(this, new CustomEventArgs(txt_box_fname_edit_patient.Text));
            this.Close();
        }

        private void Click_Cancel_Edit_Patient_Window(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

    public class CustomEventArgs : EventArgs
    {
        public CustomEventArgs(string s)
        {
            msg = s;
        }
        private string msg;
        public string Message
        {
            get { return msg; }
        }
    }
}
