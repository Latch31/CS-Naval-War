﻿using System;

namespace CS_Naval_War
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Board player1 = new Board();
            Board player2 = new Board();
            Play game = new Play();
            player1.initialise();
            player2.initialise();

            game.startGame(player1, player2);
        }
    }
}