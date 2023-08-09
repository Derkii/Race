using System;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sliders
{
    [Serializable]
    public class Setting
    {
        [SerializeField] private string _name;
        [SerializeField] private Slider _slider;
        [SerializeField] private TextMeshProUGUI _text;
        public Data data;
    
        public GameObject gameObject => _slider.gameObject;
        public float SliderValue => _slider.value;

        public void SetName(string name)
        {
            _name = name;
            data.Name = name;
        }

        public void SetValue(float value)
        {
            _slider.SetValueWithoutNotify(value);
            data.Value = value;
            _text.text = value.ToString();
        }
        public void Init()
        {
            _slider.onValueChanged.AddListener(SetValue);
        }
        [Serializable]
        public struct Data
        {
            [JsonProperty]
            public string Name { get; internal set; }
            [JsonProperty]
            public float Value { get; internal set; }
            
            internal Data(float value, string name)
            {
                Name = name;
                Value = value;
            }
        }
    }
}