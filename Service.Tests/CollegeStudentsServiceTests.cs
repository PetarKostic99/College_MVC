using BusinessLayer;
using BusinessObjectModel;
using DataAccess;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Service.Tests
{
    public class CollegeStudentsServiceTests
    {
        [Fact]
        public void GetList_WhenCalled_ShouldReturnListOfUsers()
        {
            var collegeRepository = new Mock<IGenericRepository<College>>();
            var collegeService = new CollegeService(collegeRepository.Object);

            collegeRepository
                .Setup(c => c.GetList())
                .Returns(new List<College>
                {
                    new College {UserId = 1 , Name = "mdfa", Lastname = "ansdno", Birthday_date = DateTime.Now, Password = "1234"},
                    new College {UserId = 2, Name = "mdfa", Lastname = "ansdsdfno", Birthday_date = DateTime.Now, Password = "1234"},
                });

            var students = collegeService.GetList();

            Assert.NotNull(students);
            Assert.Equal(2, students.Count);

        }

        [Fact]
        public void GetById_WhenCalled_ShouldReturnUser()
        {
            var collegeRepository = new Mock<IGenericRepository<College>>();
            var collegeService = new CollegeService(collegeRepository.Object);

            collegeRepository
                .Setup(s => s.GetByID(It.IsAny<int>()))
                .Returns(new College { UserId = 1, Name = "John" });

            var student = collegeService.GetByID(1);

            collegeRepository.Verify(s => s.GetByID(1));
            Assert.Equal("John", student.Name);
        }

        [Fact]
        public void Create_WhenCalled_ShouldCreateUser() 
        {
            var collegeRepository = new Mock<IGenericRepository<College>>();
            var collegeService = new CollegeService(collegeRepository.Object);
            var college = new College();

            collegeService.Create(college);

            collegeRepository.Verify(c => c.Create(college));

        }

        [Fact]

        public void Delete_WhenCalled_ShouldDeleteUser()
        {
            var collegeRepository = new Mock<IGenericRepository<College>>();
            var collegeService = new CollegeService(collegeRepository.Object);
            var college = new College();

            collegeService.Delete(college.UserId);

            collegeRepository.Verify(c => c.Delete(college.UserId));
        }
        [Fact]
        public void Update_WhenCalled_UpadteUser()
        {
            College college = new College
            {
                UserId = 1,
                Name = "mdfa",
                Lastname = "ansdno",
                Birthday_date = DateTime.Now,
                Password = "1234"
            };
            var collegeRepository = new Mock<IGenericRepository<College>>();
            var collegeService = new CollegeService(collegeRepository.Object);

            collegeRepository.Setup(c => c.EditDetails(It.IsAny<College>())).Verifiable();

            collegeService.EditDetails(college);

            collegeRepository.Verify(s => s.EditDetails(college));
        }

        [Fact]
        public void Export_WhenCalled_ExportDetails()
        {
            var collegeRepository = new Mock<IGenericRepository<College>>();
            var collegeService = new CollegeService(collegeRepository.Object);
            var college = new College();

            collegeService.Export(college.UserId);

            collegeRepository.Verify(c => c.Export(college.UserId));

        }
    }
}
