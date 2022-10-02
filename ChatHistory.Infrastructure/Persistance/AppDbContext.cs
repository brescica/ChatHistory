using ChatHistory.Application.Persistance;
using ChatHistory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ChatHistory.Infrastructure.Persistance
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users => Set<User>();
        public DbSet<ChatRecord> ChatRecords => Set<ChatRecord>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
