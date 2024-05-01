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
            // Attempt to make game object to start game
            try
            {
                Game game = new Game();
            }
            catch (Exception exception)
            {
                Console.WriteLine("There has been an error starting the program!" + exception.Message);
            }
            
        }

       

        

        // Testing stuff
        public static void SevensOutTesting()
        {
            while (true)
            {
                Console.WriteLine("Test player vs AI [1] or player vs player [2]?");
                string sevensOutTestingChoice = Console.ReadLine();
                if (sevensOutTestingChoice == "1")
                {
                    SevensOut sevensOut = new SevensOut();
                    int sevensOutScore = sevensOut.PlaySevensOutAI();
                    Debug.Assert(sevensOut.die1.dieCurrentValue >= 1 && sevensOut.die1.dieCurrentValue <= 6, "Dice 1 is out of range!");
                    Debug.Assert(sevensOut.die2.dieCurrentValue >= 1 && sevensOut.die2.dieCurrentValue <= 6, "Dice 2 is out of range!");
                    Debug.Assert(sevensOut.die3.dieCurrentValue >= 1 && sevensOut.die3.dieCurrentValue <= 6, "Dice 3 is out of range!");
                    Debug.Assert(sevensOut.die4.dieCurrentValue >= 1 && sevensOut.die4.dieCurrentValue <= 6, "Dice 4 is out of range!");

                    int player1Score = sevensOut.die1.dieCurrentValue += sevensOut.die2.dieCurrentValue;
                    int player2Score = sevensOut.die1.dieCurrentValue += sevensOut.die2.dieCurrentValue;

                    Debug.Assert(player1Score != 7 || player2Score != 7, "A player won without reaching 7");

                    break;
                }
                if (sevensOutTestingChoice == "2")
                {
                    SevensOut sevensOut = new SevensOut();
                    int sevensOutScore = sevensOut.PlaySevensOutHM();
                    Debug.Assert(sevensOut.die1.dieCurrentValue >= 1 && sevensOut.die1.dieCurrentValue <= 6, "Dice 1 is out of range!");
                    Debug.Assert(sevensOut.die2.dieCurrentValue >= 1 && sevensOut.die2.dieCurrentValue <= 6, "Dice 2 is out of range!");
                    Debug.Assert(sevensOut.die3.dieCurrentValue >= 1 && sevensOut.die3.dieCurrentValue <= 6, "Dice 3 is out of range!");
                    Debug.Assert(sevensOut.die4.dieCurrentValue >= 1 && sevensOut.die4.dieCurrentValue <= 6, "Dice 4 is out of range!");
                    
                    int player1Score = sevensOut.die1.dieCurrentValue += sevensOut.die2.dieCurrentValue;
                    int player2Score = sevensOut.die1.dieCurrentValue += sevensOut.die2.dieCurrentValue;

                    Debug.Assert(player1Score != 7 || player2Score != 7, "A player won without reaching 7");

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
                Console.WriteLine("Test player vs AI [1] or player vs player [2]?");
                string threeOrMoreTestingChoice = Console.ReadLine();
                if (threeOrMoreTestingChoice == "1")
                {
                    ThreeOrMore threeOrMore = new ThreeOrMore();
                    int threeOrMoreScore = threeOrMore.PlayThreeOrMoreAI();

                    Debug.Assert(threeOrMore.playerScore >= 20 || threeOrMore.AIscore >= 20, "Player score was not equal or over 20"); 
                    break;
                }
                if (threeOrMoreTestingChoice == "2")
                {
                    ThreeOrMore threeOrMore = new ThreeOrMore();
                    int threeOrMoreScore = threeOrMore.PlayThreeOrMoreHM();

                    Debug.Assert(threeOrMore.playerScore >= 20 || threeOrMore.AIscore >= 20, "Player score was not equal or over 20");
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
