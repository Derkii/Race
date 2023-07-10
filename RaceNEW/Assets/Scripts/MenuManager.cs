using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Cars.Menu.MainUIManagement
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField]
        private Button _playButton, _settingsButton, _exitButton;

        private void Start()
        {
            _playButton.onClick.AddListener(() => UnityEngine.SceneManagement.SceneManager.LoadScene("CarsScene"));
            _settingsButton.onClick.AddListener(() => UnityEngine.SceneManagement.SceneManager.LoadScene("CarSettingsScene"));
            _exitButton.onClick.AddListener(() =>
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
                Application.Quit();
            });
            }
    }
}