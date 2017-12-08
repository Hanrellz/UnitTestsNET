using AutoMoq;
using DemoDAL.Interfaces;
using DemoService;
using Moq;

namespace DemoServiceTest.Contexts
{
    public class UserServiceContext
    {
        private readonly AutoMoqer mocker;

        public Mock<IUserRepository> UserRepository { get; set; }

        public UserServiceContext()
        {
            mocker = new AutoMoqer();

            UserRepository = mocker.GetMock<IUserRepository>();
        }

        public UserService Create() =>
            mocker.Create<UserService>();

        public UserService Create(IUserRepository userRepository) =>
            new UserService(userRepository);
    }
}
