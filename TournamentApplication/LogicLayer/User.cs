using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class User
    {
        private int id;
        private string fName;
        private string lName;
        private string email;
        private string adress;
        private string password;
        private string role;
        private List<Tournament> tournaments;

        public int Id { get { return this.id; } }

        public string FName
        {
            get { return this.fName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new MyException("Name cannot be left empty!");
                }
                this.fName = value;
            } }
        public string LName { get { return this.lName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new MyException("Name cannot be left empty!");
                }
                this.lName = value;
            }
        }

        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Must be a valid Email")]
        public string Email { get { return this.email; } }

        public string Adress { get { return this.adress; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new MyException("Name cannot be left empty!");
                }
                this.adress = value;
            }
        }

        public string Password
        {
            get { return this.password; }
            private set
            {
                if (value.Length < 6)
                {
                    throw new MyException("Password must contain at least 6 or more symbols");
                }
                this.password = value;
            }
        }
        public string Role { get { return this.role; } }
        public List<Tournament> Tournaments { get { return this.tournaments; } }

        public User(int id, string fName, string lName, string email, string adress, string password, string role)
        {
            this.id = id;
            this.fName = fName;
            this.lName = lName;
            this.email = email;
            this.adress = adress;
            this.password = password;
            this.role = role;
        }


        public User(string fName, string lName, string email, string adress, string password, string role)
        {
            this.FName = fName;
            this.LName = lName;
            this.email = email;
            this.Adress = adress;
            this.Password = password;
            this.role = role;
        }

        public void AssignTournament(Tournament tournament)
        {
            tournaments.Add(tournament);
        }

        public void AssingTournaments(List<Tournament> tournaments)
        {
            this.tournaments = tournaments;
        }

        public override string ToString()
        {
            return $"{fName} {lName} {email} {adress}";
        }

    }
}
