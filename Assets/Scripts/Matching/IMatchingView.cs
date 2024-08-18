using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Matching
{
    public interface IMatchingView
    {
        public void Setup();
        public void OnMatchingButtonClick(string roomName, int playerCount);
        public virtual void OnPasswordInputFieldValueChanged(string value) { }
    }
}
