﻿using UnityEngine;

namespace Cars
{
    public class PlayerInputController : BaseInputController
    {
        private CarControls _controls;

        private void Awake()
        {
            _controls = new CarControls();
            _controls.Player.HandBrake.performed += a => CallHandBrake(true);
            _controls.Player.HandBrake.canceled += a => CallHandBrake(false);
        }

        protected override void FixedUpdate()
        {
            Acceleration = _controls.Player.Acceleration.ReadValue<float>();
            var direction = _controls.Player.Rotate.ReadValue<float>();
            if (direction == 0f && Rotate != 0f)
                Rotate = Rotate > 0f ? Rotate - Time.fixedDeltaTime : Rotate + Time.fixedDeltaTime;
            else
                Rotate = Mathf.Clamp(Rotate + direction * Time.fixedDeltaTime, -1f, 1f);
        }

        private void OnEnable()
        {
            _controls.Enable();
        }

        private void OnDisable()
        {
            _controls.Disable();
        }

        private void OnDestroy()
        {
            _controls.Dispose();
        }
    }
}