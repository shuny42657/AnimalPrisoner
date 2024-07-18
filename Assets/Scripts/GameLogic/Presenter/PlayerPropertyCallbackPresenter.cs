using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sync;

public class PlayerPropertyCallbackPresenter : MonoBehaviour
{
    [SerializeField] PlayerCustomPropertyCallback callBack;

    private void Start()
    {
        callBack.onComplete.AddListener(() => Debug.Log("Job Set"));
    }
}
