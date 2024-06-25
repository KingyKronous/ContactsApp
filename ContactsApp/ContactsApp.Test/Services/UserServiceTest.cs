
using ContactsApp.Services;
using ContactsApp.Shared.Dtos;
using ContactsApp.Shared.Repos.Contracts;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Tests.Services
{
    public class UserServiceTest
    {
        private readonly Mock<IUserRepository> _userRepositoryMock = new Mock<IUserRepository>();
        private readonly UsersService _service;
        private UserDto user;

        public UserServiceTest()
        {
            _service = new UsersService(_userRepositoryMock.Object);
        }

        [Test]
        public async Task WhenCreateAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var userDto = new UserDto()
            {

                Username = "Jasas",
                Password = "1234",
                FirstName = "JAS",
                LastName = "AS",
                RoleId = 3,
            };

            //Act
            await _service.SaveAsync(userDto);

            //Asert
            _userRepositoryMock.Verify(x => x.SaveAsync(userDto), Times.Once());



        }

        [Test]
        public async Task WhenSaveAsync_WithNull_ThenThrowArgumentNullException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _service.SaveAsync(null));
            _userRepositoryMock.Verify(x => x.SaveAsync(null), Times.Never());
        }

        [Theory]
        [TestCase(1)]
        [TestCase(22)]
        [TestCase(131)]
        public async Task WhenDeleteAsync_WithCorrectId_ThenCallDeleteAsyncInRepository(int id)
        {
            //Arrange

            //Act
            await _service.DeleteAsync(id);

            //Assert
            _userRepositoryMock.Verify(x => x.DeleteAsync(It.Is<int>(i => i.Equals(id))), Times.Once);
        }


        [Theory]
        [TestCase(1)]
        [TestCase(22)]
        [TestCase(131)]
        public async Task WhenGetByIdAsync_WithValidBreedId_ThenReturnUser(int userId)
        {
            //Arrange
            var userDto = new UserDto()
            {
                Username = "Jasas",
                Password = "1234",
                FirstName = "JAS",
                LastName = "AS",
                RoleId = 3,
            };
            _userRepositoryMock.Setup(s => s.GetByIdAsync(It.Is<int>(x => x.Equals(userId))))
                .ReturnsAsync(userDto);
            //Act
            var userResult = await _service.GetByIdIfExistsAsync(userId);

            //Assert
            _userRepositoryMock.Verify(x => x.GetByIdAsync(userId), Times.Once);
            Assert.That(userResult == userDto);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(102021)]
        public async Task WhenGetByAsync_WithInvalidBreedId_ThenReturnDefault(int userId)
        {
            var userDto = (UserDto)default;
            _userRepositoryMock.Setup(s => s.GetByIdAsync(It.Is<int>(x => x.Equals(userId))))
                .ReturnsAsync(userDto);

            //Act
            var userResult = await _service.GetByIdIfExistsAsync(userId);

            //Assert
            _userRepositoryMock.Verify(x => x.GetByIdAsync(userId), Times.Once);
            Assert.That(userResult == user);

        }

        [Test]
        public async Task WhenUpdateAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var userDto = new UserDto
            {

                Username = "Jasas",
                Password = "1234",
                FirstName = "JAS",
                LastName = "AS",
                RoleId = 3,

            };
            _userRepositoryMock.Setup(s => s.SaveAsync(It.Is<UserDto>(x => x.Equals(userDto))))
               .Verifiable();
            //Act
            await _service.SaveAsync(userDto);

            //Assert
            _userRepositoryMock.Verify(x => x.SaveAsync(userDto), Times.Once);
        }

    }
}
