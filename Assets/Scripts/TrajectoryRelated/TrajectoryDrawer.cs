using System;
using System.Collections.Generic;
using UnityEngine;

namespace TrajectoryRelated
{
    public class TrajectoryDrawer : MonoBehaviour
    {
        [SerializeField] private LineRenderer lineRenderer;
        [SerializeField] private LayerMask hitLayer;
        private const float gravity = 9.8f;

        public void Draw(Vector3 startPoint, Vector3 speed, float dt = .05f, float maxDistance = 500f)
        {
            List<Vector3> points = new List<Vector3>()
            {
                startPoint
            };
            float distancePassed = 0f;
            Vector3 position = startPoint;
            bool isHit = false;
            RaycastHit hit = new RaycastHit();
            while (distancePassed < maxDistance && !IsHit(dt, speed, position, out hit))
            {
                distancePassed += speed.magnitude * dt;
                UpdateSpeed(ref speed, dt);
                position += speed * dt;
                points.Add(position);
            }

            lineRenderer.positionCount = points.Count;

            lineRenderer.SetPositions(points.ToArray());
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