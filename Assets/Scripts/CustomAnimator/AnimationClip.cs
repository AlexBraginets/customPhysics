using System;
using UnityEngine;

namespace CustomAnimator
{
    public class AnimationClip : MonoBehaviour
    {
        [SerializeField] private AnimationCurve xCurve;
        [SerializeField] private AnimationCurve yCurve;
        [SerializeField] private AnimationCurve zCurve;
        public float Duration { get; private set; }

        public Vector3 GetPosition(float time)
        {
            time = Mathf.Clamp(
                time, 0f, Duration);
            float x = xCurve.Evaluate(time);
            float y = yCurve.Evaluate(time);
            float z = zCurve.Evaluate(time);
            return new Vector3(x, y, z);
        }
        private void Awake()
        {
            CacheData();
        }

        private void CacheData()
        {
            Duration = yCurve[yCurve.length - 1].time;
        }
    }
}
