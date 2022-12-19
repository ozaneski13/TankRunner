using UnityEngine;
using Cinemachine;
using System.Collections;

public class CinemachineController : MonoBehaviour
{
    private CinemachineVirtualCamera _cinemachineVirtualCamera = null;

    private void Awake()
    {
        _cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();

        ShakeCamera(0.4f);
    }

    public void ShakeCamera(float intensity)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = _cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
    }

    public void ShakeCamera(float intensity, float duration)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = _cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;

        StartCoroutine(ShakeRoutine(cinemachineBasicMultiChannelPerlin, duration));
    }

    private IEnumerator ShakeRoutine(CinemachineBasicMultiChannelPerlin perlin, float duration)
    {
        yield return new WaitForSeconds(duration);

        perlin.m_AmplitudeGain = 0f;
    }
}