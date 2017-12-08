using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Team : INameAndCopy
    {
        protected string _OrganizationName;
        protected int _RegNumber;


        public Team(string OrgName, int RegN)
        {
            _OrganizationName = OrgName;
            _RegNumber = RegN;
        }

        public Team()
        {
            _OrganizationName = "";
            _RegNumber = 0;
        }

        public string OrganizationName
        {
            get { return _OrganizationName; }
            set { _OrganizationName = value; }
        }

        public int RegNumber
        {
            get { return _RegNumber; }
            set {
                if (value <= 0)
                    throw new Exception("Digit is lower or equals zero");
                _RegNumber = value;
            }
        }

        

        public virtual object DeepCopy()
        {
            Team copy = (Team)this.MemberwiseClone();
            copy._OrganizationName = String.Copy(_OrganizationName);
            copy._RegNumber = RegNumber;
            return copy;
        }


        public string Name {
            get => _OrganizationName;
            set => _OrganizationName = value;
        }

        public virtual object getDeepCopy(object DeepCopy)
        {
            return DeepCopy;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;


            Team team = obj as Team;

            if ((object)team == null)
                return false;

            return (_OrganizationName == team._OrganizationName) && (_RegNumber == team._RegNumber);
        }


        public override int GetHashCode()
        {
            return _OrganizationName.GetHashCode() + _RegNumber.GetHashCode();
        }

        public static bool operator ==(Team team1, Team team2)
        {
            if (((object)team1 == null) || ((object)team2 == null))
                return false;


            //return team1.Equals(team2) && !(team1.GetHashCode() == team2.GetHashCode());
            return team1.Equals(team2) && (team1.GetHashCode() == team2.GetHashCode());
        }



        public static bool operator !=(Team team1, Team team2)
        {
            return !(team1.Equals(team2)) && (!(team1.GetHashCode() == team2.GetHashCode()));
        }

        public override string ToString()
        {
            return "OrganizationName: " + _OrganizationName + "; RegistrationNumber: " + _RegNumber;
        }
    }
}
