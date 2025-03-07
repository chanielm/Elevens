/*
Class: Deck
	FIELDS:
	- cards: List<Card>
	PROPERTIES:
	METHODS:
	+ Deck()
	+ Shuffle(): void
	+ TakeTopCard(): Card?
	+ IsEmpty(): bool
*/

class Deck {
    List<Card> cards;

    public Deck() {
        cards = [];

        foreach (Suit s in Enum.GetValues<Suit>())
        foreach (Rank r in Enum.GetValues<Rank>())
        cards.Add(new Card(s, r));
    }

    // Randomize the indices of all Cards in the deck. Does nothing if Deck is empty.
    public void Shuffle() {
        Random rand = new();

        for (int i = 0; i < cards.Count; i++) {
            int randindex = rand.Next(i, cards.Count);

            Card temp = cards[randindex];
            cards[randindex] = cards[i];
            cards[i] = temp;
        }
    }

    // Returns the top Card, aka the Card at the end of the list and removes it. Returns null if Deck is empty.
    public Card? TakeTopCard() {
        if (IsEmpty()) return null;

        Card res = cards[cards.Count - 1];
        cards.RemoveAt(cards.Count - 1);
        return res;
    }

    // Returns true if the List containing the cards is empty. False otherwise.
    public bool IsEmpty() {
        return cards.Count == 0;
    }
}

