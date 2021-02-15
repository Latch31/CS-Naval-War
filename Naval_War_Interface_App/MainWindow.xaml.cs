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
using CS_Naval_War;

namespace Naval_War_Interface_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool placement;
        public MainWindow()
        {
            InitializeComponent();
            placement = true;
            Board player1 = new Board();

        }

        private void buttonPress(object sender, RoutedEventArgs e)
        {
            Button test = (Button)sender;
            String bName = test.Name;

            int x = bName[2] - 48;
            int y = bName[3] - 48;

            // Placement situation 
            if ( placement )
            {

            }
            // Shoot situation
            else
            
            {

            }
        }
    }
}
