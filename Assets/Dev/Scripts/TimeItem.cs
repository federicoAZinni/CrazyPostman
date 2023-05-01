using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeItem : MonoBehaviour
{
    [SerializeField] int timeAdded;


    private void Start()
    {
        LeanTween.moveY(gameObject, transform.position.y + 2, 1).setLoopPingPong(-1);
        LeanTween.rotateAround(gameObject, Vector3.up, 360, 2).setRepeat(-1);
    }

    void AnimEnd()
    {
        LeanTween.cancel(gameObject);
        LeanTween.moveY(gameObject, transform.position.y + 2, 0.2f);
        LeanTween.scale(gameObject, Vector3.one * 1.5f,0.2f).setOnComplete(()=> {
            LeanTween.scale(gameObject, Vector3.zero, 0.2f).setEaseInBack();
            LeanTween.delayedCall(5, () => {
                TimeItemManager.ins.RespawnItemTime();
                Destroy(gameObject);
            }); 
        });
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            GameManager.Instance.time += timeAdded;
            AnimEnd();
        }
    }
}
