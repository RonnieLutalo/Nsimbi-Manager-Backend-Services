using ExpenseTracker.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ExpenseTracker.Identity.Configurations;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Identity
{
    public class ExpenseTrackerIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public ExpenseTrackerIdentityDbContext(DbContextOptions<ExpenseTrackerIdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
