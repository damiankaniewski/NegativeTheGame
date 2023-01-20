using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Color[] colors;
    public float transitionTime = 1.0f;

    private SpriteRenderer renderer;
    private int currentIndex = 0;
    private float timeElapsed = 0.0f;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.color = colors[currentIndex];
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;
        renderer.color = Color.Lerp(colors[currentIndex], colors[(currentIndex + 1) % colors.Length],
            timeElapsed / transitionTime);
        if (timeElapsed >= transitionTime)
        {
            currentIndex = (currentIndex + 1) % colors.Length;
            timeElapsed = 0;
        }
    }
}