using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.WorkSpace
{
    //Implements functions for WorkSpace
    public interface IWorkSpaceManager
    {
        public void SubScribe();
        public void UnSubscribe();
        public void UpGrade();
        public UpGraderName UpGraderName { get; }
    }

    //This class defines behavior of WorkSpace
    //(Maker, Crafter, Teleporter, etc)
    public class WorkSpaceManager : IWorkSpaceInteraction,IUpGradable
    {
        IWorkSpaceInteraction _workSpaceController;
        IUpGradable _upGradable;
        public WorkSpaceManager(
            IWorkSpaceInteraction workSpaceController,
            IUpGradable upGradable
            )
        {
            _workSpaceController = workSpaceController;
            _upGradable = upGradable;
        }

        public void Subscribe()
        {
            _workSpaceController.Subscribe();
        }

        public void UnSubscribe()
        {
            _workSpaceController.UnSubscribe();
        }

        public void UpGrade()
        {
            _upGradable.UpGrade();
        }

        public UpGraderName UpGraderName { get { return _upGradable.UpGraderName; } }
    }
}
