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
        TeamName _team;

        public UnityEvent<ItemName> OnNewObjectiveGenerated = new();
        public UnityEvent<ItemName> OnObjectiveAchieved = new();

        List<ItemName> _objectives = new();

        public int InitCount { get { return _objectiveInitCount; } }

        public void Init(ObjectiveInitializer objectiveInitializer, int objectiveInitCount, TeamName team)
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
                Debug.Log("Objective Created");
                var newObjective = _objectiveInitializer.CreateObjective();
                //objectives.Add(newObjective);
                OnNewObjectiveGenerated.Invoke(newObjective);
                _objectives.Add(newObjective);
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
            return _objectives;
        }
        public ItemName GetItemByIndex(int index)
        {
            return _objectives[index];
        }
        public int Count { get { return _objectives.Count; } }
    }
    public enum TeamName
    {
        None,
        Alpha,
        Beta,
    }
}
