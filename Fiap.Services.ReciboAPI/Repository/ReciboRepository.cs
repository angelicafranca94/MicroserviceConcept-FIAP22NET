using Fiap.Services.ReciboAPI.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Services.ReciboAPI.Repository
{
    public class ReciboRepository : IReciboRepository
    {
        private readonly DbContextOptions<ApplicationDbContext> _dbContext;

        public ReciboRepository(DbContextOptions<ApplicationDbContext> dbContext)
        {
            _dbContext = dbContext;
        }       
    }
}
