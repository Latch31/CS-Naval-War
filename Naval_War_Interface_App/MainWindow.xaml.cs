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
            Board player2 = new Board();
            bool player = false; // false = player 1; true = player2
            String[,] boatList = new string[5, 2];

            boatInitialiseTab(boatList);

            textblock_pop dialog;

            //Player 1 Initialization
            do
            {
                dialog = new textblock_pop();
                if (dialog.ShowDialog() == true)
                {
                    player1.setPlayerName(dialog.ResponseText);
                }
            } while (dialog.DialogResult != true);

            //Player 2 Initialization
            do
            {
                dialog = new textblock_pop();
                if (dialog.ShowDialog() == true)
                {
                    player2.setPlayerName(dialog.ResponseText);
                }
            } while (dialog.DialogResult != true);

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

        static public void boatInitialiseTab(String[,] pBoarList)
        {
            pBoarList[0, 0] = "Plane Carrier";
            pBoarList[0, 1] = "5";

            pBoarList[1, 0] = "Croiseur";
            pBoarList[1, 1] = "4";

            pBoarList[2, 0] = "Contre Torpilleur";
            pBoarList[2, 1] = "3";

            pBoarList[3, 0] = "Contre Torpilleur";
            pBoarList[3, 1] = "3";

            pBoarList[4, 0] = "Torpilleur";
            pBoarList[4, 1] = "2";
        }

    }
}
