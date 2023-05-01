using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buzon : MonoBehaviour
{
    [SerializeField] Rigidbody[] bodys;
    [SerializeField] GameObject vfxHit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (var item in bodys)
            {
                item.isKinematic = false;
                vfxHit.SetActive(true);
            }
        }
    }
}
