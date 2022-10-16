using System.Linq;
using UnityEditor;
using UnityEngine;

namespace MeshManipulation
{
    public class MeshCopier : MonoBehaviour
    {
        [SerializeField] private string meshName;
        [SerializeField] private MeshFilter target;

        [ContextMenu("Copy unscaled mesh from target")]
        private void CopyUnscaledMeshFromTarget()
        {
            var targetMesh = target.sharedMesh;
            Mesh meshCopy = new Mesh();
            meshCopy.SetVertices(GetUnscaledVertices(targetMesh.vertices));
            meshCopy.SetIndices(targetMesh.GetIndices(0), targetMesh.GetTopology(0), 0);
            meshCopy.SetUVs(0, targetMesh.uv);
            meshCopy.RecalculateBounds();
            meshCopy.normals = targetMesh.normals;
            Debug.Log("bounds: " + meshCopy.bounds);
            Debug.Log(meshCopy.vertices.Length);
            var savePath = "Assets/" + "Meshes/" + $"{meshName}.asset";
            AssetDatabase.CreateAsset(meshCopy, savePath);
            AssetDatabase.SaveAssets();
        }

        private Vector3[] GetUnscaledVertices(Vector3[] vertices)
        {
            var scale = target.transform.lossyScale;
            var unscaledVertices = 
                vertices.Select(v => new Vector3(v.x * scale.x, v.y * scale.y, v.z * scale.z));
            return unscaledVertices.ToArray();
        }
    }
}