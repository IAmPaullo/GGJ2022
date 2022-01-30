using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private Sound[] sounds;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource musicSource;
    public static SoundManager instance;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Play("Music");
        }
        else
        {
            Destroy(gameObject);
        }
    }    

    public static void Play(string sound)
    {
        if (!instance)
            return;

        foreach(Sound s in instance.sounds)
        {
            if(s.name == sound)
            {
                instance.StartSound(s);
            }
        }
    }

    public static void PlayOnShot(string sound, float pitch, float volume)
    {
        if (!instance)
            return;
        print(pitch);
        foreach (Sound s in instance.sounds)
        {
            if (s.name == sound)
            {
                instance.StartOnShot(s, pitch,volume);
            }
        }
    }

    private void StartSound(Sound sound)
    {
        audioSource.pitch = 1;
        if (sound.Loop)
        {
            if (sound.Clip == musicSource.clip)
                return;
            musicSource.volume = sound.Volume;
            musicSource.loop = sound.Loop;
            musicSource.clip = sound.Clip;
            musicSource.Play();
        }
        else
        {
            if (sound.Solo)
            {
                audioSource.volume = sound.Volume;
                audioSource.clip = sound.Clip;
                audioSource.Play();
            }
            else
            {
                audioSource.PlayOneShot(sound.Clip);
            }
        }
    }
    private void StartOnShot(Sound sound, float pitch, float volume)
    {
        audioSource.pitch = pitch;
        audioSource.PlayOneShot(sound.Clip, volume);
    }

    public static void Mute()
    {
        instance.musicSource.mute = !instance.musicSource.mute;
    }
    public static bool GetMute()
    {
        return instance.musicSource.mute;
    }    
}
