using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Util
{
    /// <summary>
    /// Written by Shinnosuke (2025/1/2)
    /// </summary>
    public interface IEnumerableRead<T>
    {
        public IEnumerable<T> GetAllItems();
        public T GetItemByIndex(int index);
        public int Count { get; }
    }
}
