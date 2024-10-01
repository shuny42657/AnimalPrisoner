using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.WorkSpace;

namespace GameLogic.Data
{
    [CreateAssetMenu(fileName = "UpGraderData", menuName = "ScriptableObjects/UpGraderData")]
    public class UpGraderData : ScriptableObject
    {
        [SerializeField] UpGraderName upGraderName; public UpGraderName UpGraderName { get { return upGraderName; } }
        [SerializeField] Sprite sourceImage; public Sprite SourceImage { get { return sourceImage; } }
    }
}
