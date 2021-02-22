using System;
using System.Collections.Generic;

namespace CS_Naval_War
{
    public class Board
    {
        
        public enum boatEnum{ Carrier, Battleship, Cruiser, Submarine, Destroyer,}
        public enum direcEnum{ North, South, East, West,}
        public Dictionary<int, Boat> boatPlace = new Dictionary<int, Boat>();
        public HashSet<direcEnum> direcList = new HashSet<direcEnum>();
        public Char[,] boardTab = new Char[10, 10];
        public Char[,] bTab{
            get { return this.boardTab; }
        }
        public bool bInitialise = false;
        public Board(){
            for (int i = 0; i < 10; i++){
                for (int y = 0; y < 10; y++){
                    boardTab[i, y] = '.';
                }
            }
            direcList.Add((direcEnum)0);
            direcList.Add((direcEnum)1);
            direcList.Add((direcEnum)2);
            direcList.Add((direcEnum)3);
        }
        public void printTab(){
            Console.WriteLine(" \\ | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |");
            for ( int i = 0; i < 10; i++){
                Console.WriteLine(" {0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8} | {9} | {10} |",
                i, this.boardTab[i, 0], this.boardTab[i, 1], this.boardTab[i, 2], this.boardTab[i, 3], this.boardTab[i, 4], this.boardTab[i, 5], this.boardTab[i, 6], this.boardTab[i, 7], this.boardTab[i, 8], this.boardTab[i, 9] );
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
        public bool Placement(int x, int y, Boat pBoat, direcEnum direc, int numBoat){
            boatPlace.Add(numBoat, pBoat);
            switch (direc){
                case direcEnum.North:
                    if ( y-(pBoat.size-1) >= 0){
                        for ( int i = 0; i < pBoat.size; i++){
                            this.boardTab[y-i, x] = (Char)(numBoat+48);
                        }
                    }
                    break;
                case direcEnum.South:
                    if ( y+(pBoat.size-1) <= 9){
                        for ( int i = 0; i < pBoat.size; i++){
                            this.boardTab[y+i, x] = (Char)(numBoat+48);
                        }
                    }
                    break;
                case direcEnum.East:
                    if ( x+(pBoat.size-1) <= 9){
                        for ( int i = 0; i < pBoat.size; i++){
                            this.boardTab[y, x+i] = (Char)(numBoat+48);
                        }
                    }
                    break;
                case direcEnum.West:
                    if ( x-(pBoat.size-1) >= 0){
                        for ( int i = 0; i < pBoat.size; i++){
                            this.boardTab[y, x-i] = (Char)(numBoat+48);
                        }
                    }
                    break;
                default:
                    return false;
            }
            return true;
        }
        public String WhereToShot(){
            Console.WriteLine("Where did you want to shoot ?");
            Console.ReadLine();
            do{
                String choice = Console.ReadLine();
                if ( choice.Length >=2){
                    int x = choice[0]-48;
                    int y = choice[1]-48;
                    return (choice.Substring(0, 2));
                }
            }while(true);
        }
        //Manage the shot system
        public bool getShot(int x, int y){
            if ( this.boardTab[y, x] == 'O'){
                this.boardTab[y, x] = 'X';
                return true;
            }
            else{
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