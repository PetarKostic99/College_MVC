using BusinessObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcAppHelloWorld
{
    public class UsersQueryViewModel
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime BirthDate { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}