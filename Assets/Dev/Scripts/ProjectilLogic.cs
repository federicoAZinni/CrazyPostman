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



    [SerializeField] GameObject uiboxRed;
    [SerializeField] GameObject uiboxBlue;
    [SerializeField] GameObject uiboxGreen;

    bool canShoot;

    public TypeMail TypeMailSelected { get => typeMailSelected; set {  typeMailSelected = value; UIBoxSelected(); } }

    private void Start()
    {
        canShoot = true;
        UIBoxSelected();
    }
    private void Update()
    {
        // Select Type  1 2 3
        if (Input.GetKeyDown(KeyCode.Alpha1)) TypeMailSelected = TypeMail.Red;
        if (Input.GetKeyDown(KeyCode.Alpha2)) TypeMailSelected = TypeMail.Blue;
        if (Input.GetKeyDown(KeyCode.Alpha3)) TypeMailSelected = TypeMail.Green;

        if (!canShoot) return;

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
            Lanzar(izq.forward, izq.position);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow)) Lanzar(der.forward, der.position);

        
    }

    private void UIBoxSelected()
    {
        LeanTween.cancel(uiboxRed);
        LeanTween.cancel(uiboxGreen);
        LeanTween.cancel(uiboxBlue);

        switch (TypeMailSelected)
        {
            case TypeMail.Red:
                LeanTween.scale(uiboxRed, Vector2.one * 1.3f, 0.1f).setLoopPingPong(-1);
                break;
            case TypeMail.Green:
                LeanTween.scale(uiboxGreen, Vector2.one * 1.3f, 0.1f).setLoopPingPong(-1);
                break;
            case TypeMail.Blue:
                LeanTween.scale(uiboxBlue, Vector2.one * 1.3f, 0.1f).setLoopPingPong(-1);
                break;
            default:
                break;
        }
    }

    private void Lanzar(Vector3 direct, Vector3 dir)
    {
        GameObject a = Instantiate(prefabProjectil, dir, Quaternion.Euler(Random.Range(0,360), Random.Range(0, 360), Random.Range(0, 360))) as GameObject;
        ProjectilFuerza projectil= a.GetComponent<ProjectilFuerza>();
        projectil.typeMail = TypeMailSelected;
        projectil.AplicarFuerza(fuerza, direct);
        fuerza = 200;
        canShoot = false;
        LeanTween.delayedCall(1, () => { canShoot = true; });
    }
}
