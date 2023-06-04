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

        continueButton.onClick.AddListener(ActivateButton);
    }

    private void ActivateButton()
    {
        if (isDouble) InventoryManager.Instance.AddRewardsToInventory();

        if (ZonesManager.Instance.currentZone < ZonesManager.maxZoneNumber)
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
    }

    private void SetButton()
    {
        continueButton = GetComponent<Button>();
    }
}
