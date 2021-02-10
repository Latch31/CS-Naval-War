using System;

namespace CS_Naval_War
{
    class Program
    {
        static void Main(string[] args)
        {
            Board patate = new Board();
            patate.printTab();
            patate.initialise();
            patate.printTab();
        }
    }
}
