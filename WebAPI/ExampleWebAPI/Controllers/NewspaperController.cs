using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Example.Service;
using ExampleWebAPI.Models;
using Example.Model;

namespace ExampleWebAPI.Controllers
{
    public class NewspaperController : ApiController
    {
        NewspaperService newspaperService = new NewspaperService();

        // GET api/newspaper
        public List<Newspaper> Get()
        {
            List<Newspaper> newspapers = newspaperService.GetNewspapers();
            return newspapers;
        }

        // GET api/newspaper/5
        public HttpResponseMessage GetNewspaperById(int id)
        {
            var newspaper1 = newspaperService.GetNewspaperById(id);

            if (newspaper1 == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Newspapers by id: {id} is not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, newspaper1);
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
                newspaperService.PostNewNewspaper(newspaper);
                return Request.CreateResponse(HttpStatusCode.OK, "Added to the Newspaper base");
            }
        }

        // PUT api/newspaper/5
        public HttpResponseMessage PutNewTitle(int id, [FromBody] string value)
        {
            if (value == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, value);
            }
            else
            {
                newspaperService.PutNewTitle(id, value);
                return Request.CreateResponse(HttpStatusCode.OK, $"Newspaper of id = {id} has changed title to {value}");
            }
        }

        // DELETE api/newspaper/5
        public HttpResponseMessage DeleteNewspaper(int id)
        {
            if (newspaperService.GetNewspaperById(id) == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Newspaper by id: {id} is not found");
            } else
            {
                newspaperService.DeleteNewspaper(id);
                return Request.CreateResponse(HttpStatusCode.OK, $"Newspaper of id= {id} has been deleted");
            }
        }
    }
    
}
      
    


