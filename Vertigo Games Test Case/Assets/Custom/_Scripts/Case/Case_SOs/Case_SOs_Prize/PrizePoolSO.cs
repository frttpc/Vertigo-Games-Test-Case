using System;
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

        public Prize(PrizeSO SO, int amount)
        {
            prizeSO = SO;
            dropAmount = amount;
        }

        public static Prize operator +(Prize a, Prize b)
        {
            if(a.prizeSO != b.prizeSO)
            {
                throw new ArgumentException("Different PrizeSOs cannot be summed!");
            }

            return new Prize(a.prizeSO, a.dropAmount + b.dropAmount);
        }

        public static Prize operator -(Prize a, Prize b)
        {
            if (a.prizeSO != b.prizeSO)
            {
                throw new ArgumentException("Different PrizeSOs cannot be subtracted!");
            }

            int num = (a.dropAmount - b.dropAmount) < 0 ? 0 : (a.dropAmount - b.dropAmount);

            return new Prize(a.prizeSO, num);
        }
    }
}

