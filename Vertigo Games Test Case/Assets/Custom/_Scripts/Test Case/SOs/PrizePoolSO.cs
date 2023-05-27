using UnityEngine;

[CreateAssetMenu(fileName = "PrizePoolSO", menuName = "Scriptable Objects/PrizePoolSO")]
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

public enum Rewards
{

}
