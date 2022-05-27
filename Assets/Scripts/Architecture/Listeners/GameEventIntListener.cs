using UnityEngine;
using UnityEngine.Events;

namespace AHLCG
{
    public class GameEventIntListener : MonoBehaviour
    {
        [Tooltip("Event to register with.")]
        public GameEventInt Event;

        [Tooltip("Response to invoke when Event is raised.")]
        public UnityEvent<int> Response;

        private void OnEnable()
        {
            Event.RegisterListener(this);
        }

        private void OnDisable()
        {
            Event.UnregisterListener(this);
        }

        public void OnEventRaised(int value)
        {
            Response.Invoke(value);
        }
    }
}
