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
    /// Logique d'interaction pour Page_Users.xaml
    /// </summary>
    public partial class Page_Users : Page
    {
        private User user_temporary;
        public StatusBarUpdate StatusProperty;
        public Page_Users(StatusBarUpdate status)
        {
            StatusProperty = status;
            StatusProperty.Message += Common.Status_Texts[0];
            InitializeComponent();
            RowDefinitionTop.Height = new GridLength(Button_Dia_Save.Height + 30);
            RefillGrid();
        }


        #region Common
        private void RefillGrid()
        {
            DataTable ds = new DataTable();
            SQLite.fill(MainWindow.db_agent.GetQueryText(Common.Number_of_Query_Users_and_PCs), ds);
            DataGridUsers.ItemsSource = ds.DefaultView;
        }
        private void DataGridUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridUsers.SelectedIndex >= 0)
            {
                Button_Dia_Change.IsEnabled = Button_Dia_Del.IsEnabled = true;
            }
            else Button_Dia_Change.IsEnabled = Button_Dia_Del.IsEnabled = false;
        }
        internal long GetUserByRow()
        {
            // Получаем поля юзера из текущей строки
            DataRowView row = (DataRowView)DataGridUsers.Items[DataGridUsers.SelectedIndex];
            string name = (String)row.Row.ItemArray[0];
            string? comment = null;
            // если комментария нет
            if (!(row.Row.ItemArray[1] == null ||
                    row.Row.ItemArray[1] == DBNull.Value))
                comment = (string?)row.Row.ItemArray[1];
            // Получаем id юзера по имени и коммментарию
            long user_id = (from p in MainWindow.db_agent.Get_Users()  // Лямбда!
                            where p.Name == name && p.Comment == comment
                            select p).Take(1).First().Id;
            return user_id;
        }

        #endregion


        #region add
        private void ChB_PC_Status(object sender, RoutedEventArgs e)
        {
            ComboBoxPC.IsEnabled = ChB_PC.IsChecked.HasValue && ChB_PC.IsChecked.Value;
        }

       
        private void Button_Save_Record_Click(object sender, RoutedEventArgs e)
        {

            if (TextBoxSaveName.Text != "")
            {   // Без проверки на уникальность - Люди могут иметь одинаковое имя
                User user = new User();
                user.Name = TextBoxSaveName.Text;
                user.Comment = TextBoxSaveComment.Text;
                user.Cabinet = (System.Int64)ComboBoxCabinet.SelectedValue;
                MainWindow.db_agent.AddUser(user);
                StatusProperty.Message += Common.Status_Texts[21] + user.Name;
                // Добавляем юзеру ПК
                if (ChB_PC.IsChecked.HasValue && ChB_PC.IsChecked.Value) 
                {
                    Pc pc = MainWindow.db_agent.GetPc((System.Int64)ComboBoxPC.SelectedValue);
                    pc.User = user.Id;
                    MainWindow.db_agent.SaveChanges();
                    StatusProperty.Message += Common.Status_Texts[22];
                }
                RefillGrid();
            }
            else
                StatusProperty.Message += Common.Status_Texts[20];
        }

        private void Button_Dia_Save_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxCabinet.ItemsSource = MainWindow.db_agent.Get_Cabinets();
            ComboBoxPC.ItemsSource      = MainWindow.db_agent.GetPCs();
            ComboBoxCabinet.DisplayMemberPath = ComboBoxPC.DisplayMemberPath = "Name";
            ComboBoxCabinet.SelectedIndex = ComboBoxPC.SelectedIndex = 0;
            TextBoxSaveName.Text = TextBoxSaveComment.Text = "";
        }
        #endregion

             



        #region Del

        private void Button_Dia_Del_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridUsers.SelectedIndex >= 0) 
            {
                DataRowView row = (DataRowView)DataGridUsers.Items[DataGridUsers.SelectedIndex];
                String name = (String)row.Row.ItemArray[0];
                TB_Confirmation_Del_User.Text = Common.Del_Confirmation + name + '?';
            }
        }


        private void Button_Del_Record_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridUsers.SelectedIndex >= 0) 
            {
                Button_Dia_Del.IsEnabled = false;
                // Получаем поля юзера из текущей строки
                long user_id = GetUserByRow();
                // Есть ли у юзера компьютеры?
                if (MainWindow.db_agent.GetPCs().Exists(p => (p.User == user_id)))
                {
                    // Получаем список ПК
                    var pcs = (from p in MainWindow.db_agent.GetPCs()
                               where p.User == user_id
                               select p);
                    // Удаление ссылок на юзера из таблицы с ПК
                    foreach (Pc p in pcs)
                    {
                        p.User = null;
                        MainWindow.db_agent.SaveChanges();
                    }
                    StatusProperty.Message += Common.Status_Texts[23];
                }
                // Есть ли у юзера сервисные обращения?
                if (MainWindow.db_agent.Get_Journal().Exists(p => (p.Client == user_id)))
                {
                    // Получаем список обращений
                    var records = (from p in MainWindow.db_agent.Get_Journal()
                               where p.Client == user_id
                               select p);
                    // Удаление ссылок на юзера из сервисного журнала
                    foreach (ServiceJournal record in records)
                    {
                        record.Client = null;
                        MainWindow.db_agent.SaveChanges();
                    }
                    StatusProperty.Message += Common.Status_Texts[25];
                }
                // Получение юзера
                User user = MainWindow.db_agent.GetUser(user_id);
                // Удаление внешних ключей
                user.Cabinet = null;
                user.Credentials = null;
                MainWindow.db_agent.SaveChanges();
                // Удаление юзера
                MainWindow.db_agent.DeleteUser(user);
                StatusProperty.Message += Common.Status_Texts[24];
                RefillGrid();
            }
        }
        #endregion

        #region Change
        private void ChB_cha_PC_Status(object sender, RoutedEventArgs e)
        {
            ComboBoxChaPC.IsEnabled = ChB_cha_PC.IsChecked.HasValue && ChB_cha_PC.IsChecked.Value;
        }

        private void Button_Dia_Change_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridUsers.SelectedIndex >= 0)
            {   // подготовка контролов
                Button_Dia_Change.IsEnabled = false;
                ComboBoxChaCabinet.ItemsSource  = MainWindow.db_agent.Get_Cabinets();
                ComboBoxChaPC.ItemsSource       = MainWindow.db_agent.GetPCs();
                ComboBoxChaCabinet.DisplayMemberPath = ComboBoxChaPC.DisplayMemberPath = "Name";
                // Получаем поля юзера из текущей строки
                long user_id = GetUserByRow();
                // Получение юзера
                User user = MainWindow.db_agent.GetUser(user_id);
                // подготовка контролов
                TextBoxChaName.Text     = user.Name;
                TextBoxChaComment.Text  = user.Comment;
                ComboBoxChaCabinet.SelectedValue = user.Cabinet;
                // Есть ли у юзера компьютеры?
                if (  MainWindow.db_agent.GetPCs().Exists (p => (p.User == user_id) )) 
                {
                                        var pc_id = (from p in MainWindow.db_agent.GetPCs()
                                 where p.User == user_id
                                 select p).Take(1).First().Id;
                    ChB_cha_PC.IsChecked = true;
                    ComboBoxChaPC.SelectedValue = pc_id;
                }
                else
                {
                    ChB_cha_PC.IsChecked = false;
                    ComboBoxChaPC.SelectedIndex = 0;
                }
                // костыль - передача через общедоступный объект
                user_temporary = user;
            }
        }

        private void Button_Cha_Record_Click(object sender, RoutedEventArgs e)
        {
            void SetNewUserToPC()
            { // Присвоить новое значение выбранному ПК
                Pc pc = MainWindow.db_agent.GetPc((System.Int64)ComboBoxChaPC.SelectedValue);
                pc.User = user_temporary.Id;
                MainWindow.db_agent.SaveChanges();
                pc = null;
                StatusProperty.Message += Common.Status_Texts[22];
            }

            if (user_temporary != null)
            {
                if (TextBoxChaName.Text != "")
                {
                    Button_Dia_Change.IsEnabled = false;
                    // Изменено имя?
                    if (user_temporary.Name != TextBoxChaName.Text)
                        user_temporary.Name = TextBoxChaName.Text;
                    // Изменено примечание?
                    if (user_temporary.Comment != TextBoxChaComment.Text)
                        user_temporary.Comment = TextBoxChaComment.Text;
                    // Изменён кабинет?
                    if (user_temporary.Cabinet != (System.Int64)ComboBoxChaCabinet.SelectedValue)
                        user_temporary.Cabinet = (System.Int64)ComboBoxChaCabinet.SelectedValue;
                    MainWindow.db_agent.SaveChanges();
                    // Изменяем юзеру ПК если надо
                    // У него были ПК?
                    bool hadPC = MainWindow.db_agent.GetPCs().Exists(p => (p.User == user_temporary.Id));
                    // А теперь есть?
                    bool hasPC = ChB_cha_PC.IsChecked.HasValue && ChB_cha_PC.IsChecked.Value;
                    if (hadPC | hasPC) //делал таблицу истинности)))
                    {
                        if (hadPC)
                        { // был
                          // найти первый попавшийся старый
                            var pc_id_old = (from p in MainWindow.db_agent.GetPCs()
                                             where p.User == user_temporary.Id
                                             select p).Take(1).First().Id;
                            // и за нуЛЛить
                            Pc pc = MainWindow.db_agent.GetPc((System.Int64)pc_id_old);
                            pc.User = null;
                            MainWindow.db_agent.SaveChanges();
                            pc = null;

                            if (hasPC)
                            { //и есть
                              // Присвоить новое значение выбранному ПК
                                SetNewUserToPC();
                            }
                            else
                            { //и нет
                            }
                        }
                        else
                        {// не было и есть
                         // Присвоить новое значение выбранному ПК
                            SetNewUserToPC();
                        }
                    }
                    else //не было и нет
                    {
                        // ничего не делать
                    }
                    MainWindow.db_agent.SaveChanges();
                    RefillGrid();
                    StatusProperty.Message += Common.Status_Texts[26] + user_temporary.Name;
                    user_temporary = null;
                }
                else
                    StatusProperty.Message += Common.Status_Texts[20];
            }
        }
        
        private void Button_Cancel_Cha_User_Click(object sender, RoutedEventArgs e)
        {
            user_temporary = null;
            TextBoxChaName.Text = "";
            TextBoxChaComment.Text = "";
        }
        #endregion

    }
}
