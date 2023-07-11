using System;
using UnityEngine;

namespace Cars
{
    public class ElapseTimeForTrackCounter : MonoBehaviour
    {
        public static float ElapsedTimeForCurrentTrack { get; private set; }
        public static bool Enabled;

        private void Start()
        {
            Enabled = true;
        }

        private void Update()
        {
            if (!Enabled) return;
            ElapsedTimeForCurrentTrack += Time.deltaTime;
            ElapsedTimeForCurrentTrack = (float)Math.Round(ElapsedTimeForCurrentTrack, 2);
        }
    }
}