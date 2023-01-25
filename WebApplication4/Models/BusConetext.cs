using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplication4.Models
{
    public class BusConetext:IdentityDbContext
    {
        public BusConetext(DbContextOptions options):base(options) { }
        
        public DbSet<Team> Teams { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}
