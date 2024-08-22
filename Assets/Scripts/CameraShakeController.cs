using System.Collections;
using Cinemachine;
using UnityEngine;

public class CameraShakeController : MonoBehaviour
{
    private CinemachineVirtualCamera virtualCamera;
    private CinemachineBasicMultiChannelPerlin perlinNoise;

    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        perlinNoise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        ResetPerlinNoise();
    }

    private void Start()
    {
        StartCoroutine(ShakeDelayTimer(1));
    }

    private void ShakeCamera(float intensity)
    {
        perlinNoise.m_AmplitudeGain = intensity;
    }

    private IEnumerator ShakeDelayTimer(float shakeTimer)
    {
        yield return new WaitForSeconds(shakeTimer);
        
        ShakeCamera(0.05f);
        
        yield return new WaitForSeconds(1.5f);
        
        ResetPerlinNoise();
        
        yield return new WaitForSeconds(0.25f);
        
        perlinNoise.m_AmplitudeGain = 0.4f;
        perlinNoise.m_FrequencyGain = 4f;
        
        yield return new WaitForSeconds(0.5f);
        
        ResetPerlinNoise();
    }

    private void ResetPerlinNoise()
    {
        perlinNoise.m_AmplitudeGain = 0f;
        perlinNoise.m_FrequencyGain = 1f;
    }
}
