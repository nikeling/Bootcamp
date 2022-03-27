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
    public class ArticleRepository
    {
        //creates and opens connection
        static string connectionString = @"Data Source=DESKTOP-P0KDF8M;Initial Catalog=Bootcamp;Integrated Security=True";
        SqlConnection conn = new SqlConnection(connectionString);

        public List<Article> GetArticles()
        {
            conn.Open();
            //creates command
            SqlCommand command = new SqlCommand(
                "SELECT * FROM Article;", conn);

            //executes command
            SqlDataReader dataReader = command.ExecuteReader();
            // creates list
            List<Article> listOfArticles = new List<Article>();

            //checks if dataReader is empty
            if (dataReader.HasRows)
            {   //dataReader reads table rows while it can
                while (dataReader.Read())

                {   //creates article object and connects it with db
                    Article article = new Article();
                    article.IdOfArticle = dataReader.GetInt32(0);
                    article.TitleOfArticle = dataReader.GetString(1);
                    
                    //adds that object to list
                    listOfArticles.Add(article);
                }
                dataReader.Close();
            }
            return listOfArticles;
        }
        public Article GetArticleById(int id)
        {
            conn.Open();
            SqlCommand command = new SqlCommand(
                $"SELECT * FROM Article WHERE IdOfArticle={id};", conn);

            SqlDataReader dataReader = command.ExecuteReader();
            Article article = new Article();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    article.IdOfArticle = dataReader.GetInt32(0);
                    article.TitleOfArticle = dataReader.GetString(1);
                }
                dataReader.Close();
            }
            conn.Close();
            return article;
        }

        public void PostNewNewspaper(Article article)
        {
            conn.Open();
            string querystring = $"INSERT INTO Article (IdOfArticle, ArticleName) VALUES ('{article.IdOfArticle }','{article.TitleOfArticle}');";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(querystring, conn);
            DataSet articleData = new DataSet();
            dataAdapter.Fill(articleData, "Article");
            conn.Close();
        }
    }
}
