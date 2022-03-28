using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Model;
using Example.Repository;

namespace Example.Service
{
    public class ArticleService
    {
        ArticleRepository articleRepo = new ArticleRepository();

        public List<Article> GetArticles()
        {
            List<Article> listoOfArticles = articleRepo.GetArticles();
            return listoOfArticles;
        }

        public Article GetArticleById(int id)
        {
            return articleRepo.GetArticleById(id);
        }

        public void PostNewArticle(Article article)
        {
            articleRepo.PostNewArticle(article);
        }

        public void PutNewTitle(int id, string value)
        {
            articleRepo.PutNewTitle(id, value);
        }

        public void DeleteArticle(int id)
        {
            articleRepo.DeleteArticle(id);
        }

    }
}
