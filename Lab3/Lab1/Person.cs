using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Person
    {
        private string name;
        private string surname;
        private System.DateTime birthday;

        public Person(string name, string surname, DateTime birthday)
        {
            this.name = name;
            this.surname = surname;
            this.birthday = birthday;
        }

        public Person()
        {
            this.name = "";
            this.surname = "";
            this.birthday = new DateTime(1997,12,24);
        }

        public string Name {
            get => name;
            set => name = value;
        }

        public string Surname {
            get => surname;
            set => surname = value;
        }

        public DateTime Birthday {
            get => birthday;
            set => birthday = value;
        }

        public int ChangeYear {
            get { return this.birthday.Year; }
            set { this.birthday = new DateTime(value, birthday.Month, birthday.Day); }
        }

        public override string ToString()
        {
            return "Name: " + name + "; Surname: " + surname + "; Birthday: " + birthday.ToString() + ";";
        }

        public virtual string ToShortString() {
            return "Name: " + name + "; Surname: " + surname + ";"; 
        }

        public override bool Equals(object obj)
        {
            
            if (obj == null)
                return false;


            Person person = obj as Person;

            if ((object)person == null)
                return false;

            return (name == person.name) && (surname == person.surname) && (birthday.Equals(person.birthday));
        }


        public override int GetHashCode()
        {
            return name.GetHashCode() + surname.GetHashCode() + birthday.GetHashCode();
        }

        public static bool operator == (Person person1, Person person2) {
            if (((object) person1 == null) || ((object) person2 == null))
                    return false;

            
            return person1.Equals(person2) && !(person1.GetHashCode() == person2.GetHashCode());
        }

       

        public static bool operator !=(Person person1, Person person2) {
            return !(person1.Equals(person2)) && (!(person1.GetHashCode() == person2.GetHashCode())); 
        }

        public Person DeepCopy() {
            Person copy = (Person) this.MemberwiseClone();
            copy.name = String.Copy(name);
            copy.surname = String.Copy(surname);
            copy.birthday = new DateTime(birthday.Year, birthday.Month, birthday.Day);
            return copy;
        }
    }
}
