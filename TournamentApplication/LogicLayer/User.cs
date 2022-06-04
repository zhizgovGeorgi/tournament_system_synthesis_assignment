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

        public int Id { get { return this.id; } }
        public string FName { get { return this.fName; } }
        public string LName { get { return this.lName; } }

        [Required(ErrorMessage ="Please enter your email")] [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Must be a valid Email Address")]
        public string Email { get { return this.email; } }
        public string Adress { get { return this.adress; } }

        public string Password 
        { 
            get { return this.password; }
            private set
            {
                if (password.Length < 6  )
                {
                    throw new MyException("Password must contain at least 6 or more symbols");
                }
                this.password = value;
            }
        }
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
