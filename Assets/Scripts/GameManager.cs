using System.Collections.Generic;
using UnityEngine;

namespace AHLCG
{
    /// <summary>
    /// This class is the in-game entry point to the game configuration managed from within
    /// the AHLCG menu option in Unity.
    /// </summary>
    public sealed class GameManager
    {
        /// <summary>
        /// The player's nickname of this game.
        /// </summary>
        public string playerName;

        /// <summary>
        /// True if the player is logged in; false otherwise (used in Master Server Kit
        /// integration).
        /// </summary>
        public bool isPlayerLoggedIn;

        /// <summary>
        /// Static instance.
        /// </summary>
        private static readonly GameManager instance = new GameManager();

        static void Init()
        {
            Instance.isPlayerLoggedIn = false;
        }

        /// <summary>
        /// Initialization method.
        /// </summary>
        public void Initialize()
        {

        }

        /// <summary>
        /// Static instance.
        /// </summary>
        public static GameManager Instance
        {
            get { return instance; }
        }
    }
}
