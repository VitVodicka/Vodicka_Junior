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

            SqlConnection SQLconnection;
            string connectionString = Properties.Settings.Default.student4ConnectionString;
            SQLconnection = new SqlConnection(connectionString);
            SQLconnection.Open();
            SqlCommand command;
            SqlDataReader dataReader;
            String sql, Output = "";
            sql = "Select Id, idBuilding from BuildingState";

            command = new SqlCommand(sql, SQLconnection);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Output += dataReader.GetValue(0) + " - " + dataReader.GetValue(1);
            }
            MessageBox.Show(Output);
            Building be = new Building(1,1,1,1,1,1,"bla");
            b.AddToCollection(be);
        }



        private void Add_Click(object sender, RoutedEventArgs e)
        {
            new AddWindow().Show();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            b.RemoveFromCollection(listview.SelectedIndex);
        }

        private void listview_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new UpdateWindow().Show();
        }
    }
}
