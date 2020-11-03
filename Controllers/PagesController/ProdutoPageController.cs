using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learn.Controllers.PagesController
{
    [Route("Produto")]
    public class ProdutoPageController : Controller
    {
        // GET: ProdutoPageController
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ModalProduto()
        {
            return View();
        }
    }
}
