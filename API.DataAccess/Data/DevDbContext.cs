using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.DataAccess.Data
{
    public class DevDbContext : IdentityDbContext<AppUser>
    {
        public DevDbContext(DbContextOptions<DevDbContext> options)
            : base(options)
        {
        }

        //  Let's try to fluently describe all of our models
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }




        public DbSet<DevProfile> DeveloperProfiles { get; set; }
        public DbSet<RecruiterProfile> RecruiterProfiles { get; set; }
        

    }
}
