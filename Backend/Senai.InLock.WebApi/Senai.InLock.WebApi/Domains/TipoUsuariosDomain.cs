using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Domains
{
    public class TipoUsuariosDomain
    {
        public int IdTipoUsuarios { get; set; }

        [Required(ErrorMessage = "É necessario inserir o tipo de permissão")]
        public string Permissao { get; set; }
    }
}
