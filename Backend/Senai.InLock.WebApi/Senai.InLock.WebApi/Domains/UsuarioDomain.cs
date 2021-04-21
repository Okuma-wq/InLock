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
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "A senha é necessária")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "O campo senha deve ter no mínimo 6 caracteres e no máximo 20")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O tipo de usuário é obrigatório")]
        public int IdTipoUsuario { get; set; }
    }
}
