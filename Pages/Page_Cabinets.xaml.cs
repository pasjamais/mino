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
    /// Logique d'interaction pour Page_Cabinets.xaml
    /// </summary>
    public partial class Page_Cabinets : Page
    {
        public Page_Cabinets()
        {
            InitializeComponent();
            RowDefinitionTop.Height = new GridLength(Button_Dia_Save.Height+30);
                
            DataGridCabinets.ItemsSource = MainWindow.db_agent.Get_Cabinets();
        }

        private void Button_Dia_Save_Click(object sender, RoutedEventArgs e)
        {
           
            
        }

        private void Button_Save_Record_Click(object sender, RoutedEventArgs e)
        {
            Cabinet cab = new Cabinet();
            cab.Name = TextBoxSaveName.Text;
            cab.Comment = TextBoxSaveComment.Text;
            MainWindow.db_agent.AddCabinet(cab);
            TextBoxSaveName.Text = TextBoxSaveComment.Text = "";
            DataGridCabinets.ItemsSource = MainWindow.db_agent.Get_Cabinets();
        }
    }
}
