using System;
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume = 1f;
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public List<Sound> sounds = new List<Sound>();
    private Dictionary<string, AudioSource> audioSources = new Dictionary<string, AudioSource>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            
        }
        else
        {
            Destroy(gameObject);
        }

        foreach (Sound sound in sounds)
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.clip = sound.clip;
            source.volume = sound.volume;
            audioSources[sound.name] = source;
        }
    }

    public void PlaySound(string name)
    {
        if (audioSources.ContainsKey(name))
        {
            audioSources[name].Play();
        }
    }

    public void StopSound(String name)
    {
        if (audioSources.ContainsKey(name))
        {
            audioSources[name].Stop();
        }
    }
}