using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Cars
{
    public class FinishManagerView : MonoBehaviour
    {
        public static FinishManagerView instance;
        [SerializeField]
        private GameObject _panel;
        [SerializeField]
        private List<TextMeshProUGUI> _texts;
        [SerializeField]
        private InputField _nameInputField;

        public static string CurrentName { get => instance._nameInputField.text; }

        private void Start()
        {
            instance = this;
            foreach (var item in _texts)
            {
                item.text = string.Empty;
            }
            _nameInputField.onEndEdit.AddListener(t => PlayerPrefs.SetString("nameInputFieldText", t));
            _nameInputField.text = PlayerPrefs.GetString("nameInputFieldText");
        }

        public static void ShowFinishPanel()
        {
            instance._panel.SetActive(true);
        }
        public static IEnumerable<TextMeshProUGUI> GetTexts()
        {
            return instance._texts;
        }
    }
}