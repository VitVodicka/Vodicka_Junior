using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Vodicka_Junior.Structures;

namespace Vodicka_Junior
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Background b = new Background();
        DatabaseConnection con = new DatabaseConnection();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = b;
            //con.DataBaseConnection();

            int Id, IdBuilding, IdType, Stamp, Neccessityinvestment, investmentAmount;
            string note;

            SqlConnection SQLconnection;
            string connectionString = Properties.Settings.Default.student4ConnectionString;
            SQLconnection = new SqlConnection(connectionString);
            SQLconnection.Open();
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



        private void Add_Click(object sender, RoutedEventArgs e)
        {
            new AddWindow().Show();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            string sql;
            SqlConnection SQLconnection;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string connectionString = Properties.Settings.Default.student4ConnectionString;
            SQLconnection = new SqlConnection(connectionString);
            SQLconnection.Open();
            SqlCommand command;

            b.RemoveFromCollection(listview.SelectedIndex);
            sql = "DELETE FROM BuildingState WHERE Id=@Id ";

            command = new SqlCommand(sql, SQLconnection);

            
           
            
            command.Parameters.AddWithValue("@Id", listview.SelectedIndex);
            int rsomething = command.ExecuteNonQuery();
                
        }
            /*adapter.DeleteCommand = new SqlCommand(sql,SQLconnection);
            adapter.DeleteCommand.Parameters.AddWithValue("@Id", listview.SelectedIndex);
            adapter.DeleteCommand.ExecuteNonQuery();*/


        }

        private void listview_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new UpdateWindow().Show();
        }
    }
}
