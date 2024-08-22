using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.WorkSpace;

namespace GameLogic.GameSystem
{
    public class ObjectiveData
    {
        ItemName craftItem; public ItemName CraftItem { get { return craftItem; } }
        IUpGradable upgradable; public IUpGradable UpGradable { get { return upgradable; } }

        public ObjectiveData(ItemName craftItem,IUpGradable upgradable)
        {
            this.craftItem = craftItem;
            this.upgradable = upgradable;
        }
        public void UpGrade()
        {
            upgradable.UpGrade();
        }
    }
}
