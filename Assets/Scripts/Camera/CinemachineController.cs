using UnityEngine;
using Cinemachine;

public class CinemachineController : MonoBehaviour
{
    private CinemachineVirtualCamera _cinemachineVirtualCamera = null;

    private CinemachineBasicMultiChannelPerlin _cinemachineBasicMultiChannelPerlin = null;

    private void Awake()
    {
        _cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera(float intensity)
    {
        _cinemachineBasicMultiChannelPerlin = _cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        _cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
    }
}