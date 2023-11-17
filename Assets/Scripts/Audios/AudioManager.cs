using System;
using UnityEngine;

public enum AudioTypes
{
    BGM,
    CLICK,
    WALK,
    JUMP,
    HIT,
    KEY,
    GAME_OVER,
    LEVEL_COMPLETE
}

[Serializable]
public class Audios
{
    public AudioTypes audioType;
    public AudioClip audioClip;
}

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSfx;
    [SerializeField] private AudioSource audioBgm;
    [SerializeField] private Audios[] audios;

    private static AudioManager instance = null;
    public static AudioManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        PlayMusic(AudioTypes.BGM);
    }

    public void PlaySfx(AudioTypes audioType)
    {
        AudioClip clip = FindClip(audioType);
        if (clip != null)
        {
            audioSfx.PlayOneShot(clip);
        }
        return;
    }

    public void PlayMusic(AudioTypes audioType)
    {
        AudioClip clip = FindClip(audioType);
        if (clip != null)
        {
            audioBgm.clip = clip;
            audioBgm.loop = true;
            audioBgm.playOnAwake = true;
            audioBgm.Play();
        }
        return;
    }

    private AudioClip FindClip(AudioTypes audioType)
    {
        Audios audio = Array.Find(audios, item => item.audioType == audioType);
        return audio.audioClip;
    }
}
