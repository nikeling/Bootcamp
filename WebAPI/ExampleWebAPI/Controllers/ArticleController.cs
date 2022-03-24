using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace ExampleWebAPI.Controllers
{
    public class ArticleController : ApiController
    {
        public static List<Article> listOfArticles = new List<Article>()
        { new Article { IdOfArticle = 1, TitleOfArticle = "Article One" },
          new Article { IdOfArticle= 2, TitleOfArticle = "Article Two" },
          new Article { IdOfArticle = 3, TitleOfArticle = "Article Three" }
        };

        // GET api/values
        public List<Article> Get()
        {
            return listOfArticles;
        }


        // GET api/values/5
        public HttpResponseMessage GetArticle(string title)
        {
            var article = listOfArticles.Find(p => p.TitleOfArticle == title);

            if (article == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, title);
            }
            return Request.CreateResponse(HttpStatusCode.OK, article);

        }

        // POST api/values
        public HttpResponseMessage PostNewArticle([FromBody]string title)
        {
            if (title == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, title);
            }
            else
            {
                Article article = new Article();
                article.TitleOfArticle = title;
                var sum = listOfArticles.Count();
                article.IdOfArticle = sum + 1;
                listOfArticles.Add(article);

                return Request.CreateResponse(HttpStatusCode.OK, listOfArticles);
            }

        }

        // PUT api/values/5
        public HttpResponseMessage PutNewTitle(int id, [FromBody] string title)
        {
            var article = listOfArticles.Find(p => p.IdOfArticle == id);

            if (article == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, id);
            }
            else
            {
                article.TitleOfArticle = title;
                return Request.CreateResponse(HttpStatusCode.OK, article);
            }
        }

        // DELETE api/values/5
        public HttpResponseMessage DeleteArticle(int id)
        {
            var article = listOfArticles.Find(p => p.IdOfArticle == id);

            if (article == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, id);
            }
            else
            {
                listOfArticles.Remove(article);
                return Request.CreateResponse(HttpStatusCode.OK, listOfArticles);
            }

        }
    }
    public class Article
    {
        public int IdOfArticle { get; set; }

        public string TitleOfArticle { get; set; }

    }

}