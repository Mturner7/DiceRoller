using System;
using System.Threading;

namespace DiceRoller
{
    class DiceRollerApp
    {
        public static void RollTheDice(int sides)
        {
            int die1 = RollDie(sides);
            int die2 = RollDie(sides);
            int sum = die1 + die2;

            Console.Write($"\nYou rolled a {die1} and a {die2}!!! ({sum} total)\n");
            CheckCombo(die1, die2, sum);
        }

        private static int RollDie(int sides)
        {
            Random PRNG = new Random();
            return PRNG.Next(1, sides);
        }

        private static void CheckCombo(int d1, int d2, int sum)
        {
            string output = "You lost. Don't worry sport, you'll get 'em next time.";

            if (sum == 12 || sum == 3 || sum == 2)
            {
                output = "Craps, way to roll! (See what I did there?)";

                if (d1 == 6 && d2 == 6) output += "\nBox Cars!";
                if (d1 == 2 && d2 == 1) output += "\nAce Deuce!";
                if (d1 == 1 && d2 == 1) output += "\nSnake Eyes!";
            }
            else if (sum == 11 || sum == 7) output = "Win";

            Console.WriteLine(output);
        }

        static void Main(string[] args)
        {
            int sides;
            string input;
            bool balling = true;

            Console.WriteLine("Ready to take some risks? Let's get to rollin'...\n");
            Console.Write("How many sides should the dice have? ");
            input = Console.ReadLine();

            while (!Int32.TryParse(input, out sides)) //Confirmation loop
            {
                Console.Write("That's not valid integer big homie, try again! ");
                input = Console.ReadLine();
            }

            while (balling)
            {
                Console.Clear();
                RollTheDice(sides);

                do //Confirmation loop. (So nice, I had to do it twice!)
                {
                    Console.Write("\nWould you like to roll again? (y/n): ");
                    input = Console.ReadLine().ToLower();
                } while (input != "y" && input != "n");

                if (input == "n") balling = false;
            }

            Console.WriteLine("\nThanks for playing!");
        }
    }
}
