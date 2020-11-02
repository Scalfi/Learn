using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Learn.Models;
using Learn.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Learn.Controllers.APIsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class APICategoriaController : BaseController
    {
        private readonly CategoriaRepository _CategoriaRepository;

        public APICategoriaController(CategoriaRepository CategoriaRepository)
        {
            _CategoriaRepository = CategoriaRepository;
        }

        // GET: api/<APICategoriaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _CategoriaRepository.PegaCategoriasAsync());
        }

        // GET api/<APICategoriaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _CategoriaRepository.PegaCategoriaAsync(id));
        }

        // POST api/<APICategoriaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Categoria Categoria)
        {

            if (ModelState.IsValid)
            {
                Categoria = await _CategoriaRepository.CriaCategoriaAsync(Categoria);

                if (Categoria != null)
                {
                    return Ok(Categoria);
                }
                return InternalServerError();
            }
            return BadRequest(ModelState);
        }

        // PUT api/<APICategoriaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Categoria autualizarCategoria)
        {
            if (ModelState.IsValid)
            {
                var Categoria = await _CategoriaRepository.PegaCategoriaAsync(id);

                if (Categoria == null)
                    return BadRequest($"Categoria {id} não encontrado para ser atualizada");

                Categoria = await _CategoriaRepository.AtualizaCategoriaAsync(autualizarCategoria, Categoria);

                if (Categoria != null)
                {
                    return Ok(Categoria);
                }

                return InternalServerError();
            }
            return BadRequest(ModelState);
        }

        // DELETE api/<APICategoriaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Categoria = await _CategoriaRepository.PegaCategoriaAsync(id);

            if (Categoria == null)
                return BadRequest($"Categoria {id} não encontrado para ser deletada");

            var sucesso = await _CategoriaRepository.DeletaCategoriaAsync(Categoria);

            if (sucesso)
            {
                return Ok($"Categoria {id} foi deletada com sucesso!");
            }

            return InternalServerError();

        }
    }
}
