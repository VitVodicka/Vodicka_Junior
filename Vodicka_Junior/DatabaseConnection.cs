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
        Collection b = new Collection();
        public int UpdateIndex { get; set; }

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
        public void DeleteFromDatabase(Collection b, int selectedindex)
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
        public void UpdateDateTime(string date)
        {
            DataBaseConnection();
            sql = "UPDATE Building SET FirstApproval=@FirstApproval WHERE Id=@Id";
            command = new SqlCommand(sql, SQLconnection);
            command.Parameters.AddWithValue("@Id", UpdateIndex);
            command.Parameters.AddWithValue("@FirstApproval", date);
            int something = command.ExecuteNonQuery();
            command.Dispose();
            SQLconnection.Dispose();
        }

        public void AddingToDatabase(string approval, int idType, int stamp, int neccesityInvestment, int investmentAmount, string note)
        {
            DataBaseConnection();
            sql = "INSERT INTO Building (FirstApproval) VALUES (@FirstApproval)";
            command = new SqlCommand(sql, SQLconnection);
            command.Parameters.AddWithValue("@FirstApproval", approval);
            //needs to place it into database and figure out the index in database
            sql = "INSERT INTO BuildingState (idBuilding,idType,stamp,NecessityInvestment,investmentAmount,note) VALUES (@idBuilding,@idType,@stamp,@NecessityInvestment,@investmentAmount,@idType,@note)";
            command = new SqlCommand(sql, SQLconnection);

            command.Parameters.AddWithValue("@idBuilding", idBuilding);
            command.Parameters.AddWithValue("@idType", idType);
            command.Parameters.AddWithValue("@stamp", stamp);
            command.Parameters.AddWithValue("@NecessityInvestment", neccesityInvestment);
            command.Parameters.AddWithValue("@investmentAmount", investmentAmount);
            command.Parameters.AddWithValue("@note", note);
            int something = command.ExecuteNonQuery();

            command.Dispose();

        }
    

    

    public void AddingToLogin(string username, string password)
        {
            DataBaseConnection();
            if(LoadingFromLogin(username, password)!=true)
                
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
        
        public void ReadingFromDatabase(Collection b)
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
        //public void UpdateSearching(string dateTime)
        /*public void UpdateSearching(int dateTime)
        {
            DataBaseConnection();
            int index=0;
            sql = "SELECT Id FROM Building WHERE FirstApproval=@FirstApproval";
            command = new SqlCommand(sql, SQLconnection);
            command.Parameters.AddWithValue("@FirstApproval",dateTime);
            datareader = command.ExecuteReader();
            while (datareader.Read())
            {
                index =int.Parse(datareader.GetValue(0).ToString());
            }

            UpdateIndex = index;
            datareader.Close();
            SQLconnection.Close();


        }*/
        public void ElementsReading(Collection collection)
        {
            DataBaseConnection();
            string Name;
            sql = "SELECT Name FROM BuildingElements";

            command = new SqlCommand(sql, SQLconnection);
            datareader = command.ExecuteReader();
            while (datareader.Read())
            {
                Name = datareader.GetValue(0).ToString();
                Element e = new Element(Name);
                collection.AddingElementsToList(e);
            }
            datareader.Close();
            SQLconnection.Close();
            
        }
    }
    
}
