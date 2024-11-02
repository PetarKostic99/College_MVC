using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CollegeStudentsQueryModel : UserQueryModel
    {
        public string College_Name { get; set; }
        public int Generation_of_Student { get; set; }
    }
}
