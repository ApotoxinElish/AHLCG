using UnityEngine;

namespace AHLCG
{
    [CreateAssetMenu(
        menuName = "AHC/Configuration/Player character",
        fileName = "PCConfiguration",
        order = 0)]
    public class PlayableCharacterConfiguration : ScriptableObject
    {
        public IntVariable Health;
        public IntVariable Sanity;

        public IntVariable Resource;

        // public StatusVariable Status;

        // public GameObject HealthWidget;
        // public GameObject StatusWidget;
    }
}
