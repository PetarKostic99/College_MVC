using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class ProfessorQueryRepository : GenericRepository<ProfessorQueryModel>
    {
        public override List<ProfessorQueryModel> GetList()
        {
            using (var db = new TuxContext())
            {

                var query = @"
                        SELECT UserId, Name, Lastname, Cabinet, ClassSubject
                        FROM Users
                        WHERE Cabinet is not null
                        ";
                var professorList = db.Database.SqlQuery<ProfessorQueryModel>(query).ToList();

                return professorList;
            }
        }
        public override IEnumerable<ProfessorQueryModel> Search(string searchString)
        {
            return GetList().Where(s => s.Name.Contains(searchString) |
                                                      s.LastName.Contains(searchString) |
                                                      s.ClassSubject.Contains(searchString) |
                                                      s.Cabinet.ToString().Contains(searchString));

        }
    }
}
