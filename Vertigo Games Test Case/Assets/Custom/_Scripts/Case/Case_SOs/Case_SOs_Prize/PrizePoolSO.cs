using UnityEngine;

namespace Case
{
    [CreateAssetMenu(fileName = "PrizePoolSO", menuName = "Scriptable Objects/PrizePool")]
    public class PrizePoolSO : ScriptableObject
    {
        public Prize[] prizePool = new Prize[8];
    }

    [System.Serializable]
    public struct Prize
    {
        public PrizeSO prizeSO;
        public int dropAmount;
    }
}

