using Microsoft.AspNetCore.Mvc;
using netCoreWorkshop.Entities;
using System.Collections.Generic;
using System.Linq;

namespace netCoreWorkshop.Controllers
{
    public class ArticlesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(Article.DataSource);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Article.DataSource.RemoveAll(a => a.Id == id);
            return View("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(Article.DataSource.First(a => a.Id == id));
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            return View(Article.DataSource.First(a => a.Id == id));
        }

        [HttpPost]
        public IActionResult Create(Article article)
        {
            if (ModelState.IsValid)
            {
                article.Id = Article.DataSource.Count() + 1;
                Article.DataSource.Add(article);
                return RedirectToAction("Index");
            }

            return View(article);
        }

        [HttpPost]
        public IActionResult Update(Article article)
        {
            if (ModelState.IsValid)
            {
                Article.DataSource.First(a=>a.Id== article.Id).Title = article.Title;
                return RedirectToAction("Index");
            }

            return View(article);
        }

    }
}