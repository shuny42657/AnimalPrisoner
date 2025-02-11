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
        public void InitObjectives();
        public bool ObjectiveAchieved(ItemName receivedItem);
        public UnityEvent<ItemName> OnNewObjectiveGenerated { get; }
        public UnityEvent<ItemName> OnObjectiveAchieved { get; }
    }

    public class ObjectiveManager : IObjectiveManager, IEnumerableRead<ItemName>
    {
        IObjectiveInitializer _objectiveInitializer;
        int _objectiveInitCount = 0;
        TeamName _team;

        UnityEvent<ItemName> _onNewObjectiveGenerated = new();
        UnityEvent<ItemName> _onObjectiveAchieved = new();
        public UnityEvent<ItemName> OnNewObjectiveGenerated { get { return _onNewObjectiveGenerated; } }
        public UnityEvent<ItemName> OnObjectiveAchieved { get { return _onObjectiveAchieved; } }

        List<ItemName> _objectives = new();

        public int InitCount { get { return _objectiveInitCount; } }

        public void Init(IObjectiveInitializer objectiveInitializer, int objectiveInitCount, TeamName team)
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
                _onNewObjectiveGenerated.Invoke(newObjective);
                _objectives.Add(newObjective);
                room.SetObjective(i, (int)_team, (int)newObjective);
            }
        }

        public bool ObjectiveAchieved(ItemName receivedItem)
        {
            var room = PhotonNetwork.CurrentRoom;
            for (int i = 0; i < _objectiveInitCount; i++)
            {
                var o = room.GetObjective(i, (int)_team);
                if (o == (int)receivedItem)
                {
                    //room.SetObjective(i, (int)_team, (int)ItemName.None);
                    _onObjectiveAchieved.Invoke((ItemName)o);
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

    public class SimpleObjectiveManager : IObjectiveManager, IEnumerableRead<ItemName>
    {
        List<ItemName> _objectives = new();
        TeamName _team;
        public int Count { get { return _objectiveCount; } }
        int _objectiveCount;

        UnityEvent<ItemName> _onNewObjectiveGenerated = new();
        UnityEvent<ItemName> _onObjectiveAchieved = new();
        public UnityEvent<ItemName> OnNewObjectiveGenerated { get { return _onNewObjectiveGenerated; } }
        public UnityEvent<ItemName> OnObjectiveAchieved { get { return _onObjectiveAchieved; } }

        public SimpleObjectiveManager(TeamName team, int objectiveCount)
        {
            _team = team;
            _objectiveCount = objectiveCount;
        }

        public IEnumerable<ItemName> GetAllItems()
        {
            List<ItemName> objectives = new();
            var currentRoom = PhotonNetwork.CurrentRoom;
            for(int i = 0; i < _objectiveCount; i++)
            {
                objectives.Add((ItemName)currentRoom.GetObjective(i, (int)_team));
            }
            return objectives;
        }

        public ItemName GetItemByIndex(int index)
        {
            return _objectives[index];
        }

        public void InitObjectives()
        {
            var room = PhotonNetwork.CurrentRoom;
            _onNewObjectiveGenerated.Invoke(ItemName.Stone);
            room.SetObjective(0, (int)_team, (int)ItemName.Stone);

            _onNewObjectiveGenerated.Invoke(ItemName.Wood);
            room.SetObjective(1, (int)_team, (int)ItemName.Wood);

            OnNewObjectiveGenerated.Invoke(ItemName.Iron);
            room.SetObjective(2, (int)_team, (int)ItemName.Iron);
        }

        public bool ObjectiveAchieved(ItemName receivedItem)
        {
            Debug.Log($"Received Item : {receivedItem}");
            var room = PhotonNetwork.CurrentRoom;
            for (int i = 0; i < _objectiveCount; i++)
            {
                var o = room.GetObjective(i, (int)_team);
                if (o == (int)receivedItem)
                {
                    //room.SetObjective(i, (int)_team, (int)ItemName.None);
                    Debug.Log($"Objective is {o}");
                    _onObjectiveAchieved.Invoke((ItemName)o);
                    return true;
                }
            }
            return false;
        }
    }

    public enum TeamName
    {
        None = 0,
        Alpha = 1,
        Beta = 2,
    }
}
