using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class ExpenseTrackerDbContext : AuditableDbContext
    {
        public ExpenseTrackerDbContext(DbContextOptions<ExpenseTrackerDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExpenseTrackerDbContext).Assembly);
        }

        public DbSet<ExpenseAllocation> ExpenseAllocations { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
    }
}
