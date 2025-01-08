using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioClip clip;
    [Range(0, 1)]
    public float volume = 0.5f;

    private void Start()
    {
        
        AudioManager.instance.PlayAudio(clip, "Musica de fondo", volume, true); 
        
    }
}
