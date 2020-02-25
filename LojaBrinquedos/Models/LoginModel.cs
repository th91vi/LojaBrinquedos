using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using LojaBrinquedos.Uteis;
using System.ComponentModel.DataAnnotations;

namespace LojaBrinquedos.Models
{
    public class LoginModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }

        // retirado valor "reqired" do formulário, para que a validação seja feita através de DataAnnotations do ASP
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Insert user email.")]
        [EmailAddress(ErrorMessage = "Invalid email.")]
        public string Email { get; set; }
        
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Insert correct user password.")]
        public string Senha { get; set; }

        // método abaixo permite injeção de SQL. Corrigir adiante
        public bool ValidarLogin()
        {
            string sql = $"SELECT ID, NOME FROM VENDEDOR WHERE EMAIL='{Email}'AND SENHA='{Senha}'";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);
            if (dt.Rows.Count == 1)
            {
                Id = dt.Rows[0]["id"].ToString();
                Nome = dt.Rows[0]["nome"].ToString();
                return true; // login válido
            } else
            {
                return false;
            }
        }
    }
}
