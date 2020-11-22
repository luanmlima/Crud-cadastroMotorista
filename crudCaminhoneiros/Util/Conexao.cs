using Npgsql;
using System;
using System.Data.SqlClient;

namespace crudCaminhoneiros
{
    public class Conexao
    {
        //dados de conexão
        private static string serverName = "localhost";
        private static string port = "5432";
        private static string userName = "postgres";
        private static string password = "123";
        private static string dataBaseName = "cadastroCaminhoneiro";

        public NpgsqlConnection getConexao()
        {
            try
            {
                //String de conexão
                string stgConexao = String.Format($"Server={serverName}; Port={port}; User Id={userName}; Password={password}; Database={dataBaseName}");


                //Classe de conexão
                NpgsqlConnection conexao = new NpgsqlConnection(stgConexao);

                //abre conexão
                conexao.Open();

                return conexao;
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}

