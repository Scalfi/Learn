using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learn.Controllers.PagesController
{
    public class ProdutoPageController : Controller
    {
        // GET: ProdutoPageController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProdutoPageController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProdutoPageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProdutoPageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdutoPageController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProdutoPageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdutoPageController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProdutoPageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
