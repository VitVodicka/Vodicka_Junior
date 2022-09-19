using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Vodicka_Junior
{
    /// <summary>
    /// Interakční logika pro UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {
        DatabaseConnection conn = new DatabaseConnection();
        public UpdateWindow()
        {
            InitializeComponent();

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conn.UpdateDateTime(date.SelectedDate.Value.ToShortDateString().ToString(), );
                MessageBox.Show("Date updated successfully");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
