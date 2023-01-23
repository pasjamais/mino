using System;
using System.Collections.Generic;
using System.Data;
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

namespace mino
{
    /// <summary>
    /// Logique d'interaction pour Page_Cartridges.xaml
    /// </summary>
    public partial class Page_Cartridges : Page
    {
        public Page_Cartridges()
        {
            InitializeComponent();
        }

        private void ShowReport_Click(object sender, RoutedEventArgs e)
        {
            String query_text = "";
           
            DataTable ds = new DataTable();
            SQLite.fill(query_text, ds);
            GridCartridges.ItemsSource = ds.DefaultView;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            var cartridgeRotation = new TechCartridgesRotation();
 
            var DialogResult = await MaterialDesignThemes.Wpf.DialogHost.Show(cartridgeRotation);
            if (DialogResult != null)
                if (DialogResult as String == "True")
                {
                  //  MainWindow.db_agent.AddCartridgeRotation(cartridgeRotation);

                };
        }
    }
}
