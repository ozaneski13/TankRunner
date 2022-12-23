using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    public static MusicManager Instance;
    public AudioClip MenuMusic;
    public AudioClip GameMusic;
    public AudioSource MusicAudioSource;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance= this;
            MusicAudioSource = GetComponent<AudioSource>();
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void SetToMenuMusic()
    {
        MusicAudioSource.Pause();
        MusicAudioSource.clip = MenuMusic;
        MusicAudioSource.Play();
    }

    public void SetToGameMusic()
    {
        MusicAudioSource.Pause();
        MusicAudioSource.clip = GameMusic;
        MusicAudioSource.Play();
    }
}
