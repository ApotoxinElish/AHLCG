using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AHLCG
{
    public abstract class BasePhase : MonoBehaviour
    {
#pragma warning disable 649
        [SerializeField]
        private RoundSequence roundSequence;
#pragma warning restore 649

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
