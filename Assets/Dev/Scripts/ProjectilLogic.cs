using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilLogic : MonoBehaviour
{
    private float fuerza;
    [SerializeField] Rigidbody r;
    [SerializeField] GameObject prefabProjectil;
    [SerializeField] private Transform izq;
    [SerializeField] private Transform der;
    [SerializeField] private float capFuerza;

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKeyDown(KeyCode.D))
        {
            if (fuerza < capFuerza) fuerza++;
        }
        if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKeyDown(KeyCode.A)) 
        {
            if (fuerza < capFuerza) fuerza++;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Lanzar(izq.forward,izq.position);
        }
        
        if (Input.GetKeyUp(KeyCode.RightArrow)) Lanzar(der.forward,der.position);

    }
    
    private void Lanzar(Vector3 direct, Vector3 dir)
    {

        GameObject a = Instantiate(prefabProjectil, dir, Quaternion.Euler(Random.Range(0,360), Random.Range(0, 360), Random.Range(0, 360))) as GameObject;
        a.GetComponent<ProjectilFuerza>().AplicarFuerza(fuerza, direct);
        fuerza = 200;
    }
}
