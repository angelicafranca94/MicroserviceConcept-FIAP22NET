using Fiap.Services.ReciboAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Services.ReciboAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<ReciboLog> ReciboLogs { get; set; }
    }
}
