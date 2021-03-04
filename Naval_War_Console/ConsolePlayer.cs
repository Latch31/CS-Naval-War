using System;
using System.Collections.Generic;

namespace CS_Naval_War
{
    public class ConsolePlayer : IPlayer{
        public String name;
        public Board boatBoard;
        public Board shootBoard;
        public Dictionary<int, Boat> boatPlace = new Dictionary<int, Boat>();

        public ConsolePlayer(String pName){
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
            Console.WriteLine("- Choose your boat -");
            do{
                foreach (KeyValuePair<int, Boat.boatEnum> i in boatList){
                    Console.WriteLine(i.Key + " : " + i.Value);
                }
                String pChoice = Console.ReadLine();
                Boat.boatEnum bChoose = new Boat.boatEnum();
                if (boatList.TryGetValue(pChoice[0] - 48, out bChoose)){
                    boatList.Remove(pChoice[0] - 48);
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

        public String ChooseCoordinate()
        {
            Console.WriteLine("Where did you want to place your boat ?");
            do
            {
                String choice = Console.ReadLine();
                if (choice.Length >= 2)
                {
                    int x = choice[0] - 48;
                    int y = choice[1] - 48;
                    if (this.boatBoard.boardTab[y, x] == 0)
                    {
                        return (choice.Substring(0, 2));
                    }
                    else
                    {
                        Console.WriteLine("there is already a boat here !, choose another coordonate");
                    }
                }
                else
                {
                    Console.WriteLine("bad coordonate, please retry");
                }
            } while (true);
        }

        public Board.direcEnum ChooseDirection()
        {
            int iter;
            do
            {
                iter = 0;
                foreach (Board.direcEnum i in this.boatBoard.direcList)
                {
                    Console.WriteLine(iter + " : " + i);
                    iter++;
                }
                String pChoice = Console.ReadLine();
                var bChoose = (Board.direcEnum)pChoice[0] - 48;
                if (Enum.IsDefined(typeof(Board.direcEnum), bChoose))
                {
                    return (Board.direcEnum)bChoose;
                }
            } while (true);
        }

        public String WhereToShot()
        {
            String choice;
            Console.WriteLine("Where did you want to shoot {0} ?", this.name);
            do
            {
                choice = Console.ReadLine();
                if (choice.Length >= 2)
                {
                    int x = choice[0] - 48;
                    int y = choice[1] - 48;
                    return (choice.Substring(0, 2));
                }
            } while (true);
        }
    }
}