using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vodicka_Junior.Structures;

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
        public void DeleteFromDatabase(Background b,int selectedindex)
        {
            string sql;
            SqlConnection SQLconnection;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string connectionString = Properties.Settings.Default.student4ConnectionString;
            SQLconnection = new SqlConnection(connectionString);
            SQLconnection.Open();
            SqlCommand command;

            b.RemoveFromCollection(selectedindex);
            sql = "DELETE FROM BuildingState WHERE Id=@Id ";

            command = new SqlCommand(sql, SQLconnection);




            command.Parameters.AddWithValue("@Id", selectedindex);
            int something = command.ExecuteNonQuery();
        }
        public void AddingToDatabase()
        {
            DataBaseConnection();


        }
        public void AddingToLogin()
        {

        }
        public void LoadingFromLogin()
        {

        }
        public void ReadingFromDatabase(Background b)
        {
            int Id, IdBuilding, IdType, Stamp, Neccessityinvestment, investmentAmount;
            string note;

            SqlCommand command;
            SqlDataReader datareader;
            String sql;
            sql = "SELECT Id,idBuilding, idType, stamp, NecessityInvestment, investmentAmount, note FROM BuildingState";

            command = new SqlCommand(sql, SQLconnection);
            datareader = command.ExecuteReader();
            while (datareader.Read())
            {
                Id = int.Parse(datareader.GetValue(0).ToString());
                IdBuilding = int.Parse(datareader.GetValue(1).ToString());
                IdType = int.Parse(datareader.GetValue(2).ToString());
                Stamp = int.Parse(datareader.GetValue(3).ToString());
                Neccessityinvestment = int.Parse(datareader.GetValue(4).ToString());
                investmentAmount = int.Parse(datareader.GetValue(5).ToString());
                note = datareader.GetValue(6).ToString();
                Building build = new Building(Id, IdBuilding, IdType, Stamp, Neccessityinvestment, investmentAmount, note);
                b.AddToCollection(build);
            }

        }
    }
}
