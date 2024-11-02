using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjectModel
{
    public class UserRole
    {
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public Users Users { get; set; }
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role Role { get; set; }
    }
}
