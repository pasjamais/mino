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
    /// Logique d'interaction pour Page_PCs.xaml
    /// </summary>
    public partial class Page_PCs : Page
    {
        public StatusBarUpdate StatusProperty;
        public Page_PCs(StatusBarUpdate status)
        {
            StatusProperty = status;
            StatusProperty.Message += Common.Status_Texts[0];
            InitializeComponent();
            RefillGridCartridges(Common.Number_of_Query_PCs);
        }
        private void RefillGridCartridges(int Number_of_Query)
        {// заполнение грида
            DataTable ds = new DataTable();
            SQLite.fill(MainWindow.db_agent.GetQueryText(Number_of_Query), ds);
            DataGridReport.ItemsSource = ds.DefaultView;
        }
        private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyType == typeof(System.DateTime))
                (e.Column as DataGridTextColumn).Binding.StringFormat = Common.AlmostRussianStringFormat;
        }
    }
}
