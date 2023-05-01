using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    [SerializeField] GameObject trashNormal;
    [SerializeField] GameObject trashCrashed;
    bool crashed;
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if (!crashed)
            {
                trashNormal.SetActive(false);
                trashCrashed.SetActive(true);
            }
        }
        
    }
}
