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
        SqlCommand command;
        SqlDataReader datareader;
        string sql;
        SqlDataAdapter adapter = new SqlDataAdapter();
        Background b = new Background();

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
            DataBaseConnection();
                      
            b.RemoveFromCollection(selectedindex);
            sql = "DELETE FROM BuildingState WHERE Id=@Id ";

            command = new SqlCommand(sql, SQLconnection);
            command.Parameters.AddWithValue("@Id", selectedindex);
            int something = command.ExecuteNonQuery();
            command.Dispose();
            SQLconnection.Close();
        }
        public void AddingToDatabase()
        {
            DataBaseConnection();


        }
        public void AddingToLogin(string username, string password)
        {
            DataBaseConnection();
            if(username != null || password != null)
            {
                sql = "INSERT INTO [User](Username, Password) VALUES (@Username,@Password)";
                command = new SqlCommand(sql, SQLconnection);

                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);
                int something = command.ExecuteNonQuery();

                command.Dispose();

            }
            
            
            SQLconnection.Close();
        }
        public bool LoadingFromLogin(string usernameFromText,string passwordFromText)
        {
            DataBaseConnection();
            string Username,Password;
            sql = "SELECT Username,Password FROM [User]";

            command = new SqlCommand(sql, SQLconnection);
            datareader = command.ExecuteReader();
            while (datareader.Read())
            {
                Username = datareader.GetValue(0).ToString();
                Password = datareader.GetValue(1).ToString();
               
                User us = new User(Username,Password);
                b.AddingToList(us);
            }
            datareader.Close();
            SQLconnection.Close();
            if(b.ListLoading(usernameFromText, passwordFromText) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public void ReadingFromDatabase(Background b)
        {
            DataBaseConnection();
            int Id, IdBuilding, IdType, Stamp, Neccessityinvestment, investmentAmount;
            string note;

            
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
            datareader.Close();
            SQLconnection.Close();

        }
    }
}
