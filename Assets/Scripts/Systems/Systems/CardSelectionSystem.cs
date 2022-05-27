using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;

namespace AHLCG
{
    /// <summary>
    /// This system is responsible for detecting when a card
    /// is selected and played by the player.
    /// </summary>
    public class CardSelectionSystem : MonoBehaviour
    {
        public IntVariable PlayerResource;

        public PhaseManagementSystem PhaseManagementSystem;
        public DeckManagementSystem DeckDrawingSystem;
        public CardPresentationSystem HandPresentationSystem;

        protected Camera MainCamera;
        protected LayerMask CardLayer;

        protected GameObject SelectedCard;

        [SerializeField]
        private Transform playArea;

        private Vector3 originalCardPos;
        private Quaternion originalCardRot;
        private int originalCardSortingOrder;

        private bool isCardAboutToBePlayed;

        private const float CardAnimationTime = 0.4f;
        private const float CardSelectionCanceledAnimationTime = 0.2f;
        private const float CardAboutToBePlayedOffsetY = 1.5f;
        private const Ease CardAnimationEase = Ease.OutBack;

        protected void Start()
        {
            CardLayer = 1 << LayerMask.NameToLayer("Card");
            MainCamera = Camera.main;

            // var pivot = GameObject.Find("PlayArea");
            // if (pivot != null)
            //     cardArea = pivot.transform.position;
        }

        private void Update()
        {
            if (PhaseManagementSystem.IsEndOfGame())
                return;

            if (HandPresentationSystem.IsAnimating())
                return;

            if (isCardAboutToBePlayed)
                return;

            if (Input.GetMouseButtonDown(0))
            {
                DetectCardSelection();
            }
            else if (Input.GetMouseButtonDown(1))
            {
                DetectCardUnselection();
            }

            if (SelectedCard != null)
                UpdateSelectedCard();
        }

        private void DetectCardSelection()
        {
            if (SelectedCard != null)
                return;

            // Checks if the player clicked over a card.
            var mousePos = MainCamera.ScreenToWorldPoint(Input.mousePosition);
            var hitInfo = Physics2D.Raycast(mousePos, Vector3.forward, Mathf.Infinity, CardLayer);
            if (hitInfo.collider != null)
            {
                var card = hitInfo.collider.GetComponent<CardObject>();
                var cardTemplate = card.Template;
                if (cardTemplate.Cost <= PlayerResource.Value)
                {
                    SelectedCard = hitInfo.collider.gameObject;
                    originalCardPos = SelectedCard.transform.position;
                    originalCardRot = SelectedCard.transform.rotation;
                    originalCardSortingOrder = SelectedCard.GetComponent<SortingGroup>().sortingOrder;
                }
            }
        }

        private void DetectCardUnselection()
        {
            if (SelectedCard != null)
            {
                var seq = DOTween.Sequence();
                seq.AppendCallback(() =>
                {
                    SelectedCard.GetComponent<CardObject>().SetState(CardObject.CardState.InHand);
                    SelectedCard.transform
                        .DOMove(originalCardPos, CardSelectionCanceledAnimationTime)
                        .SetEase(CardAnimationEase);
                    SelectedCard.transform.DORotate(originalCardRot.eulerAngles, CardSelectionCanceledAnimationTime);
                });
                seq.OnComplete(() =>
                {
                    SelectedCard.GetComponent<SortingGroup>().sortingOrder = originalCardSortingOrder;
                    SelectedCard = null;
                });
            }
        }

        private void UpdateSelectedCard()
        {
            if (Input.GetMouseButtonUp(0))
            {
                var card = SelectedCard.GetComponent<CardObject>();
                if (card.State == CardObject.CardState.AboutToBePlayed)
                {
                    isCardAboutToBePlayed = true;

                    var seq = DOTween.Sequence();
                    seq.Append(SelectedCard.transform
                        .DOMove(playArea.position, CardAnimationTime)
                        .SetEase(CardAnimationEase));
                    seq.AppendInterval(CardAnimationTime + 0.1f);
                    seq.AppendCallback(() =>
                    {
                        PlaySelectedCard();
                        SelectedCard = null;
                        isCardAboutToBePlayed = false;
                    });
                    SelectedCard.transform.DORotate(Vector3.zero, CardAnimationTime);
                }
                else
                {
                    card.SetState(CardObject.CardState.InHand);
                    SelectedCard.GetComponent<CardObject>().Reset(() => SelectedCard = null);
                }
            }

            if (SelectedCard != null)
            {
                var mousePos = MainCamera.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0;
                SelectedCard.transform.position = mousePos;

                var card = SelectedCard.GetComponent<CardObject>();
                if (mousePos.y > originalCardPos.y + CardAboutToBePlayedOffsetY)
                    card.SetState(CardObject.CardState.AboutToBePlayed);
                else
                    card.SetState(CardObject.CardState.InHand);
            }
        }

        protected void PlaySelectedCard()
        {
            var cardObject = SelectedCard.GetComponent<CardObject>();
            cardObject.SetInteractable(false);
            var cardTemplate = cardObject.Template;
            PlayerResource.SetValue(PlayerResource.Value - cardTemplate.Cost);

            HandPresentationSystem.RearrangeHand(SelectedCard);
            HandPresentationSystem.RemoveCardFromHand(SelectedCard);
            HandPresentationSystem.MoveCardToDiscardPile(SelectedCard);

            DeckDrawingSystem.MoveCardToDiscardPile(cardObject.RuntimeCard);

            var card = SelectedCard.GetComponent<CardObject>().RuntimeCard;
            // EffectResolutionSystem.ResolveCardEffects(card);
        }

        public bool HasSelectedCard()
        {
            return SelectedCard != null;
        }
    }
}
