using enaa.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace enaa.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<enaa.Models.Menu> Menu { get; set; } = default!;
        public DbSet<enaa.Models.HomeNav> HomeNav { get; set; } = default!;
    }
}