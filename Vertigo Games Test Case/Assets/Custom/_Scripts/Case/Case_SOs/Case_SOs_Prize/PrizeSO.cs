using UnityEngine;

namespace Case
{
    [CreateAssetMenu(fileName = "PrizeSO", menuName = "Scriptable Objects/Prize")]
    public class PrizeSO : ScriptableObject
    {
        public string prizeName;
        public Sprite prizeVisual;
        public RewardType rewardType;
    }

    public enum RewardType
    {
        Bomb,
        AdrenalineShot,
        HealthShot,
        Pills,
        C4,
        Cash,
        Gold,
        ElectricGrenade,
        EmpGrenade,
        M67Grenade,
        Snowball
    }
}

