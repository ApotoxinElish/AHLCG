using UnityEngine;

using DG.Tweening;

namespace AHLCG
{
    public class Popup : MonoBehaviour
    {
        public BaseScreen parentScene;

        public void Close()
        {
            OnPopupClosedActions();

            if (parentScene != null)
            {
                parentScene.OnPopupClosed(this);
            }

            Destroy(gameObject);
        }

        public virtual void OnPopupClosedActions()
        {
            DOTween.KillAll();
        }
    }
}
