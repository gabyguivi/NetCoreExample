using System.Collections.Generic;
using netCoreWorkshop.Entities;
using System.Linq;

namespace netCoreWorkshop.Business
{
    public class ArticlesService : IArticlesService
    {
        public Article GetOneArticle(int id) => Article.DataSource.Where(m => m.Id == id).FirstOrDefault();
        public List<Article> GetAllArticles() => Article.DataSource;
        public Article AddArticle(Article article)
        {
            article.Id = Article.DataSource.Count() + 1;
            Article.DataSource.Add(article);
            return article;
        }

        public Article UpdateArticle(Article article)
        {
            Article currentArticle = GetOneArticle(article.Id);
            if (currentArticle != null)
                currentArticle.Title = article.Title;
            else
                return null;

            return currentArticle;
        }

        public void DeleteArticle(int id)
        {
            Article article = GetOneArticle(id);
            if(article!=null)
                Article.DataSource.RemoveAll(a => a.Id == id);
        }
    }
}
