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
        public static readonly String DB_Path = "Data Source=mino.db";
        
        public MainWindow()
        {
            InitializeComponent();
            dbAgent.Backup_DB();
        }
        void DataWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db_agent.Close();
        }

        private void ItemUsers_Selected(object sender, RoutedEventArgs e)
        {
            FrameMain.Navigate(new Page_Users());
        }

        private void ItemPCs_Selected(object sender, RoutedEventArgs e)
        {
            FrameMain.Navigate(new Page_PCs());
        }

        private void ItemExit_Selected(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ItemJournal_Selected(object sender, RoutedEventArgs e)
        {
            FrameMain.Navigate(new Page_Journal());
        }

        private void ItemPrinters_Selected(object sender, RoutedEventArgs e)
        {
            FrameMain.Navigate(new Page_Printers());
        }

        private void ItemHardware_Selected(object sender, RoutedEventArgs e)
        {
            FrameMain.Navigate(new Page_Hardware());
        }

        private void ItemSoftware_Selected(object sender, RoutedEventArgs e)
        {
            FrameMain.Navigate(new Page_Software() );
        }

        private void ItemCabinets_Selected(object sender, RoutedEventArgs e)
        {
            FrameMain.Navigate(new Page_Cabinets());
        }

        private void ItemAbout_Selected(object sender, RoutedEventArgs e)
        {
            FrameMain.Navigate(new Page_About());
        }

        private void ItemReports_Selected(object sender, RoutedEventArgs e)
        {
            FrameMain.Navigate(new Page_Reports());
        }
        private void ItemCartridges_Selected(object sender, RoutedEventArgs e)
        {
            FrameMain.Navigate(new Page_Cartridges());
        }
    }
}
