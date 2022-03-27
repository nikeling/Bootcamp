using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Example.Model;
using Example.Service;

namespace ExampleWebAPI.Controllers
{
    public class ArticleController : ApiController
    {
        ArticleService articleServ = new ArticleService();

        // GET api/article
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, articleServ.GetArticles());
        }


        //GET api/article/5
            public HttpResponseMessage GetArticleById(int id)
            {
                if (articleServ.GetArticleById(id) == null)
                {
                return Request.CreateResponse(HttpStatusCode.NotFound, id);
                }
                return Request.CreateResponse(HttpStatusCode.OK, articleServ.GetArticleById(id));
             }

        // POST api/article
        public HttpResponseMessage PostNewArticle(Article article)
        {
            if (article== null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, article);
            }
            else
            {
                articleServ.PostNewArticle(article);
                return Request.CreateResponse(HttpStatusCode.OK, "Added to the Article base");
            }

        }

        //    // PUT api/article/5
        //    public HttpResponseMessage PutNewTitle(int id, [FromBody] string title)
        //    {
        //        var article = listOfArticles.Find(p => p.IdOfArticle == id);

        //        if (article == null)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.NotFound, id);
        //        }
        //        else
        //        {
        //            article.TitleOfArticle = title;
        //            return Request.CreateResponse(HttpStatusCode.OK, article);
        //        }
        //    }

        //    // DELETE api/article/5
        //    public HttpResponseMessage DeleteArticle(int id)
        //    {
        //        var article = listOfArticles.Find(p => p.IdOfArticle == id);

        //        if (article == null)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.NotFound, id);
        //        }
        //        else
        //        {
        //            listOfArticles.Remove(article);
        //            return Request.CreateResponse(HttpStatusCode.OK, listOfArticles);
        //        }

        //    }
        //}
        

    }
}