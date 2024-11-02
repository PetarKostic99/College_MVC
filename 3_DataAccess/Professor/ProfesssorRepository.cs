using BusinessObjectModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataAccess
{
    public class ProfesssorRepository : GenericRepository<Professor>
    {
        private TuxContext db = null;
        private readonly TuxContext _context;

        public ProfesssorRepository()
        {
            this.db = new TuxContext();
        }



        public override void Export(int id)
        {
            using (var db = new TuxContext())
            {
                var model = db.Professor.Find(id);

                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string downloadArea = Path.Combine(@"C:\\Users\\Petar\\Desktop");

                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, downloadArea, "Professor Details.txt")))
                {

                    try
                    {
                        var name = $"Name: {model.Name}";
                        var lastName = $"Last name: {model.Lastname}";
                        var birthday_date = $"Birthday date: {model.Birthday_date}";
                        var email = $"Email: {model.Email}";
                        var phone_number = $"Phone Number: {model.Phone_Number}";
                        var house_address = $"House Address: {model.House_Address}";
                        var cabinet = $"School Name: {model.Cabinet}";
                        var classSubject = $"Enrollment date: {model.ClassSubject}";

                        outputFile.WriteLine(name);
                        outputFile.WriteLine(lastName);
                        outputFile.WriteLine(birthday_date);
                        outputFile.WriteLine(email);
                        outputFile.WriteLine(phone_number);
                        outputFile.WriteLine(house_address);
                        outputFile.WriteLine(cabinet);
                        outputFile.WriteLine(classSubject);
                    }
                    catch
                    {

                    }
                }
            }
        }

        public override List<Professor> GetList()
        {
            return db.Professor.Include("UserRole").ToList();
        }

        public override void Create(Professor professor)
        {
            db.Users.Add(professor);
            db.UserRole.AddRange(professor.UserRole);
            db.SaveChanges();
        }
    }
}
