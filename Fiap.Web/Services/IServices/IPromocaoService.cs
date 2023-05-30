using Fiap.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.Services.IServices
{
    public interface IPromocaoService
    {
        Task<T> GetPromocao<T>(string codigoPromocional, string token = null);
    }
}
