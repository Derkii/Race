using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Cars.Managers
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private Button _playButton, _settingsButton, _exitButton;

        private void Start()
        {
            _playButton.onClick.AddListener(() => SceneManager.LoadScene("LoadingScene"));
            _settingsButton.onClick.AddListener(() => SceneManager.LoadScene("CarSettingsScene"));
            _exitButton.onClick.AddListener(() =>
            {
#if UNITY_EDITOR
                EditorApplication.isPlaying = false;
#endif
                Application.Quit();
            });
        }
    }
}