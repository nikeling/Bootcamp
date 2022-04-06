using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Common;
using Example.Model;

namespace Example.Repository
{
    public class NewspaperRepository : INewspaperRepository
    {

        //creates and opens connection
        static string connectionString = @"Data Source=DESKTOP-P0KDF8M;Initial Catalog=Bootcamp;Integrated Security=True";
        SqlConnection conn = new SqlConnection(connectionString);

        public async Task<List<Newspaper>> GetNewspapersAsync(Paging paging, Filtering filtering, Sorting sorting)
        {
            conn.Open();
            
            StringBuilder query = new StringBuilder();
            query.Append($"SELECT * FROM Newspaper");


            if (paging != null)
            {
                query.Append($"LIMIT {paging.RecordsPerPage} OFFSET {(paging.PageNumber - 1) - paging.RecordsPerPage}");
            }


            if (sorting != null)
            {
                if (!string.IsNullOrWhiteSpace(sorting.OrderBy))
                {
                    query.Append($"ORDER BY {sorting.OrderBy}");

                    if (!string.IsNullOrWhiteSpace(sorting.OrderAD))
                    {
                        query.Append($"{sorting.OrderBy}");
                    }
                }
            }

            if (filtering!= null)
            {
                query.Append("WHERE 1=1");

                if (!string.IsNullOrWhiteSpace(filtering.Title))
                {
                    query.Append($"AND Title LIKE '%{filtering.Title}'");
                }

                if (!string.IsNullOrWhiteSpace(filtering.CompanyName))
                {
                    query.Append($"AND CompanyName LIKE '%{filtering.CompanyName}'");
                }

            }

            
            SqlCommand command = new SqlCommand(
                query.ToString(), conn);

            //executes command
            SqlDataReader dataReader = await Task.Run(() => command.ExecuteReader());
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
                    //newspaper.Date = dataReader.GetDateTime(2);
                    newspaper.CompanyName = dataReader.GetString(4);

                    //adds that object to list
                    listOfNewspaper.Add(newspaper);
                }
                dataReader.Close();
            }
            return listOfNewspaper;
        }

        public async Task<Newspaper> GetNewspaperByIdAsync(int id)
        {
                conn.Open();
                SqlCommand command = new SqlCommand(
                    $"SELECT * FROM Newspaper WHERE IdOfNewspaper={id};", conn);

                SqlDataReader dataReader = await Task.Run(() => command.ExecuteReader());
                Newspaper newspaper = new Newspaper();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        newspaper.IdOfNewspaper = dataReader.GetInt32(0);
                        newspaper.Title = dataReader.GetString(1);
                        //newspaper.Date = dataReader.GetDateTime(2);
                        newspaper.CompanyName = dataReader.GetString(4);
                    }
                        dataReader.Close();
                 }
                conn.Close();
                return newspaper;
        }

        public async Task PostNewNewspaperAsync(Newspaper newspaper)
        {
            conn.Open();
            string querystring = $"INSERT INTO Newspaper (IdOfNewspaper, Title, CompanyName) VALUES ('{newspaper.IdOfNewspaper }','{newspaper.Title}','{newspaper.CompanyName}');";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(querystring, conn);
            DataSet newspaperData = new DataSet();
            await Task.Run(() => dataAdapter.Fill(newspaperData, "Newspaper")); 
            conn.Close();
        }


        public async Task PutNewTitleAsync(int id, string value)
        {
            conn.Open();
            string querystring = $"UPDATE Newspaper SET Title= '{value}' WHERE IdOfNewspaper='{id}'";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(querystring, conn);
            DataSet newspaperData = new DataSet();
            await Task.Run(() => dataAdapter.Fill(newspaperData, "Newspaper"));
            conn.Close();    
        }

        
        public async Task DeleteNewspaperAsync(int id)
        {
            conn.Open();
            string querystring = $"DELETE FROM Newspaper WHERE IdOfNewspaper='{id}'";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(querystring, conn);
            DataSet customerData = new DataSet();
            dataAdapter.Fill(customerData, "CustomerDetails");
            await Task.Run(() => dataAdapter.Fill(newspaperData, "Newspaper"));
            conn.Close();
        }
    }
}

