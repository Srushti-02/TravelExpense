using Microsoft.EntityFrameworkCore;
using TravelExpense.Models;

namespace TravelExpense.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ExpenseClaim> ExpenseClaims { get; set; }
    }
}