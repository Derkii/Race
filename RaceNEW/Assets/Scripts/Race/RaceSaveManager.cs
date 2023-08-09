using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

namespace Save
{
    public static class RaceSaveManager
    {
        private static List<RaceData> _races;
        private static string _path = string.Empty;

        public static IReadOnlyList<ReadonlyRaceData> Races =>
            _races.Select(t => new ReadonlyRaceData(t)).ToArray();

        public static int RaceDatasCount =>
            _races.Count;

        public static bool HasRaceByIndex(int index)
        {
            return _races.Select(t => t.Index).Contains(index);
        }

        public static void ResetRaceDatas()
        {
            ResetRaces();
        }

        public static RaceData GetRaceByIndex(int index)
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
                    Directory.CreateDirectory(Application.persistentDataPath + "\\JSON");

                File.Create(_path).Close();
            }

            _races = GetRacesFromJsonFile();
            if (_races == null) _races = new List<RaceData>();
        }


        private static List<RaceData> GetRacesFromJsonFile()
        {
            if (File.ReadAllText(_path) == string.Empty) return null;

            var json = JsonConvert.DeserializeObject<List<RaceData>>(File.ReadAllText(_path));

            return json;
        }

        public static void AddRace(RaceData raceData)
        {
            raceData.Index = _races.Count;

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