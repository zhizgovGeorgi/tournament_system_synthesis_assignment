using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class UserManager : IUserManger
    {
        private List<User> users;
        IUserDB<User> userDB;
        public UserManager(IUserDB<User> db)
        {
            this.userDB = db;
            users = userDB.Read();
        }


        public void AddUser(User user)
        {
            if (users.Find(x => x.Email == user.Email) is null)
            {
                userDB.Add(user);
                users.Add(user);
            }
        }


        public void RemoveUser(User u)
        {
            if (users.Find(x => x.Email == u.Email) != null)
            {
               // userDB..(u);
                users.Remove(u);

            }
        }
        public User GetUser(string email, string password)
        {
            return users.Find(x => x.Email == email && x.Password == password);
        }

        public List<User> GetAllUsers()
        {
            return users;
        }
    }
}
