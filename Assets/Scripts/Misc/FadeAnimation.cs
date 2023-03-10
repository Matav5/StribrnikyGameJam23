using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAnimation : MonoBehaviour
{
    public bool fadeOnStart =true;

    public float fadeDuration = 2;
    public Color fadeColor;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        if (fadeOnStart) FadeIn();
    }

    public void FadeIn() {
        Fade(1, 0);
    }

    public void FadeOut() {
        Fade(0, 1);
    }

    public void Fade(float alphaIn, float alphaOut) {
        StartCoroutine(FadeRoutine(alphaIn, alphaOut));
    }

    public IEnumerator FadeRoutine(float alphaIn, float alphaOut) {
        float timer = 0; Color newColor;
        while (timer <= fadeDuration) {
            //Debug.Log(timer);
            newColor = fadeColor;
            newColor.a = Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration);
            rend.material.SetColor("_BaseColor", newColor);
            timer += Time.deltaTime;
            yield return null;
        }
        newColor = fadeColor;
        newColor.a = Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration);
        rend.material.SetColor("_BaseColor", newColor);

    }
}
