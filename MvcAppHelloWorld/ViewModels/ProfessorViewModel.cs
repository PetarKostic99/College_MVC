using BusinessObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAppHelloWorld
{
    public class ProfessorViewModel : UsersViewModel
    {
        public string ClassSubject { get; set; }
        public string Cabinet { get; set; }
    }
}