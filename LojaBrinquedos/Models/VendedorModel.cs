using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaBrinquedos.Uteis;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace LojaBrinquedos.Models
{
    public class VendedorModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do vendedor")]
        public string Nome { get; set; }
       
        [Required(ErrorMessage = "Informe o email do vendedor")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Email invalido.")]
        public string Email { get; set; }

        public string Senha { get; set; }

        // READ
        public List<VendedorModel> ListarTodosVendedores()
        {
            List<VendedorModel> lista = new List<VendedorModel>();
            VendedorModel item;
            DAL objDAL = new DAL();
            string sql = "SELECT id, nome, email, senha FROM Vendedor order by nome asc";
            DataTable dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new VendedorModel
                {
                    Id = dt.Rows[i]["id"].ToString(),
                    Nome = dt.Rows[i]["nome"].ToString(),
                    Email = dt.Rows[i]["email"].ToString(),
                    Senha = dt.Rows[i]["senha"].ToString(),
                };
                lista.Add(item);
            }
            return lista;
        }

        public VendedorModel RetornarVendedor(int? id)
        {
            VendedorModel item;
            DAL objDAL = new DAL();
            string sql = $"SELECT id, nome, email, senha FROM Vendedor where id='{id}' order by nome asc";
            DataTable dt = objDAL.RetDataTable(sql);

                item = new VendedorModel
                {
                    Id = dt.Rows[0]["id"].ToString(),
                    Nome = dt.Rows[0]["nome"].ToString(),
                    Email = dt.Rows[0]["email"].ToString(),
                    Senha = dt.Rows[0]["senha"].ToString(),
                };

            return item;
        }

        // CREATE OU UPDATE
        public void Gravar()
        {
            DAL objDAL = new DAL();
            string sql = string.Empty; // hoisting de variável
            if (Id != null) // Se Id de cadastro for null, inserir novo vendedor. Se não, atualizar vendedor
            {
                sql = $"UPDATE VENDEDOR SET NOME='{Nome}', EMAIL='{Email}' where id='{Id}'";
            } else
            {
                sql = $"INSERT INTO VENDEDOR(nome, email, senha) value('{Nome}', '{Email}', '123456')";
            }
            objDAL.ExecutarComandoSQL(sql);
        }

        // DELETE
        public void ExcluirVendedor(int id)
        {
            DAL objDAL = new DAL();
            string sql = $"DELETE FROM VENDEDOR WHERE ID={id}";
            objDAL.ExecutarComandoSQL(sql);
        }
    }
}
