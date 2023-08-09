using Sliders;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Loading
{
    public class CarsGameLoader : MonoBehaviour
    {
        private void Start() => SceneManager.LoadScene(new SettingsGetter().SettingsExist() ? "CarsScene" : "CarSettingsScene");
    }
}

