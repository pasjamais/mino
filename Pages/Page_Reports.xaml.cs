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
    /// Logique d'interaction pour Page_Reports.xaml
    /// </summary>
    public partial class Page_Reports : Page
    {
        public StatusBarUpdate StatusProperty;
        internal int reportNumber;
        public Page_Reports(StatusBarUpdate status)
        {
            StatusProperty = status;
            StatusProperty.Message += Common.Status_Texts[0];
            InitializeComponent();
            CBOtherQuery.SelectedValuePath = "Id";
            CBOtherQuery.DisplayMemberPath = "Name";
            CBOtherQuery.ItemsSource = (from q in MainWindow.db_agent.Get_Queries()
                                        where Common.List_Different_Reports.Contains(q.Id)
                                        select q);
            CBOtherQuery.SelectedItem = 0;
        }

        private void CBOtherQuery_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefillGrid((int)(long)CBOtherQuery.SelectedValue);
        }

        private void RefillGrid(int Number_of_Query)
        {// заполнение грида
            StatusProperty.Message += Common.Status_Texts[30] + MainWindow.db_agent.GetQueryName(Number_of_Query);
            reportNumber = Number_of_Query;
            DataTable ds = new DataTable();
            SQLite.fill(MainWindow.db_agent.GetQueryText(Number_of_Query), ds);
            DataGridReport.ItemsSource = ds.DefaultView;
        }
    }
}
