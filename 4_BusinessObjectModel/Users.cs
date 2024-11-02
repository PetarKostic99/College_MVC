using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjectModel
{
    public class Users
    // Base Class
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime Birthday_date { get; set; }
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Phone_Number { get; set; }
        public string House_Address { get; set; }
        public List<Role> Role { get; set; }
        [ForeignKey("UserId")]
        public List<UserRole> UserRole { get; set; }
    }

}
