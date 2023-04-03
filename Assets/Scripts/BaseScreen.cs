using System;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using DG.Tweening;

namespace AHLCG
{
    public class BaseScreen : MonoBehaviour
    {
        public GameObject currentPopup { get; protected set; }

        [SerializeField]
        protected Canvas canvas;

        [SerializeField]
        protected CanvasGroup panelCanvasGroup;

        protected virtual void Awake()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        protected virtual void Start()
        {
        }

        protected virtual void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        protected virtual void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            DOTween.KillAll();
        }

        public void OpenPopup()
        {

        }

        public void ClosePopup()
        {

        }

        public void OnPopupClosed()
        {

        }
    }
}
