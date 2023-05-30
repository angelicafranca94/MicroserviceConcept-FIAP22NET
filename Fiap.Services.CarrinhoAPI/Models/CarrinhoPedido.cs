﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Services.CarrinhoAPI.Models
{
    public class CarrinhoPedido
    {
        [Key]
        public int CarrinhoPedidoId { get; set; }
        public string UserId { get; set; }
        public string CodigoPromocional { get; set; }
    }
}
