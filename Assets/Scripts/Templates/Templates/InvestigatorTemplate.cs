using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AHLCG
{
    [Serializable]
    [CreateAssetMenu(
        menuName = "AHLCG/Templates/Investigator",
        fileName = "Investigator",
        order = 0)]
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

        public CardLibrary StartingDeck;
    }
}
