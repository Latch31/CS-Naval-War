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
    /// Logique d'interaction pour Card_choice.xaml
    /// </summary>
    public partial class Card_choice : Window
    {
    static public Char direc;
        public Card_choice()
        {
            InitializeComponent();

            public Char dChoice
            {
                get { return direc; }
            }
        }

        private void Card_Click(object sender, RoutedEventArgs e)
        {
            Button bDirection = (Button)sender;
            direc = bDirection.Name[2];
        }
    }
}
