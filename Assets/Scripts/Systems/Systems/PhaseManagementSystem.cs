using UnityEngine;

namespace AHLCG
{
    public class PhaseManagementSystem : MonoBehaviour
    {
        [SerializeField]
        private IntVariable PlayerResource;

        public GameEvent GameBegan;
        public GameEvent MythosPhaseBegan;
        public GameEvent MythosPhaseEnded;
        public GameEvent InvestigationPhaseBegan;
        public GameEvent InvestigationPhaseEnded;
        public GameEvent EnemyPhaseBegan;
        public GameEvent EnemyPhaseEnded;
        public GameEvent UpkeepPhaseBegan;
        public GameEvent UpkeepPhaseEnded;

        private bool isMythosPhase;
        private bool isInvestigationPhase;
        private bool isEnemyPhase;
        private bool isUpkeepPhase;
        private float accTime;

        private bool isEndOfGame;

        private const float PhaseDuration = 1.0f;

        protected void Update()
        {
            if (isMythosPhase)
            {
                accTime += Time.deltaTime;
                if (accTime >= PhaseDuration)
                {
                    accTime = 0.0f;
                    EndMythosPhase();
                }
            }
            else if (isEnemyPhase)
            {
                accTime += Time.deltaTime;
                if (accTime >= PhaseDuration)
                {
                    accTime = 0.0f;
                    EndEnemyTurn();
                }
            }
            else if (isUpkeepPhase)
            {
                accTime += Time.deltaTime;
                if (accTime >= PhaseDuration)
                {
                    accTime = 0.0f;
                    EndUpkeepPhase();
                }
            }
        }

        public void BeginGame()
        {
            GameBegan.Raise();
            BeginInvestigationPhase();
        }

        public void BeginMythosPhase()
        {
            MythosPhaseBegan.Raise();
            isMythosPhase = true;
        }

        public void EndMythosPhase()
        {
            MythosPhaseEnded.Raise();
            isMythosPhase = false;
            BeginInvestigationPhase();
        }

        public void BeginInvestigationPhase()
        {
            InvestigationPhaseBegan.Raise();
            isInvestigationPhase = true;
        }

        public void EndInvestigationPhase()
        {
            InvestigationPhaseEnded.Raise();
            isInvestigationPhase = false;
            BeginEnemyPhase();
        }

        public void BeginEnemyPhase()
        {
            EnemyPhaseBegan.Raise();
            isEnemyPhase = true;
        }

        public void EndEnemyTurn()
        {
            EnemyPhaseEnded.Raise();
            isEnemyPhase = false;
            BeginUpkeepPhase();
        }

        public void BeginUpkeepPhase()
        {
            UpkeepPhaseBegan.Raise();
            isUpkeepPhase = true;
            PlayerResource.SetValue(PlayerResource.Value + 1);
        }

        public void EndUpkeepPhase()
        {
            UpkeepPhaseEnded.Raise();
            isUpkeepPhase = false;
            BeginMythosPhase();
        }

        public void SetEndOfGame(bool value)
        {
            isEndOfGame = value;
        }

        public bool IsEndOfGame()
        {
            return isEndOfGame;
        }
    }
}
