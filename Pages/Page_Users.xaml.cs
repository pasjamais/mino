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
        public Page_Users()
        {
            InitializeComponent();
            RowDefinitionTop.Height = new GridLength(Button_Dia_Save.Height + 30);
            RefillGrid();
        }
        private void RefillGrid()
        {
            //DataGridUsers.ItemsSource = MainWindow.db_agent.Get_Users();
            DataTable ds = new DataTable();
            SQLite.fill(MainWindow.db_agent.GetQueryText(Common.Number_of_Query_Users_and_PCs), ds);
            DataGridUsers.ItemsSource = ds.DefaultView;
        }


        private void Button_Save_Record_Click(object sender, RoutedEventArgs e)
        {

            if (TextBoxSaveComment.Text != "")
            {   // Без проверки на уникальность - Люди могут иметь одинаковое имя
                User user = new User();
                user.Name = TextBoxSaveName.Text;
                user.Comment = TextBoxSaveComment.Text;
                user.Cabinet = (System.Int64)ComboBoxCabinet.SelectedValue;
                MainWindow.db_agent.AddUser(user);
                // Добавляем юзеру ПК
                if (ChB_PC.IsChecked.HasValue && ChB_PC.IsChecked.Value) 
                {
                    Pc pc = MainWindow.db_agent.GetPc((System.Int64)ComboBoxPC.SelectedValue);
                    pc.User = user.Id;
                    MainWindow.db_agent.SaveChanges();
                }
                TextBoxSaveName.Text = TextBoxSaveComment.Text = "";
                ComboBoxCabinet.SelectedIndex = ComboBoxPC.SelectedIndex = 0;
                RefillGrid();


            }

               
        }

        private void Button_Dia_Save_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxCabinet.ItemsSource = MainWindow.db_agent.Get_Cabinets();
            ComboBoxPC.ItemsSource      = MainWindow.db_agent.GetPCs();
            ComboBoxCabinet.DisplayMemberPath = ComboBoxPC.DisplayMemberPath = "Name";
            ComboBoxCabinet.SelectedIndex = ComboBoxPC.SelectedIndex = 0;
        }

        
        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            User user = DataGridUsers.SelectedItem as User;
            if (user != null) 
            {
                MainWindow.db_agent.DeleteUser(user);
                DataGridUsers.ItemsSource = MainWindow.db_agent.Get_Users();
            }
        }

        private void ChB_PC_Status(object sender, RoutedEventArgs e)
        {
                ComboBoxPC.IsEnabled = ChB_PC.IsChecked.HasValue && ChB_PC.IsChecked.Value;
        }

        private void ChB_cha_PC_Status(object sender, RoutedEventArgs e)
        {
            ComboBoxChaPC.IsEnabled = ChB_cha_PC.IsChecked.HasValue && ChB_cha_PC.IsChecked.Value;
        }

        private void Button_Dia_Del_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridUsers.SelectedIndex >= 0) 
            {
                DataRowView row = (DataRowView)DataGridUsers.Items[DataGridUsers.SelectedIndex];
                String name = (String)row.Row.ItemArray[0];
                TB_Confirmation_Del_User.Text = Common.Del_Confirmation + name + '?';
            }
        }

        private void DataGridUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridUsers.SelectedIndex >= 0) 
            {
                Button_Dia_Change.IsEnabled = Button_Dia_Del.IsEnabled = true;
            }
            else Button_Dia_Change.IsEnabled = Button_Dia_Del.IsEnabled = false;
        }

        private void Button_Del_Record_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridUsers.SelectedIndex >= 0) 
            {
                Button_Dia_Del.IsEnabled = false;
                DataRowView row = (DataRowView)DataGridUsers.Items[DataGridUsers.SelectedIndex];
                string name = (String)row.Row.ItemArray[0];
                string comment = (String)row.Row.ItemArray[1];
                // Удаление ссылок на юзера из таблицы с ПК
                long user_id = (from p in MainWindow.db_agent.Get_Users()
                                                    where p.Name == name && p.Comment == comment
                                                    select p).Take(1).First().Id;
                var pcs = (from p in MainWindow.db_agent.GetPCs()
                           where p.User == user_id
                           select p);
                foreach (Pc p in pcs)
                {
                    p.User = null;
                    MainWindow.db_agent.SaveChanges();
                }
                // Удаление юзера
                User user = MainWindow.db_agent.GetUser(user_id);
                MainWindow.db_agent.DeleteUser(user);
                RefillGrid();
            }
        }

        private void Button_Dia_Change_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridUsers.SelectedIndex >= 0)
            {
                Button_Dia_Change.IsEnabled = false;
                ComboBoxChaCabinet.ItemsSource = MainWindow.db_agent.Get_Cabinets();
                ComboBoxChaPC.ItemsSource = MainWindow.db_agent.GetPCs();
                ComboBoxChaCabinet.DisplayMemberPath = ComboBoxChaPC.DisplayMemberPath = "Name";

                DataRowView row = (DataRowView)DataGridUsers.Items[DataGridUsers.SelectedIndex];
                string name = (String)row.Row.ItemArray[0];
                string comment = (String)row.Row.ItemArray[1];
                long user_id = (from p in MainWindow.db_agent.Get_Users()
                                where p.Name == name && p.Comment == comment
                                select p).Take(1).First().Id;
                User user = MainWindow.db_agent.GetUser(user_id);

                TextBoxChaName.Text = user.Name;
                TextBoxChaComment.Text = user.Comment;
                ComboBoxChaCabinet.SelectedValue = user.Cabinet;
                
                if (  MainWindow.db_agent.GetPCs().Exists (p => (p.User == user_id) )) // Лямбда! Есть ли ссылка на Юзера?
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
                user_temporary = user;
            }
        }

        private void Button_Cha_Record_Click(object sender, RoutedEventArgs e)
        {
            if (user_temporary != null)
            {
                Button_Dia_Change.IsEnabled = false;
                if (user_temporary.Name != TextBoxChaName.Text)
                    user_temporary.Name = TextBoxChaName.Text;
                if (user_temporary.Comment != TextBoxChaComment.Text)
                    user_temporary.Comment = TextBoxChaComment.Text;
                if (user_temporary.Cabinet != (System.Int64)ComboBoxChaCabinet.SelectedValue)
                    user_temporary.Cabinet = (System.Int64)ComboBoxChaCabinet.SelectedValue;
                MainWindow.db_agent.SaveChanges();

                // Добавляем юзеру ПК
                if (MainWindow.db_agent.GetPCs().Exists(p => (p.User == user_temporary.Id)))
                {
                    var pc_id_old = (from p in MainWindow.db_agent.GetPCs()
                                     where p.User == user_temporary.Id
                                     select p).Take(1).First().Id;
                }


                    if (ChB_cha_PC.IsChecked.HasValue && ChB_cha_PC.IsChecked.Value)
                {
                    Pc pc = MainWindow.db_agent.GetPc((System.Int64)ComboBoxChaPC.SelectedValue);
                    pc.User = user_temporary.Id;
                    MainWindow.db_agent.SaveChanges();
                }
                MainWindow.db_agent.SaveChanges();
                RefillGrid();
                user_temporary = null;
                TextBoxChaName.Text = "";
                TextBoxChaComment.Text = "";
            }

        }

        private void Button_Cancel_Cha_User_Click(object sender, RoutedEventArgs e)
        {
            user_temporary = null;
            TextBoxChaName.Text = "";
            TextBoxChaComment.Text = "";
        }
    }
}
