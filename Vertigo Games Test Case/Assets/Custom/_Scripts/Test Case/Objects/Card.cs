using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card : MonoBehaviour
{
    [SerializeField] private Image cardImage;
    [SerializeField] private TextMeshProUGUI cardText;

    public void SetCardValues(Sprite prizeImage, int prizeAmount)
    {
        cardImage.sprite = prizeImage;
        cardText.text = prizeAmount.ToString();
    }
}
