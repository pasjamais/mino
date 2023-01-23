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
    /// Logique d'interaction pour Page_Journal.xaml
    /// </summary>
    public partial class Page_Journal : Page
    {
        public Page_Journal()
        {
            InitializeComponent();
            DataGridJournal.ItemsSource = MainWindow.db_agent.Get_Journal(); 
        }
    }
}
