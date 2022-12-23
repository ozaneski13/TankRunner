using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance = null;

    public AudioClip ClickSound;
    public AudioClip BackSound;

    public AudioSource ClickSource;
    public AudioSource BackSource;

    public static SoundManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;

            //DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
        ClickSource.clip = ClickSound;
        BackSource.clip = BackSound;
    }

    public void OnClickSound()
    {
        ClickSource.Play();
        //StartCoroutine(PlaySound(ClickSound));
    }

    public void OnBackSound()
    {
        StartCoroutine(PlaySound(BackSource));
    }

    private IEnumerator PlaySound(AudioSource audioSource)
    {
        audioSource.Play();
        yield return new WaitForSeconds(1f);
    }




}
