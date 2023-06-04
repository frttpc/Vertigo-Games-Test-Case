using UnityEngine;

namespace Case
{
    [CreateAssetMenu(fileName = "WheelSO", menuName = "Scriptable Objects/Wheel")]
    public class WheelSO : ScriptableObject
    {
        public Sprite wheelSprite;
        public Sprite pinSprite;
    }
}

