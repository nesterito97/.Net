using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class TeamListHandlerEventArgs : EventArgs
    {
        public string CollectionName {
            get; set;
        }

        public string TypesOfChange {
            get; set;
        }

        public int ElementNumber {
            get; set;
        }

        public TeamListHandlerEventArgs(string colname, string type, int elementnumber) {
            CollectionName = colname;
            TypesOfChange = type;
            ElementNumber = elementnumber;
        }

        public override string ToString()
        {
            return "Collection Name : " + CollectionName + "; TypesOfChange : " + TypesOfChange + "; Element Added/Deleted : " + ElementNumber + ";\n";
        }
    }
}
