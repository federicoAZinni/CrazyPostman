using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMail : MonoBehaviour
{
    public TypeMail typeMail;

    private void Start()
    {
        MeshRenderer mesh = GetComponent<MeshRenderer>();

        switch (typeMail)
        {
            case TypeMail.Red:
                mesh.material.color = Color.red;
                break;
            case TypeMail.Green:
                mesh.material.color = Color.green;
                break;
            case TypeMail.Blue:
                mesh.material.color = Color.blue;
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ProjectilFuerza>(out ProjectilFuerza box))
        {
            if (box.typeMail == typeMail) Debug.Log("Sumar puntos");
        }
    }
}
