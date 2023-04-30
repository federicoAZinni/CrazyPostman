using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilFuerza : MonoBehaviour
{

    [SerializeField] Rigidbody r;
    public TypeMail typeMail;

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

}

public enum TypeMail
{
    Red,Green,Blue
}