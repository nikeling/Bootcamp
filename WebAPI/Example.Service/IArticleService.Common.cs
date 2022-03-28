using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Model;

namespace Example.Service
{
    public interface IArticleService
    {
        List<Article> GetArticles();

        Article GetArticleById(int id);

        void PostNewArticle(Article article);

        void PutNewTitle(int id, string value);

        void DeleteArticle(int id);

    }
}
