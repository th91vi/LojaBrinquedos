﻿using LojaBrinquedos.Uteis;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LojaBrinquedos.Models
{
    public class VendaModel
    {
        public string Id { get; set; }
        public string Cliente_Id { get; set; }
        public string Vendedor_Id { get; set; }
        public string ListaProdutos { get; set; }
        public double TotalCompra { get; set; }

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

        public void Inserir()
        {
            DAL objDAL = new DAL();

            string dataVenda = DateTime.Now.Date.ToString("yyyy/MM/dd");

            string sql = "INSERT INTO VENDA(data, total, vendedor_id, cliente_id)" +
                $"VALUES('{dataVenda}', {TotalCompra}, {Vendedor_Id}, {Cliente_Id})";

            // Recuperar o ID da venda
            sql = $"SELECT id FROM venda WHERE data='{dataVenda}' AND vendedor_id='{Vendedor_Id}' AND cliente_id={Cliente_Id} ORDER BY id DESC LIMIT 1";
            DataTable dt = objDAL.RetDataTable(sql);
            string id_venda = dt.Rows[0]["id"].ToString();

            // Deserializar o JSON da lista de produtos selecionados e gravá-los na tabela itens_venda
            List<ItemVendaModel> lista_produtos = JsonConvert.DeserializeObject<List<ItemVendaModel>>(ListaProdutos);
            for (int i = 0; i < lista_produtos.Count; i++)
            {
                sql = "INSERT INTO itens_venda(venda_id, produto_id, qtde_produto, preco_produto)" +
                    $"VALUES({id_venda}," +
                    $"{lista_produtos[i].CodigoProduto.ToString()}," +
                    $"{lista_produtos[i].QuantidadeProduto.ToString()}," +
                    $"{lista_produtos[i].PrecoUnitario.ToString()})";
                objDAL.ExecutarComandoSQL(sql);
            }
        }
    }
}
