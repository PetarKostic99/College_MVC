using BusinessObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcAppHelloWorld
{
    public class UsersViewModel : GenericViewModel
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Filed is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Filed is required")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Filed is required")]
        public DateTime Birthday_date { get; set; }
        [Required(ErrorMessage = "Filed is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Filed is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Phone_Number { get; set; }
        public string House_Address { get; set; }
        public List<Role> Role { get; set; }
        public List<UserRole> UserRole { get; set; }
    }
}