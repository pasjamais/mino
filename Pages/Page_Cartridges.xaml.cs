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
using System.Data.SQLite;
namespace mino
{
    /// <summary>
    /// Logique d'interaction pour Page_Cartridges.xaml
    /// </summary>
    public partial class Page_Cartridges : Page
    {
        internal int reportNumber;
        internal Place place_temporary;
        internal TechPrinterCartridgeAlliance alliance_temporary;
        internal TechModelsOfCartridge cartridge_model_temporary;
        public StatusBarUpdate StatusProperty;
        public int ReportNumber //управляет отображением, соответствует номеру запроса
        {
            get 
            {
                return reportNumber;
            }
            set 
            {
                reportNumber = value;
                if (reportNumber == Common.Cartridges_Places)
                {
                    Button_Dia_Add_CarModel.IsEnabled = Button_Dia_Add_Alliance.IsEnabled = false;
                    Button_Dia_Add_Place.IsEnabled = true;
                }
                if (reportNumber == Common.Cartridge_Models_list)
                {
                    Button_Dia_Add_Place.IsEnabled = Button_Dia_Add_Alliance.IsEnabled = false;
                    Button_Dia_Add_CarModel.IsEnabled = true;
                }
                if (reportNumber == Common.Alliances)
                {
                    Button_Dia_Add_Place.IsEnabled = Button_Dia_Add_CarModel.IsEnabled = false;
                    Button_Dia_Add_Alliance.IsEnabled = true;
                }
            }
        }
        public Page_Cartridges(StatusBarUpdate status)
        {
            StatusProperty = status;
            StatusProperty.Message += Common.Status_Texts[0];
            InitializeComponent();
            RefillGridCartridges(Common.Number_of_Query_Cartridges_Rotation);
            CBselectPrinterModel.ItemsSource = MainWindow.db_agent.Get_Printer_Models();
            CBselectPrinterModel.DisplayMemberPath = "Name";
            CBselectUser.ItemsSource = MainWindow.db_agent.Get_Users();
            CBselectUser.DisplayMemberPath = "Name";
        }

        #region General
 private void TextBoxQuantity_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {// проверка ввода на число
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
        private void RefillGridCartridges(int Number_of_Query)
        {// заполнение грида
            ReportNumber = Number_of_Query;
            DataTable ds = new DataTable();
            SQLite.fill(MainWindow.db_agent.GetQueryText(Number_of_Query), ds);
            GridCartridges.ItemsSource = ds.DefaultView;
        }

        /// <summary>
        /// Настраивает доступность кнопок в завис. от отображаемых объектов
        /// </summary>
        private void GridCartridges_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Места хранения картриджей
            if ((GridCartridges.SelectedIndex >= 0) && (ReportNumber == Common.Cartridges_Places))
            {
                Button_Dia_Add_Place.IsEnabled = Button_Dia_Cha_Place.IsEnabled = Button_Dia_Del_Place.IsEnabled = true;
            }
            else Button_Dia_Add_Place.IsEnabled = Button_Dia_Cha_Place.IsEnabled = Button_Dia_Del_Place.IsEnabled = false;
            //Модели картриджей
            if ((GridCartridges.SelectedIndex >= 0) && (ReportNumber == Common.Cartridge_Models_list))
            {
                Button_Dia_Add_CarModel.IsEnabled = Button_Dia_Cha_CarModel.IsEnabled = Button_Dia_Del_CarModel.IsEnabled = true;
            }
            else Button_Dia_Add_CarModel.IsEnabled = Button_Dia_Cha_CarModel.IsEnabled = Button_Dia_Del_CarModel.IsEnabled = false;
            //Группы совместимости 
            if ((GridCartridges.SelectedIndex >= 0) && (ReportNumber == Common.Alliances))
            {
                Button_Dia_Add_Alliance.IsEnabled = Button_Dia_Cha_Alliance.IsEnabled = Button_Dia_Del_Alliance.IsEnabled = true;
            }
            else Button_Dia_Add_Alliance.IsEnabled = Button_Dia_Cha_Alliance.IsEnabled = Button_Dia_Del_Alliance.IsEnabled = false;
        }
        #endregion

        #region Mouvement
        private void ButtonShowMouvement_Click(object sender, RoutedEventArgs e)
        {
            RefillGridCartridges(Common.Number_of_Query_Cartridges_Rotation);
        }
        private void ComboBoxMouvementType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {// Для наглядности меняет "в" на "из" в зависимости от того, поступил или выбыл картридж
            TB_Place.Text = Common.TB_Place_Text[(int)ComboBoxMouvementType.SelectedValue];
        }
        private void Button_Dia_Save_Click(object sender, RoutedEventArgs e)
        {

            ComboBoxCartridgeModel.ItemsSource = MainWindow.db_agent.Get_CartridgeModels();
            TextBoxQuantity.Text = "1";
            ComboBoxMouvementType.ItemsSource = Common.mouvement_cartridge_type;
            ComboBoxMouvementType.DisplayMemberPath = "Key";
            ComboBoxCartridgePlace.ItemsSource = MainWindow.db_agent.Get_Places();
            ComboBoxCartridgePlace.DisplayMemberPath = ComboBoxCartridgeModel.DisplayMemberPath = "Name";
            ComboBoxCartridgePlace.SelectedIndex = 0;
            ComboBoxCartridgeModel.SelectedIndex = 0;
            ComboBoxMouvementType.SelectedIndex = 0;
        }
        private void Button_Save_Record_Click(object sender, RoutedEventArgs e)
        {
            TechCartridgesRotation CartridgeRotation = new TechCartridgesRotation();
            CartridgeRotation.ModelId = (System.Int64)ComboBoxCartridgeModel.SelectedValue;
            CartridgeRotation.Place = (System.Int64)ComboBoxCartridgePlace.SelectedValue;
            CartridgeRotation.Quantity = Convert.ToInt64(TextBoxQuantity.Text) * Convert.ToInt64(ComboBoxMouvementType.SelectedValue);
            CartridgeRotation.Comment = TextBoxComment.Text;
            CartridgeRotation.Date = DateTime.Now;
            MainWindow.db_agent.AddCartridgeRotation(CartridgeRotation);
            TextBoxQuantity.Text = "1";
            TextBoxComment.Text = "";
            RefillGridCartridges(Common.Number_of_Query_Cartridges_Rotation);
        }

        #endregion //Mouvement

        #region Assortiment
 private void ButtonShowCartridgeStatus_Click(object sender, RoutedEventArgs e)
        {
            RefillGridCartridges(Common.Number_of_Query_Cartridges_Assortiment);
        }

        #endregion // Assortiment

        #region Cartridges_for_Printer
        private void CBselectPrinterModel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ReportNumber = Common.Number_of_Query_Cartridges_for_Printer_Model;
            SQLite.AddParams("@PrinterId", CBselectPrinterModel.SelectedValue);
            DataTable ds = new DataTable();
            SQLite.fill(MainWindow.db_agent.GetQueryText(Common.Number_of_Query_Cartridges_for_Printer_Model), ds);
            GridCartridges.ItemsSource = ds.DefaultView;
            SQLite.ClearParams();

        }
        #endregion

        #region Cartridges_by_User
        private void CBselectUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ReportNumber = Common.Number_of_Query_Cartridges_by_User;
            SQLite.AddParams("@UserId", CBselectUser.SelectedValue);
            DataTable ds = new DataTable();
            SQLite.fill(MainWindow.db_agent.GetQueryText(Common.Number_of_Query_Cartridges_by_User), ds);
            GridCartridges.ItemsSource = ds.DefaultView;
            SQLite.ClearParams();

        }
        #endregion

        #region Cartridge_Models
        private void ButtonShowCartridgeModels_Click(object sender, RoutedEventArgs e)
        {
            RefillGridCartridges(Common.Cartridge_Models_list);
        }

        private void Button_Dia_Add_CarModel_Click(object sender, RoutedEventArgs e)
        {

        }

        async private void  Button_Add_CarModel_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxAddCarModelName.Text != "")
            {
                if (!MainWindow.db_agent.isCartridgeModelAlreadyExist(TextBoxAddCarModelName.Text))
                {
                    TechModelsOfCartridge carmodel = new TechModelsOfCartridge();
                    carmodel.Name = TextBoxAddCarModelName.Text;
                    MainWindow.db_agent.AddCartridgeModel(carmodel);
                    TextBoxAddCarModelName.Text = "";
                    RefillGridCartridges(Common.Cartridge_Models_list);
                }
                
            };
            
        }

        private void Button_Dia_Cha_CarModel_Click(object sender, RoutedEventArgs e)
        {
            if ((GridCartridges.SelectedIndex >= 0) && (ReportNumber == Common.Cartridge_Models_list))
            {
                DataRowView row = (DataRowView)GridCartridges.Items[GridCartridges.SelectedIndex];
                String name = (String)row.Row.ItemArray[0];
                long carModel_id = (from p in MainWindow.db_agent.Get_CartridgeModels()
                                    where p.Name == name
                                    select p).Take(1).First().Id;
                cartridge_model_temporary = MainWindow.db_agent.GetCartridgeModel(carModel_id);
                TextBoxChaCarModelName.Text = cartridge_model_temporary.Name;
            }
        }

        private void Button_Cancel_Cha_CarModel_Click(object sender, RoutedEventArgs e)
        {
            cartridge_model_temporary = null;
            TextBoxChaCarModelName.Text = "";
        }

        private void Button_Cha_CarModel_Click(object sender, RoutedEventArgs e)
        {
            if (cartridge_model_temporary != null)
            {
                if (cartridge_model_temporary.Name != TextBoxChaCarModelName.Text)
                {
                    if (!MainWindow.db_agent.isCartridgeModelAlreadyExist(TextBoxAddCarModelName.Text))
                    {
                        Button_Dia_Cha_CarModel.IsEnabled = false;
                        Button_Dia_Del_CarModel.IsEnabled = false;
                        cartridge_model_temporary.Name = TextBoxChaCarModelName.Text;
                        MainWindow.db_agent.SaveChanges();
                        RefillGridCartridges(Common.Cartridge_Models_list);
                        cartridge_model_temporary = null;
                        TextBoxChaCarModelName.Text = "";
                    }
                       
                }

            }
        }

        private void Button_Dia_Del_CarModel_Click(object sender, RoutedEventArgs e)
        {
            if ((GridCartridges.SelectedIndex >= 0) && (ReportNumber == Common.Cartridge_Models_list))
            {
                DataRowView row = (DataRowView)GridCartridges.Items[GridCartridges.SelectedIndex];
                String name = (String)row.Row.ItemArray[0];
                TB_Confirmation_Del_CarModel.Text = Common.Del_Confirmation + name + '?';
            }

        }

        private void Button_Del_CarModel_Click(object sender, RoutedEventArgs e)
        {
            if ((GridCartridges.SelectedIndex >= 0) && (ReportNumber == Common.Cartridge_Models_list))
            {
                Button_Dia_Cha_CarModel.IsEnabled = false;
                Button_Dia_Del_CarModel.IsEnabled = false;
                DataRowView row = (DataRowView)GridCartridges.Items[GridCartridges.SelectedIndex];
                String name = (String)row.Row.ItemArray[0];
                string query_text = "DELETE FROM tech_Models_of_Cartridge WHERE Name = @Name";
                SQLite.AddParams("@Name", name);
                DataTable ds = new DataTable();
                SQLite.fill(query_text, ds);
                GridCartridges.ItemsSource = ds.DefaultView; // Лишнее
                SQLite.ClearParams();
                RefillGridCartridges(Common.Cartridge_Models_list);
            }
        }


        #endregion

        #region Alliances

        private void ButtonShowAlliances_Click(object sender, RoutedEventArgs e)
        {
            RefillGridCartridges(Common.Alliances);

        }

        private void Button_Dia_Del_Alliance_Click(object sender, RoutedEventArgs e)
        {
            if ((GridCartridges.SelectedIndex >= 0) && (ReportNumber == Common.Alliances))
            {
                DataRowView row = (DataRowView)GridCartridges.Items[GridCartridges.SelectedIndex];
                string printerName = (String)row.Row.ItemArray[0];
                string cartridgeName = (String)row.Row.ItemArray[1];
                TB_Confirmation_Del_Alliance.Text = Common.Del_Confirmation +
                    "альянс принтер "+ printerName +" - картридж " + cartridgeName + '?';
            }
        }

        private void Button_Del_Alliance_Click(object sender, RoutedEventArgs e)
        {
            if ((GridCartridges.SelectedIndex >= 0) && (ReportNumber == Common.Alliances))
            {
                Button_Dia_Cha_Alliance.IsEnabled = false;
                Button_Dia_Del_Alliance.IsEnabled = false;
                DataRowView row = (DataRowView)GridCartridges.Items[GridCartridges.SelectedIndex];
                string printerName = (String)row.Row.ItemArray[0];
                string cartridgeName = (String)row.Row.ItemArray[1];
                string query_text = MainWindow.db_agent.GetQueryText(Common.Number_of_Query_Del_Alliance);
                SQLite.AddParams("@Printer", printerName);
                SQLite.AddParams("@Cartridge", cartridgeName);
                DataTable ds = new DataTable();
                SQLite.fill(query_text, ds);
                GridCartridges.ItemsSource = ds.DefaultView; // Лишнее
                SQLite.ClearParams();
                RefillGridCartridges(Common.Alliances);
            }
        }

        private void Button_Dia_Cha_Alliance_Click(object sender, RoutedEventArgs e)
        {
            
            if ((GridCartridges.SelectedIndex >= 0) && (ReportNumber == Common.Alliances))
            {
                ComboBoxChangeAlliancePrinterModel.ItemsSource = MainWindow.db_agent.Get_Printer_Models();
                ComboBoxChangeAllianceCartridgeModel.ItemsSource = MainWindow.db_agent.Get_CartridgeModels();
                ComboBoxChangeAllianceCartridgeModel.DisplayMemberPath = ComboBoxChangeAlliancePrinterModel.DisplayMemberPath = "Name";
               
                DataRowView row = (DataRowView)GridCartridges.Items[GridCartridges.SelectedIndex];
                string printerName = (String)row.Row.ItemArray[0];
                string cartridgeName = (String)row.Row.ItemArray[1];
                string query_text = MainWindow.db_agent.GetQueryText(Common.Number_of_Query_Change_Alliance);
                
                TechModelsOfCartridge cartridge = (from p in MainWindow.db_agent.Get_CartridgeModels()
                                                  where p.Name == cartridgeName
                                                  select p).Take(1).First();
                TechModelsOfPrinter printer = (from p in MainWindow.db_agent.Get_Printer_Models()
                                                  where p.Name == printerName
                                                  select p).Take(1).First();
                long alliance_id = (from p in MainWindow.db_agent.Get_Alliances()
                                    where p.CartridgeModel == cartridge.Id && p.PrinterModel == printer.Id
                                    select p).Take(1).First().Id;
                alliance_temporary = MainWindow.db_agent.GetAlliance(alliance_id);
                ComboBoxChangeAlliancePrinterModel.SelectedIndex = ComboBoxChangeAlliancePrinterModel.Items.IndexOf(printer);
                ComboBoxChangeAllianceCartridgeModel.SelectedIndex = ComboBoxChangeAllianceCartridgeModel.Items.IndexOf(cartridge);
            }
            
        }

        private void Button_Cancel_Cha_Alliance_Click(object sender, RoutedEventArgs e)
        {
            alliance_temporary = null;
        }

        private void Button_Cha_Alliance_Click(object sender, RoutedEventArgs e)
        {
            if (alliance_temporary != null)
            {
                if (alliance_temporary.CartridgeModel != (System.Int64)ComboBoxChangeAllianceCartridgeModel.SelectedValue 
                    ||
                    alliance_temporary.PrinterModel != (System.Int64)ComboBoxChangeAlliancePrinterModel.SelectedValue)
                {
                    if (!MainWindow.db_agent.isAllianceAlreadyExist(
                        (System.Int64)ComboBoxChangeAllianceCartridgeModel.SelectedValue,
                        (System.Int64)ComboBoxChangeAlliancePrinterModel.SelectedValue))
                    {
                        Button_Dia_Cha_Alliance.IsEnabled = false;
                        Button_Dia_Del_Alliance.IsEnabled = false;
                        alliance_temporary.CartridgeModel = (System.Int64)ComboBoxChangeAllianceCartridgeModel.SelectedValue;
                        alliance_temporary.PrinterModel = (System.Int64)ComboBoxChangeAlliancePrinterModel.SelectedValue;
                        MainWindow.db_agent.SaveChanges();
                        alliance_temporary = null;
                        RefillGridCartridges(Common.Alliances);
                    }


                    
                }
            }
        }
        private void Button_Dia_Add_Alliance_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxAddAlliancePrinterModel.ItemsSource = MainWindow.db_agent.Get_Printer_Models();
            ComboBoxAddAllianceCartridgeModel.ItemsSource = MainWindow.db_agent.Get_CartridgeModels();
            ComboBoxAddAllianceCartridgeModel.DisplayMemberPath = ComboBoxAddAlliancePrinterModel.DisplayMemberPath = "Name";
            ComboBoxAddAlliancePrinterModel.SelectedIndex = 0;
            ComboBoxAddAllianceCartridgeModel.SelectedIndex = 0;
        }

        private void Button_Add_Alliance_Click(object sender, RoutedEventArgs e)
        {
            if (!MainWindow.db_agent.isAllianceAlreadyExist(
                        (System.Int64)ComboBoxAddAllianceCartridgeModel.SelectedValue,
                        (System.Int64)ComboBoxAddAlliancePrinterModel.SelectedValue))
            {
                TechPrinterCartridgeAlliance alliance = new TechPrinterCartridgeAlliance();
                alliance.CartridgeModel = (System.Int64)ComboBoxAddAllianceCartridgeModel.SelectedValue;
                alliance.PrinterModel = (System.Int64)ComboBoxAddAlliancePrinterModel.SelectedValue;
                MainWindow.db_agent.AddAlliance(alliance);
                  }
            RefillGridCartridges(Common.Alliances); // Перезаполним грид таблицей совместимости принтер-картридж
        }
        #endregion

        #region Places
        private void ButtonShowPlaces_Click(object sender, RoutedEventArgs e)
        {
            RefillGridCartridges(Common.Cartridges_Places);
        }
        private void Button_Dia_Add_Place_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Add_Place_Click(object sender, RoutedEventArgs e)
        {
            
            if (TextBoxAddPlaceName.Text != "")
            {
                if (!MainWindow.db_agent.isPlaceAlreadyExist(TextBoxAddPlaceName.Text))
                {
                    Place place = new Place();
                    place.Name = TextBoxAddPlaceName.Text;
                    place.Comment = TextBoxAddPlaceComment.Text;
                    MainWindow.db_agent.AddPlace(place);
                    TextBoxAddPlaceName.Text = "";
                    TextBoxAddPlaceComment.Text = "";
                }
                
            };
            RefillGridCartridges(Common.Cartridges_Places);
        }
        private void Button_Dia_Cha_Place_Click(object sender, RoutedEventArgs e)
        {
            if ((GridCartridges.SelectedIndex >= 0) && (ReportNumber == Common.Cartridges_Places))
            {
                DataRowView row = (DataRowView)GridCartridges.Items[GridCartridges.SelectedIndex];
                String name = (String)row.Row.ItemArray[0];
                long place_id = (from p in MainWindow.db_agent.Get_Places()
                                 where p.Name == name
                                 select p).Take(1).First().Id;
                place_temporary = MainWindow.db_agent.GetPlace(place_id);
                TextBoxChaPlaceName.Text = place_temporary.Name;
                TextBoxChaPlaceComment.Text = place_temporary.Comment;
            }
        }
        private void Button_Cha_Place_Click(object sender, RoutedEventArgs e)
        {
            void WriteChanges()
            {
                Button_Dia_Cha_Place.IsEnabled = false;
                Button_Dia_Del_Place.IsEnabled = false;
                place_temporary.Name = TextBoxChaPlaceName.Text;
                place_temporary.Comment = TextBoxChaPlaceComment.Text;
                MainWindow.db_agent.SaveChanges();
                RefillGridCartridges(Common.Cartridges_Places);
                place_temporary = null;
                TextBoxAddPlaceName.Text = "";
                TextBoxAddPlaceComment.Text = "";
            };
            if (place_temporary != null)
            {
                if (place_temporary.Name != TextBoxChaPlaceName.Text)
                {
                    if (!MainWindow.db_agent.isPlaceAlreadyExist(TextBoxChaPlaceName.Text))
                    {
                        WriteChanges();
                    }
                }
                else if (place_temporary.Comment != TextBoxChaPlaceComment.Text)
                {
                    WriteChanges();
                }
            }
        }
        private void Button_Cancel_Cha_Place_Click(object sender, RoutedEventArgs e)
        {
            place_temporary = null;
            TextBoxAddPlaceName.Text = "";
            TextBoxAddPlaceComment.Text = "";
        }
        private void Button_Dia_Del_Place_Click(object sender, RoutedEventArgs e)
        {
            if ((GridCartridges.SelectedIndex >= 0) && (ReportNumber == Common.Cartridges_Places))
            {
                DataRowView row = (DataRowView)GridCartridges.Items[GridCartridges.SelectedIndex];
                String name = (String)row.Row.ItemArray[0];
                TB_Confirmation_Del_Place.Text = Common.Del_Confirmation + name + '?';
            }
        }
        private void Button_Del_Place_Click(object sender, RoutedEventArgs e)
        {
            if ((GridCartridges.SelectedIndex >= 0) && (ReportNumber == Common.Cartridges_Places))
            {
                Button_Dia_Cha_Place.IsEnabled = false;
                Button_Dia_Del_Place.IsEnabled = false;
                DataRowView row = (DataRowView)GridCartridges.Items[GridCartridges.SelectedIndex];
                String name = (String)row.Row.ItemArray[0];
                string query_text = "DELETE FROM Places WHERE Name = @Name";
                SQLite.AddParams("@Name", name);
                DataTable ds = new DataTable();
                SQLite.fill(query_text, ds);
                GridCartridges.ItemsSource = ds.DefaultView; // Лишнее
                SQLite.ClearParams();
                RefillGridCartridges(Common.Cartridges_Places);
            }
        }

        #endregion //Place

        private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyType == typeof(System.DateTime))
                (e.Column as DataGridTextColumn).Binding.StringFormat = Common.AlmostRussianStringFormat;
        }

    }
}

