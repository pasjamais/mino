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
    /// Interaction logic for MainWindow.xaml 
    /// </summary>
    public partial class MainWindow : Window
    {
        public static dbAgent db_agent = new dbAgent();
        public StatusBarUpdate StatusProperty { get; set; } = new StatusBarUpdate();

        public MainWindow()
        {
            InitializeComponent();
            StatusProperty.Message += Common.Status_Texts[2];
            dbAgent.Backup_DB();
            StatusProperty.Message += Common.Status_Texts[0];
        }

       

        void DataWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db_agent.Close();
        }
        private void ItemExit_Selected(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void PlayCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        public void PlayCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            StatusProperty.Message = "Play";
        }

        public void StopCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            StatusProperty.Message = "Stop";
        }

        #region Навигация
        private void ItemUsers_Selected(object sender, RoutedEventArgs e)
        {
            StatusProperty.Message += Common.Status_Texts[3];
            FrameMain.Navigate(new Page_Users(StatusProperty));
        }

        private void ItemPCs_Selected(object sender, RoutedEventArgs e)
        {
            StatusProperty.Message += Common.Status_Texts[6];
            FrameMain.Navigate(new Page_PCs());
        }

      
        private void ItemJournal_Selected(object sender, RoutedEventArgs e)
        {
            StatusProperty.Message += Common.Status_Texts[4];
            FrameMain.Navigate(new Page_Journal(StatusProperty));
        }

        private void ItemPrinters_Selected(object sender, RoutedEventArgs e)
        {
            StatusProperty.Message += Common.Status_Texts[8];
            FrameMain.Navigate(new Page_Printers());
        }

        private void ItemHardware_Selected(object sender, RoutedEventArgs e)
        {
            StatusProperty.Message += Common.Status_Texts[10];
            FrameMain.Navigate(new Page_Hardware());
        }

        private void ItemSoftware_Selected(object sender, RoutedEventArgs e)
        {
            StatusProperty.Message += Common.Status_Texts[10];
            FrameMain.Navigate(new Page_Software() );
        }

        private void ItemCabinets_Selected(object sender, RoutedEventArgs e)
        {
            StatusProperty.Message += Common.Status_Texts[7];
            FrameMain.Navigate(new Page_Cabinets(StatusProperty));
        }

        private void ItemAbout_Selected(object sender, RoutedEventArgs e)
        {
            StatusProperty.Message += Common.Status_Texts[12];
            FrameMain.Navigate(new Page_About());
        }

        private void ItemReports_Selected(object sender, RoutedEventArgs e)
        {
            StatusProperty.Message += Common.Status_Texts[9];
            FrameMain.Navigate(new Page_Reports());
        }
        private void ItemCartridges_Selected(object sender, RoutedEventArgs e)
        {
            StatusProperty.Message += Common.Status_Texts[5];
            FrameMain.Navigate(new Page_Cartridges(StatusProperty));
        }

        #endregion

        private void TextBoxOut_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBoxOut.ScrollToEnd();
        }
    }
}
