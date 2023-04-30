using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimMailCar : MonoBehaviour
{
    void Start()
    {
        LeanTween.rotateAroundLocal(gameObject, Vector3.up, 179, 5).setRepeat(-1);
    }

}
