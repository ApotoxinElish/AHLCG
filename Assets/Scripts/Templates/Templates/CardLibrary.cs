using System;
using System.Collections.Generic;
using UnityEngine;

namespace AHLCG
{
    [Serializable]
    [CreateAssetMenu(
        menuName = "AHLCG/Templates/Card library",
        fileName = "CardLibrary",
        order = 3)]
    public class CardLibrary : ScriptableObject
    {
        public string Name;
        public List<CardLibraryEntry> Entries = new List<CardLibraryEntry>();
    }
}
