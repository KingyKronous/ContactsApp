using ContactsApp.Services;
using ContactsApp.Shared.Dtos;
using ContactsApp.Shared.Repos.Contracts;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Test.Services
{
    public class ContactsServiceTest
    {
        private readonly Mock<IContactRepository> _contactsRepositoryMock = new Mock<IContactRepository>();
        private readonly ContactsService _service;
        private ContactsDto contact;

        public ContactsServiceTest()
        {
            _service = new ContactsServiceTest(_contactsRepositoryMock.Object);
        }

        [Test]
        public async Task WhenCreateAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var ContactsDto = new ContactsDto()
            {


            };

            //Act
            await _service.SaveAsync(ContactsDto);

            //Asert
            _contactsRepositoryMock.Verify(x => x.SaveAsync(ContactsDto), Times.Once());



        }

        [Test]
        public async Task WhenSaveAsync_WithNull_ThenThrowArgumentNullException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _service.SaveAsync(null));
            _contactsRepositoryMock.Verify(x => x.SaveAsync(null), Times.Never());
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
            _contactsRepositoryMock.Verify(x => x.DeleteAsync(It.Is<int>(i => i.Equals(id))), Times.Once);
        }


        [Theory]
        [TestCase(1)]
        [TestCase(22)]
        [TestCase(131)]
        public async Task WhenGetByIdAsync_WithValidBreedId_ThenReturnUser(int contactId)
        {
            //Arrange
            var ContactsDto = new ContactsDto()
            {
                Id = 0
            };
            _contactsRepositoryMock.Setup(s => s.GetByIdAsync(It.Is<int>(x => x.Equals(contactId))))
                .ReturnsAsync(ContactsDto);
            //Act
            var userResult = await _service.GetByIdIfExistsAsync(contactId);

            //Assert
            _contactsRepositoryMock.Verify(x => x.GetByIdAsync(contactId), Times.Once);
            Assert.That(userResult == ContactsDto);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(102021)]
        public async Task WhenGetByAsync_WithInvalidBreedId_ThenReturnDefault(int contactId)
        {
            var contactsDto = (ContactsDto)default;
            _contactsRepositoryMock.Setup(s => s.GetByIdAsync(It.Is<int>(x => x.Equals(contactId))))
                .ReturnsAsync(contactsDto);

            //Act
            var userResult = await _service.GetByIdIfExistsAsync(contactId);

            //Assert
            _contactsRepositoryMock.Verify(x => x.GetByIdAsync(contactId), Times.Once);
            Assert.That(userResult == contact);

        }

        [Test]
        public async Task WhenUpdateAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var ContactsDto = new ContactsDto
            {
                Id = 0

            };
            _contactsRepositoryMock.Setup(s => s.SaveAsync(It.Is<ContactsDto>(x => x.Equals(ContactsDto))))
               .Verifiable();
            //Act
            await _service.SaveAsync(ContactsDto);

            //Assert
            _contactsRepositoryMock.Verify(x => x.SaveAsync(ContactsDto), Times.Once);
        }
    }
}
