using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication2
{
    class Treatment
    {
        public string treatment_name { get; set; }
        public int cost { get; set; }
        
        public Treatment(string treatment_name, int cost)
        {
            this.treatment_name = treatment_name;
            this.cost = cost;     
        }
    }
}
