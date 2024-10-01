using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Data
{
    public interface IDataBase<T,S> where S : System.Enum
    {
        public IEnumerable<T> GetAllData();
        public T GetData(S name);
    }
}
