using System.Collections.Generic;
using UnityEngine;

namespace Case
{
    [CreateAssetMenu(fileName = "PrizePoolsSO", menuName = "Scriptable Objects/PrizePoolList")]
    public class PrizePoolsSO : ScriptableObject
    {
        public List<PrizePoolSO> prizePools;
    }
}