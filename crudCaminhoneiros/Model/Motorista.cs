using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudCaminhoneiros.Model
{
    class Motorista
    {
        public int id_Motorista { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public Endereco Endereco { get; set; }
        public Caminhao Caminhao { get; set; }   

        public Motorista()
        {
        }

        public Motorista(int id_motorista, string nome, string sobrenome, Endereco endereco, Caminhao caminhao)
        {
            id_Motorista = id_motorista;
            Nome = nome;
            Sobrenome = sobrenome;
            this.Endereco = endereco;
            this.Caminhao = caminhao;
        }

        //Cadastro de Motorista
        public void cadastrarMotorista()
        {
            try
            {
                //Abre conexão
                NpgsqlConnection conect = new Conexao().getConexao();

                // String de comando do insert no sql
                string insert = $"INSERT INTO motorista (nome, sobrenome) VALUES ('{Nome}', '{Sobrenome}')";

                //Cria o comando passando a string e as informações de conexão
                NpgsqlCommand comand = new NpgsqlCommand(insert, conect);

                //Executa o comando
                comand.ExecuteNonQuery();

                //Fecha conexão
                conect.Close();
               
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Excluir()
        {
            NpgsqlConnection conexao = new Conexao().getConexao();
            try
            {
                string sql = $"DELETE * from motorista  where Id = '{id_Motorista}'";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);

                cmd.ExecuteNonQuery();



            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        public List<Motorista> Listar()
        {
            //Abre conexão
            NpgsqlConnection conect = new Conexao().getConexao();

            try
            {
                // Strinsg de comando para selecionar o id do motorista
                string select = "Select motorista.nome, motorista.sobrenome, endereco.endereco, endereco.numero, endereco.bairro, endereco.cidade, endereco.estado," +
                    "caminhao.marca, caminhao.modelo, caminhao.placa, caminhao.eixos " +
                                "from veiculo, motorista, caminhao " +
                                "Where motorista.id_motorista = motorista.Id";

                //Cria o comando passando a string e as informações de conexão
                NpgsqlCommand comand = new NpgsqlCommand(select, conect);

                //Executa o comando e atribui a variavel id
                NpgsqlDataReader dr = comand.ExecuteReader();

                //Lista que vai retornar o select
                List<Motorista> listaMotorista = new List<Motorista>();

                while (dr.Read())
                {
                    Motorista novoCadastro = new Motorista();

                    //Atribui cada valor do select
                    novoCadastro.id_Motorista = Convert.ToInt32(dr["Id"]);
                    novoCadastro.Nome = dr["nome"].ToString();
                    novoCadastro.Sobrenome = dr["sobrenome"].ToString();
                    novoCadastro.Endereco.Rua = dr["endereco"].ToString();
                    novoCadastro.Endereco.Numero = Convert.ToInt32(dr["endereco"]);
                    novoCadastro.Endereco.Bairro = dr["bairro"].ToString();
                    novoCadastro.Endereco.Cidade = dr["cidade"].ToString();
                    novoCadastro.Endereco.Estado = dr["estado"].ToString();
                    novoCadastro.Caminhao.Marca = dr["Marca"].ToString();
                    novoCadastro.Caminhao.Modelo = dr["Modelo"].ToString();
                    novoCadastro.Caminhao.Placa = dr["placa"].ToString();
                    novoCadastro.Caminhao.Eixos = Convert.ToInt32(dr["Eixos"]);


                    //adiciona o objeto na lista
                    listaMotorista.Add(novoCadastro);
                }

                return listaMotorista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                //Fecha conexão
                if (conect != null)
                {
                    conect.Close();
                }

            }
        }

    }
}
