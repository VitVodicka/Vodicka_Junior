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
        public void DeleteFromDatabase()
        {
            DataBaseConnection();

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
        public void ReadingFromDatabase()
        {
            
            int Id, IdBuilding, IdType, Stamp, Neccessityinvestment, investmentAmount;
            string note;
            DataBaseConnection();
            /*try
            {
                SqlDataReader datareader;
               
                SqlCommand sq = new SqlCommand();
                sq.Connection = SQLconnection;
                sq.CommandText = "SELECT Id,idBuilding, idType, stamp, NecessityInvestment, investmentAmount, note FROM BuildingState";
                datareader = sq.ExecuteReader();

                if (datareader.HasRows)
                {
                    while (datareader.Read())
                    {
                        Id = datareader.GetInt16(0);
                        IdBuilding = datareader.GetInt16(1);
                        IdType = datareader.GetInt16(2);
                        Stamp = datareader.GetInt16(3);
                        Neccessityinvestment = datareader.GetInt16(4);
                        investmentAmount = datareader.GetInt16(5);
                        note = datareader.GetString(6);
                        Building build = new Building(Id, IdBuilding, IdType, Stamp, Neccessityinvestment, investmentAmount, note);
                        b.AddToCollection(build);
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
            }*/

        }
    }
}
