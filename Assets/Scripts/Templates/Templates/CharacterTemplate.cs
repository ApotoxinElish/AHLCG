using System.Collections.Generic;
using UnityEngine;

namespace AHLCG
{
    public abstract class CharacterTemplate : ScriptableObject
    {
        public string Name;
        public GameObject Prefab;

        // public List<EffectAction> Actions = new List<EffectAction>();
    }
}
