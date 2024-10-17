using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.GamePlayer
{
    /// <summary>
    /// PlayerPrefabにつけて、ゲームで動くPlayerを生成する
    /// </summary>
    public class MainPlayer : MonoBehaviour
    {
        [SerializeField] PlayerStatus _playerStatus;
        [SerializeField] JobStatus _jobStatus;
        [SerializeField] PlayerOperatableHander _playerOperatableHandler;

        [SerializeField] KeyHoldController _rightKeyHoldController;
        [SerializeField] KeyHoldController _leftKeyHoldController;
        [SerializeField] KeyHoldController _upKeyHoldController;
        [SerializeField] KeyHoldController _downKeyHoldController;

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }

}
