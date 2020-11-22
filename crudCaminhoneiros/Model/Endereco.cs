using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudCaminhoneiros.Model
{
    class Endereco
    {
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public Endereco()
        {
        }

        public Endereco(string rua, int numero, string bairro, string cidade, string estado)
        {
            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }

        public void cadastrarEndereco()
        {
            try
            {
                //Abre conexão
                NpgsqlConnection conect = new Conexao().getConexao();

                // String de comando do insert no sql
                string insert = $"INSERT INTO endereco (endereco, numero, bairro, cidade, estado) " +
                                $"VALUES ('{this.Rua}','{this.Numero}','{this.Bairro}','{this.Cidade}','{this.Estado}')";

                //Envia a string e as informações de conexão
                NpgsqlCommand comand = new NpgsqlCommand(insert, conect);

                //Executa o camando
                comand.ExecuteNonQuery();

                //Fecha conexão
                conect.Close();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
