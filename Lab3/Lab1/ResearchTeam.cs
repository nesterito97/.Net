using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class ResearchTeam : Team, INameAndCopy, IComparer<ResearchTeam>
    {
        private string investigationName;
        private TimeFrame duration;
        private List<Person> participants;
        private List<Paper> publicationList;

        public ResearchTeam(string invName, TimeFrame time) {
            investigationName = invName;
            duration = time;
            participants = new List<Person>();
            publicationList = new List<Paper>();
        }

        public ResearchTeam() {
            investigationName = "invName";
            duration = TimeFrame.Long;
            participants = new List<Person>();
            publicationList = new List<Paper>();
        }

        public string InvestigationName {
            get => investigationName;
            set => investigationName = value;
        }


        public TimeFrame InvDuration {
            get => duration;
            set => duration = value;
        }

        public List<Paper> PublicationList {
            get => publicationList;
            set => publicationList = value;
        }

        public List<Person> Participants
        {
            get => participants;
            set => participants = value;
        }

        public Paper LastPublication {
            get {

                //publicationList.OrderByDescending(x => x.publicationDate).FirstOrDefault();

                Paper lastPublication = null;
                if (publicationList != null)
                {
                    lastPublication = publicationList[0];

                    for (int i = 0; i < publicationList.Count; i++)
                    {
                        if (publicationList[i].publicationDate > lastPublication.publicationDate)
                            lastPublication = publicationList[i];
                    }
                }

                return lastPublication;
            }
        }


 
        public void AddPapers(params Paper[] papers) {
            int len;


            len = papers.Length;
            for (int i = 0; i < len; i++)
            {
                publicationList.Add(papers[i]);
            }

        }


        public void AddPartisipants(params Person[] people)
        {
            int len;


            len = people.Length;

            for (int i = 0; i < len; i++)
            {
                participants.Add(people[i]);
            }

        }

        public override string ToString()
        {

            
            StringBuilder sbParticipants = new StringBuilder();
            if (participants != null) {
               
                for (int i = 0; i < participants.Count; i++)
                {
                    sbParticipants.Append(i + 1 + ": " + participants[i].ToString() + "\n");
                }
            }

            StringBuilder sbPublications = new StringBuilder();
            
            if (publicationList != null) {
               
                for (int i = 0; i < publicationList.Count; i++) {
                    sbPublications.Append(i + 1 + ": " + publicationList[i].ToString() + " \n");                   
                }
            }
            return "InvestigationName: " + investigationName + "; Duration: " + duration.ToString() + "\n Publications: \n" + sbPublications.ToString() + "\n Participants : \n" + sbParticipants.ToString();
         }

        public virtual string ToShortString() {
            return "InvestigationName: " + investigationName + "; Duration: " + duration.ToString() + ".";
        }

        public override object DeepCopy()
        {
            ResearchTeam copy = (ResearchTeam)this.MemberwiseClone();

            copy.investigationName = String.Copy(investigationName);
            copy.duration = this.duration;

            
            copy.participants = participants.Select(person => new Person(person.Name, person.Surname, person.Birthday)).ToList<Person>();
            copy.publicationList = publicationList.Select(paper => new Paper(paper.publicationName, paper.author, paper.publicationDate)).ToList<Paper>();


            return copy;
        }

        public Team SimilarWithBase {
            get {
                Team obj;
                //obj = (Team)base.GetDeepCopy(this);
                obj = (Team)base.DeepCopy();
                
                return obj;
            }

            set {
                base.Name = value.Name;
                OrganizationName = value.OrganizationName;
                RegNumber = value.RegNumber;
            }
        }


        public override object GetDeepCopy(object DeepCopy)
        {
            return this.DeepCopy();
        }

        /*public string Name {
            get {
                return investigationName;
            }
            set {
                investigationName = value;
            }
        }*/

        public IEnumerable<Person> ParticipantsWoutPublications(){
            
            if (publicationList != null) {
                foreach (Person i in participants) {
                    bool cond = false;
                    foreach (Paper j in publicationList) {
                        if (i.Equals(j.author))
                            cond = true;
                    }
                    if (cond == false)
                        yield return i;
                }
            }
        }

        public IEnumerable<Paper> LastNYearsPublications(int n) {
            DateTime current = DateTime.Now;
            int currentYear = current.Year;
            
            foreach (Paper j in publicationList) {
                if (j.publicationDate.Year > currentYear - n) {
                    yield return j;
                }
            }
        }

        // ----------------Additional Tasks-----------------

        public IEnumerable<Person> ParticipantsWithPublications()
        {           
            if (publicationList != null)
            {
                foreach (Person i in participants)
                {
                    bool cond = false;
                    foreach (Paper j in publicationList)
                    {
                        if (i.Equals(j.author))
                        {
                            cond = true;
                            break;
                        }                           
                    }
                    if (cond == true)
                        yield return i;
                }
            }
        }


        public IEnumerable<Person> PublicationsMoreThanOne()
        {
            if (publicationList != null)
            {
                foreach (Person i in participants)
                {
                    bool cond = false; int count = 0;
                    foreach (Paper j in publicationList)
                    {
                        if (i.Equals(j.author))
                        {
                            cond = true;
                            count++; 
                        }
                    }
                    if (cond == true && count > 1)
                        yield return i;
                }
            }
        }


        public IEnumerable<Paper> LastYearPublications()
        {
            DateTime current = DateTime.Now;
            int currentYear = current.Year;

            foreach (Paper j in publicationList)
            {
                if (j.publicationDate.Year > currentYear - 1)
                {
                    yield return j;
                }
            }
        }

        int IComparer<ResearchTeam>.Compare(ResearchTeam x, ResearchTeam y)
        {
            return x.InvestigationName.CompareTo(y.InvestigationName);
        }

       
    }
}
