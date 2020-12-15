using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public class Deck
    {
        public Deck()
        {
            SeedDeckWithCards();
        }

        /// <summary>
        /// Store cards present in the deck
        /// </summary>
        private List<Card> _cards;

        /// <summary>
        /// Return the count of cards
        /// </summary>
        public int CardsCount
        {
            get
            {
                return _cards.Count;
            }
        }

        /// <summary>
        /// Play card from the set of cards of the deck. 
        /// Returns the card and also remove it from the deck
        /// </summary>
        /// <returns></returns>
        public string PlayCard()
        {
            if (CardsCount == 0)
            {
                throw new InvalidOperationException("No cards available in the deck");
            }
            var card = _cards.Last();
            if (_cards.Remove(card))
            {
                return card.ToString();
            }
            else
            {
                throw new Exception("Unable to remove a card from the deck");
            }
        }

        /// <summary>
        /// Suffle the cards that are present in the deck.
        /// Throw exception if count of cards in the deck is zero
        /// </summary>
        public void Suffle()
        {
            if (CardsCount == 0)
            {
                throw new InvalidOperationException("No cards available in the deck to suffle");
            }
            else
            {
                _cards.Shuffle();
            }
        }

        /// <summary>
        /// Restart the game by seeding all the cards back to the deck.
        /// </summary>
        public void Restart()
        {
            if (CardsCount == 52)
            {
                throw new InvalidOperationException("The deck is full of cards");
            }
            SeedDeckWithCards();
        }

        /// <summary>
        /// Seed deck with the new cards
        /// </summary>
        private void SeedDeckWithCards()
        {
            List<Card> cards = new List<Card>();
            IEnumerable<CardType> cardTypes = Extensions.GetValues<CardType>();
            IEnumerable<SuitType> suits = Extensions.GetValues<SuitType>();
            foreach (var suit in suits)
            {
                foreach (var cardType in cardTypes)
                {
                    var card = new Card(suit, cardType);
                    cards.Add(card);
                }
            }
            cards.Shuffle();
            _cards = cards;
        }
    }
}
