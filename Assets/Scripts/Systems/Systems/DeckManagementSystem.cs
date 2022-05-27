using System.Collections.Generic;
using UnityEngine;

namespace AHLCG
{
    public class DeckManagementSystem : MonoBehaviour
    {
        public CardPresentationSystem HandPresentationSystem;

        private List<RuntimeCard> deck;
        private List<RuntimeCard> discardPile;
        private List<RuntimeCard> hand;

        private DeckWidget deckWidget;
        private DiscardPileWidget discardPileWidget;

        private const int InitialDeckCapacity = 30;
        private const int InitialDiscardPileCapacity = 30;
        private const int InitialHandCapacity = 10;

        public void Initialize(DeckWidget deck, DiscardPileWidget discardPile)
        {
            deckWidget = deck;
            discardPileWidget = discardPile;
        }

        private void Awake()
        {
            deck = new List<RuntimeCard>(InitialDeckCapacity);
            discardPile = new List<RuntimeCard>(InitialDiscardPileCapacity);
            hand = new List<RuntimeCard>(InitialHandCapacity);
        }

        public int LoadDeck(CardLibrary playerDeck)
        {
            var deckSize = 0;

            var library = playerDeck;
            foreach (var entry in library.Entries)
            {
                // Skip over invalid entries.
                if (entry.Card == null)
                    continue;

                for (var i = 0; i < entry.NumCopies; i++)
                {
                    var card = new RuntimeCard
                    {
                        Template = entry.Card
                    };
                    deck.Add(card);

                    ++deckSize;
                }
            }

            deckWidget.SetAmount(deck.Count);
            discardPileWidget.SetAmount(0);

            return deckSize;
        }

        public void ShuffleDeck()
        {
            deck.Shuffle();
        }

        public void DrawCardsFromDeck(int amount)
        {
            var deckSize = deck.Count;
            // If there are enough cards in the deck, just draw the cards from it.
            if (deckSize >= amount)
            {
                var prevDeckSize = deckSize;

                var drawnCards = new List<RuntimeCard>(amount);
                for (var i = 0; i < amount; i++)
                {
                    var card = deck[0];
                    deck.RemoveAt(0);
                    hand.Add(card);
                    drawnCards.Add(card);
                }

                HandPresentationSystem.CreateCardsInHand(drawnCards, prevDeckSize);
            }
            // If there are not enough cards in the deck, first shuffle the discard pile into
            // the deck and then draw from the deck normally.
            else
            {
                discardPile.Shuffle();
                for (var i = 0; i < discardPile.Count; i++)
                    deck.Add(discardPile[i]);

                discardPile.Clear();

                HandPresentationSystem.UpdateDiscardPileSize(discardPile.Count);

                // Prevent trying to draw more cards than those available.
                if (amount > deck.Count + discardPile.Count)
                {
                    amount = deck.Count + discardPile.Count;
                }
                DrawCardsFromDeck(amount);
            }
        }

        public void MoveCardToDiscardPile(RuntimeCard card)
        {
            var idx = hand.IndexOf(card);
            hand.RemoveAt(idx);
            discardPile.Add(card);
        }

        public void MoveCardsToDiscardPile()
        {
            foreach (var card in hand)
                discardPile.Add(card);

            hand.Clear();
        }
    }
}
