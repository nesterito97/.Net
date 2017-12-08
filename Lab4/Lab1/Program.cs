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
            ResearchTeamCollection rcol1 = new ResearchTeamCollection();
            ResearchTeamCollection rcol2 = new ResearchTeamCollection();
            rcol1.CollectionName = "Collection 1";
            rcol2.CollectionName = "Collection 2";

            TeamsJournal tj1 = new TeamsJournal();
            TeamsJournal tj2 = new TeamsJournal();

            rcol1.ResearchTeamAdded += tj1.EventHandler;
            rcol1.ResearchTeamInserted += tj1.EventHandler;

            rcol2.ResearchTeamAdded += tj1.EventHandler;
            rcol2.ResearchTeamAdded += tj2.EventHandler;
            rcol2.ResearchTeamInserted += tj1.EventHandler;
            rcol2.ResearchTeamInserted += tj2.EventHandler;


            //--------------Add Elements---------------------
            rcol1.AddDefaults(2);
            rcol2.AddDefaults(2);

            //-------------Insert---------------------------
            ResearchTeam r1 = new ResearchTeam("InvestigName 1", TimeFrame.TwoYears);
            r1.OrganizationName = "OrganzationOfRT 1";
            r1.RegNumber = 100;

            ResearchTeam r2 = new ResearchTeam("InvestigName 2", TimeFrame.TwoYears);
            r1.OrganizationName = "OrganzationOfRT 2";
            r1.RegNumber = 101;

            ResearchTeam r3 = new ResearchTeam("InvestigName 3", TimeFrame.Long);
            r1.OrganizationName = "OrganzationOfRT 3";
            r1.RegNumber = 102;

            ResearchTeam r4 = new ResearchTeam("InvestigName 4", TimeFrame.Year);
            r1.OrganizationName = "OrganzationOfRT 4";
            r1.RegNumber = 103;


            rcol1.InsertAt(1, r1);
            rcol2.InsertAt(1, r2);

            rcol1.InsertAt(24, r3);
            rcol2.InsertAt(45, r4);
            Console.WriteLine(tj1.ToString());
            Console.WriteLine(tj2.ToString());

            Console.ReadKey();
        }
    }
}
