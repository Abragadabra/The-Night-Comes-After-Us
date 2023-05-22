using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suicide : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioSource mainOST;

    public AudioClip Shot;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void SuicideShot()
    {
        audioSource.PlayOneShot(Shot);
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
