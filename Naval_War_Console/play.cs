using System;
using System.Collections.Generic;

namespace CS_Naval_War
{
    class Play
    {

        public void StartGame()
        {
            Board player1 = new Board();
            Board player2 = new Board();
            Boat tempBoat;
            String tempCoor;
            Char tempDir;

            Console.WriteLine("-- Please enter the name for the Player 1--");
            player1.setPlayerName(Console.ReadLine());

            Console.WriteLine("-- Please enter the name for the Player 2--");
            player2.setPlayerName(Console.ReadLine());

            //Boat placement
            // penser a faire un retour arrière si le dernier placement et pas bon, ou et anuller
            tempBoat = player1.ChooseBoat();
            tempCoor = player1.Coordonate();
            tempDir  = player1.ChooseDirection();

            Console.WriteLine("Coor : {0}{1}\nSize : {2}\nDir : {3}", tempCoor[0], tempCoor[1], tempBoat.size, tempDir);
            if ( player1.CheckPlacement(tempCoor[0]-48, tempCoor[1]-48, tempBoat.size, tempDir)){
                Console.WriteLine("Bravo tu peut placer le bateau, tient voila un sourire :)");
            }
            else {
                Console.WriteLine("bah tu peut recommencer, ton bateau rentre pas, dommage");
            }


        }
        public void startGame(Board p1, Board p2)
        {
            bool win = false; // know if someone win
            bool turn = false;  // name of the player to play  
            if ( !p1.bInitialise || !p2.bInitialise )
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
                    if (!win)
                    {
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                if ( turn )
                {
                    Console.WriteLine("--- {0} WIN !!! ---", p1.pName);
                }
                else
                {
                    Console.WriteLine("--- {0} WIN !!! ---", p2.pName);
                }
                Console.WriteLine("------ Game Over ------");
                
            }
        }

        private bool playturn(Board pTurn, Board pAdv)
        {
            Boolean touch = false;
            Boolean shotAppend = false;
            
            Console.WriteLine("- {0} is your turn ! -", pTurn.pName);
            do
            {
                Console.WriteLine("Where you already shoot");
                pTurn.printTab(pTurn.bShoot);
                Console.WriteLine("Choose where to shot");
                String entry = Console.ReadLine();
                if (entry.Length == 2) // check if the entry comporte 2 caracter
                {
                    //check the interval value of the entry
                    if ((entry[0] - 48) >= 0 || (entry[0] - 48) <= 10 || (entry[1] - 48) >= 0 || (entry[1] - 48) <= 10 ) 
                    {
                        int x = entry[0] - 48;
                        int y = entry[1] - 48;
                        touch = pAdv.getShot(x, y);
                        pTurn.shoot(x, y, touch);
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