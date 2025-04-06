class ElevensGame {
    List<Card> table;
    Deck deck;
    bool endKeyPressed;

    public List<Card> Table { get { return table; } }
    public List<int> Selection { get; private set; }

    public ElevensGame() {
        deck = new();
        table = [];
        Selection = [];
        endKeyPressed = false;
    }

    // Run the game.
    public void Run() {
        Console.Clear();
        Console.WriteLine("Welcome to ELEVENS! Press [ENTER] to start a game.");
        Console.WriteLine("TIP: Enter 'E' at any point if you'd like to end the current game.");
        Console.ReadLine();

        string? again;
        do {
            // Initialization
            deck = new();
            table = [];

            deck.Shuffle();
            for (int i = 0; i < 10; i++) table.Add(deck.TakeTopCard()!);

            // Game Flow
            while (ValidMovePossible())
            {
                Console.Clear();
                PrintTable();
                SelectCards();
                if (endKeyPressed) break;

                if (ValidateEleven(Selection) || ValidateFaceCards(Selection)) {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Removing...");
                    ReplaceSelected();
                }
                else {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("The cards selected are not a pair that add to 11 and are not unique face cards.");
                }

                Thread.Sleep(1000);
                Console.ResetColor();
            }
            if (endKeyPressed) {
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Write("\nEnd key was pressed... Ending game...");
                Console.ResetColor();
            }
            else if (GameWon()) {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Write("\nDeck is empty... YOU WIN!");
                Console.ResetColor();
            }
            else {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write("\nNo more valid moves possible... GAME OVER.");
                Console.ResetColor();
            }

            Console.Write("\nTry again? (Y/N) ");
            again = Console.ReadLine();
        } while (again != null && again.ToUpper().Equals("Y"));

        Console.Clear();
        Console.WriteLine("\"Elevens\" was closed.");
    }

    // Check if any pair of cards in the list adds to eleven.
    // If none add to eleven, check if a set of unique face cards (J, Q, K) is present.
    // False if neither conditions are true.
    public bool ValidMovePossible() {
        for (int i = 0; i < table.Count; i++) for (int j = 0; j < table.Count; j++) {
            if (i != j && ValidateEleven([i, j])) return true;
        }

        bool jack = false, queen = false, king = false;
        foreach (Card card in table) {
            if (card.Rank == Rank.Jack) jack = true;
            if (card.Rank == Rank.Queen) queen = true;
            if (card.Rank == Rank.King) king = true;
        }

        return jack && queen && king;
    }

    // Prompt the user to select an arbitrary number of cards. Checks for non integers and out of range.
    // Populates 'Selection' with the user's selected indices once method is complete.
    public void SelectCards() {
        Selection = [];
        string? input;
        
        do {
            Console.Write("\nEnter the indices of the cards you wish to select, separated by commas: ");
            input = Console.ReadLine();
        
            if (input == null) continue;
            if (input.Equals("E", StringComparison.CurrentCultureIgnoreCase)) {
                endKeyPressed = true;
                return;
            }

            foreach (string str in input.Split(',')) {
                if (int.TryParse(str.Trim(), out int n)) {
                    if (n < 0 || n >= table.Count) {
                        BadOutput("A negative index or index greater than the number of cards on the table was found. Please reenter.");
                        Selection = [];
                        break;
                    }
                    else if (Selection.Contains(n)) {
                        BadOutput("A duplicate index was found. Please reenter.");
                        Selection = [];
                        break;
                    }
                    else Selection.Add(n);
                }
                else {
                    BadOutput("A non integer was found. Please reenter.");
                    Selection = [];
                    break;
                }
            }
        } while (Selection.Count < 1);
    }

    // Remove the cards at the indices listed in 'Selection' and add new cards to take their place.
    // If 'deck' is empty, doesn't add anything.
    public void ReplaceSelected() {
        Selection.Sort();
        Selection.Reverse();

        foreach (int i in Selection) {
            table.RemoveAt(i);
            
            Card? next = deck.TakeTopCard();
            if (next != null) table.Add(next);
            else break;
        }
    }

    // Returns true if Jack, Queen, and King were selected. Return false otherwise.
    public bool ValidateFaceCards(List<int> indices) {
        if (indices.Count != 3) return false;
        
        bool jack = false, queen = false, king = false;
        foreach (int i in indices) {
            if (table[i].Rank == Rank.Jack) jack = true;
            if (table[i].Rank == Rank.Queen) queen = true;
            if (table[i].Rank == Rank.King) king = true;
        }

        return jack && queen && king;
    }
	
    // Returns true if selected cards add to eleven. False otherwise. False if any face cards were selected or more than 2 were selected.
    public bool ValidateEleven(List<int> indices) {
        if (indices.Count > 2) return false;

        int sum = 0;
        foreach (int i in indices) {
            if (i > Table.Count) return false;
            if (table[i].Rank > Rank.Ten) return false;
            else sum += (int)table[i].Rank + 1;
        }

        return sum == 11;
    }

    public bool GameWon() { return deck.Count() + table.Count == 0; }

    public void PrintTable() {
        Console.WriteLine($"TABLE ({deck.Count() + Table.Count} left):");

        for (int i = 0; i < table.Count; i++) {
            if (i % 5 == 0 && i != 0) Console.Write("\n");

            if (table[i].Rank > Rank.Ten) Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{i}: [{table[i]}] \t");
            Console.ResetColor();
        }
    }
    
    private static void BadOutput(string message) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(message);
        Console.ResetColor();
    }
}