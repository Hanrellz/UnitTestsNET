using DemoDAL;
using DemoDAL.Interfaces.Fakes;
using DemoServiceTest.Contexts;
using Moq;
using Shouldly;
using System;
using Xunit;

namespace DemoServiceTest
{
    public class UserServiceTest
    {
        private readonly UserServiceContext _context;

        public UserServiceTest()
        {
            _context = new UserServiceContext();
        }

        [Fact]
        public void ShouldCallGetAllFromRepositoryWhenCallingGetUsersNames()
        {
            // Arrange

            _context.UserRepository
                .Setup(x => x.GetAll())
                .Returns(new User[0]);

            var target = _context.Create();

            // Act

            target.GetUsersNames();

            // Assert

            _context.UserRepository.Verify(x => x.GetAll(), Times.Once);
        }

        [Fact]
        public void ShouldReturnDataFromRepositoryWhenCallingGetUsersNames()
        {
            // Arrange

            var users = new[]
            {
                new User { Id = 3, Name = "Anna", IsActive = true },
                new User { Id = 1, Name = "John", IsActive = false },
                new User { Id = 2, Name = "Joe", IsActive = true }
            };
            _context.UserRepository
                .Setup(x => x.GetAll())
                .Returns(users);

            var target = _context.Create();

            // Act

            var result = target.GetUsersNames();

            // Assert

            result.ShouldNotBeEmpty();
            result.ShouldContain("Anna");
            result.ShouldContain("John");
            result.ShouldContain("Joe");
        }

        [Fact]
        public void ShouldThrowAnInvalidOperationExceptionWithCustomMessageWhenNameIsNull()
        {
            // Arrange

            _context.UserRepository
                .Setup(x => x.GetAll())
                .Returns(new User[0]);

            var target = _context.Create();

            // Act
            var exception = Assert.Throws<InvalidOperationException>(() => target.HasUser(null));

            // Assert

            exception.ShouldNotBeNull();
            exception.Message.ShouldContain("Name is not provided");
        }

        [Fact]
        public void ShouldReturnDataFromRepositoryWhenCallingGetUsersNamesWithStub()
        {
            // Arrange

            var users = new[]
            {
                new User { Id = 3, Name = "Anna", IsActive = true },
                new User { Id = 1, Name = "John", IsActive = false },
                new User { Id = 2, Name = "Joe", IsActive = true }
            };
            var stubUserRepository = new StubIUserRepository
            {
                GetAll = () => users
            };            

            var target = _context.Create(stubUserRepository);

            // Act

            var result = target.GetUsersNames();

            // Assert

            result.ShouldNotBeEmpty();
            result.ShouldContain("Anna");
            result.ShouldContain("John");
            result.ShouldContain("Joe");
        }
    }
}
