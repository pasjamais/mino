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
        internal TechModelsOfPrinter PrinterModel;
        internal TechPrinter Printer;
        
        public StatusBarUpdate StatusProperty;
        public Page_Printers(StatusBarUpdate status)
        {
            StatusProperty = status;
            StatusProperty.Message += Common.Status_Texts[0];
            InitializeComponent();
            CBOtherQuery.SelectedValuePath = "Id";
            CBOtherQuery.DisplayMemberPath = "Name";
            CBOtherQuery.ItemsSource = (from q in MainWindow.db_agent.Get_Queries()
                                        where Common.List_Queries_for_Printers.Contains(q.Id)
                                        select q);
            CBOtherQuery.SelectedItem = 0;
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
                if (reportNumber == Common.Number_of_Query_List_Printers_Mouvement)
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
        internal long GetIDbyRow()
        {
            long id = 0;
            DataRowView row = (DataRowView)DataGridReport.Items[DataGridReport.SelectedIndex];
            if (DataGridReport.Columns.Count > 0)
            {
                if (!(row.Row.ItemArray[0] == null || row.Row.ItemArray[0] == DBNull.Value))
                    id = int.Parse(row.Row.ItemArray[0].ToString());
            }
            return id;
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
            RefillGrid(Common.Number_of_Query_List_Printers_Mouvement);
        }

        #endregion

        #region Models
        
        private void ButtonShowModels_Click(object sender, RoutedEventArgs e)
        {
            RefillGrid(Common.Number_of_Query_List_of_Printer_Models);
        }

        private void Button_Del_Model_Click(object sender, RoutedEventArgs e)
        {
            if ((DataGridReport.SelectedIndex >= 0) && (reportNumber == Common.Number_of_Query_List_of_Printer_Models))
            {
                Button_Dia_Cha_Model.IsEnabled = Button_Dia_Del_Model.IsEnabled = false;
                long model_id = GetIDbyRow();
                TechModelsOfPrinter model = MainWindow.db_agent.GetModelOfPrinter(model_id);
                MainWindow.db_agent.Delete_Printer_Model(model);
                StatusProperty.Message += Common.Status_Texts[24]+ model.Name;
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
        private void Button_Dia_Cha_Model_Click(object sender, RoutedEventArgs e)
        {
            if ((DataGridReport.SelectedIndex >= 0) && (reportNumber == Common.Number_of_Query_List_of_Printer_Models))
            {

                long model_id = GetIDbyRow();
                PrinterModel = MainWindow.db_agent.GetModelOfPrinter(model_id);

                TextBoxChaModelName.Text = PrinterModel.Name;
                ComboBoxIsMFU.ItemsSource = Common.Printer_Models_Type;
                ComboBoxIsMFU.DisplayMemberPath = "Value";
                if (PrinterModel.IsMfu.HasValue)
                    ComboBoxIsMFU.SelectedIndex = PrinterModel.IsMfu.Value ? 1 : 0;
            }
        }

         private void Button_Cancel_Cha_Model_Click(object sender, RoutedEventArgs e)
        {
            PrinterModel = null;

        }

        private void Button_Cha_Name_Click(object sender, RoutedEventArgs e)
        {
            if (PrinterModel != null)
            {
                if (TextBoxChaModelName.Text != "")
                {
                    if (!MainWindow.db_agent.Get_Printer_Models().Exists(p => (p.Name == TextBoxChaModelName.Text)))
                    {
                        Button_Dia_Cha_Model.IsEnabled = Button_Dia_Del_Model.IsEnabled = false;
                        bool isModified = false;
                        if (PrinterModel.Name != TextBoxChaModelName.Text)
                        {
                            PrinterModel.Name = TextBoxChaModelName.Text;
                            isModified = true;
                        }
                        var new_isMFU = System.Convert.ToBoolean(ComboBoxIsMFU.SelectedValue);
                        if (PrinterModel.IsMfu.HasValue)
                        {
                            if (PrinterModel.IsMfu.Value != new_isMFU)
                            {
                                PrinterModel.IsMfu = new_isMFU;
                                isModified = true;
                            }
                        }
                        if (isModified)
                        {
                            MainWindow.db_agent.SaveChanges();
                            StatusProperty.Message += Common.Status_Texts[26] + PrinterModel.Name;
                            RefillGrid(Common.Number_of_Query_List_of_Printer_Models);
                        }
                    }
                    else StatusProperty.Message += Common.Status_Texts[19];
                }
                else StatusProperty.Message += Common.Status_Texts[27];
                PrinterModel = null;
            }
        }

        private void Button_Dia_Add_Model_Click(object sender, RoutedEventArgs e)
        {
            if (reportNumber == Common.Number_of_Query_List_of_Printer_Models)
            {
                TextBoxAddModelName.Text = "";
                ComboBoxIsMFU_Add.ItemsSource = Common.Printer_Models_Type;
                ComboBoxIsMFU_Add.DisplayMemberPath = "Value";
                ComboBoxIsMFU_Add.SelectedIndex = 0;
            }


        }

        private void Button_Add_Model_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxAddModelName.Text != "")
            {
                if (!MainWindow.db_agent.Get_Printer_Models().Exists(p => (p.Name == TextBoxAddModelName.Text)))
                {
                    TechModelsOfPrinter model = new TechModelsOfPrinter();
                    model.Name = TextBoxAddModelName.Text;
                    model.IsMfu = System.Convert.ToBoolean(ComboBoxIsMFU_Add.SelectedValue);
                    {
                        MainWindow.db_agent.Add_Printer_Model(model);
                        StatusProperty.Message += Common.Status_Texts[21] + model.Name;
                        RefillGrid(Common.Number_of_Query_List_of_Printer_Models);
                    }

                }
                else StatusProperty.Message += Common.Status_Texts[19];
            }
            else StatusProperty.Message += Common.Status_Texts[27];
            TextBoxAddModelName.Text = "";
        }
        #endregion

        #region Printers

     
        private void ButtonShowCartridgeModels_Click(object sender, RoutedEventArgs e)
        {
            RefillGrid(Common.Number_of_Query_Printers);
        }

        private void Button_Del_Printer_Click(object sender, RoutedEventArgs e)
        {
            if ((DataGridReport.SelectedIndex >= 0) && (reportNumber == Common.Number_of_Query_Printers))
            {
                Button_Dia_Cha_Printer.IsEnabled = Button_Dia_Del_Printer.IsEnabled = false;
                long model_id = GetIDbyRow();
                TechPrinter printer = MainWindow.db_agent.GetPrinter(model_id);
                MainWindow.db_agent.DeletePrinter(printer);
                StatusProperty.Message += Common.Status_Texts[24] + printer.Comment;
                RefillGrid(Common.Number_of_Query_Printers);
            }
        }

        private void Button_Del_Printer_Cancel_Click(object sender, RoutedEventArgs e)
        {
     
        }

        private void Button_Dia_Del_Printer_Click(object sender, RoutedEventArgs e)
        {
            if ((DataGridReport.SelectedIndex >= 0) && (reportNumber == Common.Number_of_Query_Printers))
            {
                DataRowView row = (DataRowView)DataGridReport.Items[DataGridReport.SelectedIndex];
                // если имени нет
                string name = "" ;
                if (!(row.Row.ItemArray[2] == null ||
                        row.Row.ItemArray[2] == DBNull.Value))
                     name = (string?)row.Row.ItemArray[2];
                TB_Confirmation_Del_Printer.Text = Common.Del_Confirmation + name + '?';
            }
        }

 private void Button_Dia_Cha_Printer_Click(object sender, RoutedEventArgs e)
        {
            if ((DataGridReport.SelectedIndex >= 0) && (reportNumber == Common.Number_of_Query_Printers))
            {
                long model_id = GetIDbyRow();
                Printer = MainWindow.db_agent.GetPrinter(model_id);
                TextBoxChaPrinterComment.Text = Printer.Comment;
                TextBoxChaPrinterNumber.Text = Printer.InventoryNumber;
                ComboBoxChaPrinterModel.ItemsSource = MainWindow.db_agent.Get_Printer_Models();
                ComboBoxChaPrinterModel.DisplayMemberPath = "Name";
                ComboBoxChaPrinterModel.SelectedValue = Printer.Model;
            }
        }

        private void Button_Cancel_Cha_Printer_Click(object sender, RoutedEventArgs e)
        {
            Printer = null;
        }

        private void Button_Cha_Printer_Click(object sender, RoutedEventArgs e)
        {
            if (Printer != null)
            {
                bool isModified = false;
                if (Printer.Model != (System.Int64)ComboBoxChaPrinterModel.SelectedValue)
                {
                    Printer.Model = (System.Int64)ComboBoxChaPrinterModel.SelectedValue;
                    isModified = true;
                }
                if (Printer.InventoryNumber != TextBoxChaPrinterNumber.Text)
                {
                    Printer.InventoryNumber = TextBoxChaPrinterNumber.Text;
                    isModified = true;
                }
                if (Printer.Comment != TextBoxChaPrinterComment.Text)
                {
                    Printer.Comment = TextBoxChaPrinterComment.Text;
                    isModified = true;
                }
                if (isModified)
                {
                    MainWindow.db_agent.SaveChanges();
                    StatusProperty.Message += Common.Status_Texts[26] + Printer.Comment;
                    RefillGrid(Common.Number_of_Query_Printers);
                }
                PrinterModel = null;
            }
        }
        #endregion

        #region additionalQueries
        private void CBOtherQuery_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ReportNumber = -1;
            if (Common.List_Queries_for_Printers_With_Parametre.Contains((int)(long)CBOtherQuery.SelectedValue))
            {
                CB_Parametre.DisplayMemberPath = "Comment";
                CB_Parametre.ItemsSource = MainWindow.db_agent.Get_Printers();
            }
            else 
                if (Common.List_Queries_for_PrinterModels_With_Parametre.Contains((int)(long)CBOtherQuery.SelectedValue))
                {
                    CB_Parametre.DisplayMemberPath = "Name";
                    CB_Parametre.ItemsSource = MainWindow.db_agent.Get_Printer_Models();
                }
            else
            {
                RefillGrid((int)(long)CBOtherQuery.SelectedValue);
                StatusProperty.Message += Common.Status_Texts[30] + MainWindow.db_agent.GetQueryName((int)(long)CBOtherQuery.SelectedValue);
            }
            CB_Parametre.SelectedValuePath = "Id";
            CBOtherQuery.SelectedItem = 0;
        }

        private void CB_Parametre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ReportNumber == -1)
            {
                if ( (int)(long)CBOtherQuery.SelectedValue == Common.Number_of_Query_Where_Are_Printers_of_Model)
                    SQLite.AddParams("@ModelId", CB_Parametre.SelectedValue);
                SQLite.AddParams("@PrinterId", CB_Parametre.SelectedValue);
                DataTable ds = new DataTable();
                SQLite.fill(MainWindow.db_agent.GetQueryText((int)(long)CBOtherQuery.SelectedValue), ds);
                DataGridReport.ItemsSource = ds.DefaultView;
                SQLite.ClearParams();
                StatusProperty.Message += Common.Status_Texts[30] + MainWindow.db_agent.GetQueryName((int)(long)CBOtherQuery.SelectedValue);
            }
        }

#endregion

    }
}
