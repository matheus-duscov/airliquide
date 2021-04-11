using Airliquide.Domain.Entities;
using Airliquide.Infrastructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Airliquide.Infrastructure.Data.Contexts
{
    public class AirliquideClienteDbContext : DbContext
    {
        public AirliquideClienteDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMapping());
        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
