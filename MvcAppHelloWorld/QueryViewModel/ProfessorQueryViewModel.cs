using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAppHelloWorld
{
    public class ProfessorQueryViewModel : UsersQueryViewModel
    {
        public string ClassSubject { get; set; }
        public string Cabinet { get; set; }
    }
}