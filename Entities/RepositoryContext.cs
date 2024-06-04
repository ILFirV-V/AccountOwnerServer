using Entities.DbModels;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<OwnerDbModel>? Owners { get; set; }
        public DbSet<AccountDbModel>? Accounts { get; set; }
    }
}