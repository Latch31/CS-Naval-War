using System;

namespace CS_Naval_War
{
    class Play
    {
        public void startGame(Board p1, Board p2)
        {
            bool win = false; // know if someone win
            bool turn = false;  // name of the player to play  
            if ( !p1.init || !p2.init )
            {
                Console.WriteLine(" one of the 2 player don't place his ship !");
            }
            else
            {
                Console.WriteLine("------ Game Start ------");
                while (!win)
                {
                    turn = !turn;
                    if ( turn )
                    {
                        win = playturn(p1, p2);
                    }
                    else
                    {
                        win = playturn(p2, p1);
                    }
                }
                if ( turn )
                {
                    Console.WriteLine("{0} WIN !!!", p1.pName);
                }
                else
                {
                    Console.WriteLine("{0} WIN !!!", p2.pName);
                }
            }
        }

        private bool playturn(Board pTurn, Board pAdv)
        {
            Boolean touch = false;
            Boolean shotAppend = false;
            
            Console.WriteLine("{0} is your turn !", pTurn.pName);
            do
            {
            Console.WriteLine("Choose where to shot");
            String entry = Console.ReadLine();
                if (entry.Length == 2) // check if the entry comporte 2 caracter
                {
                    //check the interval value of the entry
                    if ((entry[0] - 48) >= 0 || (entry[0] - 48) <= 10 || (entry[1] - 48) >= 0 || (entry[1] - 48) <= 10 ) 
                    {
                        touch = pAdv.getShot(entry[0], entry[1]);
                        shotAppend = true;
                    }
                    else
                    {
                        Console.WriteLine("Error Entry not on board, please retry");
                    }
                }
            }while(!shotAppend);

            if ( touch )
            {
                Console.WriteLine("Touche !!!");
                return pAdv.checkAlive();
            }
            else
            {
                Console.WriteLine("Miss");
                return false;
            }
        }
    }
}