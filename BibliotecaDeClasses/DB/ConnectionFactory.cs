using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDeClasses.DB
{
    public class ConnectionFactory
    {
        private static MySqlConnection _conexao = null;

        public static MySqlConnection Connetion()
        {
            try
            {
                var server = "server=localhost";
                var porta = "port=3306";
                var userid = "User id=root";
                var password = "password=root";
                var database = "database=aplicacao_desck";
                _conexao = new MySqlConnection($"{server};{porta};{userid};{database}; {password}");
            }
            catch (MySqlException e)
            {
            }

            return _conexao;
        }
    }
}
