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
        IWorkSpaceManager _workSpaceControler;
        [SerializeField] HighlightVisualizer _highlightVisualizer;
        [SerializeField] WorkSpaceProgressView _workSpaceProgressView; public WorkSpaceProgressView WorkSapceProgressView { get { return _workSpaceProgressView; } }
        [SerializeField] GrabbableVisualizer _grabbableVisualizer; public GrabbableVisualizer GrabbableVisualizer { get { return _grabbableVisualizer; } }

        public void SetWorkSpaceManager(IWorkSpaceManager workSpaceController)
        {
            _workSpaceControler = workSpaceController;
        }

        public void OnPlayerEnter()
        {
            _workSpaceControler.SubScribe();
            _highlightVisualizer.Hilight(true);
        }

        public void OnPlayerExit()
        {
            _workSpaceControler.UnSubscribe();
            _highlightVisualizer.Hilight(false);
        }
    }
}
