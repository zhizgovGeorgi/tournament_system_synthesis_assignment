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

        User GetUser(string email, string password);
        User GetUserByEmail(string email);
        List<User> GetAllUsers();
    }
}
