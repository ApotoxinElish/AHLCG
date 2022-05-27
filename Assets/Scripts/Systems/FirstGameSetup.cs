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
        private PlayerWidget playerWidget;
        [SerializeField]
        private PlayableCharacterConfiguration playerConfig;
        [SerializeField]
        private InvestigatorTemplate investigatorTemplate;

        [Space]
        [SerializeField]
        private ObjectPool handArea;
#pragma warning restore 649

        public void Initialize()
        {
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
            var resource = playerConfig.Resource;
            health.Value = investigatorTemplate.Health;
            sanity.Value = investigatorTemplate.Sanity;
            resource.Value = investigatorTemplate.Resource;

            playerWidget.Initialize(investigatorTemplate);

            gameSystem.SetInvestigator(investigatorTemplate);
        }

        private void GatherDecks()
        {
            handArea.Initialize();
        }

        private void ChooseLeadInvestigator() { }

        private void AssembleTokenPool() { }

        private void AssembletheChaosBag() { }

        private void TakeStartingResources() { }

        private void DrawOpeningHand() { }
    }
}
