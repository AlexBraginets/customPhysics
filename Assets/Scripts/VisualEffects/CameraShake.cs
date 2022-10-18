using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace VisualEffects
{
    public class CameraShake : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float step = .02f;
        [SerializeField] private AnimationCurve magnitudeCurve;
        private WaitForSeconds _wait;
        private float _duration;

        private void Awake()
        {
            _wait = new WaitForSeconds(step);
            _duration = magnitudeCurve[magnitudeCurve.length - 1].time;
        }
        [ContextMenu("Apply")]
        public void Apply()
        {
            StartCoroutine(Shake());
        }

        private IEnumerator Shake()
        {
            Vector3 startPosition = target.localPosition;
            float elapsedTime = 0f;
            while (elapsedTime < _duration)
            {
                float magnitude = magnitudeCurve.Evaluate(elapsedTime);
                transform.localPosition = startPosition + magnitude * Random.insideUnitSphere;
                elapsedTime += step;
                yield return _wait;
            }

            target.localPosition = startPosition;
        }
    }
}