using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.GamePlayer;
using UnityEngine.Events;

public class PlayerStatus : MonoBehaviour,IPlayerStatus
{
    [SerializeField] UnityEvent<float> onEnergyModified = new(); public UnityEvent<float> OnEnergyModified { get { return onEnergyModified; } }

    [SerializeField] UnityEvent<float> onHungerModified = new(); public UnityEvent<float> OnHungerModified { get { return onHungerModified; } }
    float energy = 100f;
    float hunger = 100f;
    public float Energy
    {
        get { return energy; }
        set { energy = value; onEnergyModified.Invoke(energy); }
    }
    public float Hunger { get { return hunger; } set { hunger = value; onHungerModified.Invoke(hunger); } }
}
