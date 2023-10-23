using Microsoft.AspNetCore.Identity;

namespace enaa.Models
{
    public class User : IdentityUser
    {
        public string? FullName { get; set; }
    }
}
