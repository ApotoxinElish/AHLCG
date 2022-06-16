using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AHLCG
{
    public class RoundSequence : MonoBehaviour
    {
#pragma warning disable 649
        [SerializeField]
        private GameSystem gameSystem;

        [Space]
        [SerializeField]
        private BasePhase MythosPhase;
        [SerializeField]
        private BasePhase InvestigationPhase;
        [SerializeField]
        private BasePhase EnemyPhase;
        [SerializeField]
        private BasePhase UpkeepPhase;
#pragma warning restore 649

        public void Initialize()
        {
            Debug.Log("Round Sequence Initialize");
        }

        public void BeginGame()
        {
            BeginInvestigationPhase();
        }

        private void BeginMythosPhase() { }

        private void BeginInvestigationPhase()
        {
            Debug.Log("Investigation Phase Begin");
        }

        private void BeginEnemyPhase() { }

        private void BeginUpkeepPhase() { }
    }
}
