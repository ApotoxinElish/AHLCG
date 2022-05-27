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
        private FirstGameSetup firstGameSetup;
        [SerializeField]
        private ScenarioSetup scenarioSetup;
        [SerializeField]
        private RoundSequence roundSequence;
#pragma warning restore 649

        private Investigator investigator;

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

        public void SetInvestigator(Investigator _investigator)
        {
            investigator = _investigator;
        }
    }
}
