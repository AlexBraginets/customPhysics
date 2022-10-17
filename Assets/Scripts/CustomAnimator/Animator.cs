using System.Collections;
using UnityEngine;

namespace CustomAnimator
{
    public class Animator : MonoBehaviour
    {
        [SerializeField] private float animationStep = .02f;
        [SerializeField] private AnimationClip animationClip;
        [SerializeField] private Transform target;
        private float time;
        private WaitForSeconds wait;
        
        public void Play()
        {
            time = 0f;
            wait = new WaitForSeconds(animationStep);
            StartCoroutine(PlayCorout());
        }

        private IEnumerator PlayCorout()
        {
            float duration = animationClip.Duration;
            while (time < duration)
            {
                target.localPosition = animationClip.GetPosition(time);
                time += animationStep;
                yield return wait;
            }
            target.localPosition = animationClip.GetPosition(time);
        }
    }
}
