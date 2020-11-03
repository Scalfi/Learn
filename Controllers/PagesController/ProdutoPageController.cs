using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Learn.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learn.Controllers.PagesController
{
    [Route("Produto")]
    public class ProdutoPageController : Controller
    {
        private readonly ProdutoRepository _produtoRepository;
        private readonly CategoriaRepository _categoriaRepository;

        public ProdutoPageController(ProdutoRepository produtoRepository, CategoriaRepository categoriaRepository)
        {
            _produtoRepository = produtoRepository;
            _categoriaRepository = categoriaRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Modal(int id)
        {
            if( id > 0 )
                ViewData["produto"] = await _produtoRepository.PegaProdutoAsync(id);

            ViewData["categorias"] = await  _categoriaRepository.PegaCategoriasAsync();

            return View();
        }
    }
}
