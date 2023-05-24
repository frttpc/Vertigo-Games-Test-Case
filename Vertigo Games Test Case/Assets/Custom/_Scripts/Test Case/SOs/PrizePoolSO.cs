using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Frttpc;

[CreateAssetMenu(fileName = "PrizePoolSO", menuName = "Scriptable Objects/PrizePoolSO")]
public class PrizePoolSO : ScriptableObject
{
    [SerializeField] private Prize[] prizePool = new Prize[8];

    [System.Serializable]
    public struct Prize
    {
        public PrizeSO prizeSO;
        public int dropAmount;
    }
}
