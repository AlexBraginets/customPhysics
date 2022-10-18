using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class CannonPowerInputHandler : MonoBehaviour
{
   [SerializeField] private PowerSlider powerSlider;
   [SerializeField] private float sensitivity;
   private float _power;

   private void Start()
   {
      _power = powerSlider.GetPower();
   }

   private void Update()
   {
      if (Input.GetKey(KeyCode.W))
      {
         _power += Time.deltaTime * sensitivity;
         _power = Mathf.Clamp(_power, 0, 100);
         powerSlider.SetPower((int)_power);
      }
      if (Input.GetKey(KeyCode.S))
      {
         _power -= Time.deltaTime * sensitivity;
         _power = Mathf.Clamp(_power, 0, 100);
         powerSlider.SetPower((int)_power);
      }
   }
}
