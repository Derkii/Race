using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Cars.Animations
{
    public class TextAnimationScript : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _text;
        
        public void Start()
        {
            StartCoroutine(AnimationCoroutine());
        }

        private IEnumerator AnimationCoroutine()
        {
            var obj = (RectTransform)_text.transform;
            obj.localScale = Vector3.one;
            for (int i = int.Parse(_text.text);  i > 0; i--)
            {
                yield return Scale(obj, Vector3.one * 10, 0.5f);
                _text.text =  (int.Parse(_text.text) - 1).ToString();
                yield return Scale(obj, Vector3.one, 0.5f);
            }
            Destroy(gameObject);
        }
        private IEnumerator Scale(RectTransform tr, Vector3 scale, float time)
        {
            var currentTime = 0f;
            var startScale = tr.localScale;
            while (currentTime < time)
            {
                tr.localScale = Vector3.Slerp(startScale, scale, 1f - (time - currentTime) / time);

                currentTime += Time.deltaTime;
                yield return null;
            }
            tr.localScale = scale;

        }
    }
}
