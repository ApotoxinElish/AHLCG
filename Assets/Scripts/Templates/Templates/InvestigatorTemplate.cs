using System;
using UnityEngine;

namespace AHLCG
{
    [Serializable]
    [CreateAssetMenu(
        menuName = "AHLCG/Templates/Investigator",
        fileName = "Investigator",
        order = 1)]
    public class InvestigatorTemplate : ScriptableObject
    {
        public int Willpower;
        public int Intellect;
        public int Combat;
        public int Agility;

        public int Health;
        public int Sanity;
        public int Clue;
        public int Resource;

        public Sprite Picture;

        public CardLibrary StartingDeck;
    }
}
