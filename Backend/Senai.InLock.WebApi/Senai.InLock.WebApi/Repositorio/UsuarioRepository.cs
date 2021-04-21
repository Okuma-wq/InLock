using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositorio
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source=DESKTOP-4A3IQMH\\SQLEXPRESS; initial catalog=inlock_games_tarde; user id=sa; pwd=senai@132";
        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "SELECT idUsuario, email, senha, idTipoUsuario FROM usuarios WHERE email = @email AND senha = @senha;";

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuarioBuscado = new UsuarioDomain
                        {
                            IdUsuario = Convert.ToInt32(rdr["idUsuario"]),
                            Email = rdr["email"].ToString(),
                            Senha = rdr["senha"].ToString(),
                            IdTipoUsuario = Convert.ToInt32(rdr["idTipoUsuario"])
                        };

                        return usuarioBuscado;
                    }

                    return null;
                }
            }
        }

        public List<UsuarioDomain> Listar()
        {
            List<UsuarioDomain> listaUsuarios = new List<UsuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT * FROM usuarios;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain()
                        {
                            IdUsuario = Convert.ToInt32(rdr["idUsuario"]),
                            Email = rdr["email"].ToString(),
                            IdTipoUsuario = Convert.ToInt32(rdr["idTipoUsuario"])
                        };

                        listaUsuarios.Add(usuario);
                    }
                }

                return listaUsuarios;
            }
        }
    }
}
