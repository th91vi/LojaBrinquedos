using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaBrinquedos.Models
{
    public class ItemVendaModel
    {
        public string CodigoProduto { get; set; }
        public string QuantidadeProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public string PrecoUnitario { get; set; }
        public string ValorTotal { get; set; }
    }
}
