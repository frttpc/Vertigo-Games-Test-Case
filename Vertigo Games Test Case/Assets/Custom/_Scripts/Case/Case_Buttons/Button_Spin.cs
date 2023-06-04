using UnityEngine;
using UnityEngine.UI;

namespace Case
{
    public class Button_Spin : MonoBehaviour
    {
        private Button spinButton;

        private void OnValidate()
        {
            SetButton();
        }

        private void Awake()
        {
            SetButton();

            spinButton.onClick.AddListener(ActivateButton);
        }

        private void ActivateButton()
        {
            WheelManager.Instance.Spin();
        }

        private void SetButton()
        {
            spinButton = GetComponent<Button>();
        }
    }
}
