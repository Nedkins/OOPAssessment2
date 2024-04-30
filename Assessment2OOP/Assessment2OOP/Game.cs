using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2OOP
{
    // Game Class
    internal class Game
    {
        // Strings to hold users choices
        string gameOrTestingChoice;
        string gameChoice;

        

        // Game Constructor 
        public Game() 
        {
            while (true)

            {
                // Asks the user if they want games or stats and testing
                Console.WriteLine("Games [1], Stats and Testing [2] or exit [3]?");
                // Assigns users choice to the variable made earlier
                gameOrTestingChoice = Console.ReadLine();

                if (gameOrTestingChoice == "1")
                {
                    // Asks the user which game they want and assigns to variable
                    Console.WriteLine("Sevens out [1] or Three or More [2]?");
                    gameChoice = Console.ReadLine();

                    if (gameChoice == "1")
                    {
                        Console.WriteLine("Against AI [1] or human [2}?");
                        string sevensOutChoice = Console.ReadLine();
                        if (sevensOutChoice == "1")
                        {
                            Console.WriteLine("Playing against AI!");
                            Console.WriteLine();
                            SevensOut sevensOut = new SevensOut();
                            int sevensOutScore = sevensOut.PlaySevensOutAI();
                            
                        }
                        if (sevensOutChoice == "2")
                        {
                            Console.WriteLine("Two player mode!");
                            Console.WriteLine();
                            SevensOut sevensOut = new SevensOut();
                            int sevensOutScore = sevensOut.PlaySevensOutHM();
                            
                        }
                        
                    }
                    // Three or more selection. 
                    if (gameChoice == "2")
                    {
                        Console.WriteLine("Against AI [1] or human [2}?");
                        string sevensOutChoice = Console.ReadLine();
                        if (sevensOutChoice == "1")
                        {
                            Console.WriteLine("Playing against AI!");
                            Console.WriteLine();
                            ThreeOrMore threeOrMore = new ThreeOrMore();
                            int threeOrMoreScore = threeOrMore.PlayThreeOrMoreAI();
                            
                           
                        }
                        if (sevensOutChoice == "2")
                        {
                            Console.WriteLine("Two player mode!");
                            Console.WriteLine();
                            ThreeOrMore threeOrMore = new ThreeOrMore();
                            int threeOrMoreScore = threeOrMore.PlayThreeOrMoreHM();
                            
                        }


                    }
                    
                }
                if (gameOrTestingChoice == "2")
                {
                    while (true)
                    {
                        Console.WriteLine("View statistics [1] or perform testing [2]?");
                        string statsOrTesting = Console.ReadLine();
                        if (statsOrTesting == "1")
                        {
                            Statistics statistics = new Statistics();
                            Console.WriteLine();
                            break;
                        }
                        if (statsOrTesting == "2")
                        {
                            while (true)
                            {
                                Console.WriteLine("Sevens Out [1] or Three or More [2]?");
                                string testingGameChoice = Console.ReadLine();
                                if (testingGameChoice == "1")
                                {
                                    Testing.SevensOutTesting();
                                    Console.WriteLine();
                                    break;
                                }
                                if (testingGameChoice == "2")
                                {
                                    Testing.ThreeOrMoreTesting();
                                    Console.WriteLine();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Enter a valid option");
                                }
                                
                            }
                            break;

                        }
                        else
                        {
                            Console.WriteLine("Invalid input");
                            Console.WriteLine();
                        }

                        
                    }

                    
                }
                if (gameOrTestingChoice == "3")
                {
                    Console.WriteLine("Thank you for playing, goodbye");
                    break;
                }
                
            }
        }
    }
}
