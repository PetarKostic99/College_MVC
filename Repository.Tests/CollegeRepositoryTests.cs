using BusinessObjectModel;
using DataAccess;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Repository.Tests
{
    public class CollegeRepositoryTests
    {
        [Fact]
        public void GetList_WhenCalled_ShouldReturnListOfUsers()
        {
            var testObject = new List<College>
            {
                new College { UserId = 1, Name = "mdfa", Lastname = "ansdno", Birthday_date = DateTime.Now, Password = "1234" },
                new College { UserId = 2, Name = "mdfa", Lastname = "ansdsdfno", Birthday_date = DateTime.Now, Password = "1234" },
            };

            var mock = new Mock<IGenericRepository<College>>();

            mock.Setup(m => m.GetList()).Returns(testObject);

            Assert.NotNull(mock);
        }

        [Fact]
        public void GetById_WhenCalled_ShouldReturnUserById()
        {
            var testList = new List<College>();
            testList.Add(new College { UserId = 1, Name = "mdfa", Lastname = "ansdno", Birthday_date = DateTime.Now, Password = "1234" });
            testList.Add(new College { UserId = 2, Name = "lks", Lastname = "anno", Birthday_date = DateTime.Now, Password = "1234" });


            var repository = new Mock<IGenericRepository<College>>();
            repository.Setup(r => r.GetByID(2)).Returns(new College { UserId = 2, Name = "sad" });

            var testObject = repository.Object.GetByID(2);

            repository.Verify(m => m.GetByID(2));
            Assert.Equal("sad", testObject.Name);
        }

        [Fact]
        public void Create_WhenCalled_ShouldCreateUser()
        {
            var testObject = new College() { UserId = 1, Name = "sad" };

            var repository = new Mock<IGenericRepository<College>>();

            repository.Object.Create(testObject);

            repository.Verify(r => r.Create(It.IsAny<College>()));
        }

        [Fact]
        public void Delete_WhenCalled_ShouldDeleteUser()
        {
            var testObject = new College() { UserId = 1, Name = "sad" };
            var repository = new Mock<IGenericRepository<College>>();
            repository.Object.Delete(testObject.UserId);
            repository.Verify(r => r.Delete(testObject.UserId));
        }
        [Fact]
        public void EditDetails_WhenCalled_ShouldUpdateUser()
        {
            var testObject = new College() { UserId = 1, Name = "sad" };

            var repository = new Mock<IGenericRepository<College>>();

            repository.Setup(r => r.EditDetails(It.IsAny<College>())).Verifiable();

            repository.Object.EditDetails(testObject);

            repository.Verify(r => r.EditDetails(testObject));
        }
    }
}
