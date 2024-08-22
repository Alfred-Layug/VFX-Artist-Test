using System.Collections;
using Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private CinemachineImpulseSource mainCameraScreenShake;
    [SerializeField] private CinemachineImpulseSource topViewScreenShake;
    [SerializeField] private float powerAmount = 0.2f;
    [SerializeField] private float shakeCountdown = 1f;

    private void Start()
    {
        StartCoroutine(ScreenShakeTimer());
    }

    private void ShakeScreen()
    {
        // mainCameraScreenShake.GenerateImpulseWithForce(powerAmount);
        // topViewScreenShake.GenerateImpulseWithForce(powerAmount);
        mainCameraScreenShake.GenerateImpulseWithVelocity(Vector3.right);
        topViewScreenShake.GenerateImpulseWithVelocity(Vector3.right);
    }

    private IEnumerator ScreenShakeTimer()
    {
        yield return new WaitForSeconds(shakeCountdown);
        ShakeScreen();
    }
}
