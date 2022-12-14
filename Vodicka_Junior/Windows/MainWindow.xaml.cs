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
        Collection b = new Collection();
        DatabaseConnection con = new DatabaseConnection();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = b;
            
            con.ReadingFromDatabase(b);//reads data from database BuildingState
            con.SverenyBudovyLoading(b, 60680318);//loads data from SeverenyBudovy view









        }



        private void Add_Click(object sender, RoutedEventArgs e)
        {
            new AddWindow().Show();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (listview.SelectedIndex > -1)
            {
    
            con.DeleteFromDatabase(b, listview.SelectedIndex);//if user selected something than it deletes from database
            }

        }
    }
}
