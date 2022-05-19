using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public interface IUserManger
    {
        void AddUser(User user);

        void RemoveUser(User u);
        User GetUser(string email, string password);
        List<User> GetAllUsers();
    }
}
