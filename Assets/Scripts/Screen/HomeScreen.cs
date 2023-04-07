using System.Collections.Generic;
using System.IO;

using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

using DG.Tweening;
// using FullSerializer;
using TMPro;

namespace AHLCG
{
    public class HomeScreen : BaseScreen
    {
#pragma warning disable 649
        [SerializeField] private TextMeshProUGUI versionText;
#pragma warning restore 649

        protected override void Awake()
        {
            base.Awake();

            Assert.IsNotNull(versionText);
            SceneManager.sceneLoaded += (scene, mode) => { DOTween.KillAll(); };
        }

        protected override void Start()
        {
            base.Start();

            Application.targetFrameRate = 60;

            DOTween.SetTweensCapacity(500, 50);

            versionText.text = "Version " + AHLCGInfo.version;

            GameManager.Instance.Initialize();
        }

        public void OnPlayButtonPressed()
        {
            SceneManager.LoadScene("Lobby");
        }

        public void OnDecksButtonPressed()
        {
            SceneManager.LoadScene("DeckBuilder");
        }

        public void OnQuitButtonPressed()
        {
            OpenPopup<PopupTwoButtons>("PopupTwoButtons", popup =>
            {
                popup.text.text = "Do you want to quit?";
                popup.buttonText.text = "Yes";
                popup.button2Text.text = "No";
                popup.button.onClickEvent.AddListener(() => { Application.Quit(); });
                popup.button2.onClickEvent.AddListener(() => { popup.Close(); });
            });
        }
    }
}
