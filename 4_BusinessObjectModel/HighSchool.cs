using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjectModel
{
    public class HighSchool : Users
    {
        public string School_Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime Enrollment_date { get; set; }
    }
}