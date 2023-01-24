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
    /// Logique d'interaction pour Page_About.xaml
    /// </summary>
    public partial class Page_About : Page
         
    {
        public StatusBarUpdate StatusProperty;
        public Page_About(StatusBarUpdate status)
    {
        StatusProperty = status;
        StatusProperty.Message += Common.Status_Texts[0];
        InitializeComponent();
        TextBox.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
        }

    
    }
}
