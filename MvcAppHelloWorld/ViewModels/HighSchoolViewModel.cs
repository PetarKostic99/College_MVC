using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjectModel;
using DataAccess;

namespace MvcAppHelloWorld
{
    public class HighSchoolViewModel : UsersViewModel
    {
        public string School_Name { get; set; }
        public DateTime Enrollment_date { get; set; }
    }
}