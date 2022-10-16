using System;
using UnityEngine;
using UnityEngine.Assertions.Must;

namespace CannonControllers
{
    public class CannonController : MonoBehaviour
    {
        [SerializeField] private float verticalSensitivity;
        [SerializeField] private float horizontalSensitivity;
        [SerializeField] private Transform cannon;
        [SerializeField] private Transform barrelHolder;
        [SerializeField] private Vector2 minMaxBarrelAngle;
        private float minBarrelAngle => minMaxBarrelAngle.x;
        private float maxBarrelAngle => minMaxBarrelAngle.y;

        private float _verticalInput;
        private float _horizontalInput;
        private void Update()
        {
            CacheInput();
            UpdateCannonLocation();
        }

        private void CacheInput()
        {
            _verticalInput = Input.GetAxis("Mouse Y");
            _horizontalInput = Input.GetAxis("Mouse X");
        }

        private void UpdateCannonLocation()
        {
            UpdateCannonHorizontalAngle();
            UpdateCannonVerticalAngle();
        }

        private void UpdateCannonHorizontalAngle()
        {
            cannon.Rotate(Vector3.up, _horizontalInput * horizontalSensitivity);
        }

        private void UpdateCannonVerticalAngle()
        {
            float angle = barrelHolder.localEulerAngles.x;
            float targetAngle = angle - _verticalInput * verticalSensitivity;
            targetAngle = Mathf.Clamp(targetAngle, minBarrelAngle, maxBarrelAngle);
            barrelHolder.localRotation = Quaternion.Euler(targetAngle, 0f, 0f);
        }
    }
}
