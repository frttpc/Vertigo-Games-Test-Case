using UnityEngine.UI;
using UnityEngine;

public class Button_Continue : MonoBehaviour
{
    private Button continueButton;

    [SerializeField] private bool isDouble;

    private void OnValidate()
    {
        SetButton();
    }

    private void Awake()
    {
        SetButton();

        continueButton.onClick.AddListener(() =>
        {
            if (isDouble) InventoryManager.Instance.AddRewardsToInventory();

            if(ZonesManager.Instance.currentZone < 30)
            {
                UIManager.Instance.ChangeToSpinScreen();
                ZonesManager.Instance.ChangeToNextZone();
                WheelManager.Instance.ChangeWheelVisuals();
                PrizeManager.Instance.ChangeToNextPrizePool();
            }
            else
            {
                UIManager.Instance.ChangeToResultScreen();
                PrizeManager.Instance.ShowResultPrizes();
            }
        });
    }

    private void SetButton()
    {
        continueButton = GetComponent<Button>();
    }
}
