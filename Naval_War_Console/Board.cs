using System;
using System.Collections.Generic;

namespace CS_Naval_War
{
    public class Board
    {
        
        enum boatEnum{ Carrier, Battleship, Cruiser, Submarine, Destroyer,}
        public enum direcEnum{ North, South, East, West,}
        HashSet<boatEnum> boatList = new HashSet<boatEnum>();
        HashSet<direcEnum> direcList = new HashSet<direcEnum>();
        private Char[,] boardTab = new Char[10, 10];
        public Char[,] bTab
        {
            get { return this.boardTab; }
        }
        private Char[,] boardShoot = new char[10, 10];
        public Char[,] bShoot
        {
            get { return this.boardShoot; }
        }
        public bool bInitialise = false;
        private String name;
        public String pName
        {
            get { return name; }
        }
        public Board(){
            for (int i = 0; i < 10; i++){
                for (int y = 0; y < 10; y++){
                    boardTab[i, y] = '.';
                    boardShoot[i, y] = '.';
                }
            }
            boatList.Add((boatEnum)0);
            boatList.Add((boatEnum)1);
            boatList.Add((boatEnum)2);
            boatList.Add((boatEnum)3);
            boatList.Add((boatEnum)4);
            direcList.Add((direcEnum)0);
            direcList.Add((direcEnum)1);
            direcList.Add((direcEnum)2);
            direcList.Add((direcEnum)3);
        }

        public Boat ChooseBoat(){
            Console.WriteLine("- Choose your boat -");
            int iter = 0;
            do{
                foreach ( boatEnum i in boatList){
                    Console.WriteLine(iter + " : " + i );
                    iter++;
                }
                String pChoice = Console.ReadLine();
                var bChoose = (boatEnum)pChoice[0]-48;
                if (boatList.Contains(bChoose)){
                    switch (bChoose){
                        case boatEnum.Carrier: 
                            return BoatFactory.MakeCarrier();
                        case boatEnum.Battleship:
                            return BoatFactory.MakeBattleship();
                        case boatEnum.Cruiser:
                            return BoatFactory.MakeCruiser();
                        case boatEnum.Submarine:
                            return BoatFactory.MakeSubmarine();
                        case boatEnum.Destroyer:
                            return BoatFactory.MakeDestroyer();
                        default:
                            break;
                    }
                }
            }while(true);
        }

        public String Coordonate(){
            Console.WriteLine("Where did you want to place your boat ?");
            do{
                String choice = Console.ReadLine();
                if ( choice.Length >=2){
                    int x = choice[0]-48;
                    int y = choice[1]-48;
                    if ( this.boardTab[y,x] == '.'){
                        return (choice.Substring(0, 2));
                    }
                }
                else{
                    Console.WriteLine("position occupied, please choose another position");
                }
            }while(true);
        }

        public direcEnum ChooseDirection(){
            int iter = 0;
            do{
                foreach (direcEnum i in direcList){
                    Console.WriteLine(iter + " : " + i );
                    iter++;
                }
                String pChoice = Console.ReadLine();
                var bChoose = (direcEnum)pChoice[0]-48;
                if (Enum.IsDefined(typeof(direcEnum), bChoose)){
                    return (direcEnum)bChoose;
                }
            }while(true);
        }

        public void setPlayerName (string nameParam){
            this.name = nameParam;
        }

        public void printTab(Char[,] printTab){
            Console.WriteLine(" \\ | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |");
            for ( int i = 0; i < 10; i++){
                Console.WriteLine(" {0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8} | {9} | {10} |",
                i, printTab[i, 0], printTab[i, 1], printTab[i, 2], printTab[i, 3], printTab[i, 4], printTab[i, 5], printTab[i, 6], printTab[i, 7], printTab[i, 8], printTab[i, 9] );
            }
        }

        public Boolean CheckPlacement(int x, int y, int size, direcEnum direc){
            switch (direc){
                case direcEnum.North:
                    if ( y-(size-1) >= 0){
                        for ( int i = 0; i < size; i++){
                            if ( this.boardTab[y-i, x] != '.'){  
                                return false;
                            }
                        }
                    return true;
                    }
                    return false;
                case direcEnum.South:
                    if ( y+(size-1) <= 9){
                        for ( int i = 0; i < size; i++){
                            if ( this.boardTab[y+i, x] != '.'){                                                
                                return false;
                            }
                        }
                        return true;
                    }
                    return false;
                case direcEnum.East:
                    if ( x+(size-1) <= 9){
                        for ( int i = 0; i < size; i++){
                            if ( this.boardTab[y, x+i] != '.'){
                                return false;
                            }
                        }
                    return true;
                    }
                return false;
                case direcEnum.West:
                    if ( x-(size-1) >= 0){
                        for ( int i = 0; i < size; i++){
                            if ( this.boardTab[y, x-i] != '.'){           
                                return false;
                            }
                        }
                    return true;
                    }
                    return false;
                default:
                    return false;
            }
        }

        // old part now

        public bool placement(int x, int y, int size, direcEnum card){   

            return false;
        }

        public void shoot(int x, int y, bool touch)
        {
            if ( touch )
            {
                this.boardShoot[y, x] = 'X';
            }
            else if (this.boardShoot[y,x] != 'X')
            {
                this.boardShoot[y,x] = 'O';
            }
        }
        //Manage the shot system
        public bool getShot(int x, int y)
        {
            Char data;
            data = this.boardTab[y, x];

            if ( data == 'O')
            {
                this.boardTab[y, x] = 'X';
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool checkAlive()
        {
            for ( int x = 0; x < 10; x++)
            {
                for ( int y = 0; y < 10; y++)
                {
                    if ( this.boardTab[x, y] == 'O')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}