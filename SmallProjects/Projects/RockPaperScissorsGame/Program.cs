using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsGame
{
    public class Player
    {
        public String choice { get; set; }
    }
    public class Computer
    {
        public int computerChoice { get; set; }

        public static int DisplayMessage(String player, int computer)
        {
            if (player == "ROCK")
            {
                if (computer == 1)
                {
                    return 0;
                }
                else if (computer == 2)
                {
                    return 2;
                }
                else if (computer == 3)
                {
                    return 1;
                }
            }
            else if (player == "PAPER")
            {
                if (computer == 1)
                {
                    return 1;
                }
                else if (computer == 2)
                {
                    return 0;
                }
                else if (computer == 3)
                {
                    return 2;
                }
            }
            else if (player == "SCISSORS")
            {
                if (computer == 1)
                {
                    return 2;
                }
                else if (computer == 2)
                {
                    return 1;
                }
                else if (computer == 3)
                {
                    return 0;
                }
            }
            return 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            bool playAgain = true;

            //While Loop that controls how much times the game is initiated
            //On load <set = true>
            while (playAgain)
            {
                //Declaration and initialization of local vcariables
                int numberOfRounds = 3;
                int playerScore = 0;
                int computerScore = 0;

                while (numberOfRounds != 0)
                {
                    //<Creates a new object of the player class to get access to its fields>
                    Player player = new Player();

                    Console.WriteLine("===================== ROCK PAPER SCISSORS =======================");
                    Console.WriteLine("ROCK PAPER OR SCISSORS? ");
                    player.choice = Console.ReadLine();
                    player.choice = player.choice.ToUpper();

                    Random rnd = new Random(); //System.random fucntion
                    Computer com = new Computer();
                    com.computerChoice = rnd.Next(1, 4); //<This constructir is used, The system provides three(3) constructors>
                    switch (com.computerChoice)
                    {
                        case 1:
                            Console.WriteLine("Computer selected - ROCK");
                            break;
                        case 2:
                            Console.WriteLine("Computer selected - PAPER");
                            break;
                        case 3:
                            Console.WriteLine("Computer Selected - SCISSORS");
                            break;
                        default:
                            Console.WriteLine("Not an appropriate value retrieved");
                            break;
                    }
                    int result = Computer.DisplayMessage(player.choice, com.computerChoice);

                    //Code to print the result of the round
                    if (result == 0)
                    {
                        Console.WriteLine("Oooops, There was a draw. I'll get you next time...\n");
                    }
                    else if (result == 1)
                    {
                        Console.WriteLine("You won! I'll get you you next time <Player_Name>\n");
                        playerScore += 1;
                    }
                    else if (result == 2)
                    {
                        Console.WriteLine("YES, I the computer won this round.. You LOST HA HA HA \n");
                        computerScore += 1;
                    }
                    numberOfRounds -= 1;

                    if (numberOfRounds == 0)
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("==================== Final Scores ============================");
                        Console.WriteLine("Computer \t {0} \t\t User (Player) \t {1}", computerScore, playerScore);
                        Console.WriteLine();
                        Console.WriteLine("Do you wish to play again? (y/n)");
                        string loop = Console.ReadLine();
                        if (loop == "y")
                        {
                            playAgain = true;
                            Console.Clear();
                        }
                        else if (loop == "n")
                        {
                            Console.WriteLine();
                            Console.WriteLine("GAME OVER... THANKS FOR PLAYING...");
                            playAgain = false;
                        }
                    }
                }
            }

        }
    }
}
