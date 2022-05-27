using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AHLCG
{
    public class GameBootstrap : MonoBehaviour
    {
#pragma warning disable 649
        [SerializeField]
        private PlayableCharacterConfiguration playerConfig;

        [SerializeField]
        private DeckManagementSystem deckDrawingSystem;
        [SerializeField]
        private CardPresentationSystem handPresentationSystem;
        [SerializeField]
        private PhaseManagementSystem phaseManagementSystem;
        [SerializeField]
        private EffectResolutionSystem effectResolutionSystem;

        [SerializeField]
        private PlayerTemplate characterTemplate;

        [SerializeField]
        private Canvas canvas;

        [SerializeField]
        private PlayerWidget playerWidget;
        [SerializeField]
        private DeckWidget deckWidget;
        [SerializeField]
        private DiscardPileWidget discardPileWidget;
        [SerializeField]
        private EndTurnButton endTurnButton;

        [SerializeField]
        private ObjectPool handPool;
        // [SerializeField]
        // private ObjectPool assetPool;
        // [SerializeField]
        // private ObjectPool threatPool;
        // [SerializeField]
        // private ObjectPool deckPool;
        // [SerializeField]
        // private ObjectPool discardPool;
#pragma warning restore 649

        private Camera mainCamera;

        private CardLibrary playerDeck;

        private GameObject player;

        private void Start()
        {
            mainCamera = Camera.main;

            handPool.Initialize();

            CreatePlayer(characterTemplate);
        }

        private void CreatePlayer(PlayerTemplate template)
        {
            // player = Instantiate(template.Prefab, playerPivot);
            // Assert.IsNotNull(player);

            playerDeck = template.StartingDeck;

            var health = playerConfig.Health;
            var sanity = playerConfig.Sanity;
            var resource = playerConfig.Resource;
            health.Value = template.Health;
            sanity.Value = template.Sanity;
            resource.Value = template.Resource;

            // healthWidget.Initialize(health);
            // sanityWidget.Initialize(sanity);
            playerWidget.Initialize(template);

            InitializeGame();
        }

        private void InitializeGame()
        {
            deckDrawingSystem.Initialize(deckWidget, discardPileWidget);
            var deckSize = deckDrawingSystem.LoadDeck(playerDeck);
            deckDrawingSystem.ShuffleDeck();

            handPresentationSystem.Initialize(handPool, deckWidget, discardPileWidget);

            // effectResolutionSystem.Initialize(playerCharacter, enemyCharacter);

            phaseManagementSystem.BeginGame();
        }
    }
}
