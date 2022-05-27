using System;
using UnityEngine;
using System.Collections.Generic;

namespace AHLCG
{
    [Serializable]
    [CreateAssetMenu(
        menuName = "AHLCG/Templates/Player",
        fileName = "Player",
        order = 1)]
    public class PlayerTemplate : CharacterTemplate
    {
        public int Willpower;
        public int Intellect;
        public int Combat;
        public int Agility;

        public int Health;
        public int Sanity;
        public int Clue;
        public int Resource;

        public CardLibrary StartingDeck;
    }
}
