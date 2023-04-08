using System.Collections.Generic;

using UnityEngine.Assertions;

namespace AHLCG
{
    /// <summary>
    /// This class represents a single card in the game.
    /// </summary>
    public class Card : Resource
    {
        /// <summary>
        /// The current resource identifier.
        /// </summary>
        public static int currentId;

        /// <summary>
        /// The type of this card.
        /// </summary>
        public int cardTypeId;

        /// <summary>
        /// The name of this card.
        /// </summary>
        public string name;

        /// <summary>
        /// Constructor.
        /// </summary>
        public Card() : base(currentId++)
        {
        }
    }
}
