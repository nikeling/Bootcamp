using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ExampleWebAPI.Models;

namespace ExampleWebAPI.Controllers
{
    public class NewspaperController : ApiController
    {
        public static List<Newspaper> listOfNewspaper = new List<Newspaper>()
        { new Newspaper { IdOfNewspaper = 1, Title = "Newspaper One" },
          new Newspaper { IdOfNewspaper = 2, Title = "Newspaper Two" },
          new Newspaper { IdOfNewspaper = 3, Title = "Newspaper Three"}
        };

        // GET api/newspaper
        public List<Newspaper> Get()
        {
            return listOfNewspaper;
            //if (listOfNewspaper == null)
            //{
            //    return Request.CreateResponse(HttpStatusCode.NotFound, 0);
            //}
            //return Request.CreateResponse(HttpStatusCode.OK, listOfNewspaper);
        }

        // GET api/newspaper/5
        public HttpResponseMessage GetNewspaperById(int id)
        {
            var newspaper = listOfNewspaper.Find(p => p.IdOfNewspaper == id);

            if (newspaper == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, id);
            }
            return Request.CreateResponse(HttpStatusCode.OK, newspaper);
        }

        // POST api/newspaper
        public HttpResponseMessage PostNewNewspaper(Newspaper newspaper)
        {
            if (newspaper == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, newspaper);
            }
            else
            {
                listOfNewspaper.Add(newspaper);
                return Request.CreateResponse(HttpStatusCode.OK, listOfNewspaper);
            }
        }

        // PUT api/newspaper/5
        public HttpResponseMessage Put(int id, [FromBody] string value)
        {
            var newspaper = listOfNewspaper.Find(p => p.IdOfNewspaper == id);
            if (newspaper == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, id);
            }
            else
            {
                newspaper.Title = value;
                return Request.CreateResponse(HttpStatusCode.OK, newspaper);
            }
        }

        // DELETE api/newspaper/5
        public HttpResponseMessage Delete(int id)
        {  
            var newspaper = listOfNewspaper.Find(p => p.IdOfNewspaper == id);

            if (newspaper == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, id);
            }
            else
            {
                listOfNewspaper.Remove(newspaper);
                return Request.CreateResponse(HttpStatusCode.OK,listOfNewspaper);
            }
        }

        
    }
}

