using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace tmherronProfessionalSite.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>()
                .HasData(
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "Curator",
                    NormalizedName = "CURATOR"
                },
                new IdentityRole
                {
                    Name = "AFM",
                    NormalizedName = "AFM"
                },
                new IdentityRole
                {
                    Name = "Guest",
                    NormalizedName = "Guest"
                });
        }

    }
}
