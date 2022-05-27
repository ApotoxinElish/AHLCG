using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEditorInternal;
#endif

namespace AHLCG
{
    /// <summary>
    /// The base type of all the card effects available in the kit. As with most of the
    /// configuration elements in the codebase, effect templates are scriptable objects.
    /// </summary>
    public abstract class Effect : ScriptableObject
    {
        public abstract string GetName();
    }
}
