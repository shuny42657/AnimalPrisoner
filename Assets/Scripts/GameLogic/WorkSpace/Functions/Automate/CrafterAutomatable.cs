using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.WorkSpace
{
    public class CrafterAutomatable : MonoBehaviour,IAutomatable
    {
        public void InitateOperation()
        {
            //Start
            throw new System.NotImplementedException();
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            // increase some value (probably float) to represent progress.
            // call the callback when the process is done (you can just define a callback directly inside this script).
        }
    }
}
