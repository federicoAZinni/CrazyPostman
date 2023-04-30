using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilFuerza : MonoBehaviour
{

    [SerializeField] Rigidbody r;

    // 
    public void AplicarFuerza(float fuerza, Vector3 direct)
    {
        
        r.AddForce(direct * fuerza);
        r.AddRelativeTorque(Vector3.one * 25);
        LeanTween.delayedCall(5, () => {
            if (this != null)
            {
                Debug.Log("Fallo... alto manco");
                Destroy(this.gameObject);
            } 
        });
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("ObjetivoDeEntrega"))
        {
            Debug.Log("Entrego caja");
            LeanTween.cancel(gameObject);
            Destroy(gameObject);
        }
    }

}
