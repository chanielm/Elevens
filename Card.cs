/*
Class: Card
	FIELDS:
	- suit: Suit
	- rank: Rank
	PROPERTIES:
	+ Suit: Suit
	+ Rank: Rank
	METHODS:
	+ Card(Suit, Rank)
*/

class Card {
    Suit suit;
    Rank rank;

    public Suit Suit { get; private set; }
    public Rank Rank { get; private set; }

    public Card(Suit s, Rank r) {
        this.Suit = s;
        this.Rank = r;
    }
}