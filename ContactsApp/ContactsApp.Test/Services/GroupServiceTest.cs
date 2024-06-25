using ContactsApp.Services;
using ContactsApp.Shared.Dtos;
using ContactsApp.Shared.Repos.Contracts;
using ContactsApp.Shared.Services.Contracts;
using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Test.Services
{
    public class GroupServiceTest
    {
        private readonly Mock<IGroupRepository> _groupRepositoryMock = new Mock<IGroupRepository>();
        private readonly GroupsService _service;
        private ContactsDto group;

        public GroupServiceTest()
        {
            _service = new GroupsService(_groupRepositoryMock.Object);
        }

        [Test]
        public async Task WhenCreateAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var GroupDto = new ContactsDto()
            {
                

            };

            //Act
            await _service.SaveAsync(GroupDto);

            //Asert
            _groupRepositoryMock.Verify(x => x.SaveAsync(GroupDto), Times.Once());



        }

        [Test]
        public async Task WhenSaveAsync_WithNull_ThenThrowArgumentNullException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _service.SaveAsync(null));
            _groupRepositoryMock.Verify(x => x.SaveAsync(null), Times.Never());
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
            _groupRepositoryMock.Verify(x => x.DeleteAsync(It.Is<int>(i => i.Equals(id))), Times.Once);
        }


        [Theory]
        [TestCase(1)]
        [TestCase(22)]
        [TestCase(131)]
        public async Task WhenGetByIdAsync_WithValidBreedId_ThenReturnUser(int groupId)
        {
            //Arrange
            var GroupDto = new ContactsDto()
            {
                Id = 0
            };
            _groupRepositoryMock.Setup(s => s.GetByIdAsync(It.Is<int>(x => x.Equals(groupId))))
                .ReturnsAsync(GroupDto);
            //Act
            var userResult = await _service.GetByIdIfExistsAsync(groupId);

            //Assert
            _groupRepositoryMock.Verify(x => x.GetByIdAsync(groupId), Times.Once);
            Assert.That(userResult == GroupDto);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(102021)]
        public async Task WhenGetByAsync_WithInvalidBreedId_ThenReturnDefault(int groupId)
        {
            var groupDto = (ContactsDto)default;
            _groupRepositoryMock.Setup(s => s.GetByIdAsync(It.Is<int>(x => x.Equals(groupId))))
                .ReturnsAsync(groupDto);

            //Act
            var userResult = await _service.GetByIdIfExistsAsync(groupId);

            //Assert
            _groupRepositoryMock.Verify(x => x.GetByIdAsync(groupId), Times.Once);
            Assert.That(userResult == group);

        }

        [Test]
        public async Task WhenUpdateAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var GroupDto = new ContactsDto
            {
                Id = 0

            };
            _groupRepositoryMock.Setup(s => s.SaveAsync(It.Is<ContactsDto>(x => x.Equals(GroupDto))))
               .Verifiable();
            //Act
            await _service.SaveAsync(GroupDto);

            //Assert
            _groupRepositoryMock.Verify(x => x.SaveAsync(GroupDto), Times.Once);
        }

    }
}

