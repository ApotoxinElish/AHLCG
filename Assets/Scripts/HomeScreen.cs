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
    public class HomeScreen : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

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
            // OpenPopup<PopupTwoButtons>("PopupTwoButtons", popup =>
            // {
            //     popup.text.text = "Do you want to quit?";
            //     popup.buttonText.text = "Yes";
            //     popup.button2Text.text = "No";
            //     popup.button.onClickEvent.AddListener(() => { Application.Quit(); });
            //     popup.button2.onClickEvent.AddListener(() => { popup.Close(); });
            // });
        }
    }
}
