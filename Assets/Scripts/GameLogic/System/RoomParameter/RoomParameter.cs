using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameLogic.GameSystem
{
    public class RoomParameter :IRoomStatus,ISwitchable,ITick
    {
        [SerializeField] UnityEvent<float> onFuelModiied = new(); public UnityEvent<float> OnFuelModified { get { return onFuelModiied; } }

        [SerializeField] UnityEvent<float> onDurabilityModified = new(); public UnityEvent<float> OnDurabilityModified { get { return onDurabilityModified; } }

        [SerializeField] UnityEvent<float> onElectricityModified = new(); public UnityEvent<float> OnElectricityModified { get { return onElectricityModified; } }

        public RoomParameter(
            float maxFuel,
            float maxDurability,
            float maxElectricity,
            float fuelComsumSpeed,
            float durabilityComsumSpeed,
            float electricityComsumSpeed
            )
        {
            _maxFuel = maxFuel;
            _maxDurability = maxDurability;
            _maxElecticity = maxElectricity;
            _fuel = _maxFuel;
            _durability = _maxDurability;
            _electricity = _maxElecticity;
            _fuelComsumeSpeed = fuelComsumSpeed;
            _durabilityComsumeSpeed = durabilityComsumSpeed;
            _electriticyComsumeSpeed = electricityComsumSpeed;
            _dead = false;
            _isActive = false;

        }    
        float _fuel; public float Fuel
        {
            get { return _fuel; }
            set
            {
                _fuel = value; onFuelModiied.Invoke(_fuel);
                if(_fuel < 0 && !_dead) { OnParamDead.Invoke(); _dead = true; Debug.Log("Dead"); }
            }
        }

        float _durability; public float Durability
        {
            get { return _durability; }
            set
            {
                _durability = value; onDurabilityModified.Invoke(_durability);
                if(_durability < 0 && !_dead)
                {
                    OnParamDead.Invoke();
                    _dead = true;
                    Debug.Log("Dead");
                }
            }
        }

        float _electricity; public float Electricity
        {
            get { return _electricity; }
            set
            {
                _electricity = value; onElectricityModified.Invoke(_electricity);
                if(_electricity < 0 && !_dead) { OnParamDead.Invoke(); _dead = true; Debug.Log("Dead"); }
            }
        }

        [SerializeField] float _maxFuel;
        [SerializeField] float _maxDurability;
        [SerializeField] float _maxElecticity;

        [SerializeField] float _fuelComsumeSpeed; public float FuelComsumeSpeed { get { return _fuelComsumeSpeed; } set { _fuelComsumeSpeed = value; } }
        [SerializeField] float _durabilityComsumeSpeed; public float DuranilityCosumeSpeed { get { return _durabilityComsumeSpeed; } set { _durabilityComsumeSpeed = value; } }
        [SerializeField] float _electriticyComsumeSpeed; public float ElectricityConsumeSpeed { get { return _electriticyComsumeSpeed; } set { _electriticyComsumeSpeed = value; } }

        //[SerializeField] bool working; public bool Working { get { return working; } set { working = value; } }

        bool _isActive = false;
        public bool IsActive
        {
            get { return _isActive;}
            set { _isActive = value; }
        }

        bool _dead;
        public NoArgUnitaskDelegate OnParamDead;

        public void Tick()
        {
            if (IsActive)
            {
                //Debug.Log($"working {fuel}");
                Fuel -= FuelComsumeSpeed * Time.deltaTime;
                Durability -= DuranilityCosumeSpeed * Time.deltaTime;
                Electricity -= ElectricityConsumeSpeed * Time.deltaTime;
                onFuelModiied.Invoke(_fuel / _maxFuel);
                onDurabilityModified.Invoke(_durability / _maxDurability);
                onElectricityModified.Invoke(_electricity / _maxElecticity);
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