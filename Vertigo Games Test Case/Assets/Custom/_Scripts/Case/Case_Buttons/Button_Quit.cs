using UnityEngine;
using UnityEngine.UI;

public class Button_Quit : MonoBehaviour
{
    private Button quitButton;

    private void OnValidate()
    {
        SetButton();
    }

    private void Awake()
    {
        SetButton();

        quitButton.onClick.AddListener(ActivateButton);
    }

    private void ActivateButton()
    {
        UIManager.Instance.ChangeToResultScreen();
        PrizeManager.Instance.ShowResultPrizes();
    }

    private void SetButton()
    {
        quitButton = GetComponent<Button>();
    }
}
