using DemoDAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DemoDAL
{
    public class UserRepository : IUserRepository
    {
        public IEnumerable<User> GetAll() =>
            Enumerable.Empty<User>();
    }
}
