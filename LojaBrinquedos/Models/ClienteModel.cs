using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaBrinquedos.Uteis;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace LojaBrinquedos.Models
{
    public class ClienteModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do cliente")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "Informe o CPF do cliente")]
        public string CPF { get; set; }
        
        [Required(ErrorMessage = "Informe o email do cliente")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Email invalido.")]
        public string Email { get; set; }
        
        public string Senha { get; set; }

        public List<ClienteModel> ListarTodosClientes()
        {
            List<ClienteModel> lista = new List<ClienteModel>();
            ClienteModel item;
            DAL objDAL = new DAL();
            string sql = "SELECT id, nome, cpf_cnpj, email, senha FROM Cliente order by nome asc";
            DataTable dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ClienteModel
                {
                    Id = dt.Rows[i]["id"].ToString(),
                    Nome = dt.Rows[i]["nome"].ToString(),
                    CPF = dt.Rows[i]["cpf_cnpj"].ToString(),
                    Email = dt.Rows[i]["email"].ToString(),
                    Senha = dt.Rows[i]["senha"].ToString(),
                };
                lista.Add(item);
            }
            return lista;
        }

        public void Inserir()
        {
            DAL objDAL = new DAL();
            string sql = $"INSERT INTO CLIENTE(nome, cpf_cnpj, email, senha) value('{Nome}', '{CPF}', '{Email}', '123456')";
            objDAL.ExecutarComandoSQL(sql);
        }
    }
}
