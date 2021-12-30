using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip playerhitsound, jumpsound, enemydeathsound, buttonselectsound, walksound, playerdeathsound;
    static AudioSource audioSrc;
    private void Start()
    {
        //playerhitsound = Resources.Load<AudioClip>
        walksound = Resources.Load<AudioClip>("Samus Footstep");
        audioSrc = GetComponent<AudioSource>();
    }
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "fire":
                break;
            case "move":
                audioSrc.PlayOneShot(walksound);
                break;
            case "die":
                break;
            case "enemyDeath":
                break;
            case "jump":
                break;

        }
    }

}
