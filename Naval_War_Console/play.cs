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
            IPlayer player1;
            IPlayer player2;
            String gameType;
            
            boats.Add(new Board());
            boats.Add(new Board());
            shoot.Add(new Board());
            shoot.Add(new Board());
            bool patate;
            do
            {
                Console.WriteLine(" Party type : \n1 : Player vs IA\n2 : Player vs Player");
                gameType = Console.ReadLine();
                if (gameType[0] == '1' || gameType[0] == '2')
                {
                    patate = true;
                } else
                {
                    patate = false;
                }
            }while(!patate);


            Console.WriteLine("-- Player 1 name --");
            player1 = new ConsolePlayer(Console.ReadLine());
            player1.BoatIdCopy(idBoatP1);
            player1.ShootCopy(shoot[0]);
            if ( gameType[0] == '1'){
                player2 = new IAPlayer();
                player2.BoatIdCopy(idBoatP2);
                player2.ShootCopy(shoot[1]);
            } else {
                Console.WriteLine("-- Player 2 name --");
                player2 = new ConsolePlayer(Console.ReadLine());
                player2.BoatIdCopy(idBoatP2);
                player2.ShootCopy(shoot[1]);
            }

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
                Console.WriteLine("-- {0} WIN !!! --", player1.getPlayerName());
            } else {
                Console.WriteLine("-- {0} WIN !!! --", player2.getPlayerName());
            }
        }

        public void PlayPlacement(IPlayer player, int nbPlayer, Dictionary<int, Boat> boatPlayer){   
            Boat tempBoat;
            String tempCoordinate;
            Board.direcEnum tempDirection;
            Dictionary<int, Boat.boatEnum> boatList = new Dictionary<int, Boat.boatEnum>();
            boatList.Add(0, Boat.boatEnum.CARRIER);
            boatList.Add(1, Boat.boatEnum.BATTLESHIP);
            boatList.Add(2, Boat.boatEnum.CRUISER);
            boatList.Add(3, Boat.boatEnum.SUBMARINE);
            boatList.Add(4, Boat.boatEnum.DESTROYER);
            
            do{
                boats[nbPlayer].printTab();
                tempBoat = player.ChooseBoat(boatList);
                do{
                    tempCoordinate = player.ChooseCoordinate();
                    tempDirection  = player.ChooseDirection();
                    if (!boats[nbPlayer].CheckPlacement(tempCoordinate[0]-48, tempCoordinate[1]-48, tempBoat.size, tempDirection)){
                        Console.WriteLine("- /!\\ Error detected, please retry with another coordinate or direction /!\\ -");
                    }
                }while(!boats[nbPlayer].CheckPlacement(tempCoordinate[0]-48, tempCoordinate[1]-48, tempBoat.size, tempDirection));
                boats[nbPlayer].Placement(tempCoordinate[0]-48, tempCoordinate[1]-48, tempBoat, tempDirection, nbBoatPlace);
                boatPlayer.Add(nbBoatPlace, tempBoat);
                player.GetBoatBoard().Placement(tempCoordinate[0]-48, tempCoordinate[1]-48, tempBoat, tempDirection, nbBoatPlace);
                nbBoatPlace++;
            }while(boatList.Count != 0);
        }

        public bool PlayShoot (IPlayer player, int nbPlayerShooting, int nbPlayerTakeShoot, Dictionary<int, Boat> boatPlayer){ // return true if the player still alive after the shot
            String shootCoordinate;
            int idBoatHit;
            Boat boatHit;

            // have to change the player !!!!!
            Console.WriteLine("{0} where you have already shoot", player.getPlayerName());
            shoot[nbPlayerShooting].printTab();
            shootCoordinate = player.WhereToShot();
            if( shoot[nbPlayerShooting].ShootTake(shootCoordinate) != 1 && boats[nbPlayerTakeShoot].ShootTake(shootCoordinate) != 0){
                idBoatHit = boats[nbPlayerTakeShoot].ShootTake(shootCoordinate);
                shoot[nbPlayerShooting].ShootBoardShoot(shootCoordinate, 8);
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
                shoot[nbPlayerShooting].ShootBoardShoot(shootCoordinate, 1);
                Console.WriteLine("Miss !");
                Console.ReadKey();
                Console.Clear();
                return true;
            }
        }
    }
}