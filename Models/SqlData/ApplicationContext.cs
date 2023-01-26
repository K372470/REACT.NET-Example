using Microsoft.EntityFrameworkCore;

namespace DriveHack.Site.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<StartUpData> StartUp { get; set; }
        public DbSet<PropsModel> Props { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}