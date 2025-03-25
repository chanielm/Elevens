class ElevensGame {
    List<Card> table;
    Deck deck;

    public List<Card> Table { get { return table; } }
    public List<int> Selection { get; private set; }

    public ElevensGame() {
        deck = new();
        table = [];
        Selection = [];

        deck.Shuffle();
        for (int i = 0; i < 10; i++) {
            Card? c = deck.TakeTopCard();
            if (c != null) table.Add(c);
        }
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

    public void SelectCards() {
        Selection = [];
        int select;

        Console.WriteLine($"\nTABLE ({deck.Count() + Table.Count} left):");
        for (int i = 0; i < table.Count; i++) {
            if (i % 5 == 0 && i != 0) Console.WriteLine();
            if (table[i].Rank > Rank.Ten) Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{i}: {table[i].ToString()}\t");

            Console.ResetColor();
        }

        do {
            Console.WriteLine("\nSelect a Card index from 0 to 9. Enter -1 to stop selecting.");
            if (int.TryParse(Console.ReadLine(), out select)) {
                if (select > table.Count - 1 || select < 0) { if (select != -1) Console.WriteLine("Invalid Index."); }
                else if (!Selection.Contains(select)) Selection.Add(select);
                else Console.WriteLine("Already selected.");
            }
            else Console.WriteLine("An integer, please.");
        } while (select != -1);
    }

    // Remove the cards at the indices listed in 'Selection' and add new cards to take their place.
    // if 'deck' is empty, doesn't add anything.
    public void ReplaceSelected() {
        Selection.Sort();
        Selection.Reverse();

        foreach (int i in Selection) {
            table.RemoveAt(i);
            
            Card? next = deck.TakeTopCard();
            if (next != null) table.Add(next);
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
            if (table[i].Rank > Rank.Ten) return false;
            else sum += (int)table[i].Rank + 1;
        }

        return sum == 11;
    }
}