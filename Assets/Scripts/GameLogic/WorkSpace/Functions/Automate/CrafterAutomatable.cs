using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameLogic.WorkSpace
{
    public class CrafterAutomatable : MonoBehaviour,IAutomatable
    {
        bool working;
        ItemName itemToCraft;

        public void SetItemToCraft(ItemName itemName)
        {
            Debug.Log($"Set Item : {itemName}");
            itemToCraft = itemName;
        }

        public void InitateOperation()
        {
            if (!working && itemToCraft != ItemName.None)
            {
                onOperationInitiated.Invoke();
                working = true;
            }
            else
            {
                Debug.Log("Cannot Start Operation");
            }
        }

        float progress;
        [SerializeField] float maxProgress;

        public UnityEvent<ItemName> OnOperationFinish = new();
        public UnityEvent<float> OnProgressMade = new();

        float operationSpeed = 1;
        public float OperationSpeed { get { return operationSpeed; } set { operationSpeed = value; } }

        [SerializeField] UnityEvent onOperationInitiated = new(); public UnityEvent OnOperationInitiated { get { return onOperationInitiated; } }

        // Update is called once per frame
        void Update()
        {
            if (working)
            {
                progress += Time.deltaTime * operationSpeed;
                OnProgressMade.Invoke(progress / maxProgress);
                if(progress > maxProgress)
                {
                    progress = 0;
                    working = false;
                    OnOperationFinish.Invoke(itemToCraft);
                }
            }
        }
    }
}
