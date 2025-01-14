using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    public static AudioManager instance;

    private List<GameObject> activeAudios;

    private void Awake()
    {
        if(!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            activeAudios = new List<GameObject>();  
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public AudioSource PlayAudio(AudioClip clip, string objectName, float volume = 1, bool isLoop = false)
    {
        GameObject audioObject = new GameObject(objectName);
        AudioSource audioSourceComponent = audioObject.AddComponent<AudioSource>();
        audioSourceComponent.clip = clip;
        audioSourceComponent.volume = volume;
        audioSourceComponent.loop = isLoop;
        audioSourceComponent.Play();

        if (!isLoop)
        {
            activeAudios.Add(audioObject);
            StartCoroutine(CheckAudio(audioSourceComponent));
        }


        return audioSourceComponent;
    }

    IEnumerator CheckAudio(AudioSource audioSource)
    {
        while (audioSource != null && audioSource.isPlaying)
        {
            yield return new WaitForSeconds(.2f);
        }

        // Comprobar si el gameObject todavía existe antes de intentar destruirlo
        if (audioSource != null && !audioSource.isPlaying)
        {
            activeAudios.Remove(audioSource.gameObject);
            Destroy(audioSource.gameObject);
        }
        else if (audioSource == null)
        {
            // Si el audioSource ha sido destruido antes de completar la Coroutine
            Debug.LogWarning("El AudioSource fue destruido antes de completar la Coroutine.");
        }
    }

}
