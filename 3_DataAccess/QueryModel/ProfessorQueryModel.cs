using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProfessorQueryModel : UserQueryModel
    {
        public string ClassSubject { get; set; }
        public string Cabinet { get; set; }
    }
}
