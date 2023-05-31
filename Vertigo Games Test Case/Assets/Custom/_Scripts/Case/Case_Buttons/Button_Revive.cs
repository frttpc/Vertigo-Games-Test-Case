using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Button_Revive : MonoBehaviour
{
    private Button reviveButton;

    [SerializeField] private PrizeSO reviveCostSO;
    [SerializeField] private int reviveCostAmount;
    [SerializeField] private Image reviveCostImage;
    [SerializeField] private TextMeshProUGUI reviveCostText;

    private void OnValidate()
    {
        reviveButton = GetComponent<Button>();
        reviveCostImage.sprite = reviveCostSO.prizeVisual;
        reviveCostText.text = reviveCostAmount.ToString();
    }

    private void Awake()
    {
        reviveButton.onClick.AddListener(() => 
        {
            if(InventoryManager.Instance.TrySpend(reviveCostSO, reviveCostAmount))
            {
                UIManager.Instance.ChangeToSpinScreen();
            }
            else
            {
                UIManager.Instance.EnableWarning();
            }
        });
    }
}
