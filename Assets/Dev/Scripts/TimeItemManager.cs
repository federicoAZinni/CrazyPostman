using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeItemManager : MonoBehaviour
{
    [SerializeField] List<Transform> refPos;
    [SerializeField] List<Transform> refPosUsed;
    [SerializeField] GameObject timeItemPrefab;

    public static TimeItemManager ins;

    private void Awake()
    {
        ins = this;
    }

    private void Start()
    {
        foreach (Transform item in transform)
        {
            refPos.Add(item);
        }
        RespawnItemTime();
    }
    public void RespawnItemTime()
    {
        if(refPosUsed.Count>0)
        {
            foreach (var item in refPosUsed)
            {
                refPos.Add(item);
            }

            refPosUsed.Clear();
        }
        
        Transform a = refPos[Random.Range(0, refPos.Count)];
        refPosUsed.Add(a);
        refPos.Remove(a);
        Instantiate(timeItemPrefab, a.position, Quaternion.identity);

       
    }
}
