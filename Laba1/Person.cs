using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Person
    {
        private String FirstName { get; set; }
        private String LastName { get; set; }
        private DateTime DateOfBirth { get; set; }

        public Person(String FirstName, String LastName, DateTime DateOfBirth)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
        }

        public Person()
        {
            FirstName = "Andrii";
            LastName = "Dzhuravets";
            DateOfBirth = new DateTime(1997, 12, 12);
        }

        /*public string getFirstName()
        {
            return this.FirstName;
        }

        public void setFirstName(String name)
        {
            this.FirstName = name;
        }

        public string getLastName()
        {
            return this.LastName;
        }

        public void setLastName(String Lname)
        {
            this.LastName = Lname;
        }

        public DateTime getDateOfBirth()
        {
            return this.DateOfBitrh;            
        }

        public void setDateOfBirth(DateTime bitrh)
        {
            this.DateOfBitrh = bitrh;
        }*/
        
        public int Age
        {
            get
            {
                return DateOfBirth.Year;            
            }

            set
            {
                DateOfBirth = new DateTime(value, DateOfBirth.Month, DateOfBirth.Day);
            }
   
            
        }

        public override string ToString()
        {
            return "Name: " +  FirstName + " " + LastName + " Date of birth: " + DateOfBirth.ToString("dd/MM/yyyy");
            
        }

        public virtual String ToShortString()
        {
            return FirstName + " " + LastName; 
        }


    }
}
