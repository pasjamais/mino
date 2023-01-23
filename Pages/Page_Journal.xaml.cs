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
    /// Logique d'interaction pour Page_Journal.xaml
    /// </summary>
    public partial class Page_Journal : Page
    {
        public StatusBarUpdate StatusProperty;
        public Page_Journal(StatusBarUpdate status)
        {
            StatusProperty = status;
            StatusProperty.Message += Common.Status_Texts[0];
            InitializeComponent();
            RowDefinitionTop.Height = new GridLength(Button_Dia_Save.Height + 30);
            RefillDataGridJournal();
            

        }

        private void RefillDataGridJournal()
        {   // заполнение грида
            DataTable ds = new DataTable();
            SQLite.fill(MainWindow.db_agent.GetQueryText(Common.Number_of_Query_Journal), ds);
            DataGridJournal.ItemsSource = ds.DefaultView;
        }

        private void Button_Dia_Save_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxManipulation.ItemsSource = MainWindow.db_agent.Get_Manipulations();
            ComboBoxManipulation.DisplayMemberPath = "Name";
            ComboBoxUser.ItemsSource = MainWindow.db_agent.Get_Users();
            ComboBoxUser.DisplayMemberPath = "Name";
            ComboBoxManipulation.SelectedIndex = ComboBoxUser.SelectedIndex = 0;
        }

        private void Button_Save_Record_Click(object sender, RoutedEventArgs e)
        {
            ServiceJournal Record = new ServiceJournal();
            Record.Client = (System.Int64)ComboBoxUser.SelectedValue;
            Record.Manipulation = (System.Int64)ComboBoxManipulation.SelectedValue;
            Record.Comment = TextBoxSaveComment.Text;
            DateTime  date = DateTime.Now;
            Record.Date = date;
            MainWindow.db_agent.AddJournalRecord(Record);
            ComboBoxUser.SelectedIndex = ComboBoxManipulation.SelectedIndex = 0;
            RefillDataGridJournal();
        }
        private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyType == typeof(System.DateTime))
                (e.Column as DataGridTextColumn).Binding.StringFormat = Common.AlmostRussianStringFormat;
        }
    }
}
