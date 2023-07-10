using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Cars
{
    public class GameManager : MonoBehaviour
    {
        public static Action<GameObject> OnFinishAction;

        private void Start()
        {
            OnFinishAction += FinishManager.OnFinish;
        }

        private void Awake()
        {
            RaceSaveManager.Init();
        }
        public void ResetRaceDatas()
        {
            RaceSaveManager.ResetRaces();
        }
    }
    [Serializable]
    public struct RaceData
    {
        public float SpendedTimeForTrack { get; set; }
        public string CurrentName { get; set; }
        public int Index { get; set; }
    }
    public static class RaceSaveManager
    {
        private static List<RaceData> _races;
        private static string _path = string.Empty;
        public static bool HasRaceByIndex(int index)
        {
            return _races.Select(t => t.Index).Contains(index);
        }
        public static RaceData GetRaceDataByIndex(int index)
        {
            try
            {
                return _races.First(t => t.Index == index);
            }
            catch (Exception)
            {
                Debug.LogError($"Не существует гонка по индексу {index}");
                return default(RaceData);
            }
        }
        public static void Init()
        {
            _path = Application.persistentDataPath + "\\JSON\\Races.json";
            if (File.Exists(_path) == false)
            {
                if (Directory.Exists(Application.persistentDataPath + "\\JSON") == false)
                {
                    Directory.CreateDirectory(Application.persistentDataPath + "\\JSON");
                }
                File.Create(_path).Close();
            }
            _races = GetRacesFromJsonFile();
            if (_races == null)
            {
                _races = new List<RaceData>();
            }
        }
        public static int RaceDatasCount()
        {
            return _races.Count;
        }
        private static List<RaceData> GetRacesFromJsonFile()
        {
            if (File.ReadAllText(_path) == string.Empty) 
            {
                return null;
            }
            var json = JsonConvert.DeserializeObject<List<RaceData>>(File.ReadAllText(_path));
            
            return json;
        }
        public static void AddRaceToJsonFile(RaceData raceData)
        {
            _races.Add(raceData);
            File.WriteAllText(_path, JsonConvert.SerializeObject(_races, Formatting.Indented));
        }
        public static void Save()
        {
            File.WriteAllText(_path, JsonConvert.SerializeObject(_races, Formatting.Indented));
        }

        public static void ResetRaces()
        {
            _races = new List<RaceData>();
            File.WriteAllText(_path, JsonConvert.SerializeObject(_races));
        }

        public static void SetRaceDataByIndex(int index, RaceData newData)
        {
            _races[index] = newData;
        }

        public static void RemoveRaceByIndex(int index)
        {
            _races.RemoveAt(index);
        }
    }
    public class FinishManager
    {
        public static void OnFinish(GameObject obj)
        {
            FinishManagerView.ShowFinishPanel();
            int index = 0;
            if (RaceSaveManager.RaceDatasCount() >= 9)
            {
                RaceSaveManager.RemoveRaceByIndex(0);
                RaceSaveManager.Save();
            }
            foreach (var item in FinishManagerView.GetTexts())
            {
                var time = Speedometer.SpendedTimeForTrack;
                var name = FinishManagerView.CurrentName;
                if (RaceSaveManager.HasRaceByIndex(index) == false)
                {
                    var str = $"Race {index + 1} - {name} complete the track in { new DateTime().AddSeconds(time).ToString("mm:s:f")} seconds";
                    item.text = str;
                    RaceSaveManager.AddRaceToJsonFile(new RaceData() { SpendedTimeForTrack = time, CurrentName = name, Index = index });
                    if (RaceSaveManager.RaceDatasCount() == index + 1) break;
                }
                else
                {
                    var race = RaceSaveManager.GetRaceDataByIndex(index);
                    var str = $"Race {race.Index + 1} - {race.CurrentName} complete the track in { new DateTime().AddSeconds(race.SpendedTimeForTrack).ToString("mm:s:f")} seconds";
                    item.text = str;
                }
                index++;
            }
        }
    }
}