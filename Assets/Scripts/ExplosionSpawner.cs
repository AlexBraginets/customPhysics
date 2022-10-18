using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSpawner : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private float explosionLifetime;

    public void SpawnExplosion(Vector3 position, Vector3 hitNormal)
    {
        var explosion = Instantiate(explosionPrefab, position , Quaternion.identity, transform);
        Destroy(explosion, explosionLifetime);
    }
}
