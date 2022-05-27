using System;
using System.Collections.Generic;
using UnityEngine;

namespace AHLCG
{
    [Serializable]
    [CreateAssetMenu(
        menuName = "AHLCG/Templates/Card",
        fileName = "Card",
        order = 0)]
    public class CardTemplate : ScriptableObject
    {
        public int Id;
        public string Title;
        public int Cost;
        public Material Material;
        public Sprite Picture;
        public CardType Type;
        public List<Effect> Effects = new List<Effect>();
    }
}
