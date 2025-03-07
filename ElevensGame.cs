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
    + SelectCards(): List<int>
    + Replace(int): void
    + ValidateFaceCards(List<int>): bool
	+ ValidateEleven(List<int>): bool
*/

class ElevensGame {
    List<Card> table;
    Deck deck;

    public List<Card> Table { get; private set; }
    public List<int> Selection { get; set; }

    public ElevensGame() {
        deck = new();
        table = new();

        for (int i = 0; i < 10; i++) {
            Card? add = deck.TakeTopCard();
            if (add == null) break;
        }
    }

    // TODO: ValidMovePossible()
    // TODO: SelectCards()
    // TODO: Replace(int)

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