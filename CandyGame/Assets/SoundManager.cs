using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{

    public Sound[] sounds;

    public static SoundManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }

    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }


        s.source.Play();

    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Stop();
    }
    public void Step(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (PlayerController.walking && !PlayerController.jump)
        {
            if (!s.source.isPlaying)
            {
                s.source.PlayOneShot(s.clip);

            }
        }
        else
        {
            s.source.Stop();
        }
    }
    public void Blaster(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (PlayerController.walking && Gun.isShooting)
        {
            if (!s.source.isPlaying)
            {
                s.source.PlayOneShot(s.clip);
            }
        }
    }
    public void death(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (PlayerController.walking && Gun.isShooting)
        {
            if (!s.source.isPlaying)
            {
                s.source.PlayOneShot(s.clip);
            }
        }
    }
    public void player_hurt(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (!s.source.isPlaying)
        {
            s.source.PlayOneShot(s.clip);
        }


    }
    public void splat(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (!s.source.isPlaying)
        {
            s.source.PlayOneShot(s.clip);
        }


    }



}
