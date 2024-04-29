using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2OOP
{
    // Statistics class
    internal class Statistics
    {
        // Statistics constructor
        public Statistics() 
        {
            Console.WriteLine("Sevens Out stats: ");
            SevenOutStats();
            Console.WriteLine();
            Console.WriteLine("Three Or More Stats: ");
            ThreeOrMoreStats();
        }
        
        // Sevens out stats method
        public void SevenOutStats()
        {
            int player1Wins = SevensOut.Player1Wins;
            int player2Wins = SevensOut.Player2Wins;

            int timesPlayed = SevensOut.timesPlayed;

            Console.WriteLine("Player 1 wins: " + player1Wins);
            Console.WriteLine("Player 2 wins: " + player2Wins);

            Console.WriteLine("Times played in 2 player mode: " + timesPlayed);
        }

        // Method for three or more stats
        public void ThreeOrMoreStats()
        {
            int player1Wins2 = ThreeOrMore.Player1Wins2;
            int player2Wins2 = ThreeOrMore.Player2Wins2;

            int timesPlayed2 = ThreeOrMore.timesPlayed;

            Console.WriteLine("Player 1 wins: " + player1Wins2);
            Console.WriteLine("Player 2 wins: " + player2Wins2);
            Console.WriteLine("Times played in 2 player mode: " + timesPlayed2);
        }
        
    }
}
