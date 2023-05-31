using UnityEngine;
using UnityEngine.UI;

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

        spinButton.onClick.AddListener(() =>
        {
            WheelManager.Instance.Spin();
        });
    }

    private void SetButton()
    {
        spinButton = GetComponent<Button>();
    }
}
