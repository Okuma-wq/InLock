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

        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
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
    }
}
