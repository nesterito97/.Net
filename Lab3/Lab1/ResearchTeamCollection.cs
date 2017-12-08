using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class ResearchTeamCollection
    {
        private List<ResearchTeam> ResearchTeamColl = new List<ResearchTeam>();
        public void AddDefaults(int n){
            for (int i = 0; i < n; i++) {
                ResearchTeamColl.Add(new ResearchTeam("investigationName"+(i+1), TimeFrame.Year));
            }
        }

        public void AddResearchTeams(params ResearchTeam[] researchTeam) {
            foreach (ResearchTeam rteam in researchTeam){
                ResearchTeamColl.Add(rteam);
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
                if (ResearchTeamColl == null || ResearchTeamColl.Count == 0)
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


            List<ResearchTeam> resteamList;

            var regnumberQuery = from resteam in ResearchTeamColl
                                 where resteam.Participants.Count == value
                                 group resteam by resteam.RegNumber;

         

            IEnumerable<ResearchTeam> resTeam = regnumberQuery.SelectMany(group => group);
            resteamList = resTeam.ToList();

            return resteamList;
            
        }

        
    }
}
