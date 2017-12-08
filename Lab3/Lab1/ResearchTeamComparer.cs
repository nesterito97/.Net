using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2 
{
    class ResearchTeamComparer : IComparer<ResearchTeam>
    {
        int IComparer<ResearchTeam>.Compare(ResearchTeam x, ResearchTeam y)
        {
            return x.PublicationList.Count.CompareTo(y.PublicationList.Count);
        }
    }
}
