using System;
using TrajectoryRelated;
using UnityEngine;
using VisualEffects;
using Animator = CustomAnimator.Animator;

namespace Shooting
{
    public class Cannon : MonoBehaviour
    {
        [SerializeField] private Transform shootingPoint;
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private float bulletSpeed;
        [SerializeField] private TrajectoryDrawer trajectoryDrawer;
        [SerializeField] private Animator animator;
        [SerializeField] private CameraShake cameraShake;
        [SerializeField] private ExplosionSpawner explosionSpawner;

        public void SetBulletSpeed(float power)
        {
            bulletSpeed = power;
        }

        public float GetBulletSpeed() => bulletSpeed;
        private bool canShoot
        {
            get
            {
                return true;
            }
        }

      
        public bool TryShoot()
        {
            if (!canShoot) return false;
            Shoot();
            return true;
        }

        private int i = 0;
        private void Update()
        {
            trajectoryDrawer.Draw(shootingPoint.position, shootingPoint.up * bulletSpeed);
        }

        private void Shoot()
        {
            var bullet = Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
            bullet.Setup(bulletSpeed, shootingPoint.up);
            bullet.OnLastHit += explosionSpawner.SpawnExplosion;
            animator.Play();
            cameraShake.Apply();
        }
    }
}


