using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class TestCollections
    {
        private List<Team> teamList = new List<Team>();
        private List<string> stringList = new List<string>();
        private Dictionary<Team, ResearchTeam> teamRTDictionary = new Dictionary<Team, ResearchTeam>();
        private Dictionary<string, ResearchTeam> stringRTDictionary = new Dictionary<string, ResearchTeam>();

        static ResearchTeam CreateResearchTeam(int n) {
            ResearchTeam obj = new ResearchTeam("invName "+n, TimeFrame.Year);
            obj.OrganizationName = "Organization " + n;
            obj.RegNumber = n; 
            return obj;
        }

        public TestCollections(int n) {
            for (int i = 1; i <= n; i++) {
                ResearchTeam obj = CreateResearchTeam(i);
                Team tobj = obj.SimilarWithBase;
                
                teamList.Add(tobj);

                teamRTDictionary.Add(tobj, obj);

                stringList.Add(tobj.ToString());

                stringRTDictionary.Add(stringList[i-1], obj);
            }
            
        }

        public void ShowTime(int n) {

            Team t1 = new Team("Organization " + n, n);


            
            Stopwatch watch = new Stopwatch();
            watch.Start();
            bool contains = teamList.Contains<Team>(t1);
            watch.Stop();
            long msec = watch.ElapsedTicks;
            
            Console.WriteLine("List<Team>: " + contains + " " + msec);


           
            watch.Restart();
            contains = stringList.Contains<string>(t1.ToString());
            watch.Stop();
            msec = watch.ElapsedTicks;
            
            Console.WriteLine("List<string>: " + contains + " " + msec);


            //---------------------------------------------------------------------
            ResearchTeam rt1 = new ResearchTeam("invName " + n, TimeFrame.Year);
            rt1.OrganizationName = "Organization " + n;
            rt1.RegNumber = n;

            
            watch.Restart();
            contains = teamRTDictionary.ContainsKey(t1);
            watch.Stop();
            msec = watch.ElapsedTicks;
            
            Console.WriteLine("List<Team, ResearchTeam>: " + contains + " " + msec);


            
            watch.Restart();
            contains = stringRTDictionary.ContainsKey(t1.ToString());
            watch.Stop();
            msec = watch.ElapsedTicks;
            
            Console.WriteLine("List<string, ResearchTeam>: " + contains + " " + msec);

            //---------------------------------------------------------------------

            
            watch.Restart();
            contains = teamRTDictionary.ContainsValue(rt1);
            watch.Stop();
            msec = watch.ElapsedTicks;
            

            Console.WriteLine("List<Team, ResearchTeam> CONTAINSValue res: " + contains + " " + msec);

        }
    }
}
