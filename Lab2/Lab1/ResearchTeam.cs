using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class ResearchTeam : Team, INameAndCopy
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

        public Paper LastPublication {
            get {

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


        //Indexer
        /*public bool this[TimeFrame time] {
            get {
                if (time.Equals(this.duration))
                    return true;
                else
                    return false;
            }
        }*/

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

            string listOfParticipants = "";
            if (participants != null) {
                for (int i = 0; i < participants.Count; i++) {
                    listOfParticipants = listOfParticipants + (i + 1) + ": " + participants[i].ToString() + "; \n";
                }
            }


            string listOfPublications = "";
            if (publicationList != null) {

                for (int i = 0; i < publicationList.Count; i++) {
                    listOfPublications = listOfPublications + (i + 1) + ": " + publicationList[i].ToString() + "; \n";
                }
            }
            return "InvestigationName: " + investigationName + "; Duration: " + duration.ToString() + "\n Publications: \n" + listOfPublications + "\n Partisipants : \n" + listOfParticipants;
        }

        public virtual string ToShortString() {
            return "InvestigationName: " + investigationName + "; Duration: " + duration.ToString() + ".";
        }

        public override object DeepCopy()
        {
            ResearchTeam copy = (ResearchTeam)this.MemberwiseClone();

            copy.investigationName = String.Copy(investigationName);
            copy.duration = this.duration;
            //copy.participants = this.participants;
            //copy.publicationList = this.publicationList;
            copy.participants = new List<Person>(participants);
            copy.publicationList = new List<Paper>(publicationList);

            return copy;
        }

        public Team SimilarWithBase {
            get {
                Team obj;
                obj = (Team)base.getDeepCopy(this);
                return obj;
            }

            set {
                base.Name = value.Name;
                base.OrganizationName = value.OrganizationName;
                base.RegNumber = value.RegNumber;
            }
        }


        public override object getDeepCopy(object DeepCopy)
        {
            return DeepCopy;
        }

        public string Name {
            get {
                return investigationName;
            }
            set {
                investigationName = value;
            }
        }

        public IEnumerable<Person> ParticipantsWoutPublications(){
            /*if (publicationList == null) {
                foreach (Person i in participants) {
                    yield return i;
                }
            }*/
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
            //Console.WriteLine("Current year :" + currentYear + "  "+ current.ToString() + "\n");
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
    }
}
