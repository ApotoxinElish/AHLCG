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

        void Awake()
        {

        }

        void Start()
        {

        }

        void OnDestroy()
        {

        }

        void OnSceneLoaded()
        {

        }

        public void OpenPopup()
        {

        }

        public void ClosePopup()
        {

        }
    }
}
