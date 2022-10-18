using System;
using System.Linq;
using UnityEngine;

namespace DecalRelated
{
    public class DecalHandler : MonoBehaviour
    {
        [SerializeField] private Vector2[] points;
        [SerializeField] private MeshRenderer renderer;

        [ContextMenu("update material")]
        private void UpdateMaterial()
        {
            renderer.material.SetColorArray("_Points", GetColorArray());
            renderer.material.SetInt("_PointsCount", points.Length);
        }

        public void Add(Vector2 point)
        {
            points[0] = point;
        }
        private Color[] GetColorArray()
        {
            var colorArray = new Color[10];
            var pointArray = points.Select(PointToColor).Take(Mathf.Min(points.Length, 10)).ToArray();
            int count = pointArray.Length;
            Array.Copy(pointArray, colorArray, pointArray.Length);
            return colorArray;

        }
        private void Update()
        {
            UpdateMaterial();
        }

        private Color PointToColor(Vector2 point)
        {
            return new Color(point.x, point.y, 0f);
        }
    }
}