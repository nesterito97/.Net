using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public delegate void TeamListHandler(object source, TeamListHandlerEventArgs args);
    

    class ResearchTeamCollection
    {

        private List<ResearchTeam> ResearchTeamColl = new List<ResearchTeam>();
        
        
        public string CollectionName {
            get; set;
        }

        public void InsertAt(int j, ResearchTeam researchTeam) {
            ResearchTeam rt = ResearchTeamColl.ElementAtOrDefault(j);
            if (j == 0)
            {
                //ResearchTeamColl.Add(researchTeam);
                ResearchTeamColl.Insert(0, researchTeam);
                ResearchTeamAdded(this, new TeamListHandlerEventArgs(this.CollectionName, "Element Added", 0));
            }
            else if((object) rt == null)
            {
                ResearchTeamColl.Add(researchTeam);
                ResearchTeamAdded(this, new TeamListHandlerEventArgs(this.CollectionName, "Element Added", ResearchTeamColl.Count-1));
            }
            else
            {
                ResearchTeamColl.Insert(j - 1, researchTeam);
                ResearchTeamInserted(this, new TeamListHandlerEventArgs(this.CollectionName, "Element Inserted", j - 1));
            }
        }

        public ResearchTeam this[int i] {
            get { return ResearchTeamColl[i]; }
            set { ResearchTeamColl[i] = value; }
        }



        //public event EventHandler<TeamListHandlerEventArgs> ResearchTeamAdded;
        public event TeamListHandler ResearchTeamAdded;
        public event TeamListHandler ResearchTeamInserted; 

        public void AddDefaults(int n){
            for (int i = 0; i < n; i++) {
                ResearchTeam rt = new ResearchTeam("investigationName" + (i + 1), TimeFrame.Year);
                ResearchTeamColl.Add(rt); 
                ResearchTeamAdded(this, new TeamListHandlerEventArgs(this.CollectionName, "Element Added", ResearchTeamColl.Count-1));
            }
        }

        public void AddResearchTeams(params ResearchTeam[] researchTeam) {
            foreach (ResearchTeam rteam in researchTeam){
                ResearchTeamColl.Add(rteam);
                ResearchTeamAdded(this, new TeamListHandlerEventArgs(this.CollectionName, "Element Added", ResearchTeamColl.Count - 1));
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (ResearchTeam resteam in ResearchTeamColl){
                sb.Append(resteam.ToString() + "\n");
            }                
            return sb.ToString();
        }

        public virtual string ToShortString() {
            StringBuilder sb = new StringBuilder();
            foreach (ResearchTeam resteam in ResearchTeamColl) {
                sb.Append(resteam.ToShortString() + "\n PublicationsCount: " + resteam.PublicationList.Count + "; ParticipantsCount: " + resteam.Participants.Count + "\n");
            }
            return sb.ToString();
        }

        public void SortByRegNumber() {
            ResearchTeamColl.Sort();
        }

        public void SortByInvName()
        {
            ResearchTeam comparer = new ResearchTeam();
            ResearchTeamColl.Sort(comparer);
        }

        public void SortByPublicationsQuantity() {
            ResearchTeamComparer comparer = new ResearchTeamComparer();
            ResearchTeamColl.Sort(comparer);
        }

        public int GetMinRegNumber {
            get {   
                if (ResearchTeamColl == null)
                {
                    return -1;
                }
                return ResearchTeamColl.Min(f => f.RegNumber); ;
            }
        }

        public IEnumerable<ResearchTeam> TwoYearsInvestigation {
            get {
                return ResearchTeamColl.Where(f => f.InvDuration == TimeFrame.TwoYears);
            }
        }



        public List<ResearchTeam> NGroup(int value) {
            

            List<ResearchTeam> resteamList = new List<ResearchTeam>();

            var regnumberQuery = from resteam in ResearchTeamColl
                                 where resteam.Participants.Count == value
                                 group resteam by resteam.RegNumber;

         

            IEnumerable<ResearchTeam> resTeam = regnumberQuery.SelectMany(group => group);
            resteamList = resTeam.ToList();

            return resteamList;
            
        }

        
    }
}
