using System.Collections;
using System.Collections.Generic;
using GameLogic.Data;
using UnityEngine;

public interface IObjectiveInitializer
{
    public ItemName CreateObjective();
    public void Clear();
}

/// <summary>
/// Initialize Objective using ItemDataBase
/// </summary>
public class ItemDataBaseObjectiveInitializer : IObjectiveInitializer
{
    List<int> _objectiveItems = new();
    ItemDataBase _itemDataBase;
    public ItemDataBaseObjectiveInitializer(ItemDataBase itemDataBase)
    {
        _itemDataBase = itemDataBase;
    }

    public ItemName CreateObjective()
    {
        while (true)
        {
            var rand = Random.Range(4, 10);
            if (!_objectiveItems.Contains(rand))
            {
                _objectiveItems.Add(rand);
                return _itemDataBase.GetDataByIndex(rand).ItemName;
            }
        }
    }

    public void Clear()
    {
        _objectiveItems.Clear();
    }
}
