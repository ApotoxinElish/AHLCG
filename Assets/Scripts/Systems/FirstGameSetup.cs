using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AHLCG
{
    public class FirstGameSetup : MonoBehaviour
    {
#pragma warning disable 649
        [SerializeField]
        private GameSystem gameSystem;

        [Space]
        [SerializeField]
        private PlayableCharacterConfiguration playerConfig;
        [SerializeField]
        private InvestigatorTemplate investigatorTemplate;
#pragma warning restore 649

        public void Initialize()
        {
            Debug.Log("First Game Setup Initialize");

            ChooseInvestigators();
            GatherDecks();
            ChooseLeadInvestigator();
            AssembleTokenPool();
            AssembletheChaosBag();
            TakeStartingResources();
            DrawOpeningHand();
        }

        private void ChooseInvestigators()
        {
            var health = playerConfig.Health;
            var sanity = playerConfig.Sanity;
            health.Value = investigatorTemplate.Health;
            sanity.Value = investigatorTemplate.Sanity;

            // gameSystem.playerWidget.Initialize(investigatorTemplate);

            gameSystem.SetInvestigator(investigatorTemplate);
        }

        private void GatherDecks()
        {
            var deck = new List<RuntimeCard>();

            var library = investigatorTemplate.StartingDeck;
            foreach (var entry in library.Entries)
            {
                // Skip over invalid entries.
                if (entry.Card == null)
                    continue;

                for (var i = 0; i < entry.NumCopies; i++)
                {
                    var card = new RuntimeCard
                    {
                        Template = entry.Card
                    };
                    deck.Add(card);
                }
            }
            deck.Shuffle();
            gameSystem.SetPlayerDeck(deck);
        }

        private void ChooseLeadInvestigator() { }

        private void AssembleTokenPool() { }

        private void AssembletheChaosBag() { }

        private void TakeStartingResources()
        {
            playerConfig.Resource.SetValue(5);
        }

        private void DrawOpeningHand()
        {

        }
    }
}
