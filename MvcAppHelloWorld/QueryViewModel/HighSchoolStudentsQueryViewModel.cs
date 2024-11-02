using System;
using System.ComponentModel.DataAnnotations;

namespace MvcAppHelloWorld
{
    public class HighSchoolStudentsQueryViewModel : UsersQueryViewModel
    {
        public string School_Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime Enrollment_Date { get; set; }
    }
}