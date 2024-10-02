using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameLogic.GameSystem
{
    public class RoomParameter : MonoBehaviour,IRoomStatus,ISwitchable
    {
        [SerializeField] UnityEvent<float> onFuelModiied = new(); public UnityEvent<float> OnFuelModified { get { return onFuelModiied; } }

        [SerializeField] UnityEvent<float> onDurabilityModified = new(); public UnityEvent<float> OnDurabilityModified { get { return onDurabilityModified; } }

        [SerializeField] UnityEvent<float> onElectricityModified = new(); public UnityEvent<float> OnElectricityModified { get { return onElectricityModified; } }

        float fuel; public float Fuel
        {
            get { return fuel; }
            set
            {
                fuel = value; onFuelModiied.Invoke(fuel);
                if(fuel < 0 && !dead) { OnParamDead.Invoke(); dead = true; }
            }
        }

        float durability; public float Durability
        {
            get { return durability; }
            set
            {
                durability = value; onDurabilityModified.Invoke(durability);
                if(durability < 0 && !dead)
                {
                    OnParamDead.Invoke();
                    dead = true;
                }
            }
        }

        float electricity; public float Electricity
        {
            get { return electricity; }
            set
            {
                electricity = value; onElectricityModified.Invoke(electricity);
                if(electricity < 0 && !dead) { OnParamDead.Invoke(); dead = true; }
            }
        }

        [SerializeField] float maxFuel;
        [SerializeField] float maxDurability;
        [SerializeField] float maxElecticity;

        [SerializeField] float fuelComsumeSpeed; public float FuelComsumeSpeed { get { return fuelComsumeSpeed; } set { fuelComsumeSpeed = value; } }
        [SerializeField] float durabilityComsumeSpeed; public float DuranilityCosumeSpeed { get { return durabilityComsumeSpeed; } set { durabilityComsumeSpeed = value; } }
        [SerializeField] float electriticyComsumeSpeed; public float ElectricityConsumeSpeed { get { return electriticyComsumeSpeed; } set { electriticyComsumeSpeed = value; } }

        //[SerializeField] bool working; public bool Working { get { return working; } set { working = value; } }

        bool isActive = false;
        public bool IsActive
        {
            get { return isActive;}
            set { isActive = value; }
        }

        bool dead;
        public NoArgUnitaskDelegate OnParamDead;

        private void Awake()
        {
            fuel = maxFuel;
            durability = maxDurability;
            electricity = maxElecticity;
        }
        private void Update()
        {
            if (IsActive)
            {
                //Debug.Log($"working {fuel}");
                Fuel -= FuelComsumeSpeed * Time.deltaTime;
                Durability -= DuranilityCosumeSpeed * Time.deltaTime;
                Electricity -= ElectricityConsumeSpeed * Time.deltaTime;
                onFuelModiied.Invoke(fuel / maxFuel);
                onDurabilityModified.Invoke(durability / maxDurability);
                onElectricityModified.Invoke(electricity / maxElecticity);
            }
        }
    }
}

public enum RoomParameterName
{
    Fuel,
    Durability,
    Electricity,
}