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

namespace Naval_War_Interface_App
{
    /// <summary>
    /// Logique d'interaction pour textblock_pop.xaml
    /// </summary>
    public partial class textblock_pop : Window
    {
        public textblock_pop()
        {
            InitializeComponent();
        }
        public string ResponseText
        {
            get { return ReponseTextBox.Text; }
            set { ReponseTextBox.Text = value; }
        }

        private void Confirm_ButtonClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void repo(object sender, ContextMenuEventArgs e)
        {

        }

      
    }
}
