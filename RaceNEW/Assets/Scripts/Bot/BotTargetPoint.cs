using UnityEngine;

namespace Cars
{
    public class BotTargetPoint : MonoBehaviour
    {
        private bool _isTrigerred;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, 2f);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponentInParent<BotController>() && _isTrigerred == false)
            {
                _isTrigerred = true;
                other.gameObject.GetComponentInParent<BotController>().IndexPlus(1);
            }
        }
    }
}