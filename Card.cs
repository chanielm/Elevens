/*
Class: Card
	PROPERTIES:
	+ Suit: Suit
	+ Rank: Rank
	METHODS:
	+ Card(Suit, Rank)
*/

class Card {
    public Suit Suit { get; private set; }
    public Rank Rank { get; private set; }

    public Card(Suit s, Rank r) {
        this.Suit = s;
        this.Rank = r;
    }

    public override string ToString() {
        string res = "";
        res += Rank switch {
            Rank.Ace    => "A",
            Rank.Jack   => "J",
            Rank.Queen  => "Q",
            Rank.King   => "K",
            _           => (int)Rank + 1,
        };

        res += Suit switch {
            Suit.Spades     => "\u2660",
            Suit.Clubs      => "\u2663",
            Suit.Diamonds   => "\u2666",
            Suit.Hearts     => "\u2665",
            _               => "?" // this line should never be used
        };

        return res;
    }
}