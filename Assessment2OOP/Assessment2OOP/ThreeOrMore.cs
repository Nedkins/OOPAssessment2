using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2OOP
{
    internal class ThreeOrMore
    {
        // Stores the random object for number generation
        private Random _rng;
        
        // Creates the first 5 die objects
        public Die die1;
        public Die die2;
        public Die die3;
        public Die die4;
        public Die die5;

        // Creates the second 5 die objects
        public Die die6;
        public Die die7;
        public Die die8;
        public Die die9;
        public Die die10;

        public ThreeOrMore() 
        {
            Console.WriteLine("Welcome to Three or More");

            // Initliaze the random object
            _rng = new Random();
            // Creates the die objects
            die1 = new Die(_rng);
            die2 = new Die(_rng);
            die3 = new Die(_rng);
            die4 = new Die(_rng); 
            die5 = new Die(_rng);


            // Die for player 2 
            die6 = new Die(_rng);
            die7 = new Die(_rng);
            die8 = new Die(_rng);
            die9 = new Die(_rng);
            die10 = new Die(_rng);



            Console.WriteLine("Press any key to play!");
            Console.ReadKey();
        }

        public int PlayThreeOrMoreAI()
        {
            int playerScore = 0;
            int AIscore = 0;
            while (true)
            {
                bool player1done = false;
                bool player2done = false;

                if (playerScore >= 20 || AIscore >= 20)
                {
                    if (playerScore >= 20 && AIscore >= 20)
                    {
                        Console.WriteLine("It's a tie!");
                        Console.WriteLine();
                    }
                        
                    else if (playerScore >= 20)
                    {
                        Console.WriteLine("Congratulations player 1 won!");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("AI wins!");
                        Console.WriteLine();
                    }   
                    break;
                }

                // Human
                rollPlayer1();

                // AI Player
                rollPlayer2();

                Console.WriteLine();
                Console.WriteLine("Your dice are the following values:");
                DisplayPlayer1();
                Console.WriteLine("The computer got the following values:");
                DisplayPlayer2();


                // Makes Linq list of player1 dice
                List<int> player1Dices = new List<int>();

                // Adds to list
                player1Dices.Add(die1.dieCurrentValue);
                player1Dices.Add(die2.dieCurrentValue);
                player1Dices.Add(die3.dieCurrentValue);
                player1Dices.Add(die4.dieCurrentValue);
                player1Dices.Add(die5.dieCurrentValue);

                var duplicateCounts = player1Dices.GroupBy(x => x)
                                                  .Where(g => g.Count() > 1)
                                                  .Select(g => new { Value = g.Key, Count = g.Count() });

                // Finds if there are duplicates, starts at 5 and works down to 2
                foreach (var item in duplicateCounts)
                {
                    if (item.Count == 5 && player1done == false)
                    {
                        player1done = true;
                        Console.WriteLine($"{item.Value} is found 5 times!");
                        playerScore += 12;
                    }
                    else if (item.Count == 4 && player1done == false)
                    {
                        player1done = true;
                        Console.WriteLine($"{item.Value} is found 4 times!");
                        playerScore += 6;
                    }
                    else if (item.Count == 3 && player1done == false)
                    {
                        player1done = true;
                        Console.WriteLine($"{item.Value} is found 3 times!");
                        playerScore += 3;
                    }

                    else if (item.Count == 2 && player1done == false)
                    {
                        Console.WriteLine($"{item.Value} is found 2 times!");
                        player1done = true;
                        while (true)
                        {
                            Console.WriteLine("Would you like to roll all [1] or roll non matching [2]?");
                            string rollChoice = Console.ReadLine();
                            if (rollChoice == "1")
                            {
                                rollPlayer1();
                                Console.WriteLine("Your dice are the following values:");
                                DisplayPlayer1();
                                // Makes Linq list of player1 dice
                                List<int> player1Dices2 = new List<int>();

                                // Adds to list
                                player1Dices2.Add(die1.dieCurrentValue);
                                player1Dices2.Add(die2.dieCurrentValue);
                                player1Dices2.Add(die3.dieCurrentValue);
                                player1Dices2.Add(die4.dieCurrentValue);
                                player1Dices2.Add(die5.dieCurrentValue);

                                var duplicateCounts2 = player1Dices2.GroupBy(x => x)
                                                                  .Where(g => g.Count() > 1)
                                                                  .Select(g => new { Value = g.Key, Count = g.Count() });
                                foreach (var item2 in duplicateCounts2)
                                {
                                    if (item2.Count == 5)
                                    {
                                        Console.WriteLine($"{item2.Value} is found 5 times!");
                                        playerScore += 12;
                                    }
                                    else if (item2.Count == 4)
                                    {
                                        Console.WriteLine($"{item2.Value} is found 4 times!");
                                        playerScore += 6;
                                    }
                                    else if (item2.Count == 3)
                                    {
                                        Console.WriteLine($"{item2.Value} is found 3 times!");
                                        playerScore += 3;
                                    }
                                    
                                }
                                break;
                            }
                            else if (rollChoice == "2")
                            {
                                Console.WriteLine("Rolling non-duplicate dice...");

                                // List to store the indices of non-duplicate dice
                                List<int> nonDuplicateIndices = new List<int>();

                                // Find the indices of non-duplicate dice
                                for (int i = 0; i < player1Dices.Count; i++)
                                {
                                    if (player1Dices[i] != item.Value)
                                    {
                                        nonDuplicateIndices.Add(i);
                                    }
                                }

                                // Roll the non-duplicate dice
                                foreach (var index in nonDuplicateIndices)
                                {
                                    RollDieByIndex(index);
                                    
                                }
                                DisplayPlayer1();
                                // Makes Linq list of player1 dice
                                List<int> player1Dices2 = new List<int>();

                                // Adds to list
                                player1Dices2.Add(die1.dieCurrentValue);
                                player1Dices2.Add(die2.dieCurrentValue);
                                player1Dices2.Add(die3.dieCurrentValue);
                                player1Dices2.Add(die4.dieCurrentValue);
                                player1Dices2.Add(die5.dieCurrentValue);

                                var duplicateCounts2 = player1Dices2.GroupBy(x => x)
                                                                  .Where(g => g.Count() > 1)
                                                                  .Select(g => new { Value = g.Key, Count = g.Count() });
                                int roundScore = 0;
                                foreach (var item2 in duplicateCounts2)
                                {
                                    if (item2.Count == 5)
                                    {
                                        Console.WriteLine($"{item2.Value} is found 5 times!");
                                        roundScore += 12;
                                        
                                    }
                                    else if (item2.Count == 4)
                                    {
                                        Console.WriteLine($"{item2.Value} is found 4 times!");
                                        roundScore += 6;
                                        
                                    }
                                    else if (item2.Count == 3)
                                    {
                                        Console.WriteLine($"{item2.Value} is found 3 times!");
                                        roundScore += 3;
                                        
                                    }
                                }
                                playerScore += roundScore;
                                break;
                            }
                            
                            else
                            {
                                Console.WriteLine("Enter Valid Choice");
                            }
                        }
                    }
                    
                }


                // COMPUTER AI
                // Makes Linq list of player1 dice
                List<int> player2Dices = new List<int>();

                // Adds to list
                player2Dices.Add(die6.dieCurrentValue);
                player2Dices.Add(die7.dieCurrentValue);
                player2Dices.Add(die8.dieCurrentValue);
                player2Dices.Add(die9.dieCurrentValue);
                player2Dices.Add(die10.dieCurrentValue);

                var duplicateCounts3 = player2Dices.GroupBy(x => x)
                                                  .Where(g => g.Count() > 1)
                                                  .Select(g => new { Value = g.Key, Count = g.Count() });

                // Finds if there are duplicates, starts at 5 and works down to 2
                foreach (var item4 in duplicateCounts3)
                {
                    if (item4.Count == 5 && player2done == false)
                    {
                        player2done = true;
                        Console.WriteLine($"{item4.Value} is found 5 times!");
                        AIscore += 12;
                    }
                    else if (item4.Count == 4 && player2done == false)
                    {
                        player2done = true;
                        Console.WriteLine($"{item4.Value} is found 4 times!");
                        AIscore += 6;
                    }
                    else if (item4.Count == 3 && player2done == false)
                    {
                        player2done = true;
                        Console.WriteLine($"{item4.Value} is found 3 times!");
                        AIscore += 3;
                    }

                    else if (item4.Count == 2 && player2done == false)
                    {
                        Console.WriteLine("Player 2 rolling non duplicates!");

                        // List to store the indices of non-duplicate dice
                        List<int> nonDuplicateIndices2 = new List<int>();

                        // Find the indices of non-duplicate dice
                        for (int i = 0; i < player2Dices.Count; i++)
                        {
                            if (player2Dices[i] != item4.Value)
                            {
                                nonDuplicateIndices2.Add(i);
                            }
                        }

                        // Roll the non-duplicate dice
                        foreach (var index in nonDuplicateIndices2)
                        {
                            RollDieByIndex2(index);
                        }
                        DisplayPlayer2();

                        // Count duplicates in AI's rerolled dice
                        List<int> player2RerolledDices = new List<int>();
                        player2RerolledDices.Add(die6.dieCurrentValue);
                        player2RerolledDices.Add(die7.dieCurrentValue);
                        player2RerolledDices.Add(die8.dieCurrentValue);
                        player2RerolledDices.Add(die9.dieCurrentValue);
                        player2RerolledDices.Add(die10.dieCurrentValue);

                        var duplicateCounts4 = player2RerolledDices.GroupBy(x => x)
                                                                  .Where(g => g.Count() > 1)
                                                                  .Select(g => new { Value = g.Key, Count = g.Count() });
                        int roundScore = 0;
                        foreach (var item5 in duplicateCounts4)
                        {
                            if (item5.Count == 5)
                            {
                                Console.WriteLine($"{item5.Value} is found 5 times!");
                                roundScore += 12;
                            }
                            else if (item5.Count == 4)
                            {
                                Console.WriteLine($"{item5.Value} is found 4 times!");
                                roundScore += 6;
                            }
                            else if (item5.Count == 3)
                            {
                                Console.WriteLine($"{item5.Value} is found 3 times!");
                                roundScore += 3;
                            }
                        }
                        AIscore += roundScore;
                        break;
                    }


                }
                Console.WriteLine("Your score is: " + playerScore);
                Console.WriteLine("The AI has a score of: " + AIscore);
                Console.ReadKey();
            }
            int total = 0;

            return total;
        }
        private void DisplayPlayer1()
        {
            Console.WriteLine(die1.dieCurrentValue + " " + die2.dieCurrentValue + " " + die3.dieCurrentValue + " " + die4.dieCurrentValue + " " + die5.dieCurrentValue);
        }
        private void DisplayPlayer2()
        {
            Console.WriteLine(die6.dieCurrentValue + " " + die7.dieCurrentValue + " " + die8.dieCurrentValue + " " + die9.dieCurrentValue + " " + die10.dieCurrentValue);
        }

        private void rollPlayer1()
        {
            die1.Roll();
            die2.Roll();
            die3.Roll();
            die4.Roll();
            die5.Roll();
        }
        private void rollPlayer2()
        {
            die6.Roll();
            die7.Roll();
            die8.Roll();
            die9.Roll();
            die10.Roll();
        }
        // Method takes an int as an input, depending on 
        private void RollDieByIndex(int index)
        {
            if (index == 0)
            {
                die1.Roll();
            }
            else if (index == 1)
            {
                die2.Roll();
            }
            else if (index == 2)
            {
                die3.Roll();
            }
            else if (index == 3)
            {
                die4.Roll();
            }
            else if (index == 4)
            {
                die5.Roll();
            }
            else
            {
                Console.WriteLine("Invalid die index.");
            }
        }
        private void RollDieByIndex2(int index)
        {
            if (index == 0)
            {
                die6.Roll();
            }
            else if (index == 1)
            {
                die7.Roll();
            }
            else if (index == 2)
            {
                die8.Roll();
            }
            else if (index == 3)
            {
                die9.Roll();
            }
            else if (index == 4)
            {
                die10.Roll();
            }
            else
            {
                Console.WriteLine("Invalid die index.");
            }
        }





        // 2 Player Mode!
        public static int Player1Wins2 { get; set; }
        public static int Player2Wins2 { get; set; }

        public static int timesPlayed { get; set; }

        public static int testingPlayer1 { get; set; }

        public static int testingPlayer2 { get; set; }



        public int PlayThreeOrMoreHM()
        {
            int playerScore = 0;
            int AIscore = 0;

            testingPlayer1 = 0;
            testingPlayer2 = 0;

            timesPlayed += 1;

            while (true)
            {
                bool player1done = false;
                bool player2done = false;

                if (playerScore >= 20 || AIscore >= 20)
                {
                    if (playerScore >= 20 && AIscore >= 20)
                    {
                        Console.WriteLine("It's a tie!");
                        Console.WriteLine();
                    }

                    else if (playerScore >= 20)
                    {
                        Console.WriteLine("Congratulations player 1 won!");
                        Console.WriteLine();
                        Player1Wins2 += 1;
                    }
                    else
                    {
                        Console.WriteLine("Player 2 wins!");
                        Console.WriteLine();
                        Player2Wins2 += 1;
                    }
                    break;
                }

                // Human
                rollPlayer1();

                // AI Player
                rollPlayer2();

                Console.WriteLine("Press enter to roll Player 1!");
                Console.ReadKey();
                Console.WriteLine();
                Console.WriteLine("Your dice are the following values:");
                DisplayPlayer1();
                Console.WriteLine("Press enter to roll Player 2!");
                Console.ReadKey();
                Console.WriteLine();   
                Console.WriteLine("Player Two got the follwing values:");
                DisplayPlayer2();

                Console.WriteLine();
                Console.WriteLine("Player 1:");
                // Makes Linq list of player1 dice
                List<int> player1Dices = new List<int>();

                // Adds to list
                player1Dices.Add(die1.dieCurrentValue);
                player1Dices.Add(die2.dieCurrentValue);
                player1Dices.Add(die3.dieCurrentValue);
                player1Dices.Add(die4.dieCurrentValue);
                player1Dices.Add(die5.dieCurrentValue);

                var duplicateCounts = player1Dices.GroupBy(x => x)
                                                  .Where(g => g.Count() > 1)
                                                  .Select(g => new { Value = g.Key, Count = g.Count() });

                // Finds if there are duplicates, starts at 5 and works down to 2
                foreach (var item in duplicateCounts)
                {
                    if (item.Count == 5 && player1done == false)
                    {
                        player1done = true;
                        Console.WriteLine($"{item.Value} is found 5 times!");
                        playerScore += 12;
                        testingPlayer1 += 12;
                        break;
                    }
                    else if (item.Count == 4 && player1done == false)
                    {
                        player1done = true;
                        Console.WriteLine($"{item.Value} is found 4 times!");
                        playerScore += 6;
                        testingPlayer1 += 6;
                        break;
                    }
                    else if (item.Count == 3 && player1done == false)
                    {
                        player1done = true;
                        Console.WriteLine($"{item.Value} is found 3 times!");
                        playerScore += 3;
                        testingPlayer1 = 3;
                        break;
                    }

                    else if (item.Count == 2 && player1done == false)
                    {
                        Console.WriteLine($"There are two duplicates of value {item.Value}.");
                        player1done = true;
                        while (true)
                        {
                            Console.WriteLine("Would you like to roll all [1] or roll non matching [2]?");
                            string rollChoice = Console.ReadLine();
                            if (rollChoice == "1")
                            {
                                rollPlayer1();
                                Console.WriteLine("Your dice are the following values:");
                                DisplayPlayer1();
                                // Makes Linq list of player1 dice
                                List<int> player1Dices2 = new List<int>();

                                // Adds to list
                                player1Dices2.Add(die1.dieCurrentValue);
                                player1Dices2.Add(die2.dieCurrentValue);
                                player1Dices2.Add(die3.dieCurrentValue);
                                player1Dices2.Add(die4.dieCurrentValue);
                                player1Dices2.Add(die5.dieCurrentValue);

                                var duplicateCounts2 = player1Dices2.GroupBy(x => x)
                                                                  .Where(g => g.Count() > 1)
                                                                  .Select(g => new { Value = g.Key, Count = g.Count() });
                                foreach (var item2 in duplicateCounts2)
                                {
                                    if (item2.Count == 5)
                                    {
                                        Console.WriteLine($"{item2.Value} is found 5 times!");
                                        playerScore += 12;
                                        testingPlayer1 = 12;
                                    }
                                    else if (item2.Count == 4)
                                    {
                                        Console.WriteLine($"{item2.Value} is found 4 times!");
                                        playerScore += 6;
                                        testingPlayer1 = 6;
                                    }
                                    else if (item2.Count == 3)
                                    {
                                        Console.WriteLine($"{item2.Value} is found 3 times!");
                                        playerScore += 3;
                                        testingPlayer1 = 3;
                                    }

                                }
                                break;
                            }
                            else if (rollChoice == "2")
                            {
                                Console.WriteLine("Rolling non-duplicate dice...");

                                // List to store the indices of non-duplicate dice
                                List<int> nonDuplicateIndices = new List<int>();

                                // Find the indices of non-duplicate dice
                                for (int i = 0; i < player1Dices.Count; i++)
                                {
                                    if (player1Dices[i] != item.Value)
                                    {
                                        nonDuplicateIndices.Add(i);
                                    }
                                }

                                // Roll the non-duplicate dice
                                foreach (var index in nonDuplicateIndices)
                                {
                                    RollDieByIndex(index);

                                }
                                DisplayPlayer1();
                                // Makes Linq list of player1 dice
                                List<int> player1Dices2 = new List<int>();

                                // Adds to list
                                player1Dices2.Add(die1.dieCurrentValue);
                                player1Dices2.Add(die2.dieCurrentValue);
                                player1Dices2.Add(die3.dieCurrentValue);
                                player1Dices2.Add(die4.dieCurrentValue);
                                player1Dices2.Add(die5.dieCurrentValue);

                                var duplicateCounts2 = player1Dices2.GroupBy(x => x)
                                                                  .Where(g => g.Count() > 1)
                                                                  .Select(g => new { Value = g.Key, Count = g.Count() });
                                int roundScore = 0;
                                foreach (var item2 in duplicateCounts2)
                                {
                                    if (item2.Count == 5)
                                    {
                                        Console.WriteLine($"{item2.Value} is found 5 times!");
                                        roundScore += 12;
                                        testingPlayer1 += 12;

                                    }
                                    else if (item2.Count == 4)
                                    {
                                        Console.WriteLine($"{item2.Value} is found 4 times!");
                                        roundScore += 6;
                                        testingPlayer1 += 6;

                                    }
                                    else if (item2.Count == 3)
                                    {
                                        Console.WriteLine($"{item2.Value} is found 3 times!");
                                        roundScore += 3;
                                        testingPlayer1 += 3;

                                    }
                                }
                                playerScore += roundScore;
                                break;
                            }

                            else
                            {
                                Console.WriteLine("Enter Valid Choice");
                            }
                        }
                    }

                }

                Console.WriteLine();
                Console.WriteLine("Player 2:");
                // Player 2!
                // Makes Linq list of player2 dice
                List<int> player2Dices = new List<int>();

                // Adds to list
                player2Dices.Add(die6.dieCurrentValue);
                player2Dices.Add(die7.dieCurrentValue);
                player2Dices.Add(die8.dieCurrentValue);
                player2Dices.Add(die9.dieCurrentValue);
                player2Dices.Add(die10.dieCurrentValue);

                var duplicateCounts3 = player2Dices.GroupBy(x => x)
                                                  .Where(g => g.Count() > 1)
                                                  .Select(g => new { Value = g.Key, Count = g.Count() });

                // Finds if there are duplicates, starts at 5 and works down to 2
                foreach (var item4 in duplicateCounts3)
                {
                    if (item4.Count == 5 && player2done == false)
                    {
                        player2done = true;
                        Console.WriteLine($"{item4.Value} is found 5 times!");
                        AIscore += 12;
                        testingPlayer2 += 12;
                        break;
                    }
                    else if (item4.Count == 4 && player2done == false)
                    {
                        player2done = true;
                        Console.WriteLine($"{item4.Value} is found 4 times!");
                        AIscore += 6;
                        testingPlayer2 += 6;
                        break;
                    }
                    else if (item4.Count == 3 && player2done == false)
                    {
                        player2done = true;
                        Console.WriteLine($"{item4.Value} is found 3 times!");
                        AIscore += 3;
                        testingPlayer2 += 3;
                        break;
                    }


                    // Area to fix and a choice for player 2
                    else if (item4.Count == 2 && player2done == false)
                    {
                        Console.WriteLine("Would you like to roll all [1] or roll non matching [2]?");
                        string rollChoice = Console.ReadLine();
                        if (rollChoice == "1")
                        {
                            rollPlayer2();
                            Console.WriteLine("Your dice are the following values:");
                            DisplayPlayer2();
                            // Makes Linq list of player1 dice
                            List<int> player2Dices2 = new List<int>();

                            // Adds to list
                            player2Dices2.Add(die6.dieCurrentValue);
                            player2Dices2.Add(die7.dieCurrentValue);
                            player2Dices2.Add(die8.dieCurrentValue);
                            player2Dices2.Add(die9.dieCurrentValue);
                            player2Dices2.Add(die10.dieCurrentValue);

                            var duplicateCounts2 = player2Dices2.GroupBy(x => x)
                                                              .Where(g => g.Count() > 1)
                                                              .Select(g => new { Value = g.Key, Count = g.Count() });
                            foreach (var item5 in duplicateCounts2)
                            {
                                if (item5.Count == 5)
                                {
                                    Console.WriteLine($"{item5.Value} is found 5 times!");
                                    AIscore += 12;
                                    testingPlayer2 += 12;
                                }
                                else if (item5.Count == 4)
                                {
                                    Console.WriteLine($"{item5.Value} is found 4 times!");
                                    AIscore += 6;
                                    testingPlayer2 += 6;
                                }
                                else if (item5.Count == 3)
                                {
                                    Console.WriteLine($"{item5.Value} is found 3 times!");
                                    AIscore += 3;
                                    testingPlayer2 += 3;
                                }

                            }
                            break;
                        }
                        else if (rollChoice == "2")
                        {
                            Console.WriteLine("Player 2 rolling non duplicates!");

                            // List to store the indices of non-duplicate dice
                            List<int> nonDuplicateIndices2 = new List<int>();

                            // Find the indices of non-duplicate dice
                            for (int i = 0; i < player2Dices.Count; i++)
                            {
                                if (player2Dices[i] != item4.Value)
                                {
                                    nonDuplicateIndices2.Add(i);
                                }
                            }

                            // Roll the non-duplicate dice
                            foreach (var index in nonDuplicateIndices2)
                            {
                                RollDieByIndex2(index);
                            }
                            DisplayPlayer2();

                            // Count duplicates in AI's rerolled dice
                            List<int> player2RerolledDices = new List<int>();
                            player2RerolledDices.Add(die6.dieCurrentValue);
                            player2RerolledDices.Add(die7.dieCurrentValue);
                            player2RerolledDices.Add(die8.dieCurrentValue);
                            player2RerolledDices.Add(die9.dieCurrentValue);
                            player2RerolledDices.Add(die10.dieCurrentValue);

                            var duplicateCounts4 = player2RerolledDices.GroupBy(x => x)
                                                                      .Where(g => g.Count() > 1)
                                                                      .Select(g => new { Value = g.Key, Count = g.Count() });
                            int roundScore = 0;
                            foreach (var item5 in duplicateCounts4)
                            {
                                if (item5.Count == 5)
                                {
                                    Console.WriteLine($"{item5.Value} is found 5 times!");
                                    roundScore += 12;
                                    testingPlayer2 += 12;
                                }
                                else if (item5.Count == 4)
                                {
                                    Console.WriteLine($"{item5.Value} is found 4 times!");
                                    roundScore += 6;
                                    testingPlayer2 += 6;
                                }
                                else if (item5.Count == 3)
                                {
                                    Console.WriteLine($"{item5.Value} is found 3 times!");
                                    roundScore += 3;
                                    testingPlayer2 += 3;
                                }
                            }
                            AIscore += roundScore;
                            break;
                        }
                    }

                }
                Console.WriteLine("Player 1's score is: " + playerScore);
                Console.WriteLine("Player 2's score is: " + AIscore);
                Console.ReadKey();
            }
            int total = 0;

            return total;
        }
    }
}
