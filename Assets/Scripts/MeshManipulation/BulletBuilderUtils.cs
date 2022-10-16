using UnityEngine;

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

        public static Mesh GenerateBulletMesh()
        {
            Mesh mesh = new Mesh();
            mesh.SetVertices(GenerateBulletMeshVertices());
            mesh.SetIndices(cubeIndeces, MeshTopology.Quads, 0);
            mesh.SetUVs(0, cubeUVs);
            mesh.RecalculateBounds();
            mesh.RecalculateNormals();

            return mesh;
        }

        private static Vector3[] GenerateBulletMeshVertices()
        {
            Vector3[] vertices = referenceCubeVertices;
            for (int i = 0; i < 8; i++)
            {
            }

            return vertices;
        }
    }
}