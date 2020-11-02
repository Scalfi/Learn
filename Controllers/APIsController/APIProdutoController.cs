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
    public class APIProdutoController : ControllerBase
    {
        private readonly ProdutoRepository _produtoRepository;

        public APIProdutoController(ProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        // GET: api/<APIProdutoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok( await _produtoRepository.PegaProdutosAsync());
        }

        // GET api/<APIProdutoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            
            return Ok(await _produtoRepository.PegaProdutoAsync(id));
        }

        // POST api/<APIProdutoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Produto produto)
        {

            if(ModelState.IsValid)
            {
                produto =  await _produtoRepository.CriaProdutoAsync(produto);

                if (produto != null)
                {
                    return Ok(produto);
                }
                return BadRequest();
            }
            return BadRequest(ModelState);
        }

        // PUT api/<APIProdutoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<APIProdutoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
