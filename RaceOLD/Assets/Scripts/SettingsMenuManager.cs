using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Cars.Settings.Manager
{
    public class SettingsMenuManager : MonoBehaviour
    {
        [SerializeField]
        private Slider _maxWheelAngle, _torque, _mass, _centerOfMass, _brakeTorque;
        [SerializeField]
        private TextMeshProUGUI _maxWheelAngleText, _torqueText, _massText, _centerOfMassText, _brakeTorqueText;
        public static float MaxWheelAngleValue = 45f, TorqueValue = 2500f, MassValue = 1000f, CenterOfMassValue = -0.5f, BrakeTorqueValue = float.MaxValue;
        [SerializeField]
        private Button _toMainMenu;

        private void Start()
        {
            _toMainMenu.onClick.AddListener(() => UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu"));
            _maxWheelAngle.onValueChanged.AddListener(t => { _maxWheelAngleText.text = Math.Round(t, 1).ToString(); MaxWheelAngleValue = (float)Math.Round(t, 1); });
            _torque.onValueChanged.AddListener(t => { _torqueText.text = Math.Round(t, 1).ToString(); TorqueValue = (float)Math.Round(t, 1); });
            _mass.onValueChanged.AddListener(t => { _massText.text = Math.Round(t, 1).ToString(); MassValue = (float)Math.Round(t, 1); });
            _centerOfMass.onValueChanged.AddListener(t => { _centerOfMassText.text = Math.Round(t, 1).ToString(); CenterOfMassValue = (float)Math.Round(t, 1); });
            _brakeTorque.onValueChanged.AddListener(t => { _brakeTorqueText.text = Math.Round(t, 1).ToString(); BrakeTorqueValue = (float)Math.Round(t, 1); });
            Init();
        }

        private void Init()
        {
            _maxWheelAngle.value = MaxWheelAngleValue;
            _torque.value = TorqueValue;
            _mass.value = MassValue;
            _centerOfMass.value = CenterOfMassValue;
            _brakeTorque.value = BrakeTorqueValue;

            _maxWheelAngle.onValueChanged.Invoke(MaxWheelAngleValue);
            _torque.onValueChanged.Invoke(TorqueValue);
            _mass.onValueChanged.Invoke(MassValue);
            _centerOfMass.onValueChanged.Invoke(CenterOfMassValue);
            _brakeTorque.onValueChanged.Invoke(BrakeTorqueValue);
        }
    }
}