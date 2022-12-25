using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSoundController : MonoBehaviour
{
    public AudioClip ClickSound;
    public AudioSource ClickSource;

    public void OnClickSound()
    {
        ClickSource.Play();
        //StartCoroutine(PlaySound(ClickSound));
    }
    private IEnumerator PlaySound(AudioSource audioSource)
    {
        audioSource.Play();
        yield return new WaitForSeconds(.5f);
    }
}
