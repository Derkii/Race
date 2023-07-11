using UnityEngine;

namespace Cars
{
    public abstract class BaseInputController : MonoBehaviour
    {
        public float Acceleration { get; set; }
        
        public float Rotate { get; protected set; }
        public event System.Action<bool> OnHandBrake;

        protected abstract void FixedUpdate();
        protected void CallHandBrake(bool isBrake)
        {
            OnHandBrake?.Invoke(isBrake);
        }

        private void OnDestroy()
        {
            OnHandBrake = null;
            OnDestroyAction();
        }

        protected virtual void OnDestroyAction()
        {
            
        }
    }
}
