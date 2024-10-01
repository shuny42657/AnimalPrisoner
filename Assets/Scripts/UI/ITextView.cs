using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public interface ITextView<T>
    {
        public void ShowText(T val);
    }
}
