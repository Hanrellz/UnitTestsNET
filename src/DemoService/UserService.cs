using DemoDAL.Interfaces;
using DemoService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<string> GetUsersNames() =>
            _userRepository.GetAll().Select(u => u.Name);

        public bool HasUser(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new InvalidOperationException($"Name is not provided ({nameof(name)}).");
            }
            return _userRepository.GetAll().Any(u => u.Name.Equals(name));
        }
    }
}
