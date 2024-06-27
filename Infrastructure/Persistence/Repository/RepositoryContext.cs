using Domain.DbModels;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository
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