using System;
using Shooting;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PowerSlider : MonoBehaviour
    {
        [SerializeField] private Cannon cannon;
        [SerializeField] private Slider slider;
        [SerializeField] private TMP_Text powerLabel;
        public float GetPower() => slider.value;
        public void SetPower(int power)
        {
            slider.value = power;
        }
        private void Awake()
        {
            slider.onValueChanged.AddListener(OnValueChanged);
            slider.value = cannon.GetBulletSpeed();
        }

        private void OnValueChanged(float power)
        {
            cannon.SetBulletSpeed(power);
            powerLabel.text = power.ToString("N0");
        }
    }
}
