using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Model;

namespace Example.Repository
{
    public class NewspaperRepository
    {
        //creates and opens connection
        static string connectionString = @"Data Source=DESKTOP-P0KDF8M;Initial Catalog=Bootcamp;Integrated Security=True";
        SqlConnection conn = new SqlConnection(connectionString);

        public List<Newspaper> GetNewspapers()
        {
            conn.Open();
            //creates command
            SqlCommand command = new SqlCommand(
                "SELECT * FROM Newspaper;", conn);

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
                    //newspaper.Date = dataReader.GetDateTime(2);
                    newspaper.CompanyName = dataReader.GetString(4);

                    //adds that object to list
                    listOfNewspaper.Add(newspaper);
                }
                dataReader.Close();
            }
            return listOfNewspaper;
        }

        public Newspaper GetNewspaperById(int id)
        {
                conn.Open();
                SqlCommand command = new SqlCommand(
                    $"SELECT * FROM Newspaper WHERE IdOfNewspaper={id};", conn);

                SqlDataReader dataReader = command.ExecuteReader();
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

        public void  PostNewNewspaper(Newspaper newspaper)
        {
            conn.Open();
            string querystring = $"INSERT INTO Newspaper (IdOfNewspaper, Title, CompanyName) VALUES ('{newspaper.IdOfNewspaper }','{newspaper.Title}','{newspaper.CompanyName}');";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(querystring, conn);
            DataSet newspaperData = new DataSet();
            dataAdapter.Fill(newspaperData, "Newspaper");
            conn.Close();
        }


        public void PutNewTitle(int id, string value)
        {
            conn.Open();
            string querystring = $"UPDATE Newspaper SET Title= '{value}' WHERE IdOfNewspaper='{id}'";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(querystring, conn);
            DataSet newspaperData = new DataSet();
            dataAdapter.Fill(newspaperData, "Newspaper");
            conn.Close();    
        }

        // DELETE api/newspaper/5
        public void DeleteNewspaper(int id)
        {
            conn.Open();
            string querystring = $"DELETE FROM Newspaper WHERE IdOfNewspaper='{id}'";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(querystring, conn);
            DataSet newspaperData = new DataSet();
            dataAdapter.Fill(newspaperData, "Newspaper");
            conn.Close();
        }
    }
}

