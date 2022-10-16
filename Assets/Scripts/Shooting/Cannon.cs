using UnityEngine;

namespace Shooting
{
    public class Cannon : MonoBehaviour
    {
        [SerializeField] private Transform shootingPoint;
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private float bulletSpeed;
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

        private void Shoot()
        {
            var bullet = Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
            bullet.Setup(bulletSpeed, shootingPoint.up);
        }
    }
}


