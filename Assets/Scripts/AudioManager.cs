using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Instancia única del AudioManager para usar Singleton
    public static AudioManager instance;
    // Lista para almacenar los GameObjects de audios activos
    private List<GameObject> activeAudios;

    private void Awake()
    {
        if(!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            activeAudios = new List<GameObject>();  // Inicializa la lista de audios activos
        }
        else
        {
            Destroy(gameObject);  // Si ya hay una instancia, destruye este objeto duplicado
        }
    }


    public AudioSource PlayAudio(AudioClip clip, string objectName, float volume = 1, bool isLoop = false)
    {
        // Crea un nuevo GameObject para el audio
        GameObject audioObject = new GameObject(objectName);
        AudioSource audioSourceComponent = audioObject.AddComponent<AudioSource>(); // Agrega un componente AudioSource al GameObject
        audioSourceComponent.clip = clip;
        audioSourceComponent.volume = volume;
        audioSourceComponent.loop = isLoop;
        audioSourceComponent.Play();

        if (!isLoop)
        {
            activeAudios.Add(audioObject);
            StartCoroutine(CheckAudio(audioSourceComponent)); // Inicia la corrutina para verificar si el audio ha terminado
        }


        return audioSourceComponent;
    }

    IEnumerator CheckAudio(AudioSource audioSource)
    {
        // Mientras el audioSource exista y esté reproduciéndose
        while (audioSource != null && audioSource.isPlaying)
        {
            yield return new WaitForSeconds(.2f);
        }

        // Comprobar si el gameObject todavía existe antes de intentar destruirlo
        if (audioSource != null && !audioSource.isPlaying)
        {
            activeAudios.Remove(audioSource.gameObject); // Elimina el objeto de la lista
            Destroy(audioSource.gameObject); // Destruye el GameObject
        }
        else if (audioSource == null)
        {
            // Si el audioSource ha sido destruido antes de completar la Coroutine
            Debug.LogWarning("El AudioSource fue destruido antes de completar la Coroutine.");
        }
    }

}
