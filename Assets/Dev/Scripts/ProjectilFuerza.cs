using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilFuerza : MonoBehaviour
{

    [SerializeField] Rigidbody r;
    public TypeMail typeMail;
    [SerializeField] GameObject[] boxes;

    private void Start()
    {
        boxes[(int)typeMail].SetActive(true);
    }
    public void AplicarFuerza(float fuerza, Vector3 direct)
    {
       
        r.AddForce(direct * fuerza);
        r.AddRelativeTorque(Vector3.one * 25);
        LeanTween.delayedCall(5, () => {
            if (this != null)
            {
                LeanTween.scale(gameObject, Vector3.zero, 0.3f).setEaseInBack().setOnComplete(() => { Destroy(gameObject); });
            } 
        });
    }

}

public enum TypeMail
{
    Red,Green,Blue
}