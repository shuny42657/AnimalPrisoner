using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.Events;

namespace GameLogic.GameSystem
{
    public class Pacer : MonoBehaviourPunCallbacks, ISwitchable
    {
        [SerializeField] List<float> phaseDuration;
        float currentTime;
        int phase = 0;

        [SerializeField] bool isActive;
        public bool IsActive { get { return isActive; } set { isActive = value; } }
        public UnityEvent<int> OnCheckpointReached = new();

        [SerializeField] bool isSync;
        [SerializeField] bool looping;
        // Update is called once per frame
        void Update()
        {
            if(IsActive)
            {
                if(!isSync || PhotonNetwork.IsMasterClient)
                {
                    currentTime += Time.deltaTime;
                    if (looping)
                    {
                        if(currentTime > phaseDuration[0])
                        {
                            currentTime = 0;
                            OnCheckpointReached.Invoke(0);
                        }
                    }
                    else
                    {
                        if (phase < phaseDuration.Count && currentTime > phaseDuration[phase])
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
