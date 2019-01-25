using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    public Image fadeImage;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoFade(float alpha, float duration, Action<bool> callback)
    {
        StartCoroutine(DoFadeCoroutine(alpha, duration, callback));
    }

    IEnumerator DoFadeCoroutine(float alpha, float duration, Action<bool> callback) {
        float startAlpha = fadeImage.color.a;
        float endAlpha = alpha;

        for (float f = 0.0f; f <= duration; f += Time.deltaTime)
        {
            Color c = fadeImage.color;
            c.a = Mathf.Lerp(startAlpha, endAlpha, f/duration);
            fadeImage.color = c;
            yield return null;
        }

        Color final = fadeImage.color;
        final.a = endAlpha;
        fadeImage.color = final;
        callback.Invoke(true);
    }
}
