using System;
using Data;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MeshManipulation
{
    public static class BulletBuilderUtils
    {
        static BulletBuilderUtils()
        {
            referenceCubeVertices = new Vector3[16]
            {
                // bottom vertices
                new Vector3(.5f, -.5f, -.5f),
                new Vector3(.5f, -.5f, .5f),
                new Vector3(-.5f, -.5f, .5f),
                new Vector3(-.5f, -.5f, -.5f),

                // top vertices
                new Vector3(.5f, .5f, -.5f),
                new Vector3(.5f, .5f, .5f),
                new Vector3(-.5f, .5f, .5f),
                new Vector3(-.5f, .5f, -.5f),
                // bottom vertices
                new Vector3(.5f, -.5f, -.5f),
                new Vector3(.5f, -.5f, .5f),
                new Vector3(-.5f, -.5f, .5f),
                new Vector3(-.5f, -.5f, -.5f),

                // top vertices
                new Vector3(.5f, .5f, -.5f),
                new Vector3(.5f, .5f, .5f),
                new Vector3(-.5f, .5f, .5f),
                new Vector3(-.5f, .5f, -.5f)
               
            };
            cubeIndeces = new int[]
            {
                // bottom
                0 + 8, 1 +8, 2 + 8, 3 + 8,
                // top
                7 + 8, 6 + 8, 5 + 8, 4 + 8,
                // right
                0, 4, 5, 1,
                // left
                3, 2, 6, 7,
                // forward
                // 1, 2, 6, 5,
                5,6,2,1,
                // back 
                // 3, 0, 4, 7
                7,4,0,3
                
            };
            cubeUVs = new Vector2[]
            {
                new Vector2(0, 0),
                new Vector2(1, 0),
                new Vector2(0, 0),
                new Vector2(1, 0),

                new Vector2(0, 1),
                new Vector2(1, 1),
                new Vector2(0, 1),
                new Vector2(1, 1),
                
                new Vector2(0, 0),
                new Vector2(1, 0),
                new Vector2(1, 1),
                new Vector2(0, 1),

                new Vector2(0, 0),
                new Vector2(1, 0),
                new Vector2(1, 1),
                new Vector2(0, 1),
            };
        }

        private static readonly Vector3[] referenceCubeVertices;
        private static readonly int[] cubeIndeces;
        private static readonly Vector2[] cubeUVs;
        private const float rndVertexOffset = .05f;

        public static Mesh GenerateBulletMesh(out ColliderData colliderData)
        {
            Mesh mesh = new Mesh();
            var vertices = GenerateBulletMeshVertices();
            mesh.SetVertices(vertices);
            mesh.SetIndices(cubeIndeces, MeshTopology.Quads, 0);
            mesh.SetUVs(0, cubeUVs);
            mesh.RecalculateBounds();
            mesh.RecalculateNormals();
            colliderData = GetColliderData(vertices);
            return mesh;
        }

        private static Vector3[] GenerateBulletMeshVertices()
        {
            Vector3[] vertices = referenceCubeVertices;
            for (int i = 0; i < 8; i++)
            {
                vertices[i] += GetRandomVertexOffset();
                vertices[i + 8] = vertices[i];
            }

            return vertices;
        }

        private static ColliderData GetColliderData(Vector3[] vertices)
        {
            Vector3[] colliderDataVertices = new Vector3[8];
            Array.Copy(vertices, colliderDataVertices, 8);
            return new ColliderData(colliderDataVertices);
        }

        private static Vector3 GetRandomVertexOffset()
        {
            return Random.insideUnitSphere * rndVertexOffset;
        }
    }
}