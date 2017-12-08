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
            Team team1 = new Team("Orange", 1);
            Team team2 = new Team("Orange", 1);

            Console.WriteLine("Equals :" + team1.Equals(team2)+'\n');

            Console.WriteLine("team1 == team2: " + (team1 == team2) + '\n');

            Console.WriteLine("ReferenceEquals: " + object.ReferenceEquals(team1, team2)+'\n');

            Console.WriteLine("team1 hashCode: " + team1.GetHashCode() + '\n');

            Console.WriteLine("team2 hashCode: " + team2.GetHashCode() + '\n');


            try
            {
                team1.RegNumber = -1;
            }
            catch (Exception e) {
                Console.WriteLine("ERROR: " + e.Message + "\n\n");
            }


            ResearchTeam firstResearchTeam = new ResearchTeam();
            firstResearchTeam.InvestigationName = "First Investigtion";
            firstResearchTeam.InvDuration = TimeFrame.TwoYears;
            firstResearchTeam.OrganizationName = "Raid";
            firstResearchTeam.RegNumber = 3;

            Person[] investigators = { new Person("John", "Smith", new DateTime(1981, 1, 1)), new Person("Lara", "Feryl", new DateTime(1990, 5, 16)) };
            Paper[] papers = {
                new Paper("Part1: Life cycle", investigators[0] , new DateTime(2011, 6, 5)),
                new Paper("Part2: What causes cancer?", investigators[1], new DateTime (2012, 9, 27))
            };

            firstResearchTeam.AddPartisipants(investigators);
            firstResearchTeam.AddPapers(papers);


            Console.WriteLine(firstResearchTeam.ToString());

            Console.WriteLine("Team's class field output:" + firstResearchTeam.OrganizationName);



            Console.WriteLine("\n\n\n");
            ResearchTeam secondResearchTeam = (ResearchTeam)firstResearchTeam.DeepCopy();
            Console.WriteLine("Second ResearchTeam: \n\n" + secondResearchTeam.ToString());

            Paper[] firstInvGroupWorks = {
                new Paper("Part3: Insects", investigators[0], new DateTime(2010, 8, 16))
            };
            firstResearchTeam.AddPapers(firstInvGroupWorks);
            firstResearchTeam.InvDuration = TimeFrame.Year;
            firstResearchTeam.InvestigationName = "Changed Investigation Name";

            Console.WriteLine("First ResearchTeam after adding new works: \n\n" + firstResearchTeam.ToString() + "\n\n");

            Console.WriteLine("Check Copy after DeepCopy() method: \n" + secondResearchTeam.ToString() + "\n\n");

            //--------------------------------------------------------------------------------
            Person[] person = { new Person("Samantha", "Brown", new DateTime(1989,9,18)) };

            firstResearchTeam.AddPartisipants(person);

            Console.WriteLine("Participants Without Publications :\n");
            foreach (Person p in firstResearchTeam.ParticipantsWoutPublications())
            {
                Console.WriteLine(p.ToShortString() + "\n");
            }

            //--------------------------------------------------------------------------------
            Paper[] additionalWorks = {
                new Paper("Part4: Wild Animals", investigators[1], new DateTime(2016, 8, 19)),
                new Paper("Main Article About Our Nature", investigators[0], new DateTime(2017, 10, 28))
            };

            firstResearchTeam.AddPapers(additionalWorks);

            int n = 2;
            Console.WriteLine("\n\n\nPublications for last "+ n +" years:\n");
            foreach (Paper p in firstResearchTeam.LastNYearsPublications(n))
            {
                Console.WriteLine(p.ToString() + "\n");
            }


            //-------------Additional Tasks Main()--------------------------

            Console.WriteLine("\n\n\nParticipants With Publications :\n");
            foreach (Person p in firstResearchTeam.ParticipantsWithPublications())
            {
                Console.WriteLine(p.ToShortString() + "\n");
            }


            Console.WriteLine("\n\n\nParticipants With More Than ONE Publications :\n");
            foreach (Person p in firstResearchTeam.PublicationsMoreThanOne())
            {
                Console.WriteLine(p.ToShortString() + "\n");
            }


            Console.WriteLine("\n\n\nPublications For The Last Year :\n");
            foreach (Paper p in firstResearchTeam.LastYearPublications())
            {
                Console.WriteLine(p.ToString() + "\n");
            }

            Console.ReadKey();
        }
    }
}
