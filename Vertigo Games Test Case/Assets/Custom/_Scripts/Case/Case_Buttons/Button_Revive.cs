using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Case
{
    public class Button_Revive : MonoBehaviour
    {
        private Button reviveButton;

        [SerializeField] private PrizeSO reviveCostSO;
        [SerializeField] private int reviveCostAmount;
        [SerializeField] private Image reviveCostImage;
        [SerializeField] private TextMeshProUGUI reviveCostText;

        private void OnValidate()
        {
            SetButton();
        }

        private void Awake()
        {
            SetButton();

            reviveButton.onClick.AddListener(ActivateButton);
        }


        private void ActivateButton()
        {
            if (InventoryManager.Instance.TrySpend(reviveCostSO, reviveCostAmount))
            {
                UIManager.Instance.ChangeToSpinScreen();
            }
            else
            {
                UIManager.Instance.EnableWarning();
            }
        }

        private void SetButton()
        {
            reviveButton = GetComponent<Button>();
            reviveCostImage.sprite = reviveCostSO.prizeVisual;
            reviveCostText.text = reviveCostAmount.ToString();
        }
    }

}
