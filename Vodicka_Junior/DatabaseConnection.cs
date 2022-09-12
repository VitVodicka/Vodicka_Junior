using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vodicka_Junior
{
    internal class DatabaseConnection
    {
        SqlConnection SQLconnection;
        public void DataBaseConnection()
        {
            try
            {

                string connectionString = Properties.Settings.Default.student4ConnectionString;
                SQLconnection = new SqlConnection(connectionString);
                SQLconnection.Open();


            }
            catch (Exception e)
            {

            }
        }
        public void AddingToDatabase()
        {
            DataBaseConnection();

        }
        public void ReadingFromDatabase()
        {
            DataBaseConnection();
            try
            {
                SqlDataReader datareader;
                
                SqlCommand sq = new SqlCommand();
                sq.Connection = SQLconnection;
                datareader = sq.ExecuteReader();

                if (datareader.HasRows)
                {
                    while (datareader.Read())
                    {

                    }
                }
                else
                {

                }
                datareader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
