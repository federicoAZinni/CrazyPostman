using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bache : MonoBehaviour
{
    [SerializeField]PrometeoCarController car;
    [SerializeField]ShakeCamera cam;
    [SerializeField] Rigidbody r;

    [SerializeField] float divisionVel;
    [SerializeField] float multiplicacionArriba;
    [SerializeField] float limiteImpulso;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstaculo"))
        {
            Debug.Log("Se comio un obstaculo");
            r.AddForce(Vector3.up * Mathf.Clamp((r.velocity.magnitude*multiplicacionArriba),100,limiteImpulso),ForceMode.Impulse);
            r.velocity = r.velocity / divisionVel;
            cam.AnimShakeCamera();
        }
    }

    

}
