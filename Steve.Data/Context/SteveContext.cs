using Microsoft.EntityFrameworkCore;
using Steve.Model;

namespace Steve.Data
{
    public class SteveContext : DbContext
    {
        public SteveContext(DbContextOptions<SteveContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }

        public DbSet<OpenAIRequestResponse> OpenAIRequestResponses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UsersConfiguration());
            modelBuilder.ApplyConfiguration(new OpenAIRequestResponseConfiguration());
        }
    }
}
