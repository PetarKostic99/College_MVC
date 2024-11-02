using BusinessLayer;
using BusinessObjectModel;
using DataAccess;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Service.Tests
{
    public class HighSchooServiceTests
    {
        [Fact]
        public void GetList_ShouldReturnLists()
        {
            var mockHighSchoolRepository = new Mock<IGenericRepository<HighSchool>>();
            mockHighSchoolRepository
                .Setup(m => m.GetList())
                .Returns(new List<HighSchool>
                {
                new HighSchool {UserId = 1 , Name = "mdfa", Lastname = "ansdno", Birthday_date = DateTime.Now, Password = "1234"},
                new HighSchool {UserId = 2, Name = "mdfa", Lastname = "ansdsdfno", Birthday_date = DateTime.Now, Password = "1234"},
                });
            var highSchoolService = new HighSchoolService(mockHighSchoolRepository.Object);

            //Act
            var students = highSchoolService.GetList();

            //Assert
            Assert.NotNull(students);
            Assert.Equal(2, students.Count);

        }

        [Fact]
        public void GetById_WhithAnInvalidIdId_ShouldReturnUser()
        {
            //mock object
            var mockingHighSchoolRepository = new Mock<IGenericRepository<HighSchool>>(); //using Mock library, we want to return object that implements this interface

            mockingHighSchoolRepository
                .Setup(m => m.GetByID(It.IsAny<int>())) //SetUp method runs before each test method within a test class so is used to set up common code required for each method
                .Returns(new HighSchool { UserId = 2, Name = "sad" });

            var highSchoolService = new HighSchoolService(mockingHighSchoolRepository.Object);

            //Act
            var students = highSchoolService.GetByID(2);

            //Assert
            mockingHighSchoolRepository.Verify(m => m.GetByID(2));
            Assert.Equal("sad", students.Name);
        }


        //  Checkinhg if _serice.Create(obj) is called with a same object that we pass in in Create(Highschool obj) method. (GenerciService(HighSchool))
        [Fact]
        public void Create_WithIndividualObject_ShouldCreateUser()
        {
            //Arrange
            HighSchool highSchool = new HighSchool
            {
                UserId = 1,
                Name = "mdfa",
                Lastname = "ansdno",
                Birthday_date = DateTime.Now,
                Password = "1234"
            };

            var mockingHighSchoolRepository = new Mock<IGenericRepository<HighSchool>>();

            var studentSave = new HighSchoolService(mockingHighSchoolRepository.Object);

            //Act
            studentSave.Create(highSchool);

            //Assert
            mockingHighSchoolRepository.Verify(m => m.Create(It.IsAny<HighSchool>()));
            Assert.Contains("mdfa", highSchool.Name);
        }

        [Fact]
        public void Delete_WithIndividualId_ShouldDeleteUser()
        {
            HighSchool highSchool = new HighSchool
            {
                UserId = 1,
                Name = "mdfa",
                Lastname = "ansdno",
                Birthday_date = DateTime.Now,
                Password = "1234"
            };

            var mockingHighSchoolRepository = new Mock<IGenericRepository<HighSchool>>();

            var deleteStudent = new HighSchoolService(mockingHighSchoolRepository.Object);

            deleteStudent.Delete(highSchool.UserId);

            mockingHighSchoolRepository.Verify(r => r.Delete(highSchool.UserId));
        }

        [Fact]
        public void Update_WithIndividualObject_ShouldUpdateUser()
        {
            HighSchool highSchool = new HighSchool
            {
                UserId = 1,
                Name = "mdfa",
                Lastname = "ansdno",
                Birthday_date = DateTime.Now,
                Password = "1234"
            };

            var mockingHighSchoolRepository = new Mock<IGenericRepository<HighSchool>>();

            mockingHighSchoolRepository
                .Setup(d => d.EditDetails(It.IsAny<HighSchool>()))
                .Verifiable();


            var highSchoolService = new HighSchoolService(mockingHighSchoolRepository.Object);

            highSchoolService.EditDetails(highSchool);

            mockingHighSchoolRepository.Verify(r => r.EditDetails(highSchool));

        }
        [Fact]
        public void Export_WhenCalled_ExportDetails()
        {
            var repository = new Mock<IGenericRepository<HighSchool>>();
            var service = new HighSchoolService(repository.Object);
            var testObject = new HighSchool();

            service.Export(testObject.UserId);

            repository.Verify(c => c.Export(testObject.UserId));

        }

    }
}
