using BusinessObjectModel;
using DataAccess;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Repository.Tests
{
    public class HighSchoolRepositoryTests
    {
        [Fact]
        public void GetList_WhenCalled_ShouldReturnListOfUsers()
        {
            var testObject = new List<HighSchool>
            {
                new HighSchool { UserId = 1, Name = "mdfa", Lastname = "ansdno", Birthday_date = DateTime.Now, Password = "1234" },
                new HighSchool { UserId = 2, Name = "mdfa", Lastname = "ansdsdfno", Birthday_date = DateTime.Now, Password = "1234" },
            };

            var mock = new Mock<IGenericRepository<HighSchool>>();

            mock.Setup(m => m.GetList()).Returns(testObject);

            Assert.NotNull(mock);
        }

        [Fact]
        public void GetById_WhenCalled_ShouldReturnUserById()
        {
            var testList = new List<HighSchool>();
            testList.Add(new HighSchool { UserId = 1, Name = "mdfa", Lastname = "ansdno", Birthday_date = DateTime.Now, Password = "1234" });
            testList.Add(new HighSchool { UserId = 2, Name = "lks", Lastname = "anno", Birthday_date = DateTime.Now, Password = "1234" });


            var repository = new Mock<IGenericRepository<HighSchool>>();
            repository.Setup(r => r.GetByID(2)).Returns(new HighSchool { UserId = 2, Name = "sad" });

            var testObject = repository.Object.GetByID(2);

            repository.Verify(m => m.GetByID(2));
            Assert.Equal("sad", testObject.Name);
        }

        [Fact]
        public void Create_WhenCalled_ShouldCreateUser()
        {
            var testObject = new HighSchool() { UserId = 1, Name = "sad" };

            var repository = new Mock<IGenericRepository<HighSchool>>();

            repository.Object.Create(testObject);

            repository.Verify(r => r.Create(It.IsAny<HighSchool>()));
        }

        [Fact]
        public void Delete_WhenCalled_ShouldDeleteUser()
        {
            var testObject = new HighSchool() { UserId = 1, Name = "sad" };
            var repository = new Mock<IGenericRepository<HighSchool>>();
            repository.Object.Delete(testObject.UserId);
            repository.Verify(r => r.Delete(testObject.UserId));
        }
        [Fact]
        public void EditDetails_WhenCalled_ShouldUpdateUser()
        {
            var testObject = new HighSchool() { UserId = 1, Name = "sad" };

            var repository = new Mock<IGenericRepository<HighSchool>>();

            repository.Setup(r => r.EditDetails(It.IsAny<HighSchool>())).Verifiable();

            repository.Object.EditDetails(testObject);

            repository.Verify(r => r.EditDetails(testObject));
        }
    }
}

