using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoodFinal : MonoBehaviour
{
    public Animator anim;
    public AudioSource mainOST;
    public int levelID;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void FadeToLevel()
    {
        anim.SetTrigger("fade");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelID);
    }

    public void FadeOutMusic()
    {
        StartCoroutine(FadeOutMusicCoroutine());
    }

    private IEnumerator FadeOutMusicCoroutine()
    {
        float startVolume = mainOST.volume;
        float fadeTime = 2.5f;

        while (mainOST.volume > 0)
        {
            mainOST.volume -= startVolume * Time.deltaTime / fadeTime;

            yield return null;
        }

        mainOST.Stop();
        mainOST.volume = startVolume;
    }
}
