using Data;
using UnityEngine;

namespace TrajectoryRelated
{
    public class AdvancedHitPredictor : HitPredictor
    {
        private ColliderData _colliderData;
        private Transform _bullet;

        public void Setup(ColliderData colliderData, Transform bullet)
        {
            _colliderData = colliderData;
            _bullet = bullet;
        }

        public void ResetColliderData()
        {
            _colliderData = new ColliderData(  new []{ Vector3.zero});
        }

        protected override bool IsHit(float dt, Vector3 speed, Vector3 origin, out RaycastHit hit)
        {
            bool isHit = false;
            hit = new RaycastHit();
            foreach (var vertex in _colliderData.vertices)
            {
                if (base.IsHit(dt, speed, origin + _bullet.TransformDirection(vertex),
                        out hit))
                {
                    isHit = true;
                    break;
                }
            }

            return isHit;
        }
    }
}