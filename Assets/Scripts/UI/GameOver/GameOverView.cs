using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

namespace UI
{
    public interface IViewAppear
    {
        public UniTask Appear();
    }

    public interface IButtonCallback<T>
    {
        public UnityEvent OnButtonClick { get; set; }
    }

    public class GameOverView : MonoBehaviour,IViewAppear,IButtonCallback<int>
    {
        [SerializeField] GameObject background;

        [SerializeField] Button backToTitleButton;
        [SerializeField] TextMeshProUGUI _gameResultText;

        IGetter<bool> _playerWin;

        public void Init(IGetter<bool> playerWin)
        {
            _playerWin = playerWin;
        }

        UnityEvent onButtonClick = new();
        public UnityEvent OnButtonClick {
            get { return onButtonClick; }
            set { onButtonClick = value; }
                }

        private void Awake()
        {
            backToTitleButton.onClick.AddListener(() => onButtonClick.Invoke());
        }

        public async UniTask Appear()
        {
            Debug.Log("Show Game Over");
            background.SetActive(true);
            if (_playerWin.Value)
            {
                _gameResultText.text = "Player Team Win !";
            }
            else
            {
                _gameResultText.text = "Player Team Lose";
            }
            await UniTask.Delay(500);
        }
    }
}
