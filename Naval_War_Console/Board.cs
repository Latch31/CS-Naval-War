using System;

namespace CS_Naval_War
{
    public class Board
    {
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

        public Board()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int y = 0; y < 10; y++)
                {
                    boardTab[i, y] = '.';
                    boardShoot[i, y] = '.';
                }
            }
        }

        public void setPlayerName (string nameParam)
        {
            this.name = nameParam;
        }

        public void printTab(Char[,] printTab)
        {
            Console.WriteLine(" \\ | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |");
            for ( int i = 0; i < 10; i++)
            {
                Console.WriteLine(" {0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8} | {9} | {10} |",
                i,
                printTab[i, 0],
                printTab[i, 1],
                printTab[i, 2],
                printTab[i, 3],
                printTab[i, 4],
                printTab[i, 5],
                printTab[i, 6],
                printTab[i, 7],
                printTab[i, 8],
                printTab[i, 9]
                );
            }
        }

        public bool placement(int x, int y, int size, char card)
        {   
            bool goodPlacement = true;
            switch ( card )
            {
                case 'N' :
                //check north case
                if ( y-(size-1) >= 0)
                {
                    // check if all area is unused
                    for ( int i = 0; i < size; i++)
                    {
                        if ( this.boardTab[y-i, x] != '.')
                        {                                                
                           goodPlacement = false;
                        }
                    }
                    // if all area is unused we place the boat
                    if ( goodPlacement )
                    {
                        for ( int i = 0; i < size; i++)
                        {
                            this.boardTab[y-i, x] = 'O';
                        }
                    }
                }
                else
                {
                    goodPlacement = false;
                }
                break;
                                    
                case 'S' :
                //check South case
                if ( y+(size-1) <= 9)
                {
                    for ( int i = 0; i < size; i++)
                    {
                        if ( this.boardTab[y+i, x] != '.')
                        {                                                
                           goodPlacement = false;
                        }
                    }
                    if ( goodPlacement )
                    {
                        for ( int i = 0; i < size; i++)
                        {
                            this.boardTab[y+i, x] = 'O';
                        }
                    }
                }
                else
                {
                    goodPlacement = false;
                }
                break;
                                    
                case 'E' :
                //check East case
                if ( x+(size-1) <= 9)
                {
                    for ( int i = 0; i < size; i++)
                    {
                        if ( this.boardTab[y, x+i] != '.')
                        {           
                            goodPlacement = false;
                        }
                    }
                    if ( goodPlacement )
                    {
                        for ( int i = 0; i < size; i++)
                        {
                                this.boardTab[y, x+i] = 'O';
                        }
                    }
                }
                else
                {
                    goodPlacement = false;
                }
                break;

                case 'W' :
                //check West case
                if ( x-(size-1) >= 0)
                {
                    for ( int i = 0; i < size; i++)
                    {
                        if ( this.boardTab[y, x-i] != '.')
                        {           
                            goodPlacement = false;
                        }
                    }
                    if ( goodPlacement )
                    {
                        for ( int i = 0; i < size; i++)
                        {
                                this.boardTab[y, x-i] = 'O';
                        }
                    }
                }
                else
                {
                    goodPlacement = false;
                }
                break;
                                    
                default :
                goodPlacement = false;
                break;
            }
            if (!goodPlacement)
            {
                Console.Clear();
                Console.WriteLine("/!\\ Error no space availble /!\\");
            }
            return goodPlacement;
        }
        public bool placement(int x, int y)
        {
            if ( this.boardTab[x, y] == '.' )
            {
                this.boardTab[x, y] = 'O';
                return true;
            }
            else
            {
                return false;
            }
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