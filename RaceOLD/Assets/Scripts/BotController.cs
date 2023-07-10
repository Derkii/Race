using Cars.Animations;
using UnityEngine;

namespace Cars
{
    public class BotController : MonoBehaviour
    {
        [SerializeField]
        private BotTargetPoint[] _points;
        [SerializeField]
        private int _index = 0;
        [SerializeField]
        private Rigidbody _rb;
        [SerializeField]
        private float _maxVelocity, _maxSpeed;
        [SerializeField]
        private Vector3 _centerOfMass;
        private TextAnimationScript _textAnimScript;

        private void FixedUpdate()
        {
            if (_textAnimScript != null) return;
            OnSeek(_points[_index]);
        }
        private void Start()
        {
            _textAnimScript = FindObjectOfType<TextAnimationScript>();
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.TransformPoint(_centerOfMass), 0.5f);
        }
        private void OnSeek(BotTargetPoint botTargetPoint)
        {
            botTargetPoint.transform.position = new Vector3(botTargetPoint.transform.position.x, transform.position.y, botTargetPoint.transform.position.z);
            var desired_velocity = (botTargetPoint.transform.position - transform.position).normalized * _maxVelocity;
            //Коррекция движения от текущей к желаемой
            var steering = desired_velocity - _rb.velocity;
            //Учитываем огрначения по силе и массу объекта
            steering = Vector3.ClampMagnitude(steering, _maxVelocity) / _rb.mass;

            var velocity = Vector3.ClampMagnitude(_rb.velocity + steering, _maxSpeed);
            velocity.y = _rb.velocity.y;
            var oldRotation = transform.eulerAngles;
            transform.LookAt(botTargetPoint.transform);
            transform.eulerAngles = new Vector3(oldRotation.x, transform.eulerAngles.y, transform.eulerAngles.z);
            _rb.velocity = velocity;
        }

        public void IndexPlus(int v)
        {
            _index += v;
        }
    }
}