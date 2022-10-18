using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneUVUtils : MonoBehaviour
{
    [SerializeField] private MeshRenderer[] planes;

    private void Awake()
    {
        foreach (var plane in planes)
        {
            var planeScale = plane.transform.localScale;
            var uvScale = new Vector2(planeScale.x, planeScale.z);
            plane.material.SetTextureScale("_MainTex", uvScale);
        }
    }
}