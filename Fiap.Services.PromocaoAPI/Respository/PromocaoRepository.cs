using AutoMapper;
using Fiap.Services.PromocaoAPI.DbContexts;
using Fiap.Services.PromocaoAPI.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Services.PromocaoAPI.Respository
{
    public class PromocaoRepository : IPromocaoRepository
    {
        private readonly ApplicationDbContext _db;
        protected IMapper _mapper;
        public PromocaoRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<PromocaoDTO> GetCodigoPromocional(string codigoPromocional)
        {
            var promocaoDb = await _db.Promocoes.FirstOrDefaultAsync(u => u.CodigoPromocional == codigoPromocional);
            return _mapper.Map<PromocaoDTO>(promocaoDb);
        }
    }
}
