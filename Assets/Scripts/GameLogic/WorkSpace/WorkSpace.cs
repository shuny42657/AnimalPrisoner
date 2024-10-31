using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;
using UI;
using GameLogic.Map;

namespace GameLogic.WorkSpace
{
    /// <summary>
    /// The Main Component for WorkSpace function that is attached to a GameObject.
    /// </summary>
    public class WorkSpace : MonoBehaviour, IPlayerTrigger
    {
        protected WorkSpaceManager _workSpaceManager;
        [SerializeField] protected HighlightVisualizer _highlightVisualizer;
        [SerializeField] WorkSpaceProgressView _workSpaceProgressView; public WorkSpaceProgressView WorkSapceProgressView { get { return _workSpaceProgressView; } }
        [SerializeField] protected GrabbableVisualizer _grabbableVisualizer; public GrabbableVisualizer GrabbableVisualizer { get { return _grabbableVisualizer; } }

        public void SetWorkSpaceManager(WorkSpaceManager workSpaceController)
        {
            _workSpaceManager = workSpaceController;
        }

        public WorkSpaceManager GetWorkSpaceManager()
        {
            return _workSpaceManager;
        }

        public void OnPlayerEnter()
        {
            if(_workSpaceManager != null)
            {
                _workSpaceManager.Subscribe();
                _highlightVisualizer.Hilight(true);
            }
        }

        public void OnPlayerExit()
        {
            if(_workSpaceManager != null)
            {
                _workSpaceManager.UnSubscribe();
                _highlightVisualizer.Hilight(false);
            }
        }
    }
}
