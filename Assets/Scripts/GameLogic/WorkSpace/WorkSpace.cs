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
        IWorkSpaceController _workSpaceControler;
        [SerializeField] HighlightVisualizer _highlightVisualizer;
        [SerializeField] WorkSpaceProgressView _workSpaceProgressView; public WorkSpaceProgressView WorkSapceProgressView { get { return _workSpaceProgressView; } }
        [SerializeField] GrabbableVisualizer _grabbableVisualizer; public GrabbableVisualizer GrabbableVisualizer { get { return _grabbableVisualizer; } }

        public void SetWorkSpaceController(IWorkSpaceController workSpaceController)
        {
            _workSpaceControler = workSpaceController;
        }
        public void OnPlayerEnter()
        {
            _workSpaceControler.Subscribe();
            _highlightVisualizer.Hilight(true);
        }

        public void OnPlayerExit()
        {
            _workSpaceControler.UnSubscribe();
            _highlightVisualizer.Hilight(false);
        }
    }
}
