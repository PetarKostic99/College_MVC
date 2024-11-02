using BusinessObjectModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataAccess
{
    public class HighSchoolRepository : GenericRepository<HighSchool>
    {
        private readonly TuxContext _context;
        private TuxContext db = null;

        public HighSchoolRepository()
        {
            this.db = new TuxContext();

        }


        public override void Export(int id)
        {
            using (var db = new TuxContext())
            {
                var model = db.HighSchool.Find(id);

                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string downloadArea = Path.Combine(@"C:\\Users\\koleg\\Desktop");

                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, downloadArea, "High School Student Details.txt")))
                {

                    try
                    {
                        var name = $"Name: {model.Name}";
                        var lastName = $"Last name: {model.Lastname}";
                        var birthday_date = $"Birthday date: {model.Birthday_date}";
                        var email = $"Email: {model.Email}";
                        var phone_number = $"Phone Number: {model.Phone_Number}";
                        var house_address = $"House Address: {model.House_Address}";
                        var school_name = $"School Name: {model.School_Name}";
                        var enrollment_date = $"Enrollment date: {model.Enrollment_date}";

                        outputFile.WriteLine(name);
                        outputFile.WriteLine(lastName);
                        outputFile.WriteLine(birthday_date);
                        outputFile.WriteLine(email);
                        outputFile.WriteLine(phone_number);
                        outputFile.WriteLine(house_address);
                        outputFile.WriteLine(school_name);
                        outputFile.WriteLine(enrollment_date);
                    }
                    catch
                    {

                    }
                }
            }
        }
        public override List<HighSchool> GetList()
        {
            return db.HighSchool.Include("UserRole").ToList();
        }

        public override void Create(HighSchool highSchool)
        {
            db.Users.Add(highSchool);
            db.UserRole.AddRange(highSchool.UserRole);
            db.SaveChanges();
        }
    }
}
