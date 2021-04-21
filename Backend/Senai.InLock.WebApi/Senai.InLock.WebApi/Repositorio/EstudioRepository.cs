using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositorio
{
    public class EstudioRepository : IEstudioRepository
    {
        private string stringConexao = "Data Source=DESKTOP-4A3IQMH\\SQLEXPRESS; initial catalog=inlock_games_tarde; user id=sa; pwd=senai@132";

        public EstudioDomain BuscarPorId(int id)
        {
            using(SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "SELECT * FROM estudios WHERE idEstudio = @id";

                con.Open();

                SqlDataReader rdr;

                using(SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    rdr = cmd.ExecuteReader();

                    if(rdr.Read())
                    {
                        EstudioDomain estudio = new EstudioDomain()
                        {
                            IdEstudio = Convert.ToInt32(rdr["idEstudio"]),
                            NomeEstudio = rdr["nomeEstudio"].ToString()
                        };

                        return estudio;
                    }

                    return null;
                }
            }
        }

        public List<EstudioDomain> Listar()
        {
            List<EstudioDomain> listaEstudio = new List<EstudioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT * FROM estudios";

                con.Open();

                SqlDataReader rdr;

                using(SqlCommand cmd = new SqlCommand (querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while(rdr.Read())
                    {
                        EstudioDomain Estudio = new EstudioDomain()
                        {
                            IdEstudio = Convert.ToInt32(rdr["idEstudio"]),
                            NomeEstudio = rdr["nomeEstudio"].ToString()
                        };

                        listaEstudio.Add(Estudio);
                    }
                }

                return listaEstudio;
            }
        }
    }
}
