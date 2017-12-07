using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    enum Timeframe
    {
        Year,
        TwoYears,
        Long
    }
    class Paper
    {
        public String NameOfPublication { get; set; }
        public Person Author { get; set; }
        public DateTime DateOfPublication { get; set; }

        public Paper(String NameOfPublication, Person Author, DateTime DateOfPublication)
        {
            this.NameOfPublication = NameOfPublication;
            this.Author = Author;
            this.DateOfPublication = DateOfPublication;
        }

        public Paper()
        {
            NameOfPublication = "True Detective";
            Author = new Person();
            DateOfPublication = new DateTime(2017, 7, 13);
        }

        public override string ToString()
        {
            return String.Format("Name of publication : {0}, Author : {1},  Date of publication : {3}", NameOfPublication, Author.ToString(), DateOfPublication.ToString("dd/MM/yyyy"));

        }
    }
}
