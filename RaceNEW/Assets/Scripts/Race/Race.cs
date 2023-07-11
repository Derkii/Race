using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

namespace Save
{
    [Serializable]
    public struct RaceData
    {
        public float ElapsedTimeForTrack;

        public string Name;

        public int Index;
    }

    public static class RaceSaveManager
    {
        private static List<RaceData> _races;
        public static IReadOnlyList<RaceData> Races => _races;
        private static string _path = string.Empty;
        
        public static bool HasRaceByIndex(int index)
        {
            return _races.Select(t => t.Index).Contains(index);
        }
        
        public static void ResetRaceDatas()
        {
            ResetRaces();
        }

        static RaceSaveManager()
        {
            Init();
        }

        public static RaceData GetRaceDataByIndex(int index)
        {
            try
            {
                return _races.First(t => t.Index == index);
            }
            catch (Exception)
            {
                throw new Exception($"Race by index {index} doesn't exist");
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

        public static int RaceDatasCount =>
            _races.Count;


        private static List<RaceData> GetRacesFromJsonFile()
        {
            if (File.ReadAllText(_path) == string.Empty)
            {
                return null;
            }

            var json = JsonConvert.DeserializeObject<List<RaceData>>(File.ReadAllText(_path));

            return json;
        }

        public static void AddRace(RaceData raceData)
        {
            if (raceData.Index != _races.Count)
            {
                if (_races.FirstOrDefault(t => t.Index == _races.Count - 1).Equals(default))
                    raceData.Index = _races.Count;
                else throw new Exception($"Races already contains race by index {raceData.Index}");
            }

            _races.Add(raceData);
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
}