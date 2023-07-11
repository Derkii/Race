using Cars.Settings.Manager;
using UnityEngine;

namespace Cars
{
    public interface IFinishReactable
    {
        void OnFinish(Finish finish);
    }
    public class CarComponent : MonoBehaviour, IFinishReactable
    {
        private BaseInputController _inputs;
        [SerializeField]
        private WheelsComponent _wheels;
        private Rigidbody _rb;
        [SerializeField, Range(1f, 360f)]
        private float _maxSteerAngle = 25f;
        [SerializeField, Min(1f)]
        private float _torque = 2500f;
        [SerializeField]
        private float _brakeTorque = float.MaxValue;
        [SerializeField]
        private Vector3 _centerOfMass;

        private void Start()
        {
            _maxSteerAngle = SettingsMenuManager.MaxWheelAngleValue;
            _torque = SettingsMenuManager.TorqueValue;
            _brakeTorque = SettingsMenuManager.BrakeTorqueValue;
            _centerOfMass = new Vector3(0f, SettingsMenuManager.CenterOfMassValue, 0f);

            _inputs = GetComponent<BaseInputController>();
            _rb = GetComponent<Rigidbody>();
            _rb.mass = SettingsMenuManager.MassValue;
            _inputs.OnHandBrake += OnHandBrake;
            _rb.centerOfMass = _centerOfMass;
        }
        private void FixedUpdate()
        {
            _wheels.UpdateVisual(_inputs.Rotate * _maxSteerAngle);
            var torque = _inputs.Acceleration * _torque;
            
            foreach (var item in _wheels.GetRearWheels)
            {
                item.motorTorque = torque * _inputs.Acceleration;
            }
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.TransformPoint(_centerOfMass), 0.5f);
        }
        private void OnHandBrake(bool isBrake)
        {
            if (isBrake)
            {
                foreach (var item in _wheels.GetRearWheels)
                {
                    item.brakeTorque = _brakeTorque;
                    item.motorTorque = 0f;
                }
            }
            else
            {
                foreach (var item in _wheels.GetRearWheels)
                {
                    item.brakeTorque = 0f;
                }
            }
        }
        private void OnDestroy()
        {
            _inputs.OnHandBrake -= OnHandBrake;
        }

        public void OnFinish(Finish finish)
        {
        }

        public void OnFinish()
        {
            throw new System.NotImplementedException();
        }
    }
}