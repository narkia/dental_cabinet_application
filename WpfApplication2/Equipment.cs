using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication2
{
    class Equipment
    {
        public string equipment_name { get; set; }
        public string equipment_manufacturer{ get; set; }
        public int serial_nr { get; set; }
        public int quantity { get; set; }
        public int cost { get; set; }
        public DateTime date_of_manufacturing { get; set; }
        public DateTime date_of_aquisition { get; set; }

        public Equipment(string equipment_name, string equipment_manufacturer, int serial_nr, int quantity, int cost, DateTime date_of_manufacturing, DateTime date_of_aquisition)
        {
            this.equipment_name = equipment_name;
            this.equipment_manufacturer = equipment_manufacturer;
            this.serial_nr = serial_nr;
            this.quantity = quantity;
            this.cost = cost;
            this.date_of_manufacturing = date_of_manufacturing;
            this.date_of_aquisition = date_of_aquisition;
        }

    }
}
