using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas : MonoBehaviour
{
    public Image fadeImage;
    
    private void OnEnable()
    {
        StartCoroutine(FadeAlpha(2f, true));
    }

    public IEnumerator FadeAlpha(float duration, bool fadeIn)
    {
        Color startColor = new Color(1, 1, 1, 1);
        Color endColor = new Color(1,1,1, 0);
        float time = 0;
        while (time < duration) {
            time += Time.deltaTime;
            if (fadeIn)
            {
                fadeImage.color = Color.Lerp(startColor, endColor, time/duration);
            }
            else
            {
                fadeImage.color = Color.Lerp(endColor, startColor, time/duration);
            }
            
            yield return null;
        }
    }
    
}
