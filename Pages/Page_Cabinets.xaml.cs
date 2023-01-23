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
    /// Logique d'interaction pour Page_Cabinets.xaml
    /// </summary>
    public partial class Page_Cabinets : Page
    {
        private Cabinet cab_temporary;
        public StatusBarUpdate StatusProperty;
        public Page_Cabinets(StatusBarUpdate status)
        {
            StatusProperty = status;
            StatusProperty.Message += Common.Status_Texts[0];
            InitializeComponent();
            RowDefinitionTop.Height = new GridLength(Button_Dia_Save.Height+30);
            RefillGrid();
        }
        private void RefillGrid()
        {
            DataGridCabinets.ItemsSource = MainWindow.db_agent.Get_Cabinets();
        }

        private void Button_Dia_Save_Click(object sender, RoutedEventArgs e)
        {
            TextBoxSaveName.Text = TextBoxSaveComment.Text = "";
        }

        private void Button_Save_Record_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxSaveName.Text != "")
            {
                Cabinet cab = new Cabinet();
                cab.Name = TextBoxSaveName.Text;
                cab.Comment = TextBoxSaveComment.Text;
                MainWindow.db_agent.AddCabinet(cab);
                StatusProperty.Message += Common.Status_Texts[21] + cab.Name;
                RefillGrid();
            }
            else
                StatusProperty.Message += Common.Status_Texts[27];
        }

        private void Button_Cha_Record_Click(object sender, RoutedEventArgs e)
        {
            bool isEntityModified = false;
            if (cab_temporary != null)
            {
                if (TextBoxChangeName.Text != "")
                {
                    // Изменено имя?
                    if (cab_temporary.Name != TextBoxChangeName.Text)
                    {
                        isEntityModified = true;
                        cab_temporary.Name = TextBoxChangeName.Text;
                    }
                    // Изменено примечание?
                    if (cab_temporary.Comment != TextBoxChangeComment.Text)
                    {
                        isEntityModified = true;
                        cab_temporary.Comment = TextBoxChangeComment.Text;
                    }
                    // Надо сохранять изменения?
                    if (isEntityModified)
                    {
                        Button_Dia_Change_Cabinet.IsEnabled = Button_Dia_Del.IsEnabled = false;
                        MainWindow.db_agent.SaveChanges();
                        StatusProperty.Message += Common.Status_Texts[26] + cab_temporary.Name;
                        cab_temporary = null;
                        RefillGrid();
                    }
                }
                else
                    StatusProperty.Message += Common.Status_Texts[27];
            }
        }

        private void Button_Cancel_Cha_Click(object sender, RoutedEventArgs e)
        {
            cab_temporary = null;
        }

        
        private void Button_Dia_Change_Cabinet_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridCabinets.SelectedIndex >= 0)
            {
                // Получение кабинета
                cab_temporary = (Cabinet)DataGridCabinets.SelectedValue;
                //// подготовка контролов
                TextBoxChangeName.Text = cab_temporary.Name;
                TextBoxChangeComment.Text = cab_temporary.Comment;
            }
               
        }

        private void DataGridCabinets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                if (DataGridCabinets.SelectedIndex >= 0)
                {
                Button_Dia_Change_Cabinet.IsEnabled = Button_Dia_Del.IsEnabled = true;
                }
                else Button_Dia_Change_Cabinet.IsEnabled = Button_Dia_Del.IsEnabled = false;
        }

        private void Button_Dia_Del_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridCabinets.SelectedIndex >= 0)
            {
                // Получение кабинета
                cab_temporary = (Cabinet)DataGridCabinets.SelectedValue;
                TB_Confirmation_Del.Text = Common.Del_Confirmation + cab_temporary.Name + '?';
            }
        }

        private void Button_Cancel_Del_Click(object sender, RoutedEventArgs e)
        {
            cab_temporary = null;
        }

        private void Button_Del_Record_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridCabinets.SelectedIndex >= 0 && cab_temporary != null)
            {
                Button_Dia_Change_Cabinet.IsEnabled = Button_Dia_Del.IsEnabled = false;
                // Есть ли в кабинете пользователи?
                if (MainWindow.db_agent.Get_Users().Exists(p => (p.Cabinet == cab_temporary.Id)))
                {
                    // Получаем список пользователей
                    var users = (from p in MainWindow.db_agent.Get_Users()
                                   where p.Cabinet == cab_temporary.Id
                                    select p);
                    // Удаление ссылок на кабинет
                    foreach (User user in users)
                    {
                        user.Cabinet = null;
                        MainWindow.db_agent.SaveChanges();
                        StatusProperty.Message += Common.Status_Texts[28] + user.Name;
                    }
                }
                MainWindow.db_agent.DeleteCabinet(cab_temporary);
                StatusProperty.Message += Common.Status_Texts[29] + cab_temporary.Name;
                cab_temporary = null;
                RefillGrid();
            }
               
        }
    }
}
