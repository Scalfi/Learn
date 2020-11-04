using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Learn.Models.FrontEnd;
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
             var model = new FrontModalProdutoCategoria();

            if (id > 0)
            {
                model.Produto = await _produtoRepository.PegaProdutoAsync(id);
            }

            model.Categorias = await  _categoriaRepository.PegaCategoriasAsync();

            return View(model);
        }
    }
}
