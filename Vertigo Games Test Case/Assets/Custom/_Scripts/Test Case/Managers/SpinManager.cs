using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpinManager : MonoBehaviour
{
    public PrizePoolListSO prizePoolListSO;

    [SerializeField] private Transform[] positions = new Transform[8];

    [SerializeField] private GameObject prizePrefab;
    private Prize chosenPrize;

    [Header("Wheel")]
    [SerializeField] private GameObject wheel;
    [SerializeField] [Range(2, 5)] private int spinDuration;
    [SerializeField] private Ease spinEase;

    private Vector3 spinRotation = new (0, 0, 360);
    private const int prizeCount = 8;
    private static readonly int currentZone = 0;
    private bool isSpinning;

    public static SpinManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(prizePrefab, positions[i]);
        }
    }

    public void Spin()
    {
        isSpinning = true;

        int prizeIndex = Random.Range(0, 8);
        chosenPrize = prizePoolListSO.prizePoolList[currentZone].prizePool[prizeIndex];

        Vector3 targetRotation = spinRotation * spinDuration + new Vector3 (0, 0, prizeIndex * 45f);

        wheel.transform.DOLocalRotate(targetRotation, spinDuration, RotateMode.FastBeyond360)
            .SetEase(spinEase)
            .SetRelative()
            .OnComplete(() =>
            {
                isSpinning = false;

                UIManager.Instance.ChangeToResultScreen();
            });
    }
}
