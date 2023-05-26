using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Frttpc;

[CreateAssetMenu(fileName = "PrizePoolListSO", menuName = "Scriptable Objects/PrizePoolListSO")]
public class PrizePoolListSO : ScriptableObject
{
    public List<PrizePoolSO> prizePoolList;
}
