using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuto : MonoBehaviour
{
    [SerializeField] GameObject enter;
    void Start()
    {
        LeanTween.moveLocalY(gameObject, 0, 0.3f).setEaseOutBack().setOnComplete(()=> { 
            LeanTween.scale(enter, Vector2.one * 1.2f, 0.5f).setLoopPingPong(-1); });
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) LeanTween.moveLocalY(gameObject, 1500, 0.3f).setEaseInBack();
    }
}
