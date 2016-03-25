using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication2
{
    class Medication
    {
        public string medication_name { get; set; }
        public string medication_provider{ get; set; }
        public int quantity{ get; set; }
        public int cost { get; set; }
        public DateTime date_of_manufacturing { get; set; }
        public DateTime date_of_aquisition { get; set; }

        public Medication(string medication_name, string medication_provider, int quantity, int cost, DateTime date_of_manufacturing, DateTime date_of_aquisition)
        {
            this.medication_name = medication_name;
            this.medication_provider = medication_provider;
            this.quantity = quantity;
            this.cost = cost;
            this.date_of_manufacturing = date_of_manufacturing; 
            this.date_of_aquisition = date_of_aquisition;
        }

        /* constants - not member of Medication class */
        public static readonly DateTime DefaultDate = new DateTime(2015, 1, 1);

        public bool Medication_verify_price()
        {
            bool ret = false;
            if (cost < 0)
            {
                ret = true;
            }
            else
            {
                ret = false;
            }

            return ret;
        }

        public bool Medication_verify_quantity()
        {
            bool ret = false;
            if (quantity <= 0)
            {
                ret = true;
            }
            else
            {
                ret = false;
            }

            return ret;
        }

        public bool Medication_verify_date_of_manufacturing_accepted()
        {
            bool ret = false;

            if (date_of_manufacturing < DefaultDate)
            {
                ret = true;
            }
            else
            {
                ret = false;
            }

            return ret;
        }

        public bool Medication_verify_date_of_aquisition_accepted()
        {
            bool ret = false;

            if (date_of_aquisition < date_of_manufacturing)
            {
                ret = true;
            }
            else
            {
                ret = false;
            }

            return ret;
        }

    }
}
