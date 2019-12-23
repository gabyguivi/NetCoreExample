using System.Collections.Generic;
using netCoreWorkshop.Entities;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using netCoreWorkshop.Data;

namespace netCoreWorkshop.Business
{
    public class ArticlesService : IArticlesService
    {
        private readonly ArticlesContext _context;
        private readonly ILogger<ArticlesService> _logger;

        public ArticlesService(ArticlesContext context, ILogger<ArticlesService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public Article GetOneArticle(int id)
        {
            var article = _context.Articles.SingleOrDefault(m => m.Id == id);
            return article;
        }
        public List<Article> GetAllArticles() => _context.Articles.ToList();
        public Article AddArticle(Article article)
        {
            _logger.LogDebug("Starting save");
            var newArticle = new Article { Title = article.Title };
            _context.Articles.Add(newArticle);
            _context.SaveChanges();
            _logger.LogDebug("Finished save");
            return newArticle;
        }

        public Article UpdateArticle(Article article)
        {

            Article currentArticle = GetOneArticle(article.Id);
            if (currentArticle != null)
                currentArticle.Title = article.Title;
            else
                return null;
            _context.SaveChanges();
            return currentArticle;
        }

        public void DeleteArticle(int id)
        {
            Article article = GetOneArticle(id);
            if (article != null)
            {
                _context.Articles.Remove(article);
                _context.SaveChanges();
            }
        }
    }
}
