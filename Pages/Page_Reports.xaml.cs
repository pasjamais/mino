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


        public Page_Reports()
        {
            InitializeComponent();
            ReloadComboBox();
            TextBoxQuery.Visibility = Visibility.Hidden;
            RowDefinitionTop.Height = new GridLength(90);
        }
        private void ReloadComboBox()
        {
            ComboBoxReports.ItemsSource = MainWindow.db_agent.Get_Queries();
            ComboBoxReports.DisplayMemberPath = "Name";
            ComboBoxReports.SelectedIndex = 0;
            ComboBoxReports.FontSize = DataGridReport.FontSize;
            ComboBoxReports.FontFamily = DataGridReport.FontFamily;
            ComboBoxReports.FontStretch = DataGridReport.FontStretch;
            ComboBoxReports.FontStyle = DataGridReport.FontStyle;
            ComboBoxReports.FontWeight = DataGridReport.FontWeight;

        }
        private void ComboBoxReports_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
        }

        private void ShowReport_Click(object sender, RoutedEventArgs e)
        {
            String query_text;
            if (CheckBoxReports.IsChecked == true)
            {
                query_text = TextBoxQuery.Text as String;
            }    
            else
            {
                query_text = ComboBoxReports.SelectedValue as String;
            }
            DataTable ds = new DataTable();
            SQLite.fill(query_text, ds);
            DataGridReport.ItemsSource = ds.DefaultView;
        }

       private void CheckBoxReports_Checked(object sender, RoutedEventArgs e)
        {
            TextBoxQuery.Visibility = Visibility.Visible;
            TextBoxQuery.IsEnabled = true;
            //     RowDefinitionTop.Height = new GridLength(0.5, GridUnitType.Star);
            RowDefinitionTop.Height = new GridLength(210);
        }

        private void CheckBoxReports_Unchecked(object sender, RoutedEventArgs e)
        {
            TextBoxQuery.IsEnabled = false;
            RowDefinitionTop.Height = new GridLength(90);
            TextBoxQuery.Visibility = Visibility.Hidden;
        }

      


        private async void Button_Dia_Save_Query_Click(object sender, RoutedEventArgs e)
        {
            var query = new Query();
            query.Text = TextBoxQuery.Text;
            query.Name = "Название запроса";
            var DialogResult = await MaterialDesignThemes.Wpf.DialogHost.Show(query);
            if (DialogResult != null)
                if (DialogResult as String == "True")
                {
                    MainWindow.db_agent.AddQuery(query);
                    CheckBoxReports.IsChecked = false;
                    ReloadComboBox();
                };
        }
    }
}
