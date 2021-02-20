using System;

namespace CS_Naval_War
{
    class Program
    {
        static void Main(string[] args)
        {

            Play game = new Play();
            game.StartGame();
            /*
            Console.Clear();
            Board player1 = new Board();
            Board player2 = new Board();
            String[,] boatList = new string[5,2];
            String name;

            boatInitialiseTab(boatList);
            // Name for the player 1
            Console.WriteLine("-- Please enter the name for the Player 1--");
            name = Console.ReadLine();
            player1.setPlayerName(name);
            Console.Clear();
            // Initialize P1 Board
            for ( int i = 0; i < boatList.Length / 2; i++)
            {
                placeBoat(boatList[i,0], boatList[i,1][0] -48, player1);
            }
            player1.bInitialise = true;
            
            // Name for the player 2
            Console.WriteLine("-- Please enter the name for the Player 2--");
            name = Console.ReadLine();
            player2.setPlayerName(name);
            Console.Clear();
            // Initialize P2 Board
            for ( int i = 0; i<boatList.Length / 2; i++)
            {
                placeBoat(boatList[i,0], boatList[i,1][0] -48, player2);
            }
            player2.bInitialise = true;

            //Start the game
            game.startGame(player1, player2);
            */
        }
/*
        static public void boatInitialiseTab(String[,] pBoarList)
        {
            pBoarList[0,0] = "Plane Carrier";
            pBoarList[0,1] = "5";
    
            pBoarList[1,0] = "Croiseur";
            pBoarList[1,1] = "4";

            pBoarList[2,0] = "Contre Torpilleur";
            pBoarList[2,1] = "3";

            pBoarList[3,0] = "Contre Torpilleur";
            pBoarList[3,1] = "3";

            pBoarList[4,0] = "Torpilleur";
            pBoarList[4,1] = "2";
        }

        static public void placeBoat(String bName, int size, Board pBoard)
        {
            String entry = "";
            bool goodPlacement = false;
            int x; // horizontal
            int y; // vertical
            
            do
            {
                pBoard.printTab(pBoard.bTab);
                Console.WriteLine("\n{0} : size = {1}", bName, size);
                Console.WriteLine("where in the board ? \nfirst number = horizontal | exemple : 42");

                entry = Console.ReadLine();
                if (entry.Length == 2) // check if the entry comporte 2 caracter
                {
                    //check the interval value of the entry
                    if ((entry[0] - 48) >= 0 || (entry[0] - 48) <= 10 || (entry[1] - 48) >= 0 || (entry[1] - 48) <= 10 ) 
                    {
                        // check if the point is free or already attribute
                        if (pBoard.bTab[entry[1] - 48, entry[0] - 48 ] == '.')
                        {
                            x = entry[0] - 48;
                            y = entry[1] - 48;

                            if ( size > 1)
                            {
                                Console.WriteLine("What direction ?");
                                Console.WriteLine("Choose between : N | S | E | W ");
                                entry = Console.ReadLine();

                                if (entry[0] == 'N' ||  entry[0] == 'S' ||  entry[0] == 'E' ||  entry[0] == 'W')
                                {
                                    goodPlacement = pBoard.placement(x, y, size, entry[0]);
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("/!\\ Error in selection, please retry /!\\");
                                }
                            }
                            else
                            {
                                goodPlacement = pBoard.placement(x, y);
                            }
                            
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("/!\\ Error, position already use /!\\");
                            goodPlacement = false;
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("/!\\ Error Entry not on board, please retry /!\\");
                        goodPlacement = false;
                    }
                }
            }while(!goodPlacement);
        }*/
    }
}
