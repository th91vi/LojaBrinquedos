using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaBrinquedos.Models
{
    public class VendaModel
    {
        public string Id { get; set; }
        public string Cliente_Id { get; set; }
        public string Vendedor_Id { get; set; }

        public List<ClienteModel> RetornarListaClientes()
        {
            return new ClienteModel().ListarTodosClientes(); // acessa o método de ClienteModel por referência
        }

        public List<VendedorModel> RetornarListaVendedores()
        {
            return new VendedorModel().ListarTodosVendedores();
        }

        public List<ProdutoModel> RetornarListaProdutos()
        {
            return new ProdutoModel().ListarTodosProdutos();
        }
    }
}
