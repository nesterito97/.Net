using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ResearchTeam a = new ResearchTeam();

            Console.WriteLine(a.ToShortString());
            Console.WriteLine("Year: " + a[Timeframe.Year]);
            Console.WriteLine("TwoYears: " + a[Timeframe.TwoYears]);
            Console.WriteLine("Long: " + a[Timeframe.Long]);
            a.AddPapers(new Paper[] {new Paper("Mod", 
                new Person("First Name", "Last Name", new DateTime(1990, 1, 15)), 
                new DateTime(1990, 1, 15)) });
            Console.WriteLine(a.ToString());



            Console.ReadLine();
        }
    }
}
