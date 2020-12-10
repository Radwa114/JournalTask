using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
namespace Journal
{
    public class Program
    {
        public class article
        {
            public string title;
            public string description;
            public string author;
        }
        public class author
        {
            public string author_name;
            public List<article> articles;
            public List<article> author_articles;
            public List<string> view_articles()
            {
                List<string> return_articles = new List<string>();
                List<string> sorted_authors = new List<string>();
                SQLiteConnection conn;
                conn = new SQLiteConnection("Data Source=database.db; Version = 3; New = True; Compress = True; ");
                conn.Open();
                SQLiteDataReader sqlite_datareader;
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = conn.CreateCommand();
                sqlite_cmd.CommandText = "select * from Article where Author_name= '" + author_name + "';";
                sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    string article= sqlite_datareader.GetString(0)+"-"+ sqlite_datareader.GetString(1)+"-"+ sqlite_datareader.GetString(2);
                    return_articles.Add(article);
                }
                sqlite_datareader.Close();
                sqlite_cmd.CommandText = "select Author_name  from Article where Author_name<>  '" + author_name + "' group by Author_name order by count(Author_name) desc;";
                sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    sorted_authors.Add(sqlite_datareader.GetString(0));
                }
                sqlite_datareader.Close();
                for (int i = 0; i < sorted_authors.Count; i++)
                {
                    sqlite_cmd.CommandText = "select *  from Article where Author_name=  '" + sorted_authors[i] + "';";
                    sqlite_datareader = sqlite_cmd.ExecuteReader();
                    while (sqlite_datareader.Read())
                    {
                        string article = sqlite_datareader.GetString(0) +"-"+ sqlite_datareader.GetString(1) +"-"+ sqlite_datareader.GetString(2);
                        return_articles.Add(article);
                    }
                    sqlite_datareader.Close();
                }
                return return_articles;
            }
            public void check_existing(article article)
            {

            }
            public void create_article(article article)

            {
                SQLiteConnection conn;
                conn = new SQLiteConnection("Data Source=database.db; Version = 3; New = True; Compress = True; ");
                conn.Open();
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = conn.CreateCommand();
                sqlite_cmd.CommandText = "INSERT INTO Articles_Waiting_list(Title , Description, Author_name) VALUES(" + "'" + article.title + "'" + ',' + "'" + article.description + "'" + ',' + "'" + article.author + "'" + ");";
                sqlite_cmd.ExecuteNonQuery();
            }
        }
        public class admin
        {

            public List<string> view_articles()
            {
                List<string> return_articles = new List<string>();
                List<string> sorted_authors = new List<string>();
                SQLiteConnection conn;
                conn = new SQLiteConnection("Data Source=database.db; Version = 3; New = True; Compress = True; ");
                conn.Open();
                SQLiteDataReader sqlite_datareader;
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = conn.CreateCommand();
                sqlite_cmd.CommandText = "select Author_name  from Article  group by Author_name order by count(Author_name) desc;";
                sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    sorted_authors.Add(sqlite_datareader.GetString(0));
                }
                sqlite_datareader.Close();
                for (int i = 0; i < sorted_authors.Count; i++)
                {
                    sqlite_cmd.CommandText = "select *  from Article where Author_name=  '" + sorted_authors[i] + "';";
                    sqlite_datareader = sqlite_cmd.ExecuteReader();
                    while (sqlite_datareader.Read())
                    {
                        string article = sqlite_datareader.GetString(0) + "-" + sqlite_datareader.GetString(1) + "-" + sqlite_datareader.GetString(2);
                        return_articles.Add(article);
                    }
                    sqlite_datareader.Close();
                }
                return return_articles;
            }
            public List<string> view_waiting_articles()
            {
                List<string> return_articles = new List<string>();
                SQLiteConnection conn;
                conn = new SQLiteConnection("Data Source=database.db; Version = 3; New = True; Compress = True; ");
                conn.Open();
                SQLiteDataReader sqlite_datareader;
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = conn.CreateCommand();
                sqlite_cmd.CommandText = "select *  from Articles_Waiting_list;";
                sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    string article = sqlite_datareader.GetString(0) + "-" + sqlite_datareader.GetString(1) + "-" + sqlite_datareader.GetString(2);
                    return_articles.Add(article);
                }
                return return_articles;
            }
            public void approve_article(string title , string description , string author)
            {
                SQLiteConnection conn;
                conn = new SQLiteConnection("Data Source=database.db; Version = 3; New = True; Compress = True; ");
                conn.Open();
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = conn.CreateCommand();
                sqlite_cmd.CommandText = "INSERT INTO Article(Title , Description, Author_name) VALUES(" + "'" + title + "'" + ',' + "'" + description + "'" + ',' + "'" + author + "'" + ");";
                sqlite_cmd.ExecuteNonQuery();
                sqlite_cmd.CommandText = "Delete from Articles_Waiting_list where Title = '" + title + "'and Author_name = '" + author + "'";
                sqlite_cmd.ExecuteNonQuery();

            }
            public void delete_artice(string title,string author)
            {
                SQLiteConnection conn;
                conn = new SQLiteConnection("Data Source=database.db; Version = 3; New = True; Compress = True; ");
                conn.Open();
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = conn.CreateCommand();
                sqlite_cmd.CommandText = "Delete from Article where Title = '" + title + "'and Author_name = '" + author + "'";
                sqlite_cmd.ExecuteNonQuery();
            }
        }
        /*public void save_to_database( string title, string description, string author_name)
        {
            SQLiteConnection conn;
            conn = new SQLiteConnection("Data Source=database.db; Version = 3; New = True; Compress = True; ");
            conn.Open();
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "INSERT INTO Article(Title , Description, Author_name) VALUES("+"'"+title+"'" + ',' + "'" + description + "'" + ',' + "'" + author_name + "'" + ");";
            sqlite_cmd.ExecuteNonQuery();
        }
        public List<article> get_from_database(SQLiteConnection conn)
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            List<article> articles = new List<article>();
   
            sqlite_cmd.CommandText = "SELECT * FROM Article";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                string myreader = sqlite_datareader.GetString(0);
                article article = new article();
                string[] Article = myreader.Split(' ');
                article.title = Article[0];
                article.description = Article[1];
                article.author = Article[2];
                articles.Add(article);
            }
            return articles;
        }*/
        public List<string> get_authors_names()
        {
            SQLiteConnection conn;
            conn = new SQLiteConnection("Data Source=database.db; Version = 3; New = True; Compress = True; ");
            conn.Open();
            List<string> author_names = new List<string>();
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT distinct Author_name FROM Article";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                string myreader = sqlite_datareader.GetString(0);
                author_names.Add(myreader);
            }
            return author_names;
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
