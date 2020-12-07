using DDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DDD.Infra.Data
{
    public class DDDContext : DbContext
    {
        public DDDContext()
        {

        }

        public DDDContext(DbContextOptions<DDDContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<User> Usuarios { get; set; }

        public override int SaveChanges()
        {
            foreach(var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if(entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }
            }
            

            return base.SaveChanges();
        }
    }
}
