using System;
using System.Collections.Generic;

namespace CS_Naval_War
{
    public class IAPlayer : IPlayer
    {
        public string name;
        public Board boatBoard;
        public Board shootBoard;
        public Dictionary<int, Boat> boatPlace = new Dictionary<int, Boat>();

        public IAPlayer(){
            this.name = "bot_Peter";
            boatBoard = new Board();
            shootBoard = new Board();
        }

        public IAPlayer(String pName){
            this.name = pName;
            boatBoard = new Board();
            shootBoard = new Board();
        }

        public void BoatIdCopy(Dictionary<int, Boat> pBoatPlace){
            boatPlace = pBoatPlace;
        }
        public void ShootCopy(Board pBoardShoot){
            shootBoard = pBoardShoot;
        }

        public Board GetBoatBoard(){
            return this.boatBoard;
        }
        public String getPlayerName(){
            return this.name;
        }

        public Boat ChooseBoat(Dictionary<int, Boat.boatEnum> boatList){
            Random rng = new Random();
            do{
                foreach (KeyValuePair<int, Boat.boatEnum> i in boatList){
                    Console.WriteLine(i.Key + " : " + i.Value);
                }
                int pChoice = rng.Next(0, 5);
                Boat.boatEnum bChoose = new Boat.boatEnum();
                if (boatList.TryGetValue(pChoice, out bChoose)){
                    boatList.Remove(pChoice);
                    switch (bChoose){
                        case Boat.boatEnum.CARRIER:
                            return BoatFactory.MakeCarrier();
                        case Boat.boatEnum.BATTLESHIP:
                            return BoatFactory.MakeBattleship();
                        case Boat.boatEnum.CRUISER:
                            return BoatFactory.MakeCruiser();
                        case Boat.boatEnum.SUBMARINE:
                            return BoatFactory.MakeSubmarine();
                        case Boat.boatEnum.DESTROYER:
                            return BoatFactory.MakeDestroyer();
                        default:
                            break;
                    }
                }
            } while (true);
        }
        public String ChooseCoordinate(){
            Random rng = new Random();
            String choice;
            do{
                int x = rng.Next(0,9);
                int y = rng.Next(0,9);
                if (this.boatBoard.boardTab[y, x] == 0){
                    choice = $"{x}{y}";
                    return (choice.Substring(0, 2));
                }
            }while(true);
        }
        public Board.direcEnum ChooseDirection(){
            Random rng = new Random();
            do{
                int pChoice = rng.Next(0, 3);
                var bChoose = (Board.direcEnum)pChoice;
                if (Enum.IsDefined(typeof(Board.direcEnum), bChoose)){
                    return (Board.direcEnum)bChoose;
                }
            }while(true);
        }
        public String WhereToShot(){
            Random rng = new Random();
            String choice;
            do{
                int x = rng.Next(0,9);
                int y = rng.Next(0,9);
                if (this.boatBoard.boardTab[y, x] == 0){
                    choice = $"{x}{y}";
                    return (choice.Substring(0, 2));
                }
            }while(true);
        }
    }
}