using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class ShakeCamera : MonoBehaviour
{
    [SerializeField]CinemachineVirtualCamera vcam;
    CinemachineBasicMultiChannelPerlin noise;
    private void Awake()
    {
        noise = vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Crash")) AnimShakeCamera();
    }

    void AnimShakeCamera()
    {
        noise.m_AmplitudeGain = 3;
        LeanTween.delayedCall(0.5f, () => {
            LeanTween.value(3, 0, 0.3f).setOnUpdate((value) => { noise.m_AmplitudeGain = value; });
        });
    }
}