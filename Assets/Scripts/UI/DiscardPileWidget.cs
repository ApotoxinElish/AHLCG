using TMPro;
using UnityEngine;

namespace AHLCG
{
    /// <summary>
    /// The widget used to display the current number of cards in the player's discard pile.
    /// </summary>
    public class DiscardPileWidget : MonoBehaviour
    {
#pragma warning disable 649
        [SerializeField]
        private TextMeshProUGUI textLabel;
#pragma warning restore 649

        private int discardPileSize;

        public void SetAmount(int amount)
        {
            discardPileSize = amount;
            textLabel.text = amount.ToString();
        }

        public void AddCard()
        {
            SetAmount(discardPileSize + 1);
        }
    }
}
