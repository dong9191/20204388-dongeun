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
        float duration = 1.5f; 
        float timer = 0f;
        Color color = fadeImage.color;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Lerp(0f, 1f, timer / duration); 
            fadeImage.color = color;
            yield return null;
        }


        winText.SetActive(true);

       
        Time.timeScale = 0f;
    }
}