using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PrizePoolListSO", menuName = "Scriptable Objects/PrizePoolListSO")]
public class PrizePoolListSO : ScriptableObject
{
    public List<PrizePoolSO> prizePoolList;
}
