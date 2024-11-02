using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class CollegeStudentsQueryRepository : GenericRepository<CollegeStudentsQueryModel>
    {
        public override List<CollegeStudentsQueryModel> GetList()
        {
            using (var db = new TuxContext())
            {
                var query = @"
                        SELECT UserId, Name, Lastname, College_Name, Generation_of_Student
                        FROM Users
                        WHERE College_Name is not null
                        ";
                var colelgeStudentsList = db.Database.SqlQuery<CollegeStudentsQueryModel>(query).ToList();
                return colelgeStudentsList;
            }
        }
        public override IEnumerable<CollegeStudentsQueryModel> Search(string searchString)
        {
            return GetList().Where(s => s.Name.Contains(searchString) |
                                                     s.LastName.Contains(searchString) |
                                                     s.College_Name.Contains(searchString) |
                                                     s.Generation_of_Student.ToString().Contains(searchString));

        }
    }
}
