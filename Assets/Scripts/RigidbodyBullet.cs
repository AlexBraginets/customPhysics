using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyBullet : MonoBehaviour
{
    [SerializeField] private Bullet refBullet;
    [SerializeField] private Rigidbody rb;

    private void Awake()
    {
        rb.velocity = refBullet.direction.normalized * refBullet.speed;
    }
}
