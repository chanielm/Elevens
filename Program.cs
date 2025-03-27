class Program
{
    static void Main()
    {
        string? again;
        do {
            ElevensGame e = new();

            while (e.ValidMovePossible())
            {
                e.PrintTable();
                e.SelectCards();
                if (e.ValidateEleven(e.Selection)) {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("These Cards Add to 11. Removing...");
                    e.ReplaceSelected();
                }
                else if (e.ValidateFaceCards(e.Selection)) {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("These are unique face cards. Removing...");
                    e.ReplaceSelected();
                }
                else {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Invalid Selection.");
                }
                Console.ResetColor();
            }

            if (e.GameWon()) {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Write("\nDeck is empty... YOU WIN!");
                Console.ResetColor();
            }
            else {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write("\nNo valid moves possible... GAME OVER.");
                Console.ResetColor();
                e.PrintTable();
            }

            Console.Write("\nTry again? (Y/N) ");
            again = Console.ReadLine();
        } while (again != null && again.ToUpper().Equals("Y"));
    } 
}