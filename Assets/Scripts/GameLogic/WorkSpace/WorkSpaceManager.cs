using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.WorkSpace
{
    public interface IWorkSpaceManager
    {
        public void SubScribe();
        public void UnSubscribe();
        public void UpGrade();
    }
    public class WorkSpaceManager : IWorkSpaceManager
    {
        IWorkSpaceController _workSpaceController;
        IUpGradable _upGradable;
        public WorkSpaceManager(
            IWorkSpaceController workSpaceController,
            IUpGradable upGradable
            )
        {
            _workSpaceController = workSpaceController;
            _upGradable = upGradable;
        }

        public void SubScribe()
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
    }
}
