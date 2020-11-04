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
    [Route("categoria")]

    public class CategoriaPageController : Controller
    {
        private readonly CategoriaRepository _categoriaRepository;

        public CategoriaPageController(CategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<IActionResult> Index()
        {
            var produtos = await _categoriaRepository.PegaCategoriasAsync();
            return View(produtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Modal(int id)
        {
            var model = new FrontModalProdutoCategoria();
            model.Url = "/api/categoria";

            if (id > 0)
            {
                model.Categoria = await _categoriaRepository.PegaCategoriaAsync(id);
                model.Url = model.Url + "/" + model.Produto.ProdutoId;
                model.Method = "PUT";
            }

            return View(model);
        }
    }
}
