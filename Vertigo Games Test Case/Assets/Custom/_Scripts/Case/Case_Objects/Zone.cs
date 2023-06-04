using UnityEngine;
using TMPro;

namespace Case
{
    public class Zone : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI zoneNumber;

        public void SetZoneNumber(int number)
        {
            zoneNumber.text = number.ToString();
        }
    }
}

