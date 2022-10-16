using System;
using UnityEngine;

namespace MeshManipulation
{
    public class BulletBuilder : MonoBehaviour
    {
        [SerializeField] private MeshFilter meshFilter;

        private void Awake()
        {
            BuildMesh();
        }

        public void BuildMesh()
        {
            meshFilter.mesh = BulletBuilderUtils.GenerateBulletMesh();
        }
    }
}
