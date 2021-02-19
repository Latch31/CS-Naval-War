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
using System.Collections;

namespace Naval_War_Interface_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public static bool placement = true;
        public static bool player = false; // false = player 1; true = player2
        public static Stack boatP1 = new Stack();
        public static Stack boatP2 = new Stack();
        public MainWindow()
        {
            InitializeComponent();
            Board player1 = new Board();
            Board player2 = new Board();
            String[,] boatList = new string[5, 2];

            initStack(boatP1);
            initStack(boatP2);
            boatInitialiseTab(boatList);

            TextBlock_Popup name_choice;

            //Player 1 Initialization
            do
            {
                name_choice = new TextBlock_Popup();
                if (name_choice.ShowDialog() == true)
                {
                    player1.setPlayerName(name_choice.ResponseText);
                }
            } while (name_choice.DialogResult != true);

            //Player 2 Initialization
            do
            {
                name_choice = new TextBlock_Popup();
                if (name_choice.ShowDialog() == true)
                {
                    player2.setPlayerName(name_choice.ResponseText);
                }
            } while (name_choice.DialogResult != true);

        }

        private void buttonPress(object sender, RoutedEventArgs e)
        {
            Button bPress = (Button)sender;
            String bName = bPress.Name;
            Char direction;

            int x = bName[2] - 48;
            int y = bName[3] - 48;

            // Placement situation 
            if ( placement )
            {
                if ( !player )
                {
                    String boatName = (String)boatP1.Pop();
                    Char size = (Char)boatP1.Pop();
                    // fenetre avec cardinalite
                    Card_choice direc_pop = new Card_choice();
                    if (direc_pop.ShowDialog() == true)
                    {
                        direction = (direc_pop.dChoice);
                    }
                }
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

        static public void initStack( Stack myStack )
        {
            myStack.Push("2");
            myStack.Push("Torpilleur");
            myStack.Push("3");
            myStack.Push("Contre Torpilleur");
            myStack.Push("3");
            myStack.Push("Contre Torpilleur");
            myStack.Push("4");
            myStack.Push("Croiseur");
            myStack.Push("5");
            myStack.Push("Plane Carrier");
        }
    }
}
