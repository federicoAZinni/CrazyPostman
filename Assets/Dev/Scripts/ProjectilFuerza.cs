using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilFuerza : MonoBehaviour
{

    [SerializeField] Rigidbody r;


    public void AplicarFuerza(float fuerza, Vector3 direct)
    {
        
        r.AddForce(direct * fuerza);
        r.AddRelativeTorque(Vector3.one * 25);
        LeanTween.delayedCall(5, () => { Destroy(this.gameObject); });
    }
    
}
