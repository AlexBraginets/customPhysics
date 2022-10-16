using UnityEngine;

namespace Shooting
{
    public class Cannon : MonoBehaviour
    {
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
            Debug.Log("Shoot");
        }
    }
}


