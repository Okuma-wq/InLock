using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O email é obrigatorio")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é necessária")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O tipo de usuário é obrigatório")]
        public int IdTipoUsuario { get; set; }
    }
}
