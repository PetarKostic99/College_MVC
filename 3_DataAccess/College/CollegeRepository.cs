using BusinessObjectModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataAccess
{
    public class CollegeRepository : GenericRepository<College>
    {
        private TuxContext db = null;
        public CollegeRepository()
        {
            this.db = new TuxContext();

        }
        public override IEnumerable<College> Search(string searchString)
        {
            using (var db = new TuxContext())
            {
                var students = from m in db.College
                               select m;

                if (string.IsNullOrEmpty(searchString))
                {
                    return db.College.ToList();
                }
                else
                {
                    return db.College.ToList().Where(s => s.Name.Contains(searchString) |
                                                     s.Lastname.Contains(searchString) |
                                                     s.Email.Contains(searchString) |
                                                     s.House_Address.Contains(searchString) |
                                                     s.Birthday_date.ToString().Contains(searchString) |
                                                     s.Phone_Number.ToString().Contains(searchString) |
                                                     s.Generation_of_Student.ToString().Contains(searchString) |
                                                     s.College_Name.Contains(searchString));

                }
            }
        }

        public override void Export(int id)
        {
            using (var db = new TuxContext())
            {
                var model = db.College.Find(id);

                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string downloadArea = Path.Combine(@"C:\\Users\\Petar\\Desktop");

                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, downloadArea, "College Student Details.txt")))
                {

                    try
                    {
                        var name = $"Name: {model.Name}";
                        var lastName = $"Last name: {model.Lastname}";
                        var birthday_date = $"Birthday date: {model.Birthday_date}";
                        var email = $"Email: {model.Email}";
                        var phone_number = $"Phone Number: {model.Phone_Number}";
                        var house_address = $"House Address: {model.House_Address}";
                        var college_name = $"College Name: {model.College_Name}";
                        var generation_of_student = $"Generation of Student: {model.Generation_of_Student}";

                        outputFile.WriteLine(name);
                        outputFile.WriteLine(lastName);
                        outputFile.WriteLine(birthday_date);
                        outputFile.WriteLine(email);
                        outputFile.WriteLine(phone_number);
                        outputFile.WriteLine(house_address);
                        outputFile.WriteLine(college_name);
                        outputFile.WriteLine(generation_of_student);
                    }
                    catch
                    {

                    }
                }
            }
        }
        public override void Create(College college)
        {
            db.Users.Add(college);
            db.UserRole.AddRange(college.UserRole);
            db.SaveChanges();
        }
        //public override void Delete(int id)
        //{
        //    var userRole = db.UserRole.Where(ur => ur.UserId == id);
        //    db.UserRole.RemoveRange(userRole);
        //    db.Users.Remove(GetByID(id));
        //}
        public override List<College> GetList()
        {
            return db.College.Include("UserRole").ToList();
        }
    }
}
