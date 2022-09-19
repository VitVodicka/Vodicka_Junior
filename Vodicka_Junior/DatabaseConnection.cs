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
        SqlConnection SQLconnection;//declaring classes SQLconnection,SQLCommand and SQL Datareader and Collection
        SqlCommand command;
        SqlDataReader datareader;
        string sql;
        Collection b = new Collection();

        public void DataBaseConnection()//Connecting to databse
        {
            try
            {

                string connectionString = Properties.Settings.Default.student4ConnectionString;//getting connectionstring
                SQLconnection = new SqlConnection(connectionString);//declaring new class SQL connection
                SQLconnection.Open();
                


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void ElementsReading(Collection collection)//Reading elements from table BuildingElements and pasting it into combox int addwindow 
        {
            try { 
            DataBaseConnection();//connecting to the database using class
            string Name;
            sql = "SELECT Name FROM BuildingElements";//sql command

            command = new SqlCommand(sql, SQLconnection);
            datareader = command.ExecuteReader();
            while (datareader.Read())//reads throught BuildingElements table and returns lisst of elements 
            {
                Name = datareader.GetValue(0).ToString();
                Element e = new Element(Name);//creates new elements
                collection.AddingElementsToList(e);//adds elements to elementsList
            }
            datareader.Close();
            SQLconnection.Close();//closes datareader and SQlconnection
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void DeleteFromDatabase(Collection b,int selectedindex)//deltes record from database
        {
            try { //bad index
            DataBaseConnection();
                      
            b.RemoveFromCollection(selectedindex);
            sql = "DELETE FROM BuildingState WHERE Id=@Id ";//delte command
            selectedindex += 1;
            command = new SqlCommand(sql, SQLconnection);
            command.Parameters.AddWithValue("@Id", selectedindex);
            int something = command.ExecuteNonQuery();
            command.Dispose();
            SQLconnection.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void AddingToDatabase(string date, int idType, int propertyCondition, int investmentNeed, int investmentEstimate, string note)//adds to database BuildingState
        {
            try { 
            DataBaseConnection();
                sql = "INSERT INTO [BuildingState](Date,idType,stamp,NecessityInvestment,investAmount,note) VALUES (@date,@idType,@stamp,@NecessityInvestment,@investAmount,@note )";//command which inserts into Building table datetime
                command = new SqlCommand(sql, SQLconnection);
                command.Parameters.AddWithValue("@date", date);
                command.Parameters.AddWithValue("@idType", idType);
                command.Parameters.AddWithValue("@stamp", propertyCondition);
                command.Parameters.AddWithValue("@NecessityInvestment", investmentNeed);
                command.Parameters.AddWithValue("@investAmount", investmentEstimate);
                command.Parameters.AddWithValue("@note", note);
                int something = command.ExecuteNonQuery();

                command.Dispose();
                


            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            SQLconnection.Close();


        }
        public void AddingToLogin(string username, string password)//class which registers new user
        {
            try { 
            DataBaseConnection();
            if(username != null || password != null)
            {
                sql = "INSERT INTO [User](Username, Password) VALUES (@Username,@Password)";//command which inserts into login table(user) username and password
                command = new SqlCommand(sql, SQLconnection);

                command.Parameters.AddWithValue("@Username", username);//adds value into @Username,@Password
                command.Parameters.AddWithValue("@Password", password);
                int something = command.ExecuteNonQuery();

                command.Dispose();

            }
            
            
            SQLconnection.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public bool LoadingFromLogin(string usernameFromText,string passwordFromText)//logining into app, reads data into list and if the data equals then the app continues
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
                b.AddingToList(us);//adds to list
            }
            datareader.Close();
            SQLconnection.Close();
            if(b.ListLoading(usernameFromText, passwordFromText) == true)//checking if login user is in list
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void SverenyBudovyLoading(Collection b, int s_ico)//loading from view Svereny Budovy and adds it into observablecollection
        {
            DataBaseConnection();
            sql = "SELECT id,obec,typ_budovy FROM SVERENE_BUDOVY WHERE s_ico=@s_ico";
            command = new SqlCommand(sql, SQLconnection);
            command.Parameters.AddWithValue("@s_ico", s_ico);//reads records with similar s_ico
            datareader = command.ExecuteReader();
            while (datareader.Read())
            {
                int id = int.Parse(datareader.GetValue(0).ToString());
                string obec = datareader.GetValue(1).ToString();
                string typ_budovy = datareader.GetValue(2).ToString();
                SvereneBudovy s = new SvereneBudovy(id, obec, typ_budovy);//adds it into observablecollction
                b.AddingToSvereneBudovy(s);


            }
            datareader.Close();
        }

        public void ReadingFromDatabase(Collection b)//reads from database BuildingState
        {
            try { 
            DataBaseConnection();
            int Id, IdType, Stamp, Neccessityinvestment, investmentAmount;//declaring variables 
                string note, Date;

            
            sql = "SELECT Id,Date, idType, stamp, NecessityInvestment, investmentAmount, note FROM BuildingState";

            command = new SqlCommand(sql, SQLconnection);
            datareader = command.ExecuteReader();
            while (datareader.Read())
            {
                Id = int.Parse(datareader.GetValue(0).ToString());//inserts data into variables if it find record
                Date = datareader.GetValue(1).ToString();
                IdType = int.Parse(datareader.GetValue(2).ToString());
                Stamp = int.Parse(datareader.GetValue(3).ToString());
                Neccessityinvestment = int.Parse(datareader.GetValue(4).ToString());
                investmentAmount = int.Parse(datareader.GetValue(5).ToString());
                note = datareader.GetValue(6).ToString();
                Building build = new Building(Id, Date, IdType, Stamp, Neccessityinvestment, investmentAmount, note);//declaring new object
                b.AddToCollection(build);
            }
            datareader.Close();
            SQLconnection.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
