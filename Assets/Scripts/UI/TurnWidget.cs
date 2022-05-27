using TMPro;
using UnityEngine;

namespace AHLCG
{
    /// <summary>
    /// The widget used to display the player's turn.
    /// </summary>
    public class TurnWidget : MonoBehaviour
    {
#pragma warning disable 649
        [SerializeField]
        private TextMeshProUGUI text;
        // [SerializeField]
        // private TextMeshProUGUI textBorder;
#pragma warning restore 649

        private int maxValue;

        public void Initialize(IntVariable turn)
        {
            maxValue = turn.Value;
            SetValue(turn.Value);
        }

        private void SetValue(int value)
        {
            text.text = $"{value.ToString()}"; // /{maxValue.ToString()}";
            // textBorder.text = text.text;
        }

        public void OnTurnChanged(int value)
        {
            SetValue(value);
        }
    }
}
