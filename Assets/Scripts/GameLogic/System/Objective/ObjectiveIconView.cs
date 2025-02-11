using System.Collections;
using System.Collections.Generic;
using GameLogic.Data;
using GameLogic.GameSystem;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using Sync;
using TMPro;

public class ObjectiveIconView : MonoBehaviour, IObjectiveIconView
{
    [SerializeField] Image _objective1;
    [SerializeField] Image _objective2;
    [SerializeField] Image _objective3;
    [SerializeField] Image _objective1_1;
    [SerializeField] Image _objective1_2;
    [SerializeField] Image _objective2_1;
    [SerializeField] Image _objective2_2;
    [SerializeField] Image _objective3_1;
    [SerializeField] Image _objective3_2;
    [SerializeField] TextMeshProUGUI _qty1_1;
    [SerializeField] TextMeshProUGUI _qty1_2;
    [SerializeField] TextMeshProUGUI _qty2_1;
    [SerializeField] TextMeshProUGUI _qty2_2;
    [SerializeField] TextMeshProUGUI _qty3_1;
    [SerializeField] TextMeshProUGUI _qty3_2;

    TeamName _teamName;
    ItemDataBase _itemDataBase;

    public void Init(TeamName teamName,ItemDataBase itemDataBase)
    {
        _itemDataBase = itemDataBase;
        _teamName = teamName;
    }

    public void ShowObjectiveIcon()
    {
        var room = PhotonNetwork.CurrentRoom;
        var obj1 = _itemDataBase.GetData((ItemName)room.GetObjective(0, (int)_teamName));
        var obj2 = _itemDataBase.GetData((ItemName)room.GetObjective(1, (int)_teamName));
        var obj3 = _itemDataBase.GetData((ItemName)room.GetObjective(2, (int)_teamName));
        _objective1.sprite = obj1.SourceImage;
        _objective2.sprite = obj2.SourceImage;
        _objective3.sprite = obj3.SourceImage;
        var material1_1 = obj1.Source1;
        var material1_2 = obj1.Source2;
        var qty1_1 = obj1.Qty1;
        var qty1_2 = obj1.Qty2;
        var material2_1 = obj2.Source1;
        var material2_2 = obj2.Source2;
        var qty2_1 = obj2.Qty1;
        var qty2_2 = obj2.Qty2;
        var material3_1 = obj3.Source1;
        var material3_2 = obj3.Source2;
        var qty3_1 = obj3.Qty1;
        var qty3_2 = obj3.Qty2;

        _objective1_1.sprite = _itemDataBase.GetData(material1_1).SourceImage;
        _objective1_2.sprite = _itemDataBase.GetData(material1_2).SourceImage;
        _objective2_1.sprite = _itemDataBase.GetData(material2_1).SourceImage;
        _objective2_2.sprite = _itemDataBase.GetData(material2_2).SourceImage;
        _objective3_1.sprite = _itemDataBase.GetData(material3_1).SourceImage;
        _objective3_2.sprite = _itemDataBase.GetData(material3_2).SourceImage;

        _qty1_1.text = qty1_1.ToString();
        _qty1_2.text = qty1_2.ToString();
        _qty2_1.text = qty2_1.ToString();
        _qty2_2.text = qty2_2.ToString();
        _qty3_1.text = qty3_1.ToString();
        _qty3_2.text = qty3_2.ToString();
    }
}
