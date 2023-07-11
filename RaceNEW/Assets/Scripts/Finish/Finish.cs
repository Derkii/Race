using System;
using UnityEngine;

namespace Cars
{
    public class Finish : MonoBehaviour
    {
        public Action<IFinishReactable> OnFinishAction;

        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.TryGetComponent(out IFinishReactable finishReactable))
            {
                finishReactable = collision.gameObject.GetComponentInChildren<IFinishReactable>();
                if (finishReactable == null)
                {
                    finishReactable = collision.gameObject.GetComponentInParent<IFinishReactable>();
                    if (finishReactable == null) return;
                }
            }

            finishReactable.OnFinish(this);
            OnFinishAction.Invoke(finishReactable);
            ElapseTimeForTrackCounter.Enabled = false;
        }

        public void OnDestroy()
        {
            OnFinishAction = null;
        }
    }
}