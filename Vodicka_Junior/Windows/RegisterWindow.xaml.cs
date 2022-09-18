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

namespace Vodicka_Junior.Windows
{
    /// <summary>
    /// Interakční logika pro RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        DatabaseConnection conn = new DatabaseConnection();
        public RegisterWindow()
        {
            InitializeComponent();
            
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            try {
                if ((username.Text.ToString()!=null) && (password.Text.ToString()!=null)){
                    conn.AddingToLogin(username.Text.ToString(), password.Text.ToString());
                    MessageBox.Show("User has been added successfully");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Boxes cannot be empty");
                }
            
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
