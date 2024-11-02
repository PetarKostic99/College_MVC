using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class HighSchoolStudentsQueryRepository : GenericRepository<HighSchoolStudentsQueryModel>
    {
        public override List<HighSchoolStudentsQueryModel> GetList()
        {
            using (var db = new TuxContext())
            {
                var query = @"
                        SELECT UserId, Name, Lastname, School_Name, Enrollment_date
                        FROM Users
                        WHERE School_Name is not null
                        ";
                var highSchoolStudentsList = db.Database.SqlQuery<HighSchoolStudentsQueryModel>(query).ToList();
                return highSchoolStudentsList;
            }
        }
        public override IEnumerable<HighSchoolStudentsQueryModel> Search(string searchString)
        {
            return GetList().Where(s => s.Name.Contains(searchString) |
                                                     s.LastName.Contains(searchString) |
                                                     s.School_Name.Contains(searchString) |
                                                     s.Enrollment_Date.ToString().Contains(searchString));

        }
    }
}
