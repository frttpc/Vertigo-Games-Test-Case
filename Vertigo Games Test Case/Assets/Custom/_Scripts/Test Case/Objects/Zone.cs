using UnityEngine;
using TMPro;

public class Zone : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI zoneNumber;

    public void SetZoneNumber(int number)
    {
        zoneNumber.text = number.ToString();
    }
}
