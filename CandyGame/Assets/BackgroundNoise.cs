using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundNoise : MonoBehaviour
{
    // Update is called once per frame
    private void Start()
    {

    }
    void Update()
    {
        FindObjectOfType<SoundManager>().bgnoise("bg");
    }
}
