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
using System.Threading.Tasks;

namespace ExampleWebAPI.Controllers
{
    public class NewspaperController : ApiController
    {
        NewspaperService newspaperService = new NewspaperService();


        // GET api/newspaper
        public async Task <List<Newspaper>> GetAsync()
        {
            List<Newspaper> newspapers = await Task.Run(() => newspaperService.GetNewspapersAsync()); 
            return newspapers;
        }

        // GET api/newspaper/5
        public async Task<HttpResponseMessage> GetNewspaperByIdAsync(int id)
        {
            var newspaper1 = await Task.Run(() => newspaperService.GetNewspaperByIdAsync(id)); 

            if (newspaper1 == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Newspapers by id: {id} is not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, newspaper1);
        }

        // POST api/newspaper
        public async Task<HttpResponseMessage> PostNewNewspaperAsync(NewspaperRest newspaperRest)
        {
            if (newspaperRest == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, newspaperRest);
            }
            else
            {
                Newspaper newspaper = new Newspaper();
                newspaper.IdOfNewspaper = newspaperRest.IdOfNewspaper;
                newspaper.Title = newspaperRest.Title;
                await Task.Run(() => newspaperService.PostNewNewspaperAsync(newspaper)); 
                return Request.CreateResponse(HttpStatusCode.OK, "Added to the Newspaper base");
            }
        }

        // PUT api/newspaper/5
        public async Task<HttpResponseMessage> PutNewTitleAsync(int id, [FromBody] string value)
        {
            if (value == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, value);
            }
            else
            {
                await Task.Run(() => newspaperService.PutNewTitleAsync(id, value));
                return Request.CreateResponse(HttpStatusCode.OK, $"Newspaper of id = {id} has changed title to {value}");
            }
        }

        // DELETE api/newspaper/5
        public async Task<HttpResponseMessage> DeleteNewspaperAsync(int id)
        {
           var x = await Task.Run(() => newspaperService.GetNewspaperByIdAsync(id));
            if (x == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Newspaper by id: {id} is not found");
            } else
            {
                await Task.Run(() => newspaperService.DeleteNewspaperAsync(id));
                return Request.CreateResponse(HttpStatusCode.OK, $"Newspaper of id= {id} has been deleted");
            }
        }
    }
    
}
      
    


