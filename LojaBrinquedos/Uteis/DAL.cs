using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace LojaBrinquedos.Uteis
{
    //Data Access Layer
    public class DAL
    {
        private static string Server = "localhost";
        private static string Database = "loja_brinquedos";
        private static string User = "root";
        private static string Password = "";
        private static string ConnectionString = $"Server={Server};Database={Database};Uid={User};Pwd={Password};Sslmode=none;Charset=utf8;";
        private static MySqlConnection Connection;

        public DAL()
        {
            Connection = new MySqlConnection(ConnectionString);
            Connection.Open();
        }

        // Espera um parâmetro do tipo string contendo um comando SQl do tipo SELECT
        public DataTable RetDataTable(string sql)
        {
            DataTable data = new DataTable();
            MySqlCommand Command = new MySqlCommand(sql, Connection);
            MySqlDataAdapter DataAdapter = new MySqlDataAdapter(Command);
            DataAdapter.Fill(data);
            return data;
        }

        public DataTable RetDataTable(MySqlCommand Command)
        {
            DataTable data = new DataTable();
            Command.Connection = Connection;
            MySqlDataAdapter DataAdapter = new MySqlDataAdapter(Command);
            DataAdapter.Fill(data);
            return data;
        }

        // Espera um parâmetro do tipo string contendo um comando SQl do tipo INSERT, UPDATE, DELETE
        // É executado primeiramente em HomeController
        public void ExecutarComandoSQL(string sql) 
        {
            MySqlCommand Command = new MySqlCommand(sql, Connection);
            Command.ExecuteNonQuery();
        }
    }
}
