using System;
using Shooting;
using UnityEngine;

namespace CannonControllers
{
    public class CannonShootingController : MonoBehaviour
    {
        [SerializeField] private Cannon cannon;
       

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                cannon.TryShoot();
            }
        }
    }
}
