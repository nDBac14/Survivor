using UnityEngine;
using Unity.Cinemachine;  

public class ScreenShake : MonoBehaviour
{
    public static ScreenShake Instance { get; private set; }
    [SerializeField] private CinemachineImpulseSource impulseSource;

    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
    }

    public void Shake(float force = 1f)
    {
        if (impulseSource != null) impulseSource.GenerateImpulseWithForce(force);
    }
}