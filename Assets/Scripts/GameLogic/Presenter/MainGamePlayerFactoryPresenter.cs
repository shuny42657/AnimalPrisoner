using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.WorkSpace;
using Sync;
using GameLogic.Map;
using GameLogic.GameSystem;
using GameLogic.Factory;
using UI;
using GameLogic.GamePlayer;

/// <summary>
/// MainGame_NoMatching(将来的にはメインのゲームシーンになる）内で動く、
/// PlayerFactoryのプレゼンター。
/// </summary>
public class MainGamePlayerFactoryPresenter 
{
    PlayerFactory _playerFactory;
    JobStatus _jobStatus;
    IPlayerStatus _playerStatus;
    BedAutomatable _bedAutomatable;
    PlayerCustomPropertyCallback _callback;
    MapBuilder _mapBuilder;
    JobDisplay _jobDisplay;
    GaugeView _gaugeView;
    IPlayStopper _playerStopper;
    IObjectiveCreator _objectiveCreator;
    public MainGamePlayerFactoryPresenter(
        PlayerFactory playerFactory,
        JobStatus jobStatus,
        IPlayerStatus playerStatus,
        BedAutomatable bedAutomatable,
        PlayerCustomPropertyCallback callback,
        MapBuilder mapBuilder,
        JobDisplay jobDisplay,
        GaugeView gaugeView,
        IPlayStopper playStopper,
        IObjectiveCreator objectiveCreator
        )
    {
        _playerFactory = playerFactory;
        _jobStatus = jobStatus;
        _playerStatus = playerStatus;
        _bedAutomatable = bedAutomatable;
        _callback = callback;
        _mapBuilder = mapBuilder;
        _jobDisplay = jobDisplay;
        _gaugeView = gaugeView;
        _playerStopper = playStopper;
        _objectiveCreator = objectiveCreator;
    }

    public void Set()
    {

    }
}

/// <summary>
/// JobAllocatorによってプレイヤーのジョブの割り当てが完了した際に呼ぶ
/// 処理をJobStatusに登録する
/// </summary>
public class SetJobPresenter
{
    JobStatus _jobStatus;
    MapBuilder _mapBuilder;
    JobDisplay _jobDisplay;

    public SetJobPresenter(
        JobStatus jobStatus,
        MapBuilder mapBuilder,
        JobDisplay jobDisplay
        )
    {
        _jobStatus = jobStatus;
        _mapBuilder = mapBuilder;
        _jobDisplay = jobDisplay;
    }

    public void Set()
    {
        _jobStatus.OnJobSet.AddListener((i_jobStatus) => _mapBuilder.BuildWorkSpaces(i_jobStatus));
        _jobStatus.OnJobSet.AddListener((i_jobStatus) => _jobDisplay.DisplayJob(i_jobStatus));
    }
}

/// <summary>
/// プレイヤーのステータスが変化した時に呼ぶコールバックの登録
/// </summary>
public class PlayerStatusPresenter
{
    IPlayerStatus _playerStatus;
    GaugeView _gaugeView;
    public PlayerStatusPresenter(IPlayerStatus playerStatus,GaugeView gaugeView)
    {
        _playerStatus = playerStatus;
        _gaugeView = gaugeView;
    }

    public void Set()
    {
        _playerStatus.OnEnergyModified.AddListener((rate) => _gaugeView.ModifyGauge(rate));
    }
}

public class PlayerManagerPresenter
{
    PlayerManager _playerManager;
    IPlayStopper _playStopper;

    public PlayerManagerPresenter(
        PlayerManager playerManager,
        IPlayStopper playStopper
        )
    {
        _playerManager = playerManager;
        _playStopper = playStopper;
    }

    public void Set()
    {

    }
}

/// <summary>
/// ObjectiveCreatorに
/// </summary>
public class ObjectiveCreatorPresenter
{
    IObjectiveCreator _objectiveCreator;
    PlayerManager _playerManager;
    public ObjectiveCreatorPresenter(
        IObjectiveCreator objectiveCreator,
        PlayerManager playerManager
        )
    {
        _objectiveCreator = objectiveCreator;
        _playerManager = playerManager;
    }

    public void Set()
    {
        _objectiveCreator.AddUpGradable(_playerManager.UpGradable);
    }
}

