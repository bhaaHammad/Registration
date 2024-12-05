using Microsoft.EntityFrameworkCore;
using Registration.Entity;

namespace Registration.Utilities
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<PrivacyPolicyEntity> PrivacyPolicies { get; set; }
    }
}
