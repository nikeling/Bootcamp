using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Example.Model;
using Example.Service;
using ExampleWebAPI.Models;

namespace ExampleWebAPI.Controllers
{
    public class ArticleController : ApiController 
    {
            private IArticleService articleServ;

            public ArticleController(IArticleService articleServ)
            {
            this.articleServ = articleServ;
            }



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
                    ArticleRest articleRest = new ArticleRest();
                    articleRest.IdOfArticle = article.IdOfArticle;
                    articleRest.TitleOfArticle = article.TitleOfArticle;
                    articleServ.PostNewArticle(article);
                    return Request.CreateResponse(HttpStatusCode.OK, "Added to the Article base");
                }

            }

            // PUT api/article/5
            public HttpResponseMessage PutNewTitle(int id, [FromBody] string value)
            {
                if (value == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, value);
                }
                else
                {
                    articleServ.PutNewTitle(id, value);
                    return Request.CreateResponse(HttpStatusCode.OK, $"Article of id = {id} has changed title to {value}");
                }
            }

            // DELETE api/article/5
            public HttpResponseMessage DeleteArticle(int id)
            {
                  if (articleServ.GetArticleById(id) == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, $"Article of id: {id} is not found");
                } else
                {
                    articleServ.DeleteArticle(id);
                    return Request.CreateResponse(HttpStatusCode.OK, $"Article of id= {id} has been deleted");
                }

            }
      
    }
}