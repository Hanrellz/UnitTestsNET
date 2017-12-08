using System.Collections.Generic;

namespace DemoDAL.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
    }
}
