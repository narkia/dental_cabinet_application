using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication2
{
    public struct address
    {
        public string street;
        public int nr;
        public string village;
        public string city;
        public string county;
        public string country;

        public address(string street, int nr, string village, string city, string county, string country)
        {
            this.street = street;
            this.nr = nr;
            this.village = village;
            this.city = city;
            this.county = county;
            this.country = country;
        }
    }

    class Patient
    {
        string path = @"C:\Users\nars\Documents\visual studio 2015\Projects\WpfApplication2\WpfApplication2\MyTest.txt";

        public string lastname { get; set; }
        public string firstname { get; set; }
        public int cnp { get; set; }
        public DateTime date_of_birth { get; set; }
        public address address { get; set; }

        public Patient(string lastname, string firstname, int cnp, DateTime date_of_birth, address address)
        {
            this.lastname = lastname;
            this.firstname = firstname;
            this.cnp = cnp;
            this.date_of_birth = date_of_birth;
            this.address = address;
        }

        public bool Patient_check_name_only_letters()
        {
            bool ret = false;
            bool ret_lastname = true;
            bool ret_firstname = false;
            char[] lastname_char = lastname.ToCharArray();
            char[] firstname_char = firstname.ToCharArray();
            int i = 0;
            while (i <= lastname_char.Length)
            {
                if (!Char.IsLetter(lastname_char[i]))
                {
                    ret_lastname = ret_lastname & false;
                }
                else
                {
                    ret_lastname = ret_lastname & true;
                }
            }

            while (i <= firstname_char.Length)
            {
                if (!Char.IsLetter(firstname_char[i]))
                {
                    ret_firstname = ret_firstname & false;
                }
                else
                {
                    ret_firstname = ret_firstname & true;
                }
            }

            ret = ret_firstname & ret_lastname;

            //if ret == 0 then we have a digit in the firstname/lastname, so this is not accepted --> messagebox will be highlighted
            return ret;
        }

        public int Patient_verify_if_already_in_database()
        {
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            string line = "";
            int flagul = 0;

            string name_complete = lastname + " " + firstname;

            while ((line = file.ReadLine()) != null)
            {
                //var result = search_name_in_line(nume_pacient, line);

                var position = line.IndexOf(name_complete, StringComparison.InvariantCultureIgnoreCase);
                if (position > -1)
                {
                    flagul = 1;
                }
            }

            if (flagul == 0)
            {
                // nu exista nici un pacient cu numele asta... Pas 1. Introduceti pacientul in baza de date; Pas 2. Programati din nou o data valida pentru acest nou pacient;
            }
            else if (flagul == 1)
            {
                // pacientul " + nume_pacient + " exista in database si putem face o programare pentru el";

            }

            return flagul;
        }
    }


}
