using System.Collections.Generic;
using netCoreWorkshop.Entities;

public interface IArticlesService
{
    Article GetOneArticle(int id);
    List<Article> GetAllArticles();
    Article AddArticle(Article article);
    Article UpdateArticle(Article article);
    void DeleteArticle(int id);
}