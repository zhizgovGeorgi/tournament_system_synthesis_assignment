using System;
using System.Collections.Generic;
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

        public int Id { get { return this.id; } }
        public string FName { get { return this.fName; } }
        public string LName { get { return this.lName; } }
        public string Email { get { return this.email; } }
        public string Adress { get { return this.adress; } }
        public string Password { get { return this.password; } }
        public string Role { get { return this.role; } }

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


        public User( string fName, string lName, string email, string adress, string password, string role)
        {
            this.fName = fName;
            this.lName = lName;
            this.email = email;
            this.adress = adress;
            this.password = password;
            this.role = role;
        }

        public User()
        {

        }

        public override string ToString()
        {
            return $"{fName} {lName} {email} {adress}";
        }

    }
}
