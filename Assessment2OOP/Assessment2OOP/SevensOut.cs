using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2OOP
{
    internal class SevensOut
    {
        // Stores the random object for number generation
        private Random _rng;
        // Creates the two public die objects
        public Die die1;
        public Die die2;
        
        // Die for player 2 
        public Die die3;
        public Die die4;



        public SevensOut() 
        {
            try
            {
                Console.WriteLine("Welcome to Sevens Out!");
                // Initliaze the random object
                _rng = new Random();
                // Creates the die objects
                die1 = new Die(_rng);
                die2 = new Die(_rng);
                // Die for player 1 
                die3 = new Die(_rng);
                die4 = new Die(_rng);
            }
            catch (Exception exception)
            {
                Console.WriteLine("An error occured during game creation!" + exception);
            }
    }

    public int PlaySevensOutAI()
        {
            Console.ReadKey();
            int score = 0;
            int total = 0;

            int AIScore = 0;
            int AITotal = 0;

            while (true)
            {
                total += die1.Roll();
                total += die2.Roll();

                AITotal += die3.Roll();
                AITotal += die4.Roll();

                // Draw
                if (die1.dieCurrentValue + die2.dieCurrentValue == 7 && die3.dieCurrentValue + die4.dieCurrentValue == 7)
                {
                    Console.WriteLine("You got: " + die1.dieCurrentValue + " and " + die2.dieCurrentValue);
                    Console.WriteLine("The AI got: " + die3.dieCurrentValue + " and " + die4.dieCurrentValue);

                    if (score == AIScore)
                    {
                        Console.WriteLine("Its a draw!");
                        Console.WriteLine("Your final score is: " + score);
                        Console.WriteLine("The AI's final score is: " + AIScore);
                    }
                    else if (score > AIScore)
                    {
                        Console.WriteLine("You won!");
                        Console.WriteLine("Your final score is: " + score);
                        Console.WriteLine("The AI's final score is: " + AIScore);
                    }
                    else if (score < AIScore)
                    {
                        Console.WriteLine("You lost!");
                        Console.WriteLine("Your final score is: " + score);
                        Console.WriteLine("The AI's final score is: " + AIScore);
                    }

                    Console.WriteLine();
                    break;
                }

                // If the user gets a 7
                if (die1.dieCurrentValue + die2.dieCurrentValue == 7)
                {
                    Console.WriteLine("You got: " + die1.dieCurrentValue + " and " + die2.dieCurrentValue);
                    Console.WriteLine("The AI got: " + die3.dieCurrentValue + " and " + die4.dieCurrentValue);

                    
                    Console.WriteLine("You got 7!");
                    if (die3.dieCurrentValue == die4.dieCurrentValue)
                    {
                        AIScore += die3.dieCurrentValue * 2;
                        AIScore += die4.dieCurrentValue * 2;
                    }
                    else
                    {
                        AIScore += die3.dieCurrentValue;
                        AIScore += die4.dieCurrentValue;
                    }

                    Console.WriteLine("Your final score is: " + score);
                    Console.WriteLine("The AI's final score is: " + AIScore);

                    Console.WriteLine();
                    break;
                }
                // If the AI gets a 7
                else if (die3.dieCurrentValue + die4.dieCurrentValue == 7)
                {
                    Console.WriteLine("You got: " + die1.dieCurrentValue + " and " + die2.dieCurrentValue);
                    Console.WriteLine("The AI got: " + die3.dieCurrentValue + " and " + die4.dieCurrentValue);

                    Console.WriteLine("The AI got a 7!");

                    if (die1.dieCurrentValue == die2.dieCurrentValue)
                    {
                        score += die1.dieCurrentValue * 2;
                        score += die2.dieCurrentValue * 2;
                    }
                    else
                    {
                        score += die1.dieCurrentValue;
                        score += die2.dieCurrentValue;
                    }
                    

                    Console.WriteLine("Your final score is: " + score);
                    Console.WriteLine("The AI's final score is: " + AIScore);
                    Console.WriteLine();
                    break;
                }

                // If the user gets a double
                if (die1.dieCurrentValue == die2.dieCurrentValue)
                {
                    Console.WriteLine("You got: " + die1.dieCurrentValue + " and " + die2.dieCurrentValue);
                    Console.WriteLine("The AI got: " + die3.dieCurrentValue + " and " + die4.dieCurrentValue);
                    
                    Console.WriteLine("You got a Double!");
                    score += die1.dieCurrentValue * 2;
                    score += die2.dieCurrentValue * 2;

                    AIScore += die3.dieCurrentValue;
                    AIScore += die4.dieCurrentValue;

                    Console.WriteLine("Your current score is: " + score);
                    Console.WriteLine("The AI's current score is: " + AIScore);

                    Console.WriteLine();
                    Console.ReadKey();
                }

                // If the AI gets a double
                else if (die3.dieCurrentValue == die4.dieCurrentValue)
                {
                    Console.WriteLine("You got: " + die1.dieCurrentValue + " and " + die2.dieCurrentValue);
                    Console.WriteLine("The AI got: " + die3.dieCurrentValue + " and " + die4.dieCurrentValue);
                    
                    Console.WriteLine("The AI got a double!");
                    AIScore += die3.dieCurrentValue * 2;
                    AIScore += die4.dieCurrentValue * 2;

                    score += die1.dieCurrentValue; 
                    score += die2.dieCurrentValue;

                    Console.WriteLine("Your current score is: " + score);
                    Console.WriteLine("The AI's current score is: " + AIScore);

                    Console.WriteLine();
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("You got: " + die1.dieCurrentValue + " and " + die2.dieCurrentValue);
                    Console.WriteLine("The AI got: " + die3.dieCurrentValue + " and " + die4.dieCurrentValue);
                    score += die1.dieCurrentValue;
                    score += die2.dieCurrentValue;

                    AIScore += die3.dieCurrentValue;
                    AIScore += die4.dieCurrentValue;

                    Console.WriteLine("Your current score is: " + score);
                    Console.WriteLine("The AI's current score is: " + AIScore);
                    
                    Console.WriteLine();
                    Console.ReadKey();
                }


            }
            // Returns the score 
            return score;
        }

        public static int Player1Wins { get; set; }
        public static int Player2Wins { get; set; }

        public static int timesPlayed { get; set; }

        public static int testingSevensOut { get; set; }

        public static int testingSevensOut2 { get; set; }


        public int PlaySevensOutHM()
        {
            
            int Player1score = 0;
            int Player1total = 0;

            int Player2score = 0;
            int Player2total = 0;

            timesPlayed += 1;

            while (true)
            {

                Console.WriteLine("Player 1 roll!");
                Console.ReadKey();
                Player1total += die1.Roll();
                Player1total += die2.Roll();
                Console.WriteLine("Player 1 got: " + die1.dieCurrentValue + " and " + die2.dieCurrentValue);

                Console.WriteLine("Player 2 roll!");
                Console.ReadKey();
                Player2total += die3.Roll();
                Player2total += die4.Roll();
                Console.WriteLine("Player 2 got: " + die3.dieCurrentValue + " and " + die4.dieCurrentValue);
                Console.WriteLine();

                testingSevensOut = 0;

                testingSevensOut += die1.dieCurrentValue;
                testingSevensOut += die2.dieCurrentValue;
                
                testingSevensOut2 = 0;

                testingSevensOut2 += die3.dieCurrentValue;
                testingSevensOut2 += die4.dieCurrentValue;

                // Draw
                if (die1.dieCurrentValue + die2.dieCurrentValue == 7 && die3.dieCurrentValue + die4.dieCurrentValue == 7)
                {
                    if (Player1score == Player2score)
                    {
                        Console.WriteLine("Its a draw!");
                        Console.WriteLine("Player 1's final score is: " + Player1score);
                        Console.WriteLine("Player 2's final score is: " + Player2score);
                    }
                    else if (Player1score > Player2score)
                    {
                        Player1Wins += 1;
                        Console.WriteLine("Player 1 wins!");
                    }
                    else if (Player1score < Player2score)
                    {
                        Player2Wins += 1;
                        Console.WriteLine("Player 2 wins!");
                    }
                    Console.WriteLine();
                    break;
                }

                // If player 1 gets a 7
                if (die1.dieCurrentValue + die2.dieCurrentValue == 7)
                {
                    Console.WriteLine("Player 1 got a 7!");
                    if (die3.dieCurrentValue == die4.dieCurrentValue)
                    {
                        Player2score += die3.dieCurrentValue * 2;
                        Player2score += die4.dieCurrentValue * 2;
                    }
                    else
                    {
                        Player2score += die3.dieCurrentValue;
                        Player2score += die4.dieCurrentValue;
                    }

                    Console.WriteLine("Player 1's final score: " + Player1score);
                    Console.WriteLine("Player 2's final score: " + Player2score);
                    if (Player1score > Player2score)
                    {
                        Player1Wins += 1;
                        Console.WriteLine("Player 1 wins!");
                    }
                    else if (Player1score < Player2score)
                    {
                        Player2Wins += 1;
                        Console.WriteLine("Player 2 wins!");
                    }
                    
                    Console.WriteLine();
                    break;
                }
                // If Player 2 gets a 7
                else if (die3.dieCurrentValue + die4.dieCurrentValue == 7)
                {
                    Console.WriteLine("Player 2 got a 7!");

                    if (die1.dieCurrentValue == die2.dieCurrentValue)
                    {
                        Player1score += die1.dieCurrentValue * 2;
                        Player1score += die2.dieCurrentValue * 2;
                    }
                    else
                    {
                        Player1score += die1.dieCurrentValue;
                        Player1score += die2.dieCurrentValue;
                    }


                    Console.WriteLine("Player 1's final score: " + Player1score);
                    Console.WriteLine("Player 2's final score: " + Player2score);
                    if (Player1score > Player2score)
                    {
                        Player1Wins += 1;
                        Console.WriteLine("Player 1 wins!");
                    }
                    else if (Player1score < Player2score)
                    {
                        Player2Wins += 1;
                        Console.WriteLine("Player 2 wins!");
                    }
                    Console.WriteLine();
                    break;
                }

                // If player 1 gets a double
                if (die1.dieCurrentValue == die2.dieCurrentValue)
                {
                    Console.WriteLine("Player 1 got a double!");
                    Player1score += die1.dieCurrentValue * 2;
                    Player1score += die2.dieCurrentValue * 2;

                    Player2score += die3.dieCurrentValue;
                    Player2score += die4.dieCurrentValue;

                    Console.WriteLine("Player 1's current score: " + Player1score);
                    Console.WriteLine("Player 2's current score: " + Player2score);

                    Console.WriteLine();
                    
                }

                // If player 2 gets a double
                else if (die3.dieCurrentValue == die4.dieCurrentValue)
                {
                    Console.WriteLine("Player 2 got a double!");
                    Player2score += die3.dieCurrentValue * 2;
                    Player2score += die4.dieCurrentValue * 2;

                    Player1score += die1.dieCurrentValue;
                    Player1score += die2.dieCurrentValue;

                    Console.WriteLine("Player 1's current score: " + Player1score);
                    Console.WriteLine("Player 2's current score: " + Player2score);

                    Console.WriteLine();
                    
                }
                else
                {
                    Player1score += die1.dieCurrentValue;
                    Player1score += die2.dieCurrentValue;

                    Player2score += die3.dieCurrentValue;
                    Player2score += die4.dieCurrentValue;

                    Console.WriteLine("Player 1's current score is: " + Player1score);
                    Console.WriteLine("Player 2's current score is: " + Player2score);

                    Console.WriteLine();
                    
                }


            }
            // Returns the score 
            return Player1score;
        }
    }
   
}
