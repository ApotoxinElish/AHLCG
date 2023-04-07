using System;
using System.Collections.Generic;

namespace AHLCG
{
    /// <summary>
    /// A single entry in a deck.
    /// </summary>
    [Serializable]
    public class DeckEntry
    {
        /// <summary>
        /// The unique identifier of the card.
        /// </summary>
        public int id;

        /// <summary>
        /// The number of copies of the card.
        /// </summary>
        public int amount;
    }

    /// <summary>
    /// A deck is a collection of cards that players use when entering a game.
    /// </summary>
    [Serializable]
    public class Deck
    {
        /// <summary>
        /// The name of this deck.
        /// </summary>
        public string name = "New deck";

        /// <summary>
        /// The entries of this deck.
        /// </summary>
        public List<DeckEntry> cards = new List<DeckEntry>();

        /// <summary>
        /// Returns the number of cards in this deck.
        /// </summary>
        /// <returns>The number of cards in this deck.</returns>
        public int GetNumCards()
        {
            var total = 0;
            foreach (var card in cards)
            {
                total += card.amount;
            }
            return total;
        }

        /// <summary>
        /// Returns the number of cards of the specified type in this deck.
        /// </summary>
        /// <param name="config">The game's configuration.</param>
        /// <param name="cardTypeId">The card type.</param>
        /// <returns>The number of cards of the specified type in this deck.</returns>
        public int GetNumCards(GameConfiguration config, int cardTypeId)
        {
            var total = 0;
            foreach (var card in cards)
            {
                foreach (var set in config.cardSets)
                {

                }
            }
            return total;
        }
    }
}
