using System;

namespace Save
{
    [Serializable]
    public struct RaceData
    {
        public float ElapsedTimeForTrack;

        public string Name;

        public int Index;
    }

    public struct ReadonlyRaceData
    {
        private RaceData _raceData;
        public float ElapsedTimeForTrack => _raceData.ElapsedTimeForTrack;
        public string Name => _raceData.Name;
        public int Index => _raceData.Index;

        public ReadonlyRaceData(RaceData raceData)
        {
            _raceData = raceData;
        }
    }
}