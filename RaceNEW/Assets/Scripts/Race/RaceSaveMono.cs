using System.Linq;
using Cars;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Save
{
    public class RaceSaveMono : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI[] _texts;
        [SerializeField] private Button _resetButton;

        [SerializeField] private Button _saveButton;
        private bool _saved;
#if UNITY_EDITOR
        [ContextMenu("Reset")]
        public void Reset()
        {
            RaceSaveManager.ResetRaces();
        }
#endif

        private void Start()
        {
            RaceSaveManager.Init();
            _resetButton.onClick.AddListener(() =>
            {
                RaceSaveManager.ResetRaces();
                foreach (var text in _texts) text.text = string.Empty;
            });
            _saveButton.onClick.AddListener(() =>
            {
                var race = CreateRace();
                if (_saved) return;

                RaceSaveManager.AddRace(race);
                RaceSaveManager.Save();
                _texts.First(t => t.text == string.Empty).text = RaceToString(race);
            });
            foreach (var item in _texts) item.text = string.Empty;

            if (_texts.Length <= RaceSaveManager.RaceDatasCount)
            {
                RaceSaveManager.RemoveRaceByIndex(RaceSaveManager.Races.First(t =>
                    t.ElapsedTimeForTrack == RaceSaveManager.Races.Max(t => t.ElapsedTimeForTrack)).Index);
            }

            for (var i = 0; i < RaceSaveManager.RaceDatasCount; i++)
            {
                var race = RaceSaveManager.GetRaceByIndex(i);

                _texts[i].text = RaceToString(race);
            }
        }

        private void OnApplicationQuit()
        {
            RaceSaveManager.Save();
        }

        private string RaceToString(RaceData race)
        {
            return
                $"Race by index {race.Index + 1} and by name {race.Name} has finished track in {race.ElapsedTimeForTrack}";
        }

        private RaceData CreateRace()
        {
            return new RaceData
            {
                ElapsedTimeForTrack = ElapseTimeForTrackCounter.ElapsedTimeForCurrentTrack,
                Name = PlayerPrefs.GetString(FinishPanelManager.PlayerPrefsPathToRaceName)
            };
        }
    }
}