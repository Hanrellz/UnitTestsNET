using System.Collections.Generic;

namespace DemoService.Interfaces
{
    public interface IUserService
    {
        IEnumerable<string> GetUsersNames();

        bool HasUser(string name);
    }
}
