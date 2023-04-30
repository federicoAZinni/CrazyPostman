using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bache : MonoBehaviour
{
    [SerializeField]PrometeoCarController car;
    [SerializeField]ShakeCamera cam;
    
    [SerializeField] Rigidbody r;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstaculo"))
        {
            Debug.Log("Se comio un obstaculo");
            r.AddForce(Vector3.up * Mathf.Clamp((r.velocity.magnitude*400),100,5000),ForceMode.Impulse);
            //quitar puntos
            cam.AnimShakeCamera();
        }
    }

}
