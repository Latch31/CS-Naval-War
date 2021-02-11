using System;

namespace CS_Naval_War
{
    class Play
    {
        public void startGame(Board p1, Board p2)
        {
            String p1Name; // just little personation for player
            String p2Name;
            bool win = false; // know if someone win
            String winner;    // name of the winner
            bool turn = false;  // name of the player to play  
            if ( !p1.init || !p2.init )
            {
                Console.WriteLine(" one of the 2 player don't place his ship !");
            }

            Console.WriteLine("Please enter the name for Player 1");
            p1Name = Console.ReadLine();
            Console.WriteLine("Please enter the name for Player 2");
            p2Name = Console.ReadLine();

            Console.WriteLine("------ Game Start ------");

            while (!win)
            {
                turn = !turn;
                if ( turn )
                {
                    playturn(p1);
                }
                else
                {
                    playturn(p1);
                }
            }
        }


        private void playturn(Board player)
        {

        }
    }
}