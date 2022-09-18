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
using Vodicka_Junior.Structures;

namespace Vodicka_Junior.Windows
{
    /// <summary>
    /// Interakční logika pro LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        RegisterWindow reg = new RegisterWindow();
        DatabaseConnection conn = new DatabaseConnection();
        Collection b = new Collection();
        public LoginPage()
        {
            InitializeComponent();
            conn.DataBaseConnection();

        }

        

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            try {

                if (username.Text.ToString() != null && (password.Password.ToString() != null)) { 
                    if (conn.LoadingFromLogin(username.Text.ToString(), password.Password.ToString()) == true)
                        {
                            new MainWindow().Show();
                            MessageBox.Show("Successful login");
                            this.Close();
                        }
                    else
                        {
                            MessageBox.Show("Unsuccessful login");
                        }
                }
                else
                {
                    MessageBox.Show("Boxes must be filled");
                }
            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message);
            }


        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            reg.Show();
        }
    }
}
