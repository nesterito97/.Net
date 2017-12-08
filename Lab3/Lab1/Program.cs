using System;
using System.Collections.Generic;
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
            ResearchTeamCollection rtc = new ResearchTeamCollection();

            ResearchTeam rt1 = new ResearchTeam("invName1", TimeFrame.Year);
            rt1.OrganizationName = "Organization 1";
            rt1.RegNumber = 1;
            Person[] participants = { new Person("John", "Smith", new DateTime(1985, 6, 3)) };
            rt1.AddPartisipants(participants);
            Paper[] papers = { new Paper("Part1: John Smith's Water Theory", participants[0], new DateTime(2000, 7, 13)) };
            rt1.AddPapers(papers);

            ResearchTeam rt2 = new ResearchTeam("invName2", TimeFrame.Year);
            rt2.OrganizationName = "Organization 2";
            rt2.RegNumber = 2;
            Person[] participants2 = {
                new Person("Aron", "Good", new DateTime(1985, 6, 3)),
                new Person("Samantha", "Hill", new DateTime(1990, 2,23))
            };
            rt2.AddPartisipants(participants2);
            Paper[] papers2 = {
                new Paper("Part1: Samantha Brown: Air and Everything it consists", participants2[1], new DateTime(2000, 7, 13)),
                new Paper("Part2: Aron Good's: Polution of Environment", participants2[0], new DateTime(2001, 8, 15))
            };
            rt2.AddPapers(papers2);

            ResearchTeam rt3 = new ResearchTeam("invName3", TimeFrame.TwoYears);
            rt3.OrganizationName = "Organization 3";
            rt3.RegNumber = 3;

            ResearchTeam rt4 = new ResearchTeam("invName4", TimeFrame.TwoYears);
            rt4.OrganizationName = "Organization 4";
            rt4.RegNumber = 4;

            ResearchTeam[] mas = { rt3, rt4, rt1, rt2 };

            rtc.AddResearchTeams(mas);
            
            Console.WriteLine(rtc.ToShortString());


            //------Sorting-------------------



            //rtc.SortByRegNumber();


            //Console.WriteLine(rtc.ToShortString());



            rtc.SortByInvName();

            Console.WriteLine(rtc.ToShortString());

            //rtc.SortByPublicationsQuantity();
            //Console.WriteLine(rtc.ToShortString());

            //-----------Operations with Collection-----------
            int minnumber = rtc.GetMinRegNumber;
            Console.WriteLine("\nMinRegNumber: " + minnumber);

            Console.WriteLine("\n\n\nResearch Teams with Two Years investigation: \n");

            foreach (ResearchTeam rt in rtc.TwoYearsInvestigation) {
                Console.WriteLine(rt.ToShortString()); 
            }

            Console.WriteLine("\n\n\n");
            Console.WriteLine("Participants with n publications :\n");
            List<ResearchTeam> listrt = rtc.NGroup(0);

            foreach (ResearchTeam rt in listrt){
                Console.WriteLine(rt.ToString()); 
            }


            //---------------------------------------------------

            /*TestCollections testcol = new TestCollections(15);

            Console.WriteLine("\n\n\nTIME OF SEARCHING: \n");
            testcol.ShowTime(1);
            Console.WriteLine("\n\n 8: \n");
            testcol.ShowTime(8);
            Console.WriteLine("\n\n 15: \n");
            testcol.ShowTime(15);*/

            TestCollections testcol = new TestCollections(200);

            Console.WriteLine("\n\n\nTIME OF SEARCHING: \n");
            testcol.ShowTime(1);
            Console.WriteLine("\n\n 100: \n");
            testcol.ShowTime(100);
            Console.WriteLine("\n\n 200: \n");
            testcol.ShowTime(200);

            //testcol.ShowTime(0);
            Console.ReadKey();
        }
    }
}
