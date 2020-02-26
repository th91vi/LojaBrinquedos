using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaBrinquedos.Uteis;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace LojaBrinquedos.Models
{
    public class ProdutoModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do produto")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a descrição do produto")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe o preço unitário do produto")]
        public decimal Preco_Unitario { get; set; }

        [Required(ErrorMessage = "Informe a quantidade em estoque do produto")]
        public int Quantidade_Estoque { get; set; }

        [Required(ErrorMessage = "Insira um link para imagem do produto")]
        public string Link_Foto { get; set; }

        // READ
        public List<ProdutoModel> ListarTodosProdutos()
        {
            List<ProdutoModel> lista = new List<ProdutoModel>();
            ProdutoModel item;
            DAL objDAL = new DAL();
            string sql = "SELECT id, nome, descricao, preco_unitario, quantidade_estoque, link_foto FROM Produto order by nome asc";
            DataTable dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ProdutoModel
                {
                    Id = dt.Rows[i]["id"].ToString(),
                    Nome = dt.Rows[i]["nome"].ToString(),
                    Descricao = dt.Rows[i]["descricao"].ToString(),
                    Preco_Unitario = decimal.Parse(dt.Rows[i]["preco_unitario"].ToString()),
                    Quantidade_Estoque = Int16.Parse(dt.Rows[i]["quantidade_estoque"].ToString()),
                    Link_Foto = dt.Rows[i]["link_foto"].ToString(),
                };
                lista.Add(item);
            }
            return lista;
        }

        public ProdutoModel RetornarProduto(int? id)
        {
            ProdutoModel item;
            DAL objDAL = new DAL();
            string sql = $"SELECT id, nome, descricao, preco_unitario, quantidade_estoque, link_foto FROM Produto where id='{id}' order by nome asc";
            DataTable dt = objDAL.RetDataTable(sql);

                item = new ProdutoModel
                {
                    Id = dt.Rows[0]["id"].ToString(),
                    Nome = dt.Rows[0]["nome"].ToString(),
                    Descricao = dt.Rows[0]["descricao"].ToString(),
                    Preco_Unitario = decimal.Parse(dt.Rows[0]["preco_unitario"].ToString()),
                    Quantidade_Estoque = Int16.Parse(dt.Rows[0]["quantidade_estoque"].ToString()),
                    Link_Foto = dt.Rows[0]["link_foto"].ToString(),
                };

            return item;
        }

        // CREATE OU UPDATE
        public void Gravar()
        {
            DAL objDAL = new DAL();
            string sql = string.Empty; // hoisting de variável
            if (Id != null) // Se Id de cadastro for null, inserir novo Produto. Se não, atualizar Produto
            {
                sql = $"UPDATE Produto SET NOME='{Nome}', DESCRICAO='{Descricao}', PRECO_UNITARIO='{Preco_Unitario.ToString().Replace(",",".")}', QUANTIDADE_ESTOQUE='{Quantidade_Estoque}', LINK_FOTO='{Link_Foto}' where id='{Id}'";
            } else
            {
                sql = $"INSERT INTO Produto(nome, descricao, preco_unitario, quantidade_estoque, link_foto) value('{Nome}', '{Descricao}', '{Preco_Unitario}', '{Quantidade_Estoque}', '{Link_Foto}')";
            }
            objDAL.ExecutarComandoSQL(sql);
        }

        // DELETE
        public void ExcluirProduto(int id)
        {
            DAL objDAL = new DAL();
            string sql = $"DELETE FROM Produto WHERE ID={id}";
            objDAL.ExecutarComandoSQL(sql);
        }
    }
}
