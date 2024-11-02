using System;
using Xunit;
using BusinessObjectModel;
using DataAccess;
using System.Data.Entity;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Tests
{
    public class ProfessorRepositoryTests
    {

        [Fact]
        public void GetList_WhenCalled_ShouldReturnListOfUsers()
        {
            var professors = new List<Professor>
            {
                new Professor { UserId = 1, Name = "mdfa", Lastname = "ansdno", Birthday_date = DateTime.Now, Password = "1234" },
                new Professor { UserId = 2, Name = "mdfa", Lastname = "ansdsdfno", Birthday_date = DateTime.Now, Password = "1234" },
            };

            var mock = new Mock<IGenericRepository<Professor>>();

            mock.Setup(m => m.GetList()).Returns(professors);

            Assert.NotNull(mock);
        }

        [Fact]
        public void GetById_WhenCalled_ShouldReturnUserById()
        {
            //var testObject = new Professor() { UserId = 1 };
            var testList = new List<Professor>();
            testList.Add(new Professor { UserId = 1, Name = "mdfa", Lastname = "ansdno", Birthday_date = DateTime.Now, Password = "1234" });
            testList.Add(new Professor { UserId = 2, Name = "lks", Lastname = "anno", Birthday_date = DateTime.Now, Password = "1234" });


            var repository = new Mock<IGenericRepository<Professor>>();
            repository.Setup(r => r.GetByID(2)).Returns(new Professor { UserId = 2, Name = "sad" });

            var professor = repository.Object.GetByID(2);

            repository.Verify(m => m.GetByID(2));
            Assert.Equal("sad", professor.Name);
        }

        [Fact]
        public void Create_WhenCalled_ShouldCreateUser()
        {
            var testObject = new Professor() { UserId = 1, Name = "sad" };

            var repository = new Mock<IGenericRepository<Professor>>();

            repository.Object.Create(testObject);

            repository.Verify(r => r.Create(It.IsAny<Professor>()));
        }

        [Fact]
        public void Delete_WhenCalled_ShouldDeleteUser()
        {
            var testObject = new Professor() { UserId = 1, Name = "sad" };
            var repository = new Mock<IGenericRepository<Professor>>();
            repository.Object.Delete(testObject.UserId);
            repository.Verify(r => r.Delete(testObject.UserId));
        }
        [Fact]
        public void EditDetails_WhenCalled_ShouldUpdateUser()
        {
            var testObject = new Professor() { UserId = 1, Name = "sad" };

            var repository = new Mock<IGenericRepository<Professor>>();

            repository.Setup(r => r.EditDetails(It.IsAny<Professor>())).Verifiable();

            repository.Object.EditDetails(testObject);

            repository.Verify(r => r.EditDetails(testObject));
        }

    }
}
