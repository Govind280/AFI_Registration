using AFI_Registration.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AFI_Registration.Data.Data
{
    public class PolicyHolderDetailsContext : DbContext
    {
        public PolicyHolderDetailsContext(DbContextOptions<PolicyHolderDetailsContext> options) : base(options)
        {

        }

        public DbSet<PolicyHolderDetails> PolicyHolderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<int>("CustomerId", schema: "shared")
                .StartsAt(1000)
                .IncrementsBy(5);

            modelBuilder.Entity<PolicyHolderDetails>()
                .Property(p => p.CustomerID)
                .HasDefaultValueSql("NEXT VALUE FOR shared.CustomerId");
        }
    }
}
