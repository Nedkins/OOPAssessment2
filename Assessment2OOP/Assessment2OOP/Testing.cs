using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2OOP
{
    internal class Testing
    {
        public static void Test()
        {
            while (true)
            {
                Game game = new Game();
            }
            
        }
        public static void SevensOutTesting()
        {
            while (true)
            {
                Console.WriteLine("Test player 1 or player 2?");
                string sevensOutTestingChoice = Console.ReadLine();
                if (sevensOutTestingChoice == "1")
                {
                    int expectedTotal = SevensOut.testingSevensOut;
                    Debug.Assert(expectedTotal == 7, "Total was not equal to 7");
                    Console.WriteLine("Tests passed successfully");
                    break;
                }
                if (sevensOutTestingChoice == "2")
                {
                    int expectedTotal2 = SevensOut.testingSevensOut2;
                    Debug.Assert(expectedTotal2 == 7, "Total was not equal to 7");
                    Console.WriteLine("Tests passed successfully");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }

        public static void ThreeOrMoreTesting()
        {
            while (true)
            {
                Console.WriteLine("Test player 1 or player 2?");
                string threeOrMoreTestingChoice = Console.ReadLine();
                if (threeOrMoreTestingChoice == "1")
                {
                    int expectedTotal = ThreeOrMore.testingPlayer1;
                    Debug.Assert(expectedTotal >= 20, "Total was not equal or greater than 20");
                    Console.WriteLine("Tests passed successfully");
                    break;
                }
                if (threeOrMoreTestingChoice == "2")
                {
                    int expectedTotal2 = ThreeOrMore.testingPlayer2;
                    Debug.Assert(expectedTotal2 >= 20, "Total was not equal or greater than 20");
                    Console.WriteLine("Tests passed successfully");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }
    }
}
