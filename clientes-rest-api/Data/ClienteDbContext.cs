using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using clientes_rest_api.Models;
using Microsoft.EntityFrameworkCore;


namespace clientes_rest_api.Data
{
    public class ClienteDbContext : DbContext
    {
        public ClienteDbContext(DbContextOptions<ClienteDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var Cliente = modelBuilder.Entity<Cliente>();
            Cliente.ToTable("tb_cliente");
            Cliente.HasKey(x => x.Id);
            Cliente.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            Cliente.Property(x => x.Nome).HasColumnName("nome").IsRequired();
            Cliente.Property(x => x.Email).HasColumnName("email").IsRequired();

        }
    }
}