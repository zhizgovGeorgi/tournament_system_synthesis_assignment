using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class UserManager : IUserManger
    {
        private List<User> users = new List<User>();
        IUserDB<User> userDB;
        public UserManager(IUserDB<User> db)
        {
            this.userDB = db;
            userDB.GetAllTournamentsForParticipants(users);
        }


        public void AddUser(User user)
        {
            if (users.Find(x => x.Email == user.Email) is null)
            {
                userDB.Add(user);
                users.Add(user);
                return;
            }
            throw new MyException("There is already user with the same data");
        }

        public User GetUser(string email, string password)
        {
            return users.Find(x => x.Email == email && x.Password == password);
        }

        public User GetUserByEmail(string email)
        {
            return users.Find(x => x.Email == email);
        }

        public List<User> GetAllUsers()
        {
            return users;
        }
    }
}
