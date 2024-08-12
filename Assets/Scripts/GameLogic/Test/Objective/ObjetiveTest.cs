using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.WorkSpace;
using GameLogic.GameSystem;

public class ObjetiveTest : MonoBehaviour
{
    [SerializeField] List<BaseWorkSpace> upgradables;
    [SerializeField] ObjectiveCreator objCreator;
    private void Awake()
    {
        foreach(var u in upgradables)
        {
            objCreator.AddUpGradable(u);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
