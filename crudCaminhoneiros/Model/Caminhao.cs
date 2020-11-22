using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudCaminhoneiros.Model
{
    class Caminhao
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public int Eixos { get; set; }

        public Caminhao()
        {
        }

        public Caminhao(string marca, string modelo, string placa, int eixos)
        {
            Marca = marca;
            Modelo = modelo;
            Placa = placa;
            Eixos = eixos;
        }


        public void CadastrarVeiculo()
        {
            try
            {
                

                //Abre conexão
                NpgsqlConnection conect = new Conexao().getConexao();

                // String de comando do insert no sql
                string insert = $"INSERT INTO caminhao (marca, modelo, placa, eixos) " +
                                $"VALUES ('{this.Marca}','{this.Modelo}','{this.Placa}','{this.Eixos}')";

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
