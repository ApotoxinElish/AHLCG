using System.Collections.Generic;

namespace AHLCG
{
    /// <summary>
    /// A card set is a named collection of cards. Their main purpose is to help organize
    /// a big collection of cards into smaller, more manageable sub-groups.
    /// </summary>
    public class CardSet
    {
        /// <summary>
        /// The name of this card set.
        /// </summary>
        public string name;

        /// <summary>
        /// The cards of this card set.
        /// </summary>
        public List<Card> cards = new List<Card>();
    }
}
