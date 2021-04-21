using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Domains
{
    public class JogoDomain
    {
        public int IdJogo { get; set; }

        [Required(ErrorMessage = "Nome do jogo obrigatório")]
        public string NomeJogo { get; set; }

        [Required(ErrorMessage = "Descrição do jogo é obrigatória")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "A data de lançamento é obrigatória")]
        public DateTime DataLancamento { get; set; }

        [Required(ErrorMessage = "O valor do jogo é obrigatório")]
        public double? Valor { get; set; }

        [Required(ErrorMessage = "O id do estudio é obrigatório")]
        public int IdEstudio { get; set; }
    }
}
