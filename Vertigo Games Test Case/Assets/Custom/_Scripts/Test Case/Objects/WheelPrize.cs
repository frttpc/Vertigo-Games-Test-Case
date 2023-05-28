using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WheelPrize : MonoBehaviour
{
    [SerializeField] private Image wheelPrizeImage_value;
    [SerializeField] private TextMeshProUGUI wheelPrizeText_value;

    public void SetWheelPrizeValues(Sprite wheelPrizeImage, int wheelPrizeAmount)
    {
        wheelPrizeImage_value.sprite = wheelPrizeImage;

        string amount = wheelPrizeAmount.ToString();

        if (wheelPrizeAmount == 1)
            amount = "";

        wheelPrizeText_value.text = amount;
    }
}
