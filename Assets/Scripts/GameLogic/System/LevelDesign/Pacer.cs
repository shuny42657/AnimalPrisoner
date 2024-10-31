using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.Events;

namespace GameLogic.GameSystem
{
    /// <summary>
    /// Stores ITick
    /// </summary>
    public interface IClock
    {
        public void AddTick(ITick tick);
    }

    /// <summary>
    /// Implements function that is executed repeatedly (e.g. at every Update())
    /// </summary>
    public interface ITick
    {
        public void Tick();
    }

    /// <summary>
    /// Basic Class that executes single function repetively.
    /// Used with a class that implements IClock
    /// (Does not get fired unless registered to IClock class)
    /// </summary>
    public class Pacer : ISwitchable,ITick
    {
        [SerializeField] List<float> _phaseDuration;
        float currentTime;
        int phase = 0;

        [SerializeField] bool isActive;
        public bool IsActive { get { return isActive; } set { isActive = value; } }
        public UnityEvent<int> OnCheckpointReached = new();

        [SerializeField] bool _isSync;
        [SerializeField] bool _looping;

        public Pacer(List<float> phaseDuration,bool isSync,bool looping)
        {
            _phaseDuration = phaseDuration;
            isActive = false;
            _isSync = isSync;
            _looping = looping;
        }


        public void Tick()
        {
            if (IsActive)
            {
                if (!_isSync || PhotonNetwork.IsMasterClient)
                {
                    currentTime += Time.deltaTime;
                    if (_looping)
                    {
                        if (currentTime > _phaseDuration[0])
                        {
                            currentTime = 0;
                            OnCheckpointReached.Invoke(0);
                        }
                    }
                    else
                    {
                        if (phase < _phaseDuration.Count && currentTime > _phaseDuration[phase])
                        {
                            currentTime = 0;
                            phase++;
                            OnCheckpointReached.Invoke(phase);
                        }
                    }
                }
            }
        }
    }
}
