using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class TeamsJournalEntry
    {
        public string CollectionName {
            get; set;
        }

        public string TypeOfChange {
            get; set;
        }

        public int NewElementNumber {
            get; set;
        }

        public TeamsJournalEntry(string colname, string typeofchange, int elnumber){
            CollectionName = colname;
            TypeOfChange = typeofchange;
            NewElementNumber = elnumber;
        }
        public override string ToString()
        {
            return "Colname : "+CollectionName+"; "+"TypeOfChange : "+TypeOfChange+"; "+"NewElementNumber "+ NewElementNumber+";\n";
        }
    }
}
