using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AHLCG
{
    /// <summary>
    /// In-Play Game System
    /// </summary>
    public class GameSystem : MonoBehaviour
    {
#pragma warning disable 649
        [SerializeField]
        private PlayerWidget playerWidget;
        [SerializeField]
        private DeckWidget deckWidget;
        [SerializeField]
        private DiscardPileWidget discardPileWidget;

        [Space]
        [SerializeField]
        private EncounterArea encounterArea;
        [SerializeField]
        private ObjectPool handArea;

        [Space]
        [SerializeField]
        private FirstGameSetup firstGameSetup;
        [SerializeField]
        private ScenarioSetup scenarioSetup;
        [SerializeField]
        private RoundSequence roundSequence;
#pragma warning restore 649

        // [SerializeField]
        private InvestigatorTemplate investigator;
        // [SerializeField]
        private List<RuntimeCard> playerDeck;

        private void Start()
        {
            firstGameSetup.Initialize();
            scenarioSetup.Initialize();
            roundSequence.Initialize();

            BeginGame();
        }

        private void BeginGame()
        {
            roundSequence.BeginGame();
        }

        public void SetInvestigator(InvestigatorTemplate _investigator)
        {
            investigator = _investigator;
            playerWidget.Initialize(_investigator);
        }

        public void SetPlayerDeck(List<RuntimeCard> deck, int discardPileCount = 0)
        {
            playerDeck = deck;
            deckWidget.SetAmount(deck.Count);
            discardPileWidget.SetAmount(discardPileCount);

            // Debug.Log(playerDeck);
        }
    }
}
