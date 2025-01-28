using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;
using UnityEngine.Events;
using Photon;
using Photon.Pun;
using Sync;


namespace GameLogic.GameSystem
{
    public interface IObjectiveManager
    {
        public void AddNewObjective();
        public bool ObjectiveAchieved(ItemName receivedItem);
    }


    public class ObjectiveManager : IObjectiveManager, IEnumerableRead<ItemName>
    {
        ObjectiveInitializer _objectiveInitializer;
        int _objectiveInitCount = 0;
        Team _team;

        //List<ItemName> objectives = new();
        public UnityEvent<ItemName> OnNewObjectiveGenerated = new();
        public UnityEvent<ItemName> OnObjectiveAchieved = new();

        public int InitCount { get { return _objectiveInitCount; } }

        /// <summary>
        /// Added by Shinnosuke (2025/1/2)
        /// </summary>
        public ObjectiveManager(ObjectiveInitializer objectiveInitializer, int objectiveInitCount, Team team)
        {
            _objectiveInitializer = objectiveInitializer;
            _objectiveInitCount = objectiveInitCount;
            _team = team;
        }
        public void InitObjectives()
        {
            var room = PhotonNetwork.CurrentRoom;
            for (int i = 0; i < _objectiveInitCount; i++)
            {
                var newObjective = _objectiveInitializer.CreateObjective();
                //objectives.Add(newObjective);
                OnNewObjectiveGenerated.Invoke(newObjective);
                room.SetObjective(i, (int)_team, (int)newObjective);
            }
        }
        ///

        ///iranai kamo
        public void AddNewObjective()
        {
            /*
            Debug.Log("objective added");
            var room = PhotonNetwork.CurrentRoom;
            if (objectives.Count < 2)
            {
                var newObjective = _objectiveInitializer.CreateObjective();
                objectives.Add(newObjective);
                OnNewObjectiveGenerated.Invoke(newObjective);
            }
            */
        }

        public bool ObjectiveAchieved(ItemName receivedItem)
        {
            var room = PhotonNetwork.CurrentRoom;
            for (int i = 0; i < _objectiveInitCount; i++)
            {
                var o = room.GetObjective(i, (int)_team);
                if (o == (int)receivedItem)
                {
                    room.SetObjective(i, (int)_team, (int)ItemName.None);
                    OnObjectiveAchieved.Invoke((ItemName)o);
                    return true;
                }
            }
            /*
            foreach(var o in objectives)
            {
                if(o.CraftItem == receivedItem)
                {
                    o.UpGradable.UpGrade();
                    objectives.Remove(o);
                    OnObjectiveAchieved.Invoke(o);
                    return true;
                }
            }
            */
            return false;

        }

        /// <summary>
        /// Added by Shinnosuke (2025/1/2)
        /// </summary>
        public IEnumerable<ItemName> GetAllItems()
        {
            return null;
        }
        public ItemName GetItemByIndex(int index)
        {
            return 0;
        }
        public int Count { get { return _objectiveInitCount; } }
    }
    public enum Team
    {
        None,
        Alpha,
        Beta,
    }
}
