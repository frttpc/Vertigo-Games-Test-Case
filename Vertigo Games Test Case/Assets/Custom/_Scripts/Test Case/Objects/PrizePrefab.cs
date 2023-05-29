using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PrizePrefab : MonoBehaviour
{
    [SerializeField] private Image prizeImage_value;
    [SerializeField] private TextMeshProUGUI prizeText_value;

    public void SetPrizeValues(Sprite prizeImage, int prizeAmount)
    {
        prizeImage_value.sprite = prizeImage;

        string amount = prizeAmount.ToString();

        if (prizeAmount == 1)
            amount = "";

        prizeText_value.text = amount;
    }
}
