using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Mocks
{
    public class MockUserDB : IUserDB<User>
    {
        public void Add(User obj)
        {
            
        }

        public void GetAllTournamentsForParticipants(List<User> users)
        {

        }

        public List<User> Read()
        {
            return new List<User>();
        }

        public void Update(User obj)
        {
            
        }
    }
}
