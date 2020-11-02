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
    public class APIProdutoController : BaseController
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
                return InternalServerError();
            }
            return BadRequest(ModelState);
        }

        // PUT api/<APIProdutoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Produto autualizarProduto)
        {
            if (ModelState.IsValid)
            {
                var produto = await _produtoRepository.PegaProdutoAsync(id);

                if (produto == null)
                    return BadRequest($"Produto {id} não encontrado para ser atualizado");

                produto = await _produtoRepository.AtualizaProdutoAsync( autualizarProduto, produto);

                if (produto != null)
                {
                    return Ok(produto);
                }

                return InternalServerError();
            }
            return BadRequest(ModelState);
        }

        // DELETE api/<APIProdutoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var produto = await _produtoRepository.PegaProdutoAsync(id);

            if (produto == null)
                return BadRequest($"Produto {id} não encontrado para ser deletado");

            var sucesso = await _produtoRepository.DeletaProdutoAsync(produto);

            if (sucesso)
            {
                return Ok($"Produto {id} foi deletado com sucesso!");
            }
            
            return InternalServerError();    
           
        }
    }
}
