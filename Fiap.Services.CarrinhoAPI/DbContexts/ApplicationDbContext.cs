using Fiap.Services.CarrinhoAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;

namespace Fiap.Services.CarrinhoAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<CarrinhoPedido> CarrinhoPedidos { get; set; }
        public DbSet<CarrinhoDetalhe> CarrinhoDetalhes { get; set; }
    }
}
