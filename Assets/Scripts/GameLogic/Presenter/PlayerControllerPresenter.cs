using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.GamePlayer;

public class PlayerControllerPresenter : MonoBehaviour
{
    [SerializeField] SerializeInterface<IKeyInputController> keyInputController;
    [SerializeField] SerializeInterface<IMovable> characterMove;
    [SerializeField] PlayerOperatableHander handler;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(keyInputController.Value != null);
        //Debug.Log(characterMove.Value != null);
        keyInputController.Value.OnHAxis.AddListener((val) => characterMove.Value.MoveHorizontal(val));
        keyInputController.Value.OnVAxis.AddListener((val) => characterMove.Value.MoveVertical(val));
        keyInputController.Value.OnEPressed.AddListener(() => handler.PutOrTake());
    }
}
