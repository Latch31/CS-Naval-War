using System;

namespace CS_Naval_War
{
    public class Board
    {
        private String[,] boardTab = new String[10, 10];
        private bool bInitialise = false;

        public Board()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int y = 0; y < 10; y++)
                {
                    boardTab[i, y] = ".";
                }
            }
        }

        public void initialise()
        {
            Console.WriteLine("Place your boat");
            Console.WriteLine("Porte-Avions ( 5 case )"); //a trad en anglais

            bInitialise = true;
        }

        public void printTab()
        {
            Console.WriteLine("\\  | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |");
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
    }
}