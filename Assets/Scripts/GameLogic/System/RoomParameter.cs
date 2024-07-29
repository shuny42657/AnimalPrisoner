using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameLogic.GameSystem
{
    public class RoomParameter : MonoBehaviour,IRoomStatus
    {
        [SerializeField] UnityEvent<float> onFuelModiied = new(); public UnityEvent<float> OnFuelModified { get { return onFuelModiied; } }

        [SerializeField] UnityEvent<float> onDurabilityModified = new(); public UnityEvent<float> OnDurabilityModified { get { return onDurabilityModified; } }

        [SerializeField] UnityEvent<float> onElectricityModified = new(); public UnityEvent<float> OnElectricityModified { get { return onElectricityModified; } }

        float fuel; public float Fuel { get { return fuel; } }

        float durability; public float Durability { get { return durability; } }

        float electricity; public float Electricity { get { return electricity; } }
        [SerializeField] float maxFuel;
        [SerializeField] float maxDurability;
        [SerializeField] float maxElecticity;

        [SerializeField] float fuelComsumeSpeed; public float FuelComsumeSpeed { get { return fuelComsumeSpeed; } set { fuelComsumeSpeed = value; } }
        [SerializeField] float durabilityComsumeSpeed; public float DuranilityCosumeSpeed { get { return durabilityComsumeSpeed; } set { durabilityComsumeSpeed = value; } }
        [SerializeField] float electriticyComsumeSpeed; public float ElectricityConsumeSpeed { get { return electriticyComsumeSpeed; } set { electriticyComsumeSpeed = value; } }

        [SerializeField] bool working; public bool Working { get { return working; } set { working = value; } }

        private void Awake()
        {
            fuel = maxFuel;
            durability = maxDurability;
            electricity = maxElecticity;
        }
        private void Update()
        {
            if (working)
            {
                //Debug.Log($"working {fuel}");
                fuel -= FuelComsumeSpeed * Time.deltaTime;
                durability -= DuranilityCosumeSpeed * Time.deltaTime;
                electricity -= ElectricityConsumeSpeed * Time.deltaTime;
                onFuelModiied.Invoke(fuel / maxFuel);
                onDurabilityModified.Invoke(durability / maxDurability);
                onElectricityModified.Invoke(electricity / maxElecticity);
            }
        }
    }
}
