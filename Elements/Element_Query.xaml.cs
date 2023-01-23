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
using System.Windows.Shapes;

namespace mino
{
    /// <summary>
    /// Logique d'interaction pour Element_Query.xaml
    /// </summary>
    public partial class Element_Query : Window
    {
        public string QueryText
        {
            get { return TextBoxQuery.Text; }
        }

        public string QueryName
        {
            get { return TextBoxName.Text; }
        }
        public Element_Query()
        {
            InitializeComponent();
        }

        private void Button_OK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

    }
    

}
