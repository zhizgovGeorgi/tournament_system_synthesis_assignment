using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public interface IUserDB<User>
    {
        void Add(User obj);


        void Update( User obj);

        void GetAllTournamentsForParticipants(List<User> users);
    }
}
