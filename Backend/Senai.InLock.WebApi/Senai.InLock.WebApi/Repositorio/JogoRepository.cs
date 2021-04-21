using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositorio
{
    public class JogoRepository : IJogoRepository
    {
        private string stringConexao = "Data Source=DESKTOP-4A3IQMH\\SQLEXPRESS; initial catalog = inlock_games_tarde; user id = sa; pwd=senai@132";
        public JogoDomain BuscarPorId(int id)
        {

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "SELECT J.idJogo, J.nomeJogo, J.descricao, J.dataLancamento, J.valor, J.idEstudio, E.nomeEstudio FROM jogos AS J " +
                    "INNER JOIN estudios AS E " +
                    "ON J.idEstudio = E.idEstudio " +
                    "WHERE idJogo = @id; ";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        JogoDomain jogo = new JogoDomain()
                        {
                            IdJogo = Convert.ToInt32(rdr["idJogo"]),
                            NomeJogo = rdr["nomeJogo"].ToString(),
                            Descricao = rdr["descricao"].ToString(),
                            DataLancamento = Convert.ToDateTime(rdr["dataLancamento"]),
                            Valor = Convert.ToDouble(rdr["valor"]),
                            IdEstudio = Convert.ToInt32(rdr["idEstudio"])

                        };

                        return jogo;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(JogoDomain novoJogo)
        {
            using(SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO jogos (nomeJogo, descricao, dataLancamento, valor, idEstudio)" +
                    "VALUES (@nomeJogo, @descricao, @dataLancamento, @valor, @idEstudio)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nomeJogo", novoJogo.NomeJogo);
                    cmd.Parameters.AddWithValue("@descricao", novoJogo.Descricao);
                    cmd.Parameters.AddWithValue("@dataLancamento", novoJogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@valor", novoJogo.Valor);
                    cmd.Parameters.AddWithValue("@idEstudio", novoJogo.IdEstudio);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using(SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM jogos " +
                    "WHERE idJogo = @id;";

                using(SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogoDomain> Listar()
        {
            List<JogoDomain> listaJogos = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT * FROM jogos;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogoDomain jogo = new JogoDomain()
                        {
                            IdJogo = Convert.ToInt32(rdr["idJogo"]),
                            NomeJogo = rdr["nomeJogo"].ToString(),
                            Descricao = rdr["descricao"].ToString(),
                            DataLancamento = Convert.ToDateTime(rdr["dataLancamento"]),
                            Valor = Convert.ToDouble(rdr["valor"]),
                            IdEstudio = Convert.ToInt32(rdr["idEstudio"])

                        };

                        listaJogos.Add(jogo);
                    }
                }

                return listaJogos;
            }
        }
    }
}
