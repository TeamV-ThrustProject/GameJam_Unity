using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class CutSceneController : MonoBehaviour
{
    public GameObject unAc;
    public GameObject ac;

    public Image fadeImage;
    public float fadeDuration = 1f;
    public GameObject cutSceneObject;
    public float cutSceneDuration = 3.5f;

    private void Start()
    {
        // 시작 시 이미지가 완전히 투명하도록 설정
        if (fadeImage != null)
        {
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0f);
        }
        else
        {
            Debug.LogError("Fade Image is not assigned!");
        }
    }

    public void PlayCutScene()
    {
        StartCoroutine(CutSceneSequence());
    }

    private IEnumerator CutSceneSequence()
    {
        ac.SetActive(true);
        unAc.GetComponent<PlayerMovement>().enabled = false;
        unAc.SetActive(false);
        ac.GetComponent<PlayerMovement>().enabled = false;


        yield return StartCoroutine(FadeCoroutine(0f, 1f));

        if (cutSceneObject != null)
        {
            cutSceneObject.SetActive(true);
        }

        

        yield return StartCoroutine(FadeCoroutine(1f, 0f));

        yield return new WaitForSeconds(cutSceneDuration);

        yield return StartCoroutine(FadeCoroutine(0f, 1f));
        if (cutSceneObject != null)
        {
            cutSceneObject.SetActive(false);
        }

        yield return StartCoroutine(FadeCoroutine(1f, 0f));

        ac.GetComponent<PlayerMovement>().enabled = true;
    }

    private IEnumerator FadeCoroutine(float startAlpha, float endAlpha)
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, newAlpha);
            yield return null;
        }
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, endAlpha);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayCutScene();
        }
    }
}
