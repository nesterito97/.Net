using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public enum TimeFrame { Year, TwoYears, Long }
    
    class Program
    {

        
        static void Main(string[] args)
        {
            //ResearchTeam rt1 = new ResearchTeam("invName1", TimeFrame.Long);
            ResearchTeam rt1 = new ResearchTeam("invName1", TimeFrame.Long);

            rt1.OrganizationName = "Organization1";
            rt1.RegNumber = 1;

            Person author1 = new Person("James", "Lock", new DateTime(1963,12,1));
            Person author2 = new Person("Julia", "Brook", new DateTime(1987, 4, 3));
            rt1.Participants.Add(author1);
            rt1.Participants.Add(author2);
            Paper paper1 = new Paper("How does it work?: By James Lock", author1, new DateTime(1980, 11, 8));
            Paper paper2 = new Paper("Counting the stars", author2, new DateTime(2000, 9, 12));
            rt1.PublicationList.Add(paper1);
            rt1.PublicationList.Add(paper2);

            ResearchTeam rt2 = rt1.DeepCopy<ResearchTeam>();

            Console.WriteLine("Object: \n" + rt1.ToString());
            Console.WriteLine("Copy: \n" + rt2.ToString());


            //Console.WriteLine("Please write down filename: ");
            //string filename = Console.ReadLine();
            string filename = @"D:\STUDY\Course 4 University\NET\Lab5\Lab1\file.xml";
            //string filename = "file.xml";

            ResearchTeam rt3 = new ResearchTeam();
            if (!File.Exists(filename))
            {
                Console.WriteLine("File with name " + filename + " doesn't exist. It will be created soon.");
                File.Create(filename);
            }
            else {
                //rt3.Load(filename);
                //rt1.Save(filename);
                //rt3.Load(filename);
            }
            Console.WriteLine("\n\nFrom File : ");
            Console.WriteLine(rt3.ToString());

            //--------------------------------------------------------
            Console.WriteLine("\n\n\n\n");
            //rt3.AddFromConsole();
            //rt3.Save(filename);
            //Console.WriteLine("\n");
            //Console.WriteLine("New Version after Adding : \n"+rt3.ToString());

            //----------------static--methods-------------------------
            rt3 = ResearchTeam.Load<ResearchTeam>(filename, rt3);
            Console.WriteLine("\n\n\nLoaded static  method: \n"+rt3.ToString());
            //rt3.AddFromConsole();
            ResearchTeam.Save<ResearchTeam>(filename, rt3);
            Console.WriteLine("\n\nResult :\n"+rt3.ToString());
            Console.ReadKey();
        }
    }
}
