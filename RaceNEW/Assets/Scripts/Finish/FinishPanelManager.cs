using TMPro;
using UnityEngine;

namespace Cars
{
    public class FinishPanelManager : MonoBehaviour
    {
        [SerializeField] private GameObject Panel;

        [SerializeField] private TMP_InputField _nameInputField;

        public const string PlayerPrefsPathToRaceName = "nameInputFieldText";

        private void Start()
        {
            FindObjectOfType<Finish>().OnFinishAction += _ => ShowFinishPanel();
            _nameInputField.onEndEdit.AddListener(t => PlayerPrefs.SetString(PlayerPrefsPathToRaceName, t));
            _nameInputField.text = PlayerPrefs.GetString(PlayerPrefsPathToRaceName);
        }

        public void ShowFinishPanel()
        {
            Panel.SetActive(true);
        }
    }
}