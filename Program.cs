using System;

namespace CS_Naval_War
{
    class Program
    {
        static void Main(string[] args)
        {
            Board player1 = new Board();
            player1.initialise();
            player1.printTab();
        }
    }
}
