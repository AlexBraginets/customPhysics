using UnityEngine;

namespace Data
{
    [System.Serializable]
    public class ColliderData
    {
        public Vector3[] vertices;
        public ColliderData(Vector3[] vertices)
        {
            this.vertices = vertices;
        }
    }
}
