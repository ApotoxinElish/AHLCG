using UnityEngine;
using UnityEngine.UI;

namespace AHLCG
{
    public class EndTurnButton : MonoBehaviour
    {
        private Button button;

        private CardPresentationSystem handPresentationSystem;
        // private CardWithArrowSelectionSystem cardWithArrowSelectionSystem;
        // private CardWithoutArrowSelectionSystem cardWithoutArrowSelectionSystem;

        private void Awake()
        {
            button = GetComponent<Button>();
        }

        private void Start()
        {
            handPresentationSystem = FindObjectOfType<CardPresentationSystem>();
            // cardWithArrowSelectionSystem = FindObjectOfType<CardWithArrowSelectionSystem>();
            // cardWithoutArrowSelectionSystem = FindObjectOfType<CardWithoutArrowSelectionSystem>();
        }

        public void OnButtonPressed()
        {
            if (handPresentationSystem.IsAnimating())
            {
                return;
            }

            // if (cardWithArrowSelectionSystem.HasSelectedCard() ||
            //     cardWithoutArrowSelectionSystem.HasSelectedCard())
            // {
            //     return;
            // }

            button.interactable = false;

            var system = GameObject.FindObjectOfType<PhaseManagementSystem>();
            system.EndInvestigationPhase();
        }

        public void OnPlayerTurnBegan()
        {
            button.interactable = true;
        }
    }
}
