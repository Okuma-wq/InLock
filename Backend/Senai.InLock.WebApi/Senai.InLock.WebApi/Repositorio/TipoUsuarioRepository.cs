using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositorio
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private string stringConexao = "Data Source=DESKTOP-4A3IQMH\\SQLEXPRESS; initial catalog = inlock_games_tarde; user id = sa; pwd=senai@132";

        public List<TipoUsuariosDomain> Listar()
        {
            List<TipoUsuariosDomain> listaTiposUsuario = new List<TipoUsuariosDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT * FROM tipoUsuarios;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        TipoUsuariosDomain TiposUsuario = new TipoUsuariosDomain()
                        {
                            IdTipoUsuarios = Convert.ToInt32(rdr["idTipoUsuario"]),
                            Permissao = rdr["permissao"].ToString()
                        };

                        listaTiposUsuario.Add(TiposUsuario);
                    }
                }

                return listaTiposUsuario;
            }
        }
    }
}
