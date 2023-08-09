using System;
using UnityEngine;

namespace Cars
{
    public abstract class BaseInputController : MonoBehaviour
    {
        public float Acceleration { get; set; }

        public float Rotate { get; protected set; }

        protected abstract void FixedUpdate();

        private void OnDestroy()
        {
            OnHandBrake = null;
            OnDestroyAction();
        }

        public event Action<bool> OnHandBrake;

        protected void CallHandBrake(bool isBrake)
        {
            OnHandBrake?.Invoke(isBrake);
        }

        protected virtual void OnDestroyAction()
        {
        }
    }
}