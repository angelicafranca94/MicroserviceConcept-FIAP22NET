using AutoMapper;
using Fiap.Services.CarrinhoAPI.DbContexts;
using Fiap.Services.CarrinhoAPI.Models;
using Fiap.Services.CarrinhoAPI.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Services.CarrinhoAPI.Repository
{
    public class CarrinhoRepository : ICarrinhoRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public CarrinhoRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<bool> AplicarPromocao(string userId, string codigoPromocional)
        {
            var carrinhoDb = await _db.CarrinhoPedidos.FirstOrDefaultAsync(u => u.UserId == userId);
            carrinhoDb.CodigoPromocional = codigoPromocional;
            _db.CarrinhoPedidos.Update(carrinhoDb);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> LimparCarrinho(string userId)
        {
            var carrinhoPedidoDb = await _db.CarrinhoPedidos.FirstOrDefaultAsync(u => u.UserId == userId);
            if (carrinhoPedidoDb != null)
            {
                _db.CarrinhoDetalhes
                    .RemoveRange(_db.CarrinhoDetalhes.Where(u => u.CarrinhoPedidoId == carrinhoPedidoDb.CarrinhoPedidoId));
                _db.CarrinhoPedidos.Remove(carrinhoPedidoDb);
                await _db.SaveChangesAsync();
                return true;

            }
            return false;
        }

        public async Task<CarrinhoDTO> CreateUpdateCarrinho(CarrinhoDTO carrinhoDTO)
        {
            Carrinho carrinho = _mapper.Map<Carrinho>(carrinhoDTO);

            // Verifica se o curso existe no banco de dados, caso contrário, cria!
            var cursoDb = await _db.Cursos
                .FirstOrDefaultAsync(u => u.CursoId == carrinhoDTO.CarrinhoDetalhes.FirstOrDefault()
                .CursoId);
            if (cursoDb == null)
            {
                _db.Cursos.Add(carrinho.CarrinhoDetalhe.FirstOrDefault().Curso);
                await _db.SaveChangesAsync();
            }

            // Verifica se o pedido tem lastro
            var carrinhoPedidoDb = await _db.CarrinhoPedidos.AsNoTracking()
                .FirstOrDefaultAsync(u => u.UserId == carrinho.CarrinhoPedido.UserId);

            if (carrinhoPedidoDb == null)
            {
                // Criar lastro e detalhe
                _db.CarrinhoPedidos.Add(carrinho.CarrinhoPedido);
                await _db.SaveChangesAsync();
                carrinho.CarrinhoDetalhe.FirstOrDefault().CarrinhoPedidoId = carrinho.CarrinhoPedido.CarrinhoPedidoId;
                carrinho.CarrinhoDetalhe.FirstOrDefault().Curso = null;
                _db.CarrinhoDetalhes.Add(carrinho.CarrinhoDetalhe.FirstOrDefault());
                await _db.SaveChangesAsync();
            }
            else
            {
                // Se o pedido estiver sem dono, verificar se tem cursos
                var carrinhoDetalheDb = await _db.CarrinhoDetalhes.AsNoTracking().FirstOrDefaultAsync(
                    u => u.CursoId == carrinho.CarrinhoDetalhe.FirstOrDefault().CursoId &&
                    u.CarrinhoPedidoId == carrinhoPedidoDb.CarrinhoPedidoId);

                if (carrinhoDetalheDb == null)
                {
                    // Criar detalhe
                    carrinho.CarrinhoDetalhe.FirstOrDefault().CarrinhoPedidoId = carrinhoPedidoDb.CarrinhoPedidoId;
                    carrinho.CarrinhoDetalhe.FirstOrDefault().Curso = null;
                    _db.CarrinhoDetalhes.Add(carrinho.CarrinhoDetalhe.FirstOrDefault());
                    await _db.SaveChangesAsync();
                }
                else
                {
                    // atualiza quantidade e detalhe do carrrinho
                    carrinho.CarrinhoDetalhe.FirstOrDefault().Curso = null;
                    carrinho.CarrinhoDetalhe.FirstOrDefault().Count += carrinhoDetalheDb.Count;
                    carrinho.CarrinhoDetalhe.FirstOrDefault().CarrinhoDetalheId = carrinhoDetalheDb.CarrinhoDetalheId;
                    carrinho.CarrinhoDetalhe.FirstOrDefault().CarrinhoPedidoId = carrinhoDetalheDb.CarrinhoPedidoId;
                    _db.CarrinhoDetalhes.Update(carrinho.CarrinhoDetalhe.FirstOrDefault());
                    await _db.SaveChangesAsync();
                }
            }

            return _mapper.Map<CarrinhoDTO>(carrinho);
        }

        public async Task<CarrinhoDTO> GetCarrinhoByUserId(string userId)
        {
            Carrinho carrinho = new()
            {
                CarrinhoPedido = await _db.CarrinhoPedidos.FirstOrDefaultAsync(u => u.UserId == userId)
            };

            carrinho.CarrinhoDetalhe = _db.CarrinhoDetalhes
                .Where(c => c.CarrinhoPedidoId == carrinho.CarrinhoPedido.CarrinhoPedidoId).Include(c => c.Curso);

            return _mapper.Map<CarrinhoDTO>(carrinho);
        }

        public async Task<bool> RetirarPromocao(string userId)
        {
            var carrinhoDb = await _db.CarrinhoPedidos.FirstOrDefaultAsync(u => u.UserId == userId);
            carrinhoDb.CodigoPromocional = "";
            _db.CarrinhoPedidos.Update(carrinhoDb);
            await _db.SaveChangesAsync();
            
            return true;
        }

        public async Task<bool> RemoverDoCarrinho(int carrinhoDetalheId)
        {
            try
            {
                CarrinhoDetalhe carrinhoDetalhe = await _db.CarrinhoDetalhes
                    .FirstOrDefaultAsync(u => u.CarrinhoDetalheId == carrinhoDetalheId);

                int QuantidadeTotalDeCursos = _db.CarrinhoDetalhes
                    .Where(u => u.CarrinhoPedidoId == carrinhoDetalhe.CarrinhoPedidoId).Count();

                _db.CarrinhoDetalhes.Remove(carrinhoDetalhe);
                if (QuantidadeTotalDeCursos == 1)
                {
                    var RemoverCursoDoCarrinho = await _db.CarrinhoPedidos
                        .FirstOrDefaultAsync(u => u.CarrinhoPedidoId == carrinhoDetalhe.CarrinhoPedidoId);

                    _db.CarrinhoPedidos.Remove(RemoverCursoDoCarrinho);
                }
                await _db.SaveChangesAsync();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
