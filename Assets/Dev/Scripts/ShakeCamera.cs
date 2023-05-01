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

    public void AnimShakeCamera()
    {
        float choque;
        choque = Random.Range(1, 3);
        switch(choque)
        {
            case 1:
                FindObjectOfType<AudioManager>().Play("Choque");
                break;
            case 2:
                FindObjectOfType<AudioManager>().Play("Choque2");
                break;
        }
            

        
        noise.m_AmplitudeGain = 3;
        LeanTween.delayedCall(0.5f, () => {
            LeanTween.value(3, 0, 0.3f).setOnUpdate((value) => { noise.m_AmplitudeGain = value; });
        });
    }
}