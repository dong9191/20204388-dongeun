using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public Image fadeImage;    
    public GameObject winText; 

 
    public void GameClear()
    {
        StartCoroutine(FadeAndShowText());
    }

    IEnumerator FadeAndShowText()
    {
        float duration = 1.5f; // 1.5초 동안 화면이 어두워집니다.
        float timer = 0f;
        Color color = fadeImage.color;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Lerp(0f, 1f, timer / duration); 
            fadeImage.color = color;
            yield return null;
        }

        // 화면이 다 어두워지면 글자를 스르륵 띄웁니다!
        winText.SetActive(true);

        // 연출이 완전히 끝난 후 게임을 멈춥니다.
        Time.timeScale = 0f;
    }
}