using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class Program
    {
        public static int roundsInput;
        public static bool roundsInRange = false;
        public static string player;

        static void Main(string[] args)
        {
            string numOfRounds;

            while (!roundsInRange)
            {
                Console.WriteLine("Rock Paper Scissors [Max rounds is 10]");
                Console.WriteLine("Enter the number of rounds: ");
                numOfRounds = Console.ReadLine();

                if (!int.TryParse(numOfRounds, out roundsInput) || roundsInput < 1 || roundsInput > 10)
                {
                    roundsInRange = false;
                    Console.WriteLine("Invalid input.");
                    break;
                }

                roundsInRange = true;
                PlayGame(roundsInput);

                string playAgain;
                Console.WriteLine("Would you like to play again? Type: y/n");
                playAgain = Console.ReadLine().ToLower();

                if (playAgain == "y")
                {
                    roundsInRange = false;
                }
                else if (playAgain == "n")
                {
                    Console.WriteLine("Thanks for playing!");
                    break;
                }
                else
                {
                    break;
                }

            }

        }

        public static void PlayGame(int rounds)
        {
            string selectMode;
            int inputMode;
            int countRounds = 0;
            int countWins = 0;
            int countLoses = 0;
            int countTies = 0;

            List<string> rpsList = new List<string> { "rock", "paper", "scissors" };

            Random r = new Random();

            do
            {
                if (roundsInRange)
                {
                    for (int round = 0; round < rounds; round++)
                    {
                        Console.WriteLine("Choose Rock, Paper, or Scissors: ");
                        Console.WriteLine("1 - Rock");
                        Console.WriteLine("2 - Paper");
                        Console.WriteLine("3 - Scissors");
                        selectMode = Console.ReadLine();

                        string opponent = rpsList[r.Next(0, rpsList.Count)];

                        if (int.TryParse(selectMode, out inputMode))
                        {
                            switch (inputMode)
                            {
                                case 1:
                                    player = "rock";
                                    break;
                                case 2:
                                    player = "paper";
                                    break;
                                case 3:
                                    player = "scissors";
                                    break;
                                default:
                                    Console.WriteLine("Invalid input");
                                    round--;
                                    continue;
                            }
                        }

                        if (player == opponent)
                            countTies++;
                        else if (player == "rock" && opponent == "scissors"
                            || player == "paper" && opponent == "rock"
                            || player == "scissors" && opponent == "paper")
                            countWins++;
                        else countLoses++;

                        countRounds++;
                        Console.WriteLine($"Opponent Answer: {opponent}");
                        Console.WriteLine($"Ties: {countTies} Wins: {countWins} Loses: {countLoses}");
                    }

                    if (countWins > countLoses)
                    {
                        Console.WriteLine("You win!");
                    }
                    else if (countWins == countLoses)
                    {
                        Console.WriteLine("Tie!");
                    }
                    else
                    {
                        Console.WriteLine("You Lose!");
                    }
                    roundsInRange = false;
                }
            } while (roundsInRange);
        }
    }
}
