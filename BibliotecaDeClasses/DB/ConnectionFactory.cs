using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
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

        public MySqlCommand CrieComando(string comandoSQL)
        {
            AbreConexaoBD();
            var command = Conexao.CreateCommand();
            command.CommandText = comandoSQL;
            return command;
        }

        public DbParameter CrieParametro(string parametro, object valor)
        {
            return new MySqlParameter(parametro, ConverteParametro(valor));
        }

        private object ConverteParametro(object valor)
        {
            var parametro = valor;
            if (valor == null)
                parametro = DBNull.Value;
            if (valor is bool)
                parametro = (bool)valor ? "S" : "N";
            if (valor is float)
                parametro = (double)(float)valor;
            if (valor is DateTime)
                parametro = Convert.ToInt32(((DateTime)valor).ToString("ddMMyyyy"));
            if (valor is TimeSpan)
                parametro = Convert.ToInt32(new DateTime(((TimeSpan)valor).Ticks).ToString("HHmm"));

            return parametro;
        }

        /*
         * -Servidor: se não for informado, como padrão esta confiugurado localhost!
         * -Porta: se não for informada, como padrão vem 3306!
         */
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

        private void AbreConexaoBD()
        {
            try
            {
                Conexao.Open();
            }
            finally
            {
            }
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
