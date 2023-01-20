using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomRotation : MonoBehaviour
{
    void Start()
    {
        transform.Rotate(0,0,Random.Range(0,90));
    }
}