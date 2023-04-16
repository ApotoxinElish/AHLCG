#if UNITY_EDITOR

using UnityEditor;

#endif

using UnityEngine;

namespace AHLCG
{
    /// <summary>
    /// The base class for properties.
    /// </summary>
    public class Property
    {
        /// <summary>
        /// The name of this property.
        /// </summary>
        public string name;

#if UNITY_EDITOR

        /// <summary>
        /// Draws this property in the editor.
        /// </summary>
        public virtual void Draw()
        {
            GUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel("Name");
            name = EditorGUILayout.TextField(name, GUILayout.MaxWidth(100));
            GUILayout.EndHorizontal();
        }

#endif
    }
}
