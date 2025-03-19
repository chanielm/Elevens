/*
Class: ElevensGame
	FIELDS:
	- table: List<Card>
	- deck: Deck
	PROPERTIES:
	+ SelectionList: List<int>
	METHODS:
	+ ElevensGame()
	+ ValidMovePossible(): bool
    + SelectCards(): void
    + Replace(int): void
    + ValidateFaceCards(List<int>): bool
	+ ValidateEleven(List<int>): bool
*/

class ElevensGame {
    List<Card> table;
    Deck deck;

    public List<Card> Table { get { return table; } }
    public List<int> Selection { get; set; }

    public ElevensGame() {
        deck = new();
        table = [];
        Selection = [];

        deck.Shuffle();
        for (int i = 0; i < 10; i++) table.Add(deck.TakeTopCard());
    }

    // TODO: ValidMovePossible()

    public void SelectCards() {
        Selection = [];
        int select;

        Console.WriteLine($"\nTABLE ({deck.Count() + Table.Count} left):");
        for (int i = 0; i < table.Count; i++) Console.WriteLine($"{i}. {table[i].ToString()}");

        do {
            Console.WriteLine("Select a Card index from 0 to 9. Enter -1 to stop selecting.");
            if (int.TryParse(Console.ReadLine(), out select)) {
                if (select > 9 || select < 0) { if (select != -1) Console.WriteLine("Invalid Index."); }
                else if (!Selection.Contains(select)) Selection.Add(select);
                else Console.WriteLine("Already selected.");
            }
            else Console.WriteLine("An integer, please.");
        } while (select != -1);

        Console.Write("You selected: ");
        foreach (int n in Selection) Console.Write($"{n} ");
    }

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
        bool jack = false, queen = false, king = false;
        foreach (int i in indices) {
            if (table[i].Rank == Rank.Jack) jack = true;
            if (table[i].Rank == Rank.Queen) queen = true;
            if (table[i].Rank == Rank.King) king = true;
        }

        return jack && queen && king;
    }
	
    // Returns true if selected cards add to eleven. False otherwise. False if any face cards were selected.
    public bool ValidateEleven(List<int> indices) {
        
        // Check if any face cards were selected (automatically false if so)
        foreach (int i in indices) if (table[i].Rank > Rank.Ten) return false;

        int sum = 0;
        foreach (int i in indices) sum += (int)table[i].Rank + 1;

        return sum == 11;
    }
}