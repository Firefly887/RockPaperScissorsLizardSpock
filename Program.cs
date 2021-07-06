using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Convert;

namespace RockPaperScissorsLizardSpock
{
    class Program
    {
        static string myChoice;
        static string opponentChoice;
        static int round;
        static string weaponChoice;
        static int myChoiceInt;

        static int WhoWins(int myChoice, string opponentChoice)
        {
            string[] message = { "Paper covers Rock", "Rock crushes Scissors", "Rock crushes Lizard", "Spock vaporizes Rock", "Scissors cut Paper", "Lizard eats Paper", "Paper disproves Spock", "Scissors decapitates Lizard", "Spock smashes Scissors", "Lizard poisons Spock" };
            if (myChoice == 1)
            {
                switch (opponentChoice)
                {
                    case "PAPER":
                        WriteLine(message[0]);
                        return 2;
                    case "SCISSORS":
                        WriteLine(message[1]);
                        return 1;
                    case "LIZARD":
                        WriteLine(message[2]);
                        return 1;
                    case "SPOCK":
                        WriteLine(message[3]);
                        return 2;
                    default:
                        return 3;
                }
            }
            if (myChoice == 2)
            {
                switch (opponentChoice)
                {
                    case "ROCK":
                        WriteLine(message[0]);
                        return 1;
                    case "SCISSORS":
                        WriteLine(message[4]);
                        return 2;
                    case "LIZARD":
                        WriteLine(message[5]);
                        return 2;
                    case "SPOCK":
                        WriteLine(message[6]);
                        return 1;
                    default:
                        return 3;
                }
            }
            if (myChoice == 3)
            {
                switch (opponentChoice)
                {
                    case "ROCK":
                        WriteLine(message[1]);
                        return 2;
                    case "PAPER":
                        WriteLine(message[4]);
                        return 1;
                    case "LIZARD":
                        WriteLine(message[7]);
                        return 1;
                    case "SPOCK":
                        WriteLine(message[8]);
                        return 2;
                    default:
                        return 3;
                }
            }
            if (myChoice == 4)
            {
                switch (opponentChoice)
                {
                    case "ROCK":
                        WriteLine(message[2]);
                        return 2;
                    case "PAPER":
                        WriteLine(message[5]);
                        return 1;
                    case "SCISSORS":
                        WriteLine(message[7]);
                        return 2;
                    case "SPOCK":
                        WriteLine(message[9]);
                        return 1;
                    default:
                        return 3;
                }
            }
            else
            {
                switch (opponentChoice)
                {
                    case "ROCK":
                        WriteLine(message[3]);
                        return 1;
                    case "PAPER":
                        WriteLine(message[6]);
                        return 2;
                    case "SCISSORS":
                        WriteLine(message[8]);
                        return 1;
                    case "LIZARD":
                        WriteLine(message[9]);
                        return 2;
                    default:
                        return 3;
                }
            }
        }

        static string WeaponChoice(int Choice)
        {
            string[] myWeapon = { "INVALID", "ROCK", "PAPER", "SCISSORS", "LIZARD", "SPOCK" };
            return myWeapon[Choice];
        }

        static void Round(int roundNo)
        {
            WriteLine($"Round {roundNo}!");
            WriteLine("Choose a weapon:");
            WriteLine("1) ROCK.");
            WriteLine("2) PAPER.");
            WriteLine("3) SCISSORS.");
            WriteLine("4) LIZARD.");
            WriteLine("5) SPOCK.");
            WriteLine("(Press 'q' to quit)");
            Program.weaponChoice = ReadLine();
        }
        static void MainGame()
        {
            Random r = new Random();
            WriteLine("ROCK, PAPER, SCISSORS, LIZARD, SPOCK!");
            WriteLine("=====================================");
            bool result = false;
            int opponentChoiceInt = 0;
            int myScore = 0;
            int opponentScore = 0;
            int winner = 0;
            for (round = 1;; round++)
            {
                Round(round);
                do
                {
                    if (Program.weaponChoice == "q")
                        goto endOfLoop;
                    result = int.TryParse(Program.weaponChoice, out myChoiceInt);
                    if (result == false)
                    {
                        WriteLine("Please choose a number between 1 and 5!");
                        Round(round);
                    }
                    if (Program.myChoiceInt > 5)
                    {
                        WriteLine("Please choose a number between 1 and 5!");
                        Round(round);
                    }
                } while (Program.myChoiceInt == 0);
                opponentChoiceInt = r.Next(1, 5);
                Program.myChoice = WeaponChoice(Program.myChoiceInt);
                Program.opponentChoice = WeaponChoice(opponentChoiceInt);
                WriteLine($"You Chose: {Program.myChoice}");
                WriteLine($"Opponent chose: {Program.opponentChoice}");
                winner = WhoWins(Program.myChoiceInt, Program.opponentChoice);
                if (winner == 1)
                {
                    WriteLine($"You won round {round}");
                    myScore++;
                }
                else if (winner == 2)
                {
                    WriteLine($"Opponent won round {round}");
                    opponentScore++;
                }
                else if (winner == 3)
                    WriteLine($"Round {round} was tied!");
                WriteLine($"Your Score: {myScore}");
                WriteLine($"Opponent Score: {opponentScore}");
                WriteLine("=================================");
                if ((myScore == 3) || (opponentScore == 3))
                    break;
            }
            endOfLoop:
            WriteLine("=================================");
            if (myScore > opponentScore)
                WriteLine("You Are Victorious!");
            if (opponentScore > myScore)
                WriteLine("Opponent Is Victorious!");
            if (myScore == opponentScore)
                WriteLine("Game Is Tied!");
            WriteLine("Would you like to play again?\nYes/No");
            string replay = ReadLine();
            replay = replay.ToUpper();
            if ((replay == "Y") || (replay == "YES"))
                MainGame();
            else
            {
                WriteLine("Press any key to quit");
                ReadKey();
            }
        }
        static void Main(string[] args)
        {
            MainGame();
        }
    }
}