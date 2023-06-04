using UnityEngine;
using DG.Tweening;

public class ZonesManager : MonoBehaviour
{
    [Header("Zone Prefabs")]
    [SerializeField] private Zone normalZonePrefab;
    [SerializeField] private Zone safeZonePrefab;
    [SerializeField] private Zone goldZonePrefab;

    [Space]
    [SerializeField] private Transform zonesParent;
    [SerializeField] [Range(0, 1)] private float gapBetweenZones;

    [Header("Switch")]
    [SerializeField] [Range(0, 2)] private float switchDuration;
    [SerializeField] private Ease switchEase;

    public const int maxZoneNumber = 30;
    public const int silverZonePerNumber = 5;
    public int currentZone { get; private set; } = 0;

    public static ZonesManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        int length = PrizeManager.Instance.prizePoolsSO.prizePools.Count;
        Zone newZonePrefab;

        for (int i = 1; i < length + 1; i++)
        {
            Vector3 pos = new (gapBetweenZones * (i-1), 0, 0);

            if (i % silverZonePerNumber == 0 || i == 1)
            {
                if (i == maxZoneNumber)
                {
                    newZonePrefab = goldZonePrefab;
                }
                else
                {
                    newZonePrefab = safeZonePrefab;
                }
            }
            else
                newZonePrefab = normalZonePrefab;

            Zone newZone = Instantiate(newZonePrefab, pos, Quaternion.identity, zonesParent);
            newZone.SetZoneNumber(i);
            newZone.transform.localPosition = pos;
        }
    }

    public void ChangeToNextZone()
    {
        IncreaseCurrentZone();
        zonesParent.transform.DOLocalMoveX(zonesParent.transform.localPosition.x - gapBetweenZones, switchDuration).SetEase(switchEase).SetRecyclable();
    }

    private void IncreaseCurrentZone()
    {
        currentZone++;
    }
}
