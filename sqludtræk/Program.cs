using System;
using System.Data.SqlClient;
using System.Text;

namespace sqludtræk
{
    class Program
    {
        static void Main(string[] args)
        {
        
            Console.WriteLine("Getting Connection ...");

            var datasource = @"chnpowerapptest.database.windows.net,1433";//your server
            var database = "Powerapps"; //your database name
            var username = "chn"; //username of server to connect
            var password = "Rh49er8c77467m9k"; //password

            //your connection string 
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;

            //create instanace of database connection
            SqlConnection conn = new SqlConnection(connString);


            try
            {
                //Console.WriteLine("Openning Connection ...");

                //open connection
                conn.Open();

                //Console.WriteLine("Connection successful!");

                //create a new SQL Query using StringBuilder
                StringBuilder strBuilder = new StringBuilder();
                strBuilder.Append("INSERT INTO TestUser (login, password) VALUES ");
                strBuilder.Append("(N'Pipelines_user1', N'4124'), ");
                strBuilder.Append("(N'Pipelines_user1', N'123') ");

                string sqlQuery = strBuilder.ToString();
                using (SqlCommand command = new SqlCommand(sqlQuery, conn)) //pass SQL query created above and connection
                {
                    command.ExecuteNonQuery(); //execute the Query
                    //Console.WriteLine("Query Executed.");
                }

                strBuilder.Clear(); // clear all the string

                //add Query to update to Student_Details table
                strBuilder.Append("UPDATE TestUser SET login = N'test123' WHERE password = '123'");
                sqlQuery = strBuilder.ToString();
                using (SqlCommand command = new SqlCommand(sqlQuery, conn))
                {
                    int rowsAffected = command.ExecuteNonQuery(); //execute query and get updated row count
                    //Console.WriteLine(rowsAffected + " row(s) updated");
                }

            }
            catch (Exception e)
            {
                //Console.WriteLine("Error: " + e.Message);
            }

            Console.Read();
        }
    }
}