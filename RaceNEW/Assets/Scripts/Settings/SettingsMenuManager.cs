using System;
using System.Linq;
using Newtonsoft.Json;
using Sliders;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Cars.Managers
{
    public class SettingsMenuManager : MonoBehaviour
    {
        [SerializeField] private Setting[] _sliders;
        [SerializeField] private Button _toMainMenu;

        public void OnValidate()
        {
            foreach (var slider in _sliders)
            {
                if (slider.data.Name == default)
                {
                    slider.SetName(slider.gameObject.name);
                }
            }
        }

        [ContextMenu("ResetSave")]
        private void ResetSave()
        {
            PlayerPrefs.SetString(SettingsGetter.SavePath, string.Empty);
        }

        private void Start()
        {
            var getter = new SettingsGetter();
            foreach (var setting in _sliders)
            {
                try
                {
                    setting.SetValue(getter.StartBuild().WithFullName(setting.data.Name).Setting.Value);
                }
                catch (Exception e)
                {
                    setting.SetValue(setting.SliderValue);
                }

                setting.Init();
            }

            _toMainMenu.onClick.AddListener(() => SceneManager.LoadScene("MainMenu"));
        }

        private void OnDisable()
        {
            Save();
        }

        private void Save()
        {
            var datas = new Setting.Data[_sliders.Length];
            for (var index = 0; index < _sliders.Length; index++)
            {
                datas[index] = _sliders[index].data;
            }

            PlayerPrefs.SetString(SettingsGetter.SavePath, JsonConvert.SerializeObject(datas));
            PlayerPrefs.Save();
        }
    }
}