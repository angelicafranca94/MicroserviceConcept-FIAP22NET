using Fiap.Services.PromocaoAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Fiap.Services.PromocaoAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Promocao> Promocoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Promocao>().HasData(new Promocao
            {
                PromocaoId = 1,
                CodigoPromocional = "10OFF",
                Desconto = 10
            });
            modelBuilder.Entity<Promocao>().HasData(new Promocao
            {
                PromocaoId = 2,
                CodigoPromocional = "20OFF",
                Desconto = 20
            });

        }
    }
}
