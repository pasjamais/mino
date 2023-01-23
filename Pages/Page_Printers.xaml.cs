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
using SQLitePCL;

namespace mino
{
    /// <summary>
    /// Logique d'interaction pour Page_Printers.xaml
    /// </summary>
    public partial class Page_Printers : Page
    {
        internal int reportNumber;
        public StatusBarUpdate StatusProperty;
        public Page_Printers(StatusBarUpdate status)
        {
            StatusProperty = status;
            StatusProperty.Message += Common.Status_Texts[0];
            InitializeComponent();
        }

        #region Common
        public int ReportNumber //управляет отображением, соответствует номеру запроса
        {
            get
            {
                return reportNumber;
            }
            set
            {
                reportNumber = value;
                if (reportNumber == Common.Number_of_Query_Where_Are_Printers_Now)
                {
                    Button_Dia_Cha_Model.IsEnabled = Button_Dia_Add_Model.IsEnabled =
                    Button_Dia_Del_Model.IsEnabled = false;
                    Button_Dia_Add_Printer.IsEnabled = Button_Dia_Cha_Printer.IsEnabled =
                    Button_Dia_Del_Printer.IsEnabled = false;

                    Button_Dia_Add_Mouvement.IsEnabled = true;
                }
                if (reportNumber == Common.Number_of_Query_List_of_Printer_Models)
                {
                    Button_Dia_Add_Printer.IsEnabled = Button_Dia_Cha_Printer.IsEnabled =
                    Button_Dia_Del_Printer.IsEnabled = false;
                    Button_Dia_Add_Mouvement.IsEnabled = false;
                    Button_Dia_Cha_Model.IsEnabled = Button_Dia_Del_Model.IsEnabled = false;
                    Button_Dia_Add_Model.IsEnabled = true;
                }
                if (reportNumber == Common.Number_of_Query_Printers)
                {
                    Button_Dia_Cha_Model.IsEnabled = Button_Dia_Add_Model.IsEnabled =
                    Button_Dia_Del_Model.IsEnabled = false;
                    Button_Dia_Add_Mouvement.IsEnabled = false;
                    Button_Dia_Cha_Printer.IsEnabled = Button_Dia_Del_Printer.IsEnabled = false;
                    Button_Dia_Add_Printer.IsEnabled = true;
                }
            }
        }


        private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyType == typeof(System.DateTime))
                (e.Column as DataGridTextColumn).Binding.StringFormat = Common.AlmostRussianStringFormat;
        }
        private void RefillGrid(int Number_of_Query)
        {// заполнение грида
            StatusProperty.Message += Common.Status_Texts[30] + MainWindow.db_agent.GetQueryName(Number_of_Query);
            ReportNumber = Number_of_Query;
            DataTable ds = new DataTable();
            SQLite.fill(MainWindow.db_agent.GetQueryText(Number_of_Query), ds);
            DataGridReport.ItemsSource = ds.DefaultView;
        }

        /// <summary>
        /// Настраивает доступность кнопок в завис. от отображаемых объектов
        /// </summary>
        private void DataGridReport_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridReport.SelectedIndex >= 0)
            {
                if (ReportNumber == Common.Number_of_Query_Where_Are_Printers_Now)
                {
                }
                if (ReportNumber == Common.Number_of_Query_List_of_Printer_Models)
                {
                    Button_Dia_Cha_Model.IsEnabled = Button_Dia_Del_Model.IsEnabled = true;
                }
                if (ReportNumber == Common.Number_of_Query_Printers) 
                {
                    Button_Dia_Cha_Printer.IsEnabled = Button_Dia_Del_Printer.IsEnabled = true;
                }
            }
        }

#endregion
        #region Mouvement
        private void ButtonShowMouvement_Click(object sender, RoutedEventArgs e)
        {

            InitializeComponent();
            RefillGrid(Common.Number_of_Query_Where_Are_Printers_Now);
        }

        #endregion




        #region Models
        internal long GetModelByRow()
        {
            long id = 0;
            DataRowView row = (DataRowView)DataGridReport.Items[DataGridReport.SelectedIndex];
            if (DataGridReport.Columns.Count >0)
            {
                if (!(row.Row.ItemArray[0] == null || row.Row.ItemArray[0] == DBNull.Value))
                id =  int.Parse(row.Row.ItemArray[0].ToString());
                       
            }
            return id;
        }
        private void ButtonShowModels_Click(object sender, RoutedEventArgs e)
        {
            RefillGrid(Common.Number_of_Query_List_of_Printer_Models);
        }

        private void Button_Del_Model_Click(object sender, RoutedEventArgs e)
        {
            if ((DataGridReport.SelectedIndex >= 0) && (reportNumber == Common.Number_of_Query_List_of_Printer_Models))
            {
                Button_Dia_Cha_Model.IsEnabled = Button_Dia_Del_Model.IsEnabled = false;
               
                long model_id = GetModelByRow();
                //// Есть ли у юзера компьютеры?
                //if (MainWindow.db_agent.GetPCs().Exists(p => (p.User == user_id)))
                //{
                //    // Получаем список ПК
                //    var pcs = (from p in MainWindow.db_agent.GetPCs()
                //               where p.User == user_id
                //               select p);
                //    // Удаление ссылок на юзера из таблицы с ПК
                //    foreach (Pc p in pcs)
                //    {
                //        p.User = null;
                //        MainWindow.db_agent.SaveChanges();
                //    }
                //    StatusProperty.Message += Common.Status_Texts[23];
                //}
                //// Есть ли у юзера сервисные обращения?
                //if (MainWindow.db_agent.Get_Journal().Exists(p => (p.Client == user_id)))
                //{
                //    // Получаем список обращений
                //    var records = (from p in MainWindow.db_agent.Get_Journal()
                //                   where p.Client == user_id
                //                   select p);
                //    // Удаление ссылок на юзера из сервисного журнала
                //    foreach (ServiceJournal record in records)
                //    {
                //        record.Client = null;
                //        MainWindow.db_agent.SaveChanges();
                //    }
                //    StatusProperty.Message += Common.Status_Texts[25];
                //}
                //// Получение юзера
                TechModelsOfPrinter model = MainWindow.db_agent.GetModelOfPrinter(model_id);
                MainWindow.db_agent.Delete_Printer_Model(model);
                StatusProperty.Message += Common.Status_Texts[24];
                RefillGrid(Common.Number_of_Query_List_of_Printer_Models);
            }

        }

        private void Button_Dia_Del_Model_Click(object sender, RoutedEventArgs e)
        {
            if ((DataGridReport.SelectedIndex >= 0) && (reportNumber == Common.Number_of_Query_List_of_Printer_Models))
            {
                DataRowView row = (DataRowView)DataGridReport.Items[DataGridReport.SelectedIndex];
                String name = (String)row.Row.ItemArray[1];
                TB_Confirmation_Del_Model.Text = Common.Del_Confirmation + name + '?';
            }
        }

        #endregion

        #region Printers
        private void ButtonShowCartridgeModels_Click(object sender, RoutedEventArgs e)
        {
            RefillGrid(Common.Number_of_Query_Printers);
        }


        #endregion


   
    }
}
