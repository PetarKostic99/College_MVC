using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RoleQueryRepository : GenericRepository<RoleQueryModel>
    {
        public override List<RoleQueryModel> GetList()
        {
            using (var db = new TuxContext())
            {

                var query = @"
                        SELECT *
                        FROM Role
                        ";
                var roleList = db.Database.SqlQuery<RoleQueryModel>(query).ToList();

                return roleList;
            }
        }
    }
}
