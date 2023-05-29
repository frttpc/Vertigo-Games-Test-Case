using UnityEngine;

[CreateAssetMenu(fileName = "PrizeSO", menuName = "Scriptable Objects/Prize")]
public class PrizeSO : ScriptableObject
{
    public string prizeName;
    public Sprite prizeVisual;
    public RewardType rewardType;
}
