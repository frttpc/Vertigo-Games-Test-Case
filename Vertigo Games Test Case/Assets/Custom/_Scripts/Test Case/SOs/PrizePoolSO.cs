using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Frttpc;

public class PrizePoolSO : MonoBehaviour
{
    [SerializeField] private Prize[] prizePool = new Prize[6];

    [System.Serializable]
    public struct Prize
    {
        public PrizeSO prizeSO;
        public int dropAmount;
    }
}
