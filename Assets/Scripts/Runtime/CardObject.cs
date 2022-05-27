using DG.Tweening;
using System;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

namespace AHLCG
{
    /// <summary>
    /// This component is linked to the actual GameObjects corresponding to the cards that
    /// are in the player's hand.
    /// </summary>
    public class CardObject : MonoBehaviour
    {
#pragma warning disable 649
        [SerializeField]
        private TextMeshPro costText;
        [SerializeField]
        private TextMeshPro titleText;
        [SerializeField]
        private TextMeshPro typeText;
        [SerializeField]
        private TextMeshPro abilityText;

        [SerializeField]
        private SpriteRenderer picture;
        [SerializeField]
        private SpriteRenderer glow;

        [SerializeField]
        private Color inHandColor;
        [SerializeField]
        private Color aboutToBePlayedColor;
#pragma warning restore 649

        public RuntimeCard RuntimeCard;
        public CardTemplate Template;

        private SortingGroup sortingGroup;

        private Vector3 cachedPos;
        private Quaternion cachedRot;
        private int cachedSortingOrder;
        private int highlightedSortingOrder;

        private bool interactable;

        private CardPresentationSystem handPresentationSystem;
        private CardSelectionSystem cardSelectionSystem;

        private bool beingHighlighted;
        private bool beingUnhighlighted;

        public enum CardState
        {
            InHand,
            AboutToBePlayed
        }

        public CardState State => currState;
        private CardState currState;

        private void Awake()
        {
            sortingGroup = GetComponent<SortingGroup>();
            SetGlowEnabled(false);
        }

        private void Start()
        {
            handPresentationSystem = FindObjectOfType<CardPresentationSystem>();
            cardSelectionSystem = FindObjectOfType<CardSelectionSystem>();
        }

        // private void OnEnable()
        // {
        //     SetState(CardState.InHand);
        // }

        public void SetInfo(RuntimeCard card)
        {
            RuntimeCard = card;
            Template = card.Template;
            // costText.text = Template.Cost.ToString();
            // titleText.text = Template.Title;
            // typeText.text = "Asset";
            // var builder = new StringBuilder();
            // foreach (var effect in Template.Effects)
            // {
            //     builder.AppendFormat("{0}. ", effect.GetName());
            // }
            // abilityText.text = builder.ToString();
            // picture.material = Template.Material;
            picture.sprite = Template.Picture;
        }

        public void SetGlowEnabled(bool glowEnabled)
        {
            glow.enabled = glowEnabled;
        }

        public void SetGlowEnabled(int playerResource)
        {
            glow.enabled = playerResource >= Template.Cost;
        }

        public bool IsGlowEnabled()
        {
            return glow.enabled;
        }

        public void OnResourceChanged(int resource)
        {
            SetGlowEnabled(Template.Cost <= resource);
        }

        public void SetState(CardState state)
        {
            currState = state;
            switch (currState)
            {
                case CardState.InHand:
                    glow.color = inHandColor;
                    break;

                case CardState.AboutToBePlayed:
                    glow.color = aboutToBePlayedColor;
                    break;
            }
        }

        public void SetInteractable(bool value)
        {
            interactable = value;
        }

        public void CacheTransform(Vector3 position, Quaternion rotation)
        {
            cachedPos = position;
            cachedRot = rotation;
            cachedSortingOrder = sortingGroup.sortingOrder;
            highlightedSortingOrder = cachedSortingOrder + 10;
        }

        private void OnMouseEnter()
        {
            if (interactable)
            {
                HighlightCard();
                handPresentationSystem.UnHighlightOtherCards(gameObject);
            }
        }

        private void OnMouseExit()
        {
            if (interactable)
            {
                UnHighlightCard();
            }
        }

        public void HighlightCard()
        {
            if (cardSelectionSystem.HasSelectedCard())
            {
                return;
            }

            if (beingHighlighted)
            {
                return;
            }

            beingHighlighted = true;

            sortingGroup.sortingOrder = highlightedSortingOrder;
            transform.DOMove(cachedPos + new Vector3(0.0f, 35f / 108f, 0.0f), 0.05f)
                .SetEase(Ease.OutCubic)
                .OnComplete(() => beingHighlighted = false);
        }

        public void UnHighlightCard()
        {
            if (cardSelectionSystem.HasSelectedCard())
            {
                return;
            }

            if (beingUnhighlighted)
            {
                return;
            }

            beingUnhighlighted = true;

            sortingGroup.sortingOrder = cachedSortingOrder;
            // var y = transform.position.y;
            // var seq = DOTween.Sequence();
            transform.DOMove(cachedPos, 0.02f)
                .SetEase(Ease.OutCubic)
                .OnComplete(() => beingUnhighlighted = false);
        }

        public void Reset(Action onComplete)
        {
            transform.DOMove(cachedPos, 0.2f);
            transform.DORotateQuaternion(cachedRot, 0.2f);
            sortingGroup.sortingOrder = cachedSortingOrder;
            onComplete();
        }
    }
}
