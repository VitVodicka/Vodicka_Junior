using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Vodicka_Junior
{
    /// <summary>
    /// Interakční logika pro AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        bool value=false;
        DatabaseConnection con = new DatabaseConnection();
        Collection collection = new Collection();

        public AddWindow()
        {
            InitializeComponent();
            DataContext = collection;
            con.ElementsReading(collection);
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

            //datetime maybe changing

            SpaceChecker(note.Text);

            SpaceChecker(PropertyType.Text);
            SpaceChecker(investmentNeed.Text);
            SpaceChecker(investmentEstimate.Text);


            bool PropertyTypeToInt = int.TryParse(PropertyType.Text, out int intPropertyType);
            bool investementNeedToInt = int.TryParse(investmentNeed.Text, out int intInvestmentNeed);
            bool investmentEstimateToInt = int.TryParse(investmentEstimate.Text, out int intInvestmentEstimate);

            
            if ((PropertyTypeToInt == true) && (investementNeedToInt == true)&&(investmentEstimateToInt==true))
            {
                con.AddingToDatabase(date.SelectedDate.Value.ToShortDateString().ToString(),intPropertyType,combo.SelectedIndex, );
            }
            else
            {
                MessageBox.Show("Property type, investment need, investment estimate field must be a number not a text");
            }
        }
    }
}
