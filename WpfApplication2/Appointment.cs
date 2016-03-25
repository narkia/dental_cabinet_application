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
using System.Windows.Media.Imaging;

namespace WpfApplication2
{
    class Appointment
    {
        public string lastname { get; set; }
        public string firstname { get; set; }
        public DateTime date_of_appointment { get; set; }
        public string start_hour { get; set; }
        public string stop_hour { get; set; }

        //constant
        string path1 = @"C:\Users\nars\Documents\visual studio 2015\Projects\WpfApplication2\WpfApplication2\MyAppointmentList.txt";

        public Appointment(string lastname, string firstname, DateTime date_of_appointment, string start_hour, string stop_hour)
        {
            this.lastname = lastname;
            this.firstname = firstname;
            this.date_of_appointment = date_of_appointment;
            this.start_hour = start_hour;
            this.stop_hour = stop_hour;
        }

        public int Appointment_check_possible_date()
        {
            int result = 0;
            string date_appointment_complete = date_of_appointment.ToString();
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


        
    }

}
