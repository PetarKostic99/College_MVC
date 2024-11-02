using System.ComponentModel.DataAnnotations;

namespace MvcAppHelloWorld
{
    public class RoleViewModel : GenericViewModel
    {
        public int RoleId { get; set; }
        [Required(ErrorMessage = "Filed is required")]
        public string Name { get; set; }
    }
}