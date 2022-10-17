using System.Collections.Generic;
using UnityEngine;

namespace TrajectoryRelated
{
    public class HitPredictor : MonoBehaviour
    {
        private const float gravity = 9.8f;
        [SerializeField] private LayerMask hitLayer;

        public bool CalculateHitTime(out float hitTime, float dt, float maxDistance, Vector3 speed, Vector3 startPoint)
        {
            float distancePassed = 0f;
            Vector3 position = startPoint;
            bool isHit = false;
            bool hitHasHappened = false;
            RaycastHit hit = new RaycastHit();
            RaycastHit lastHit = hit;
            hitTime = 0f;
            while (distancePassed < maxDistance)
            {
                while (distancePassed < maxDistance && !(isHit = IsHit(dt, speed, position, out hit)))
                {
                    distancePassed += speed.magnitude * dt;
                    UpdateSpeed(ref speed, dt);
                    position += speed * dt;
                    hitTime += dt;
                }

                if (isHit)
                {
                    hitHasHappened = true;
                    lastHit = hit;
                    Vector3 hitDirVector3 = hit.normal;
                    speed = Vector3.Reflect(speed, hitDirVector3);
                }
            }

            return hitHasHappened;
        }

        public List<Vector3> GetTrajectory(out float hitTime, float dt, float maxDistance, Vector3 speed,
            Vector3 startPoint)
        {
            List<Vector3> trajectory = new List<Vector3>();
            trajectory.Add(startPoint);
            float distancePassed = 0f;
            Vector3 position = startPoint;
            bool isHit = false;
            bool hitHasHappened = false;
            RaycastHit hit = new RaycastHit();
            RaycastHit lastHit = hit;
            hitTime = 0f;
            while (distancePassed < maxDistance)
            {
                while (distancePassed < maxDistance && !(isHit = IsHit(dt, speed, position, out hit)))
                {
                    distancePassed += speed.magnitude * dt;
                    UpdateSpeed(ref speed, dt);
                    position += speed * dt;
                    hitTime += dt;
                    trajectory.Add(position);
                }

                if (isHit)
                {
                    hitHasHappened = true;
                    lastHit = hit;
                    Vector3 hitDirVector3 = hit.normal;
                    speed = Vector3.Reflect(speed, hitDirVector3);
                }
            }

            return trajectory;
        }
        private void UpdateSpeed(ref Vector3 speed, float dt)
        {
            speed.y -= gravity * dt;
        }

        private bool IsHit(float dt, Vector3 speed, Vector3 vertexPosition, out RaycastHit hit)
        {
            Ray ray = new Ray(vertexPosition, speed);
            bool isHit = Physics.Raycast(ray, out hit, speed.magnitude * dt, hitLayer);
            return isHit;
        }
    }
}