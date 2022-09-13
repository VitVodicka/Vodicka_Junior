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
    /// Interakční logika pro AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        bool value=false;
        public AddWindow()
        {
            InitializeComponent();
        }

        public void SpaceChecker(string text)
        {
            if((text == null) || (text == ""))
            {
                MessageBox.Show("Space problem");
                value = true;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

            SpaceChecker(date.Text);
            SpaceChecker(type.Text);
            SpaceChecker(PropertyType.Text);
            SpaceChecker(investmentNeed.Text);
            SpaceChecker(investmentEstimate.Text);
            SpaceChecker(note.Text);
        }
    }
}
