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
                mesh.material.color= Color.red;
                mesh.material.SetColor("_EmissionColor", Color.red); 
                break;
            case TypeMail.Green:
                mesh.material.color = Color.green;
                mesh.material.SetColor("_EmissionColor", Color.green);
                break;
            case TypeMail.Blue:
                mesh.material.color = Color.blue;
                mesh.material.SetColor("_EmissionColor", Color.blue);
                break;
            default:
                break;
        }

        LeanTween.moveY(gameObject, transform.position.y + 0.5f,2).setLoopPingPong(-1);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ProjectilFuerza>(out ProjectilFuerza box))
        {
            if (box.typeMail == typeMail) {
                LeanTween.scale(gameObject, Vector3.zero, 0.3f).setEaseInBack().setOnComplete(() => { Destroy(gameObject); });
                Debug.Log("Sumar puntos"); }

        }
    }
}
