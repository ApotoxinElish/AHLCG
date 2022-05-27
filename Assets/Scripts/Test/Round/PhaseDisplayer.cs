using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PhaseDisplayer : MonoBehaviour
{
    public TMP_Text phaseText;
    // Start is called before the first frame update
    void Awake()
    {
        // RoundManager.Instance.phaseChangeEvent.AddListener(UpdateText);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateText()
    {
        phaseText.text = RoundManager.Instance.GamePhase.ToString();
    }
}
