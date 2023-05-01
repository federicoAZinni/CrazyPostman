using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeItem : MonoBehaviour
{
    [SerializeField] int timeAdded;
    BoxCollider boxCol;
    [SerializeField] GameObject vfxParcticle;
    [SerializeField] GameObject vfxWave;
    [SerializeField] GameObject prefabTime;

    private void Awake()
    {
        boxCol = GetComponent<BoxCollider>();
    }
    private void Start()
    {
        LeanTween.moveY(prefabTime, transform.position.y + 2, 1).setLoopPingPong(-1);
        LeanTween.rotateAround(prefabTime, Vector3.up, 360, 2).setRepeat(-1);
    }

    void AnimEnd()
    {
        LeanTween.cancel(prefabTime);
        LeanTween.moveY(prefabTime, transform.position.y + 2, 0.2f);
        LeanTween.scale(prefabTime, Vector3.one * 1.5f,0.2f).setOnComplete(()=> {
            LeanTween.scale(prefabTime, Vector3.zero, 0.2f).setEaseInBack();
            vfxParcticle.SetActive(true);
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
            FindObjectOfType<AudioManager>().Play("PickupReloj");
            GameManager.Instance.time += timeAdded;
            boxCol.enabled = false;
            vfxWave.SetActive(false);
            AnimEnd();
        }
    }
}
