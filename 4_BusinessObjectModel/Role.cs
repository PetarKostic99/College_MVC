using System.Collections.Generic;

namespace BusinessObjectModel
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public List<Users> Users { get; set; }
        public List<UserRole> UserRole { get; set; }
    }
}
