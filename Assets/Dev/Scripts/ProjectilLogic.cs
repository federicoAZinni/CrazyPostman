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

    [SerializeField] TypeMail typeMailSelected;
    private void Update()
    {
        // Select Type  1 2 3
        if (Input.GetKeyDown(KeyCode.Alpha1)) typeMailSelected = TypeMail.Red;
        if (Input.GetKeyDown(KeyCode.Alpha2)) typeMailSelected = TypeMail.Blue;
        if (Input.GetKeyDown(KeyCode.Alpha3)) typeMailSelected = TypeMail.Green;



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
        ProjectilFuerza projectil= a.GetComponent<ProjectilFuerza>();
        projectil.typeMail = typeMailSelected;
        projectil.AplicarFuerza(fuerza, direct);
        fuerza = 200;
    }
}
