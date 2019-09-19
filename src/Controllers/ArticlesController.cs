using Microsoft.AspNetCore.Mvc;
using netCoreWorkshop.Entities;
using System.Collections.Generic;
using System.Linq;

namespace netCoreWorkshop.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IArticlesService articlesService;
        public ArticlesController(IArticlesService articlesService)
        {
            this.articlesService = articlesService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(articlesService.GetAllArticles());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            articlesService.DeleteArticle(id);
            return View("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(articlesService.GetOneArticle(id));
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            return View(articlesService.GetOneArticle(id));
        }

        [HttpPost]
        public IActionResult Create(Article article)
        {
            if (ModelState.IsValid)
            {
                articlesService.AddArticle(article);
                return RedirectToAction("Index");
            }

            return View(article);
        }

        [HttpPost]
        public IActionResult Update(Article article)
        {
            if (ModelState.IsValid)
            {
                articlesService.UpdateArticle(article);
                return RedirectToAction("Index");
            }

            return View(article);
        }

    }
}