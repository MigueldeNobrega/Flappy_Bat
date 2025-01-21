using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    //Script para guardar el clip de audio que se reproducirá como música de fondo y su volumen

    public AudioClip clip;
    [Range(0, 1)]
    public float volume = 0.5f;

    private void Start()
    {
        // Llama al AudioManager para reproducir la música de fondo en bucle
        AudioManager.instance.PlayAudio(clip, "Musica de fondo", volume, true); 
        
    }
}
