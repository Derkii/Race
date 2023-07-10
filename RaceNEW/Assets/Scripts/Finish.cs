using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cars
{
    public class Finish : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            var obj = collision.gameObject.GetComponent<IFinishReactable>();
            if (obj == null)
            {
                obj = collision.gameObject.GetComponentInChildren<IFinishReactable>();
                if (obj == null)
                {
                    obj = collision.gameObject.GetComponentInParent<IFinishReactable>();
                    if (obj == null) return;
                }
            }
            if (obj != null)
            {
                obj.OnFinish();
            }
        }
    }
}