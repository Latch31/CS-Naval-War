using System;
using System.Collections.Generic;

namespace CS_Naval_War{
    class Play{
        public List<Board> boats = new List<Board>();
        public Dictionary<int, Boat> boatPlaceList = new Dictionary<int, Boat>();
        public void StartGame(){
            
            
            boats.Add(new Board());
            boats.Add(new Board());
            
            Console.WriteLine("-- Please enter the name for the Player 1--");
            Player player1 = new Player(Console.ReadLine());

            Console.WriteLine("-- Please enter the name for the Player 2--");
            Player player2 = new Player(Console.ReadLine());

            PlayPlacement(player1, 0);
            PlayPlacement(player2, 1);
            
        }
        public void PlayPlacement(Player player, int nbPlayer){   
            Boat tempBoat;
            String tempCoor;
            Board.direcEnum tempDir;
            Dictionary<int, Board.boatEnum> boatList = new Dictionary<int, Board.boatEnum>();
            boatList.Add(0, (Board.boatEnum)0);
            boatList.Add(1, (Board.boatEnum)1);
            boatList.Add(2, (Board.boatEnum)2);
            boatList.Add(3, (Board.boatEnum)3);
            boatList.Add(4, (Board.boatEnum)4);
            
            do{
                player.boatBoard.printTab();
                tempBoat = player.ChooseBoat(boatList);
                do{
                    tempCoor = player.ChooseCoordonate();
                    tempDir  = player.ChooseDirection();
                    if (!player.boatBoard.CheckPlacement(tempCoor[0]-48, tempCoor[1]-48, tempBoat.size, tempDir)){
                        Console.WriteLine("- /!\\ Error detected, please retry with another coordonate or direction /!\\ -");
                    }
                }while(!player.boatBoard.CheckPlacement(tempCoor[0]-48, tempCoor[1]-48, tempBoat.size, tempDir));
                boats[nbPlayer].Placement(tempCoor[0]-48, tempCoor[1]-48, tempBoat, tempDir, boatList.Count);
                boatPlaceList.Add(boatList.Count, tempBoat);
                player.boatBoard.Placement(tempCoor[0]-48, tempCoor[1]-48, tempBoat, tempDir, boatList.Count);
            }while(boatList.Count != 0);
        }
        










// NOT TO SEE OLD CODE, i keep it when i have to do the part play


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