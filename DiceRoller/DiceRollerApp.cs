using System;
using System.Threading;

namespace DiceRoller
{
    class DiceRollerApp
    {
        private static Random PRNG = new Random();

        private static bool PromptUser(string msg)
        {
            string input = "";
            while (input != "n" && input != "y")
            {
                Console.Write($"\n{msg}? (y/n): ");
                input = Console.ReadLine().ToLower();
            }
            if (input == "n") return false;
            return true;
        }

        public static void RollTheDice(int sides)
        {
            int die1 = RollDie(sides);
            int die2 = RollDie(sides);
            int sum = die1 + die2;

            Console.Write($"You rolled a {die1} and a {die2}!!! ({sum} total)\n");
            if (sides == 6) CheckCombo(die1, die2, sum);
        }

        private static int RollDie(int sides)
        {
            return PRNG.Next(1, sides + 1);
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
            int sides = 0;
            int rolls = 1;
            bool balling = true;

            Console.WriteLine("Ready to take some risks? Let's get to rollin'...\n");
            Console.Write("How many sides should each die have? ");
            Int32.TryParse(Console.ReadLine(), out sides);

            while (sides < 1) //Confirmation loop
            {
                Console.Write("That's not a valid number of sides, please try again: ");
                Int32.TryParse(Console.ReadLine(), out sides);
            }

            while (balling)
            {
                Console.WriteLine($"\nRoll {rolls}:");
                RollTheDice(sides);
                rolls++;

                balling = PromptUser("Would you like to roll again?");
            }

            Console.WriteLine("\nThanks for playing!");
        }
    }
}
