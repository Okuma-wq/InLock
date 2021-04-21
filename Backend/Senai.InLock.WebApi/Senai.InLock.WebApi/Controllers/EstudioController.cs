using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interface;
using Senai.InLock.WebApi.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class EstudioController : ControllerBase
    {
        private IEstudioRepository _estudioRepository { get; set; }

        private IJogoRepository _jogoRepository { get; set; }

        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
            _jogoRepository = new JogoRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            List<EstudioDomain> listaEstudios = _estudioRepository.Listar();

            return Ok(listaEstudios);
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            EstudioDomain estudioBuscado = _estudioRepository.BuscarPorId(id);

            if(estudioBuscado == null)
            {
                return NotFound("O estudio buscado não foi encontrado");
            }

            return Ok(estudioBuscado);
        }

        [Authorize]
        [HttpGet("{id}/Jogos")]
        public IActionResult GetByIdJogos(int id)
        {
            EstudioDomain estudioBuscado = _estudioRepository.BuscarPorId(id);

            List<JogoDomain> listaJogos = _jogoRepository.BuscarPorIdEstudio(id);

            var resultado = new
            {
                idEstudio = estudioBuscado.IdEstudio,
                nomeEstudio = estudioBuscado.NomeEstudio,
                Jogos = listaJogos
            };

            if (estudioBuscado == null)
            {
                return NotFound("O estudio buscado não foi encontrado");
            }

            return Ok(resultado);
        }
    }
}
