using System;

namespace CS_Naval_War
{
    public class Board
    {
        private Char[,] boardTab = new Char[10, 10];
        private bool bInitialise = false;
        public bool init
        {
            get { return bInitialise; }
        }
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
                }
            }
        }

        public void initialise()
        {
            Console.WriteLine("Please enter the name for the Player");
            this.name = Console.ReadLine();

            Console.WriteLine("Place your boat");
            this.placeBoat("Plane Carrier", 5);
            this.placeBoat("Crioseur", 4);
            this.placeBoat("Contre Torpilleur", 3);
            this.placeBoat("Contre Torpilleur", 3);
            this.placeBoat("Torpilleur", 2);

            bInitialise = true;
        }

        public void printTab()
        {
            Console.WriteLine(" \\ | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |");
            for ( int i = 0; i < 10; i++)
            {
                Console.WriteLine(" {0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8} | {9} | {10} |",
                i,
                this.boardTab[i, 0],
                this.boardTab[i, 1],
                this.boardTab[i, 2],
                this.boardTab[i, 3],
                this.boardTab[i, 4],
                this.boardTab[i, 5],
                this.boardTab[i, 6],
                this.boardTab[i, 7],
                this.boardTab[i, 8],
                this.boardTab[i, 9]
                );
            }
        }

        private void placeBoat(String bName, int size)
        {
            String entry = "";
            bool goodPlacement = false;
            int x; // horizontal
            int y; // vertical
            
            do
            {
                this.printTab();
                Console.WriteLine("{0} : size = {1}", bName, size);
                Console.WriteLine("where in the board ? \nfirst number = horizontal | exemple : 42");

                entry = Console.ReadLine();
                if (entry.Length == 2) // check if the entry comporte 2 caracter
                {
                    //check the interval value of the entry
                    if ((entry[0] - 48) >= 0 || (entry[0] - 48) <= 10 || (entry[1] - 48) >= 0 || (entry[1] - 48) <= 10 ) 
                    {
                        // check if the point is free or already attribute
                        if (this.boardTab[entry[1] - 48, entry[0] - 48 ] == '.')
                        {
                            x = entry[0] - 48;
                            y = entry[1] - 48;

                            if ( size > 1)
                            {
                                Console.WriteLine("Quel Orrientation ?");
                                Console.WriteLine("Choose between : N | S | E | W ");
                                entry = Console.ReadLine();

                                if (entry[0] == 'N' ||  entry[0] == 'S' ||  entry[0] == 'E' ||  entry[0] == 'W')
                                {
                                    goodPlacement = this.placement(x, y, size, entry[0]);
                                }
                                else
                                {
                                    Console.WriteLine("Error in selection, please retry");
                                }
                            }
                            else
                            {
                                goodPlacement = this.placement(x, y);
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("Error, position already use");
                            goodPlacement = false;
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("Error Entry not on board, please retry");
                        goodPlacement = false;
                    }
                }
            }while(!goodPlacement);
        }

        private bool placement(int x, int y, int size, char card)
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
                Console.WriteLine("Error no space availble");
            }
            return goodPlacement;
        }
        private bool placement(int x, int y)
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