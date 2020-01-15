using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using netCoreWorkshop.Entities;

namespace netCoreWorkshop.API
{
    [Route("/api/articles")]
    [ApiController]
    public class ArticlesApiController : ControllerBase
    {

        private readonly IArticlesService articlesService;
        public ArticlesApiController(IArticlesService articlesService)
        {
            this.articlesService = articlesService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var article = articlesService.GetOneArticle(id);
            
            if (article == null)
            {
                return NotFound();
            }

            return Ok(article);
        }

        [HttpGet]
        public IActionResult Get() => Ok(articlesService.GetAllArticles());

        [HttpPost]
        public IActionResult Create([FromBody]Article article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newArticle = new Article { Title = article.Title, Price= article.Price };

            articlesService.AddArticle(newArticle);

            return CreatedAtAction(nameof(Create), new { id = newArticle.Id }, newArticle);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody]Article article)
        {
            if (id != article.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentArticle = articlesService.GetOneArticle(id);

            if (currentArticle == null)
            {
                return NotFound();
            }

            currentArticle.Title = article.Title;
            currentArticle.Price = article.Price;
            articlesService.UpdateArticle(currentArticle);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var currentArticle = articlesService.GetOneArticle(id);

            if (currentArticle == null)
            {
                return NotFound();
            }

            articlesService.DeleteArticle(id);
            return NoContent();
        }
    }
}