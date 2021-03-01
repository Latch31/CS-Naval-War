using System;
using System.Collections.Generic;

namespace CS_Naval_War
{
    public class Board
    {
        public enum direcEnum{ North, South, East, West,}
        public Dictionary<int, Boat> boatPlace = new Dictionary<int, Boat>();
        public HashSet<direcEnum> direcList = new HashSet<direcEnum>();
        public int[,] boardTab = new int[10, 10];
        public int[,] bTab{
            get { return this.boardTab; }
        }
        public bool bInitialise = false;
        public Board(){
            /*for (int i = 0; i < 10; i++){
                for (int y = 0; y < 10; y++){
                    boardTab[i, y] = '.';
                }
            }*/
            direcList.Add(direcEnum.North);
            direcList.Add(direcEnum.South);
            direcList.Add(direcEnum.East);
            direcList.Add(direcEnum.West);
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
                            if ( this.boardTab[y-i, x] != 0){  
                                return false;
                            }
                        }
                    return true;
                    }
                    return false;
                case direcEnum.South:
                    if ( y+(size-1) <= 9){
                        for ( int i = 0; i < size; i++){
                            if ( this.boardTab[y+i, x] != 0){                                                
                                return false;
                            }
                        }
                        return true;
                    }
                    return false;
                case direcEnum.East:
                    if ( x+(size-1) <= 9){
                        for ( int i = 0; i < size; i++){
                            if ( this.boardTab[y, x+i] != 0){
                                return false;
                            }
                        }
                    return true;
                    }
                return false;
                case direcEnum.West:
                    if ( x-(size-1) >= 0){
                        for ( int i = 0; i < size; i++){
                            if ( this.boardTab[y, x-i] != 0){           
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
                            this.boardTab[y-i, x] = numBoat;
                        }
                    }
                    break;
                case direcEnum.South:
                    if ( y+(pBoat.size-1) <= 9){
                        for ( int i = 0; i < pBoat.size; i++){
                            this.boardTab[y+i, x] = numBoat;
                        }
                    }
                    break;
                case direcEnum.East:
                    if ( x+(pBoat.size-1) <= 9){
                        for ( int i = 0; i < pBoat.size; i++){
                            this.boardTab[y, x+i] = numBoat;
                        }
                    }
                    break;
                case direcEnum.West:
                    if ( x-(pBoat.size-1) >= 0){
                        for ( int i = 0; i < pBoat.size; i++){
                            this.boardTab[y, x-i] = numBoat;
                        }
                    }
                    break;
                default:
                    return false;
            }
            return true;
        }
        
        //Manage the shot system
        public void ShootBoardShoot(String coordonate, int number){
            this.boardTab[coordonate[1]-48, coordonate[0]-48] = number;
        }

        public int ShootTake(String coordonate){
            //this.boardTab[coordonate[1], coordonate[0]] = 'X';
            return this.boardTab[coordonate[1]-48, coordonate[0]-48];
        }

        public bool CheckBoatAlcie(int idBoat){
            return false;
        }
    }
}