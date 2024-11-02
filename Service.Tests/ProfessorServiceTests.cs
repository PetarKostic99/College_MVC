using BusinessLayer;
using BusinessObjectModel;
using DataAccess;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

    
namespace Service.Tests
{
    public class ProfessorServiceTests
    {
        [Fact]
        public void GetList_WhenCalled_ShouldReturnListOfUsers()
        {
            var professorRepository = new Mock<IGenericRepository<Professor>>();
            ProfessorService professorservice = new ProfessorService(professorRepository.Object);

            professorRepository
               .Setup(m => m.GetList())
               .Returns(new List<Professor>
               {
                    new Professor {UserId = 1 , Name = "mdfa", Lastname = "ansdno", Birthday_date = DateTime.Now, Password = "1234"},
                    new Professor {UserId = 2, Name = "mdfa", Lastname = "ansdsdfno", Birthday_date = DateTime.Now, Password = "1234"},
               });


            var professors = professorservice.GetList();

            Assert.NotNull(professors);
            Assert.Equal(2, professors.Count);
        }

        public void GetById_WhenCalled_ShouldReturnUser()
        {
            var professorRepository = new Mock<IGenericRepository<Professor>>();
            var professorservice = new ProfessorService(professorRepository.Object);

            professorRepository
                .Setup(s => s.GetByID(It.IsAny<int>()))
                .Returns(new Professor { UserId = 1, Name = "John" });

            var professor = professorservice.GetByID(1);

            professorRepository.Verify(s => s.GetByID(1));
            Assert.Equal("John", professor.Name);
        }

        [Fact]
        public void Create_WhenCalled_ShouldCreateUser()
        {
            var professorRepository = new Mock<IGenericRepository<Professor>>();
            var professorservice = new ProfessorService(professorRepository.Object);
            var professor = new Professor();

            professorservice.Create(professor);

            professorRepository.Verify(c => c.Create(professor));

        }

        [Fact]
        public void Delete_WhenCalled_ShouldDeleteUser()
        {
            var professorRepository = new Mock<IGenericRepository<Professor>>();
            var professorservice = new ProfessorService(professorRepository.Object);
            var professor = new Professor();

            professorservice.Delete(professor.UserId);

            professorRepository.Verify(c => c.Delete(professor.UserId));
        }
        [Fact]
        public void Update_WhenCalled_UpadteUser()
        {
            Professor professor = new Professor
            {
                UserId = 1,
                Name = "mdfa",
                Lastname = "ansdno",
                Birthday_date = DateTime.Now,
                Password = "1234"
            };
            var professorRepository = new Mock<IGenericRepository<Professor>>();
            var professorservice = new ProfessorService(professorRepository.Object);

            professorRepository.Setup(c => c.EditDetails(It.IsAny<Professor>())).Verifiable();

            professorservice.EditDetails(professor);

            professorRepository.Verify(s => s.EditDetails(professor));
        }
        [Fact]
        public void Export_WhenCalled_ExportDetails()
        {
            var repository = new Mock<IGenericRepository<Professor>>();
            var service = new ProfessorService(repository.Object);
            var testObject = new Professor();

            service.Export(testObject.UserId);

            repository.Verify(c => c.Export(testObject.UserId));

        }

    }
}
