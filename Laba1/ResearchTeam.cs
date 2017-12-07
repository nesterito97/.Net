using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ResearchTeam
    {
        private String NameOfResearch { get; set; }
        private String NameOfOrganization { get; set; }
        private int NumberOfRegestration { get; set; }
        private Timeframe TimeOfResearch { get; set; }
        private Paper[] ListOfPublication = new Paper[] { new Paper() };

        public ResearchTeam(String NameOfResearch, String NameOfOrganization, int NumberOfRegestration, Timeframe TimeOfResearch)
        {
            this.NameOfResearch = NameOfResearch;
            this.NameOfOrganization = NameOfOrganization;
            this.NumberOfRegestration = NumberOfRegestration;
            this.TimeOfResearch = TimeOfResearch;
        }

        public ResearchTeam()
        {
            NameOfResearch = "Story";
            NameOfOrganization = "TheoryAndPractice";
            NumberOfRegestration = 12;
            TimeOfResearch = Timeframe.Long;

        }

        public Paper LastPublication
        {
            get
            {
                if (ListOfPublication.Length == 0)
                {
                    return null;

                }

                return ListOfPublication[ListOfPublication.Length - 1];
            }
            
             
        }

        public bool this[Timeframe TimeResearch]
        {
            get
            {
                if  (TimeResearch == TimeOfResearch)
                {
                    return true;
                }
                return false;

            }

        }

        public void AddPapers(Paper[] list)
        {
            int count_publication = this.ListOfPublication.Length;
            int add_count = list.Length;
            Array.Resize(ref this.ListOfPublication, count_publication + add_count);
            for(int i=0; i<add_count; i++)
            {
                this.ListOfPublication[count_publication + i] =  list[i];
            }

            
        }

        public override string ToString()
        {
            return String.Format("{0}  {1}  {2}  {3}  {4}", NameOfResearch, NameOfOrganization, NumberOfRegestration, TimeOfResearch, ListOfPublication);

        }

        public virtual String ToShortString()
        {
            return "NameOfResearch: " + NameOfResearch + "\nNameOfOrganization: " + NameOfOrganization + "\nNumberOfRegestration: "
                + NumberOfRegestration + "\nTimeOfResearch: " + TimeOfResearch;


        }

    }
}
