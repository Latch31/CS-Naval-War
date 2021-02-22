using System;
using System.Collections.Generic;

namespace CS_Naval_War{
    class Player{

        public String name;
        public Board  boatBoard;
        public Board  shootBoard;
        public Dictionary<int, Boat> boatPlace = new Dictionary<int, Boat>();

        public Player(String pName){
            this.name = pName;
            boatBoard = new Board();
            shootBoard = new Board();
        }

        public void BoatIdCopy(Dictionary<int, Boat> pBoatPlace){
            boatPlace = pBoatPlace;
        }

        public Boat ChooseBoat(Dictionary<int, Board.boatEnum> boatList){
            Console.WriteLine("- Choose your boat -");
            do{
                foreach ( KeyValuePair<int, Board.boatEnum> i in boatList){
                    Console.WriteLine(i.Key + " : " + i.Value );
                }
                String pChoice = Console.ReadLine();
                Board.boatEnum bChoose = new Board.boatEnum();
                if (boatList.TryGetValue(pChoice[0]-48, out bChoose)){
                    boatList.Remove(pChoice[0]-48);
                    switch (bChoose){
                        case Board.boatEnum.Carrier: 
                            return BoatFactory.MakeCarrier();
                        case Board.boatEnum.Battleship:
                            return BoatFactory.MakeBattleship();
                        case Board.boatEnum.Cruiser:
                            return BoatFactory.MakeCruiser();
                        case Board.boatEnum.Submarine:
                            return BoatFactory.MakeSubmarine();
                        case Board.boatEnum.Destroyer:
                            return BoatFactory.MakeDestroyer();
                        default:
                            break;
                    }
                }
            }while(true);
        }

        public String ChooseCoordonate(){
            Console.WriteLine("Where did you want to place your boat ?");
            do{
                String choice = Console.ReadLine();
                if ( choice.Length >=2){
                    int x = choice[0]-48;
                    int y = choice[1]-48;
                    if ( this.boatBoard.boardTab[y,x] == '.'){
                        return (choice.Substring(0, 2));
                    }
                }
                else{
                    Console.WriteLine("position occupied, please choose another position");
                }
            }while(true);
        }

        public Board.direcEnum ChooseDirection(){
            int iter;
            do{
                iter = 0;
                foreach (Board.direcEnum i in this.boatBoard.direcList){
                    Console.WriteLine(iter + " : " + i );
                    iter++;
                }
                String pChoice = Console.ReadLine();
                var bChoose = (Board.direcEnum)pChoice[0]-48;
                if (Enum.IsDefined(typeof(Board.direcEnum), bChoose)){
                    return (Board.direcEnum)bChoose;
                }
            }while(true);
        }

    }
}