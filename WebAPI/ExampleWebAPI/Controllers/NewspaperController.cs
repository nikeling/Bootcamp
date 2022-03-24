using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace ExampleWebAPI.Controllers
{
    public class NewspaperController : ApiController
    {
       
        // GET api/newspaper
        public HttpResponseMessage Get()
        {  
            //creates and opens connection
            string connectionString =@"Data Source=DESKTOP-P0KDF8M;Initial Catalog=Bootcamp;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            //creates command
            SqlCommand command = new SqlCommand(
                "SELECT * FROM Newspaper;",conn);

            //executes command
            SqlDataReader dataReader = command.ExecuteReader();
            // creates list
            List<Newspaper> listOfNewspaper = new List<Newspaper>();

            //checks if dataReader is empty
            if (dataReader.HasRows)
            {   //dataReader reads table rows while it can
                while (dataReader.Read())

                {   //creates newspaper object and connects it with db
                    Newspaper newspaper = new Newspaper();
                    newspaper.IdOfNewspaper = dataReader.GetInt32(0);
                    newspaper.Title = dataReader.GetString(1);
                    newspaper.Date = dataReader.GetDateTime(2);
                    newspaper.CompanyName = dataReader.GetString(4);

                    //adds that object to list
                    listOfNewspaper.Add(newspaper);
                }
                
                dataReader.Close();
                return Request.CreateResponse(HttpStatusCode.OK, listOfNewspaper);
            } 
            else { return Request.CreateResponse(HttpStatusCode.NotFound, "List is not found"); }
            
        }

        // GET api/newspaper/5
        public HttpResponseMessage GetNewspaperById(int id)
        {   
            //creates and opens connection
            string connectionString = @"Data Source=DESKTOP-P0KDF8M;Initial Catalog=Bootcamp;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

  
            SqlCommand command = new SqlCommand(
                $"SELECT * FROM Newspaper WHERE IdOfNewspaper={id};", conn);

            SqlDataReader dataReader = command.ExecuteReader();

            List<Newspaper> listOfNewspaper = new List<Newspaper>();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    Newspaper newspaper = new Newspaper();
                    newspaper.IdOfNewspaper = dataReader.GetInt32(0);
                    newspaper.Title = dataReader.GetString(1);
                    newspaper.Date = dataReader.GetDateTime(2);
                    newspaper.CompanyName = dataReader.GetString(4);
                    listOfNewspaper.Add(newspaper);
                }
                dataReader.Close();

                var searchedNewspaper = listOfNewspaper.Find(p => p.IdOfNewspaper == id);

                if (searchedNewspaper == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Newspaper by id " + id + " is not found");
                }
                return Request.CreateResponse(HttpStatusCode.OK, searchedNewspaper);
            }
            else { return Request.CreateResponse(HttpStatusCode.NotFound, "List is not found"); }
        }

        // POST api/newspaper
        public HttpResponseMessage PostNewNewspaper(Newspaper newspaper)
        {   
            
            string connectionString = @"Data Source=DESKTOP-P0KDF8M;Initial Catalog=Bootcamp;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);
            

            if (newspaper == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, newspaper);
            }
            else
            {
                conn.Open();
                string querystring = $"INSERT INTO Newspaper (IdOfNewspaper, Title, CompanyName) VALUES ('{newspaper.IdOfNewspaper }','{newspaper.Title}','{newspaper.CompanyName}');";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(querystring, conn);
                DataSet newspaperData = new DataSet();
                dataAdapter.Fill(newspaperData, "Newspaper");
                conn.Close();
                return Request.CreateResponse(HttpStatusCode.OK, "Dodano u listu");
            }
        }

        // PUT api/newspaper/5
        //public HttpResponseMessage Put(int id, [FromBody] string value)
        //{
           
        //}

        //// DELETE api/newspaper/5
        //public HttpResponseMessage Delete(int id)
        //{  
        //    var newspaper = listOfNewspaper.Find(p => p.IdOfNewspaper == id);

        //    if (newspaper == null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound, id);
        //    }
        //    else
        //    {
        //        listOfNewspaper.Remove(newspaper);
        //        return Request.CreateResponse(HttpStatusCode.OK,listOfNewspaper);
        //    }
        //}
    }
    public class Newspaper
    {
        public int IdOfNewspaper { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string ArticleName { get; set; }

        public string CompanyName { get; set; }

       

    }
}

