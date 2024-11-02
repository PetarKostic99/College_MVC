using BusinessObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAppHelloWorld
{
    public class CollegeViewModel : UsersViewModel
    {
       
        public string College_Name { get; set; }
        public int Generation_of_Student { get; set; }
    }
}