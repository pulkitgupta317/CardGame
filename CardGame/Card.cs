using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public class Card
    {
        public Card(SuitType suitType, CardType cardType)
        {
            Suit = suitType;
            CardType = cardType;
        }

        public SuitType Suit { get; private set; }

        public CardType CardType { get; private set; }

        public override string ToString()
        {
            return $"{CardType} of {Suit}";
        }
    }
}
