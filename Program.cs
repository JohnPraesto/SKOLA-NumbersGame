// JOHN PRAESTO SUT-23 \\

namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] tooHigh = new string[4] { "Din gissning var för hög. ", "Det är ett lägre nummer ", "Sänk, sänk! ", "Gissa på ett mindre tal " };
            string[] tooLow = new string[4] { "Din gissning var för låg. ", "Det är ett högre nummer ", "Höj, höj! ", "Gissa på ett större tal " };
            string[] close = new string[4] { "Riktigt nära nu. ", "Nästan! ", "Missat med en hårsmån! ", "Wow! Tror du tar den på nästa! "};
            int[] range = new int[4] { 10, 50, 200, 1000 };
            Random random = new Random();
            int guessesLeft = 20;
            int increment = 0;

            LetterDelay("VÄLKOMMEN\n");
            Console.WriteLine("GISSA NUMMRET!\n");
            Console.WriteLine("På första nivån ska du gissa på ett tal mellan 1 & 10.");
            int guess = 0;
            int number = random.Next(1, range[increment]);

            while (true)
            {
                Console.Write($"Skriv in din gissning (1-{range[increment]}): ");
                while (!Int32.TryParse(Console.ReadLine(), out guess)) ;
                guessesLeft--;
                Console.Clear();

                if (guess == number)
                {
                    Console.Clear();
                    number = random.Next(1, range[increment]);
                    increment++;
                    Console.WriteLine("RÄTT!");
                    Console.WriteLine($"Du har klarat nivå {increment}! Rätt gissning var {guess}.\n");
                    if (increment == 4)
                        break;
                    Console.WriteLine($"Du har {guessesLeft} gissningar kvar.");
                    Console.WriteLine("Tryck Enter för att komma till nästa nivå");
                    Console.ReadLine();
                    Console.Clear();
                }

                else if (guessesLeft == 1)
                    break;

                // Anpassade "närhets-intervall" utefter svårighetsgrad:
                // ANNARS OM gissningen är mindre eller lika med:
                // nivå 1 (1-10): increment (0) * 3 = 0     + 1 = 1
                // nivå 2 (1-50): increment (1) * 3 = 3     + 1 = 4
                // nivå 2 (1-200): increment (2) * 3 = 6    + 1 = 7
                // nivå 2 (1-1000): increment (3) * 3 = 9   + 1 = 10
                else if (guess <= (increment * 3 + 1) + number && guess >= number - (increment * 3 + 1))
                {
                    Console.Write(close[random.Next(0, 4)]);
                    if (guess < number)
                    {
                        Console.WriteLine(tooLow[random.Next(0, 4)]);
                    }
                    else
                    {
                        Console.WriteLine(tooHigh[random.Next(0, 4)]);
                    }
                }
                else if (guess < number)
                {
                    Console.WriteLine(tooLow[random.Next(0, 4)]);
                }
                else
                {
                    Console.WriteLine(tooHigh[random.Next(0, 4)]);
                }

                if (guessesLeft > 3)
                    Console.WriteLine($"Gissningar kvar: {guessesLeft}\n");
                else if (guessesLeft < 4 && guessesLeft > 1)
                    Console.WriteLine($"Nu har du bara {guessesLeft} gissningar kvar!\n");
                else if (guessesLeft == 1)
                    Console.WriteLine($"SISTA GISSNINGEN!\n");
            }
            
            if (increment == 4)
                Console.WriteLine("DU HAR KLARAT SPELET");
            else
                Console.WriteLine("DU HAR FÖRLORAT");
        }


        public static void LetterDelay(string sentence)
        {
            Console.Clear();
            foreach (char letter in sentence)
            {
                Console.Write(letter);
                Thread.Sleep(50);
            }
        }
    }
}
