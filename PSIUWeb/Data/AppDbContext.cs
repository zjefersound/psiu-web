using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PSIUWeb.Models;

namespace PSIUWeb.Data
{
    public class AppDbContext : 
        IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<Patient>? Patients { get; set; }
        public DbSet<Psychologist>? Psychologists { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Content>? Contents { get; set; }
        public DbSet<Media>? Medias { get; set; }
        public DbSet<ContentCategory>? ContentCategories { get; set; }
    }
}
