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
    public class JogoController : ControllerBase
    {
        private IJogoRepository _jogoRepository { get; set; }

        public JogoController()
        {
            _jogoRepository = new JogoRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            List<JogoDomain> listaJogos = _jogoRepository.Listar();

            return Ok(listaJogos);
        }
        
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            JogoDomain jogoBuscado = _jogoRepository.BuscarPorId(id);

            if(jogoBuscado == null)
            {
                return NotFound("O jogo buscado não foi encontrado");
            }

            return Ok(jogoBuscado);
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(JogoDomain novoJogo)
        {
            _jogoRepository.Cadastrar(novoJogo);

            return StatusCode(204);
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _jogoRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}
