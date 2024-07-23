using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameLogic.WorkSpace
{
    public class MakerPutAndTake : MonoBehaviour,IPutAndTake
    {
        IResource resource;
        public IResource Resource { get { return resource; } }

        UnityEvent<IResource> onPut = new(); public UnityEvent<IResource> OnPut { get { Debug.Log("set"); return onPut; } }

        UnityEvent onTake = new(); public UnityEvent OnTake { get { return onTake; } }

        public bool Put(IResource resource)
        {
            if(this.resource == null)
            {
                Debug.Log("Item Put");
                this.resource = resource;
                onPut.Invoke(resource);
                return true;
            }
            else
            {
                Debug.Log("Fail");
                return false;
            }
        }

        public IResource Take()
        {
            var item = resource;
            resource = null;
            onTake.Invoke();
            return item;
        }
    }
}


