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

        [SerializeField]
        private InvestigatorTemplate investigator;

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
            gameSystem.SetInvestigator(investigator);
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
