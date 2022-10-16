using System;
using Data;
using UnityEngine;

namespace MeshManipulation
{
    public class BulletBuilder : MonoBehaviour
    {
        [SerializeField] private MeshFilter meshFilter;
        [SerializeField] private ColliderDataHolder colliderData;
        public void Build()
        {
            meshFilter.mesh = BulletBuilderUtils.GenerateBulletMesh(out ColliderData colliderData);
            this.colliderData.Data = colliderData;
        }
    }
}
