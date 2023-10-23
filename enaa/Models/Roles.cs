using System.ComponentModel.DataAnnotations;

namespace enaa.Models
{
    public class Roles
    {
        [Display(Name = "Role")]
        public string? RoleId { get; set; }
        [Display(Name = "User")]
        public string? UserId { get; set; }
    }
}
