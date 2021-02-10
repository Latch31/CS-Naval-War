using System;

namespace CS_Naval_War
{
    public class Board
    {
        private Char[,] boardTab = new Char[10, 10];
        private bool bInitialise = false;

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

        //Todo
        public void initialise()
        {
            Console.WriteLine("Place your boat");
            this.planeCarrier();
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

        //Todo
        private void planeCarrier()
        {
            String entry = "";
            bool goodPlacement = false;
            int x; // horizontal
            int y; // vertical
            
            do
            {
                this.printTab();
                Console.WriteLine("Plane Carrier ( 5 case )");
                Console.WriteLine("where ? first number = horizontal | exemple : 42");

                entry = Console.ReadLine();
                if (entry.Length == 2) // check if the entry comporte 2 caracter
                {
                    //check the interval value of the entry
                    if ((entry[0] - 48) >= 0 || (entry[0] - 48) <= 10 || (entry[1] - 48) >= 0 || (entry[1] - 48) <= 10 ) 
                    {
                        // check if the point is free or already attribute
                        if (this.boardTab[entry[0] - 48, entry[1] - 48 ] == '.')
                        {
                            y = entry[0] - 48;
                            x = entry[1] - 48;

                            Console.WriteLine("Quel Orrientation ?");
                            Console.WriteLine("Choose between : N | S | E | W ");

                            entry = Console.ReadLine();
                            if (entry[0] == 'N' ||  entry[0] == 'S' ||  entry[0] == 'E' ||  entry[0] == 'W')
                            {
                                goodPlacement = this.placement(x, y,5,  entry[0]);
                            }
                            else
                            {
                                Console.WriteLine("Error in selection, please retry");
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
                        Console.WriteLine("Error in selection, please retry");
                        goodPlacement = false;
                    }
                }
            }while(!goodPlacement);
        }

        // maybe add length of the boat in parameter
        private bool placement(int x, int y, int size, char card)
        {   
            bool goodPlacement = true;
            switch ( card )
            {
                case 'N' :
                //check north case
                if ( y >= size - 1)
                {
                    for ( int i = 0; i < 5; i++)
                    {
                        if ( this.boardTab[x-i, y] == '.')
                        {                                                
                            this.boardTab[x-i, y] = 'O';
                        }
                        else
                        {
                            goodPlacement = false;
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
                if ( y <= size - 1)
                {
                    for ( int i = 0; i < 5; i++)
                    {
                        if ( this.boardTab[x+i, y] == '.')
                        {                                                
                            this.boardTab[x+i, y] = 'O';
                        }
                        else
                        {
                            goodPlacement = false;
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
                if ( x <= size - 1)
                {
                    for ( int i = 0; i < 5; i++)
                    {
                        if ( this.boardTab[x, y+i] == '.')
                        {                                                
                            this.boardTab[x, y+i] = 'O';
                        }
                        else
                        {
                            goodPlacement = false;
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
                if ( x >= size - 1)
                {
                    for ( int i = 0; i < 5; i++)
                    {
                        if ( this.boardTab[x, y-i] == '.')
                        {                                                
                            this.boardTab[x, y-i] = 'O';
                        }
                        else
                        {
                            goodPlacement = false;
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
    }
}