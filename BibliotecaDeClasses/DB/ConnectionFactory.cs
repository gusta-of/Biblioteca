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
        public MySqlConnection Conexao { get; private set; }

        public ConnectionFactory(string sever, string port, string user, string password, string dataBase)
        {
            Conexao = Connetion(sever, port, user, password, dataBase);
        }

        private MySqlConnection Connetion(string servidor, string porta, string usuario, string senha, string nomeBD)
        {
            MySqlConnection conexao = null;

            if (string.IsNullOrEmpty(porta))
                porta = "3306";

            if (string.IsNullOrEmpty(servidor))
                servidor = "localhost";

            try
            {
                var server = $"server={servidor}";
                var port = $"port={porta}";
                var userid = $"User id={usuario}";
                var passwordId = $"password={senha}";
                var database = $"database={nomeBD}";
                conexao = new MySqlConnection($"{server};{port};{userid};{database}; {passwordId}");
            }
            catch (MySqlException e)
            {
            }

            return conexao;
        }

        private MySqlConnection AbreConexaoBD()
        {
            try
            {
                Conexao.Open();
            }
            finally
            {
            }

            return Conexao;
        }

        private void FechaConexaoBD()
        {
            try
            {
                Conexao.Close();
            }
            finally
            {
            }
        }
    }
}
