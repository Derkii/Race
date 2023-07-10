using Cars.Animations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Cars
{
    public class Speedometer : MonoBehaviour
    {
        private CarComponent _car;

        private const float c_convertMeterInSecFromRmInH = 3.6f;

        [SerializeField]
        private float _maxSpeed = 300f;
        [SerializeField]
        private Color _minColor = Color.yellow;
        [SerializeField]
        private Color _maxColor = Color.red;
        [SerializeField]
        private TextMeshProUGUI _speedInKmsText, _spendTimeForTrackText;
        [SerializeField, Range(0.1f, 1f)]
        private float _delay = 0.3f;

        public static float SpendedTimeForTrack { private set; get; }
        private TextAnimationScript _textAnimScript;

        private void Start()
        {
            _car = FindObjectOfType<CarComponent>();
            StartCoroutine(SpeedTest());
            GameManager.OnFinishAction += (t) => { Destroy(_speedInKmsText.gameObject); Destroy(_spendTimeForTrackText); Destroy(this); };
            _textAnimScript = FindObjectOfType<TextAnimationScript>();
        }
        private void Update()
        {
            if (_textAnimScript == null)
            {
                SpendedTimeForTrack += Time.deltaTime;
                _spendTimeForTrackText.text = new DateTime().AddSeconds(SpendedTimeForTrack).ToString("mm:s:fff");
            }
            SpendedTimeForTrack = (float)Math.Round(SpendedTimeForTrack, 2);
        }

        private IEnumerator SpeedTest()
        {
            var prevPos = _car.transform.position;
            while (true)
            {
                var distance = Vector3.Distance(prevPos, _car.transform.position);
                var speed = (float)Math.Round(distance / _delay * c_convertMeterInSecFromRmInH, 1);

                _speedInKmsText.text = speed.ToString();
                _speedInKmsText.color = Color.Lerp(_minColor, _maxColor, speed / _maxSpeed);
                prevPos = _car.transform.position;

                yield return new WaitForSeconds(_delay);
            }
        }
    }
}