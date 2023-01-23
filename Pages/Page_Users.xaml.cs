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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace mino
{
    /// <summary>
    /// Logique d'interaction pour Page_Users.xaml
    /// </summary>
    public partial class Page_Users : Page
    {
        public Page_Users()
        {
            InitializeComponent();
            DataGridUsers.ItemsSource = MainWindow.db_agent.Get_Users();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        
            private void DataGridUsers_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            User user = e.Row.Item as User;
            MessageBox.Show($"{user.Cabinet} {user.Name} {user.Comment}");
        }
    }
}
