using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Services.ReciboAPI.Models
{
    public class ReciboLog
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Log { get; set; }
        public DateTime DataDeEnvio { get; set; }
    }
}
