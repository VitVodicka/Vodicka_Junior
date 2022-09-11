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
        }
    }
}
