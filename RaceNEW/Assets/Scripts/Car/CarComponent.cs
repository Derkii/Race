using System;
using Sliders;
using UnityEngine;

namespace Cars
{
    public class CarComponent : MonoBehaviour, IFinishReactable
    {
        [SerializeField] private WheelsComponent _wheels;
        [SerializeField] [Range(1f, 360f)] private float _maxSteerAngle = 25f;
        [SerializeField] [Min(1f)] private float _torque = 2500f;
        [SerializeField] private float _brakeTorque = float.MaxValue;
        [SerializeField] private Vector3 _centerOfMass;
        private BaseInputController _inputs;
        private Rigidbody _rb;

        private void Start()
        {
            var getter = new SettingsGetter();

            _maxSteerAngle = getter.StartBuild().WithNotFullName("WheelAngle").Setting.Value;
            _torque = getter.StartBuild().WithNotFullName("Torque").WithExclusion("Brake").Setting.Value;
            _brakeTorque = getter.StartBuild().WithNotFullName("BrakeTorque").Setting.Value;

            _inputs = GetComponent<BaseInputController>();
            _rb = GetComponent<Rigidbody>();
            _rb.mass = getter.StartBuild().WithFullName("Mass").Setting.Value;
            _inputs.OnHandBrake += OnHandBrake;
            _rb.centerOfMass = _centerOfMass;
        }

        private void FixedUpdate()
        {
            _wheels.UpdateVisual(_inputs.Rotate * _maxSteerAngle);
            var torque = _inputs.Acceleration * _torque;

            foreach (var item in _wheels.GetRearWheels) item.motorTorque = torque * _inputs.Acceleration;
        }

        private void OnDestroy()
        {
            _inputs.OnHandBrake -= OnHandBrake;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.TransformPoint(_centerOfMass), 0.5f);
        }

        private void OnHandBrake(bool isBrake)
        {
            if (isBrake)
                foreach (var item in _wheels.GetRearWheels)
                {
                    item.brakeTorque = _brakeTorque;
                    item.motorTorque = 0f;
                }
            else
                foreach (var item in _wheels.GetRearWheels)
                    item.brakeTorque = 0f;
        }

        public void OnFinish()
        {
        }
    }
}