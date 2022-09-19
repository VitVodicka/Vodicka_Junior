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

namespace Vodicka_Junior
{
    /// <summary>
    /// Interakční logika pro AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        bool value=false;
        DatabaseConnection con = new DatabaseConnection();
        Collection collection = new Collection();//declaring classes
        public AddWindow()
        {
            InitializeComponent();
            DataContext = collection;
            con.ElementsReading(collection);//reads elemnts from database
        }

        public void SpaceChecker(string text)//checking for spaces
        {
            if((text == null) || (text == ""))
            {
                MessageBox.Show("Space problem");
                value = true;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

            

            SpaceChecker(note.Text);

            SpaceChecker(PropertyCondition.Text);//checking for spaces
            SpaceChecker(investmentNeed.Text);
            SpaceChecker(investmentEstimate.Text);


            bool PropertyConditionToInt = int.TryParse(PropertyCondition.Text, out int intPropertyCondition);//converting to int
            bool investementNeedToInt = int.TryParse(investmentNeed.Text, out int intInvestmentNeed);
            bool investmentEstimateToInt = int.TryParse(investmentEstimate.Text, out int intInvestmentEstimate);


            if ((PropertyConditionToInt == true) && (investementNeedToInt == true) && (investmentEstimateToInt == true))//if iit can be converted to int
            {
                try
                {
                    //adds to database
                    con.AddingToDatabase(date.SelectedDate.Value.ToShortDateString().ToString(), combo.SelectedIndex, intPropertyCondition, intInvestmentNeed, intInvestmentEstimate, note.Text.ToString());
                    MessageBox.Show("added successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Property type, investment need, investment estimate field must be a number not a text");
            }

        }
    }
}
