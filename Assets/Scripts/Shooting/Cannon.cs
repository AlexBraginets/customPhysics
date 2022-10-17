using System;
using TrajectoryRelated;
using UnityEngine;

namespace Shooting
{
    public class Cannon : MonoBehaviour
    {
        [SerializeField] private Transform shootingPoint;
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private float bulletSpeed;
        [SerializeField] private TrajectoryDrawer trajectoryDrawer;
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
            i++;
            if (i % 5 != 0) return;
            trajectoryDrawer.Draw(shootingPoint.position, shootingPoint.up * bulletSpeed);
        }

        private void Shoot()
        {
            var bullet = Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
            bullet.Setup(bulletSpeed, shootingPoint.up);
        }
    }
}


