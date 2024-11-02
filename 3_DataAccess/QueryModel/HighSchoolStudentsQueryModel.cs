using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class HighSchoolStudentsQueryModel : UserQueryModel
    {
        public string School_Name { get; set; }
        public DateTime Enrollment_Date { get; set; }
    }
}
