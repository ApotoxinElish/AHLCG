using TMPro;
using UnityEngine;

namespace AHLCG
{
    /// <summary>
    /// The widget used to display the player's resource.
    /// </summary>
    public class PlayerWidget : MonoBehaviour
    {
#pragma warning disable 649
        [SerializeField]
        private TextMeshProUGUI willpowerText;
        [SerializeField]
        private TextMeshProUGUI intellectText;
        [SerializeField]
        private TextMeshProUGUI combatText;
        [SerializeField]
        private TextMeshProUGUI agilityText;

        [SerializeField]
        private TextMeshProUGUI healthText;
        [SerializeField]
        private TextMeshProUGUI sanityText;
        [SerializeField]
        private TextMeshProUGUI clueText;
        [SerializeField]
        private TextMeshProUGUI resourceText;
#pragma warning restore 649

        // private int maxValue;

        public void Initialize(InvestigatorTemplate template)
        {
            // maxValue = resource.Value;
            SetWillpowerValue(template.Willpower);
            SetIntellectValue(template.Intellect);
            SetCombatValue(template.Combat);
            SetAgilityValue(template.Agility);
            SetHealthValue(template.Health);
            SetSanityValue(template.Sanity);
            // SetClueValue(template.Clue);
            // SetResourceValue(template.Resource);
        }

        private void SetWillpowerValue(int value)
        {
            willpowerText.text = $"{value.ToString()}";
            // textBorder.text = text.text;
        }

        private void SetIntellectValue(int value)
        {
            intellectText.text = $"{value.ToString()}"; // /{maxValue.ToString()}";
            // textBorder.text = text.text;
        }

        private void SetCombatValue(int value)
        {
            combatText.text = $"{value.ToString()}"; // /{maxValue.ToString()}";
            // textBorder.text = text.text;
        }

        private void SetAgilityValue(int value)
        {
            agilityText.text = $"{value.ToString()}"; // /{maxValue.ToString()}";
            // textBorder.text = text.text;
        }
        private void SetHealthValue(int value)
        {
            healthText.text = $"{value.ToString()}"; // /{maxValue.ToString()}";
            // textBorder.text = text.text;
        }
        private void SetSanityValue(int value)
        {
            sanityText.text = $"{value.ToString()}"; // /{maxValue.ToString()}";
            // textBorder.text = text.text;
        }
        private void SetClueValue(int value)
        {
            clueText.text = $"{value.ToString()}"; // /{maxValue.ToString()}";
            // textBorder.text = text.text;
        }
        private void SetResourceValue(int value)
        {
            resourceText.text = $"{value.ToString()}"; // /{maxValue.ToString()}";
            // textBorder.text = text.text;
        }

        public void OnResourceChanged(int value)
        {
            SetResourceValue(value);
        }
    }
}
