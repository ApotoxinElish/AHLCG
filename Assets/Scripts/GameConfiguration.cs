using System.Collections.Generic;
using System.IO;
using System.Linq;

using UnityEngine;

namespace AHLCG
{
    /// <summary>
    /// Contains the entire game configuration details, which are comprised of general game settings,
    /// player/card/effect definitions and the card database.
    /// </summary>
    public class GameConfiguration : MonoBehaviour
    {
        /// <summary>
        /// The card sets of the game.
        /// </summary>
        public List<CardSet> cardSets = new List<CardSet>();

    }
}
