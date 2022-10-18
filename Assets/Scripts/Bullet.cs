using System;
using System.Collections;
using System.Collections.Generic;
using DecalRelated;
using MeshManipulation;
using TrajectoryRelated;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    private Vector3 originalPosition;
    private float originalSpeed;
    private Vector3 originalDirection;
    [SerializeField] private LayerMask hitLayer;
    [SerializeField] private float gravity = 9.8f;
    [SerializeField] private BulletBuilder builder;
    [SerializeField] private ColliderDataHolder colliderData;
    private HitPredictor hitPredictor;
    public event Action<Vector3, Vector3> OnLastHit;

    private void Awake()
    {
        originalPosition = transform.position;
        originalSpeed = speed;
        originalDirection = direction;
    }

    public void Setup(float speed, Vector3 direction, HitPredictor hitPredictor)
    {
        this.speed = speed;
        this.direction = direction;
        builder.Build();
        this.hitPredictor = hitPredictor;
    }

    private void FixedUpdate()
    {
        Vector3 fullSpeed = speed * direction.normalized;
        fullSpeed.y -= gravity * Time.fixedDeltaTime;
        speed = fullSpeed.magnitude;
        direction = fullSpeed;
        bool isHit = false;
        RaycastHit hit = new RaycastHit();
        foreach (var vertex in colliderData.Data.vertices)
        {
            if (IsHit(Time.deltaTime, transform.TransformPoint(vertex), out hit))
            {
                isHit = true;
                break;
            }
        }

        if (!isHit)
            transform.position += direction.normalized * speed * Time.deltaTime;
        else
        {
            Vector3 hitDirVector3 = hit.normal;
            bool isdecalHit = Physics.Raycast(new Ray(transform.position, direction), out var decalHit, 2f, hitLayer);
            direction = Vector3.Reflect(direction, hitDirVector3);

            if (!isdecalHit) decalHit = hit;
            var uv = decalHit.textureCoord;
            var decalHandler = decalHit.collider.GetComponent<DecalHandler>();
            if (decalHandler)
            {
                decalHandler.Add(uv);
            }

            if (hitPredictor.IsLastHit(transform.position, direction))
            {
                LastHit(hit);
            }

        }
    }

    private void LastHit(Vector3 position, Vector3 normal)
    {
        OnLastHit?.Invoke(position, normal);
        Destroy(gameObject);
    }

    private void LastHit(RaycastHit hit)
    {
        LastHit(hit.point, hit.normal);
    }

    private bool IsHit(float dt, Vector3 vertexPosition, out RaycastHit hit)
    {
        Ray ray = new Ray(vertexPosition, direction);
        bool isHit = Physics.Raycast(ray, out hit, speed * dt, hitLayer);
        return isHit;
    }

    [ContextMenu("simulate")]
    private void Simulate()
    {
        transform.position = originalPosition;
        speed = originalSpeed;
        direction = originalDirection;
    }
}