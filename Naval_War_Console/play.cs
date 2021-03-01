using System;
using System.Collections.Generic;

namespace CS_Naval_War{
    class Play{
        public List<Board> boats = new List<Board>();
        public List<Board> shoot = new List<Board>();
        //public Dictionary<int, Boat> boatPlaceList = new Dictionary<int, Boat>();
        public Dictionary<int, Boat> idBoatP1 = new Dictionary<int, Boat>();
        public Dictionary<int, Boat> idBoatP2 = new Dictionary<int, Boat>();
        public int nbBoatPlace = 1;
        public void StartGame(){
            bool turn = false;
            bool alive  = true;
            
            boats.Add(new Board());
            boats.Add(new Board());
            shoot.Add(new Board());
            shoot.Add(new Board());
            
            Console.WriteLine("-- Please enter the name for the Player 1--");
            Player player1 = new Player(Console.ReadLine());
            player1.boatPlace = idBoatP1;
            player1.shootBoard = shoot[0];

            Console.WriteLine("-- Please enter the name for the Player 2--");
            Player player2 = new Player(Console.ReadLine());
            player2.boatPlace = idBoatP2;
            player2.shootBoard = shoot[1];

            PlayPlacement(player1, 0, idBoatP1);
            PlayPlacement(player2, 1, idBoatP2);
            
            do{
                turn = !turn;   
                Console.Clear();
                if ( turn ){
                    alive = PlayShoot(player1, 0, 1, idBoatP2); // player 1 to play
                } else {
                    alive = PlayShoot(player2, 1, 0, idBoatP1); // player 2 to play
                }             
            }while(alive); // to be change with win condition

            if ( turn ){
                Console.WriteLine("-- {0} WIN !!! --", player1.name);
            } else {
                Console.WriteLine("-- {0} WIN !!! --", player2.name);
            }
        }
        public void PlayPlacement(Player player, int nbPlayer, Dictionary<int, Boat> boatPlayer){   
            Boat tempBoat;
            String tempCoordonate;
            Board.direcEnum tempDirection;
            Dictionary<int, Boat.boatEnum> boatList = new Dictionary<int, Boat.boatEnum>();
            boatList.Add(0, Boat.boatEnum.CARRIER);
            boatList.Add(1, Boat.boatEnum.BATTLESHIP);
            boatList.Add(2, Boat.boatEnum.CRUISER);
            boatList.Add(3, Boat.boatEnum.SUBMARINE);
            boatList.Add(4, Boat.boatEnum.DESTROYER);
            
            do{
                player.boatBoard.printTab();
                tempBoat = player.ChooseBoat(boatList);
                do{
                    tempCoordonate = player.ChooseCoordonate();
                    tempDirection  = player.ChooseDirection();
                    if (!player.boatBoard.CheckPlacement(tempCoordonate[0]-48, tempCoordonate[1]-48, tempBoat.size, tempDirection)){
                        Console.WriteLine("- /!\\ Error detected, please retry with another coordonate or direction /!\\ -");
                    }
                }while(!player.boatBoard.CheckPlacement(tempCoordonate[0]-48, tempCoordonate[1]-48, tempBoat.size, tempDirection));
                boats[nbPlayer].Placement(tempCoordonate[0]-48, tempCoordonate[1]-48, tempBoat, tempDirection, nbBoatPlace);
                boatPlayer.Add(nbBoatPlace, tempBoat);
                player.boatBoard.Placement(tempCoordonate[0]-48, tempCoordonate[1]-48, tempBoat, tempDirection, nbBoatPlace);
                nbBoatPlace++;
            }while(boatList.Count != 0);
        }

        public bool PlayShoot (Player player, int nbPlayerShooting, int nbPlayerTakeShoot, Dictionary<int, Boat> boatPlayer){ // return true if the player still alive after the shot
            String shootCoordonate;
            int idBoatHit;
            Boat boatHit;

            // have to change the player !!!!!
            Console.WriteLine("{0} where you have already shoot", player.name);
            shoot[nbPlayerShooting].printTab();
            shootCoordonate = player.WhereToShot();
            if( shoot[nbPlayerShooting].ShootTake(shootCoordonate) != 1 && boats[nbPlayerTakeShoot].ShootTake(shootCoordonate) != 0){
                idBoatHit = boats[nbPlayerTakeShoot].ShootTake(shootCoordonate);
                shoot[nbPlayerShooting].ShootBoardShoot(shootCoordonate);
                // boat gestion

                if (boatPlayer.TryGetValue(idBoatHit, out boatHit)){
                    boatHit.takeDamage();
                    if ( boatHit.isAlive() ){
                        Console.WriteLine("Touch !");
                        Console.ReadKey();
                        Console.Clear();
                        return true;
                    } else {
                        Console.WriteLine("Touch and Kill !");
                        Console.ReadKey();
                        Console.Clear();
                        foreach ( KeyValuePair<int, Boat> i in boatPlayer) {
                            if (i.Value.isAlive()){
                                return true;
                            }
                        }
                        return false;
                    }
                } else {
                    return true;
                }
            } else {
                Console.WriteLine("Miss !");
                Console.ReadKey();
                Console.Clear();
                return true;
            }
        }
        










// NOT TO SEE OLD CODE, i keep it when i have to do the part play

/*
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
        }*/
    }
}