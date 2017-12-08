using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Lab2
{
    [Serializable]
    public class ResearchTeam : Team, /*INameAndCopy,*/ IComparer<ResearchTeam>, ISerializable
    {
        [XmlElement("investigationName")]
        /*private*/
        public string investigationName;
        [XmlElement("duration")]
        /*private*/
        public TimeFrame duration;

        [XmlArrayItem(typeof(Person))]
        [XmlElement("duration")]
        /*private*/public List<Person> participants;

        [XmlArrayItem(typeof(Person))]
        [XmlElement("duration")]
        /*private*/
        public List<Paper> publicationList;

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

        public T DeepCopy<T>() {
            using (var ms = new MemoryStream()) {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, this);
                ms.Position = 0;
                return (T)formatter.Deserialize(ms);
            }          
        }

        public bool Save(string filename) {
            if (this == null)
                return false;
            try
            {
               
               FileStream s = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite);
               BinaryFormatter B = new BinaryFormatter();
               B.Serialize(s, this);
               s.Close();

            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return true;
        }

        public bool Load(string filename) {
            if (string.IsNullOrEmpty(filename)) {
                return false;
            }

            ResearchTeam objOut = default(ResearchTeam);

            try
            {
                
                FileStream Fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                BinaryFormatter F = new BinaryFormatter();
                objOut = (ResearchTeam)F.Deserialize(Fs);

                OrganizationName = objOut.OrganizationName;
                RegNumber = objOut.RegNumber;

                this.InvestigationName =  objOut.InvestigationName;
                this.InvDuration = objOut.InvDuration;
                this.Participants = objOut.Participants;
                this.PublicationList = objOut.PublicationList;
                Fs.Close();

                return true;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public bool AddFromConsole() {
            
            //publicationList
            Console.WriteLine("String Format For This Type of List: \n publicationName ; name, surname, day.month.year ; day.month.year ;");
            string row = Console.ReadLine();

            try
            {
                string[] rowMas = row.Split(';');

                string[] publicationdateMas = rowMas[2].Split('.');

                string publicationName = rowMas[0];

                //------------------author------------------------------
                string[] authorMas = rowMas[1].Split(',');
                string[] birthday = authorMas[2].Split('.');
                Person author = new Person(authorMas[0], authorMas[1], new DateTime( Int32.Parse(birthday[2]), Int32.Parse(birthday[1]), Int32.Parse(birthday[0]) ));
                //------------------------------------------------------

                DateTime publicationDate = new DateTime(Int32.Parse(publicationdateMas[2]), Int32.Parse(publicationdateMas[1]), Int32.Parse(publicationdateMas[0]));

                Paper paper = new Paper(publicationName, author, publicationDate);

                publicationList.Add(paper);

            }
             catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            
            return true;
        }

        public static bool Save<T>(string filename, T obj) {
            if (obj == null)
                return false;

            try
            {
                
                 FileStream s = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite);
                 BinaryFormatter B = new BinaryFormatter();
                 B.Serialize(s, obj);
                 s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return true;
        }

        public static T Load<T>(string filename, T obj)
        {
            if (string.IsNullOrEmpty(filename))
                return default(T);

            //T obj = default(T);
            //obj = default(T);
            try
            {
                
                FileStream Fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                BinaryFormatter F = new BinaryFormatter();
                obj = (T)F.Deserialize(Fs);

                /*this.InvestigationName = objOut.InvestigationName;
                this.InvDuration = objOut.InvDuration;
                this.Participants = objOut.Participants;
                this.PublicationList = objOut.PublicationList;*/
                Fs.Close();
            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);             
            }
            return obj;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("OrganizationName", SimilarWithBase.OrganizationName);
            info.AddValue("RegNumber", SimilarWithBase.RegNumber);

            info.AddValue("investigationName", InvestigationName);
            info.AddValue("duration", InvDuration);
            info.AddValue("participants", Participants);
            info.AddValue("publicationList", PublicationList);

                //public List<Person> participants;
        
                //List<Paper> publicationList;
        /*foreach (Person p in participants)
        {
            info.AddValue("Name", p.Name);
            info.AddValue("Surname", p.Surname);
            info.AddValue("Birthday", p.Birthday);
        }
        foreach (Paper paper in publicationList)
        {
            info.AddValue("publicationName", paper.publicationName);
            info.AddValue("author", paper.author);
            info.AddValue("publicationDate", paper.publicationDate);
        }*/

    }

        public ResearchTeam(SerializationInfo info, StreamingContext context)
        {
            OrganizationName = (string)info.GetValue("OrganizationName", typeof(string));
            RegNumber = (int)info.GetValue("RegNumber", typeof(int));

            InvestigationName = (string)info.GetValue("investigationName", typeof(string));
            InvDuration = (TimeFrame)info.GetValue("duration", typeof(TimeFrame));
            Participants = (List<Person>)info.GetValue("participants", typeof(List<Person>));
            PublicationList = (List<Paper>)info.GetValue("publicationList", typeof(List<Paper>));
        }
    }
}
