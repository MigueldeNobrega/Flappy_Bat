using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BatmanPlayer : MonoBehaviour
{
    [SerializeField] private float upVel = 300f;
    private Rigidbody2D batmanRb;
    private bool isDead;
    private int deadCount;
    private Animator batmanAnimation;
    public AudioClip deadAudioClip;
    public AudioClip flapAudioClip;
    private int deadNumber;

    private void Awake()
    {
        LoadGameData(); // Carga los datos guardados o genera nuevos si no existen
    }

    void Start()
    {
        batmanRb = GetComponent<Rigidbody2D>();
        batmanAnimation = GetComponent<Animator>();
    }

    void Update()
    {
        // Solo se ejecuta si no estás muerto
        if (!isDead)
        {
            // Para escritorio 
#if UNITY_STANDALONE || UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.Space))  // barra espaciadora
            {
                Flap();
            }

            // Para móviles 
#elif UNITY_ANDROID || UNITY_IOS
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)  // Si tocas la pantalla
        {
            Flap();
        }
#endif
        }
    }

    //Función para volar
    private void Flap()
    {
        batmanRb.velocity = Vector2.zero;
        batmanRb.AddForce(Vector2.up * upVel);
        //Activar la animacion y el sonido
        batmanAnimation.SetTrigger("Flap"); 
        AudioManager.instance.PlayAudio(flapAudioClip, "FlapSound");
    }

    private void OnCollisionEnter2D()
    {
        if (!isDead)
        {
            //Activar la animacion y el sonido
            AudioManager.instance.PlayAudio(deadAudioClip, "DeadSound");
            isDead = true;
            batmanAnimation.SetTrigger("Dead");
            GameManager.Instance.GameOver();
            deadCount++;

            Debug.Log($"Muertes actuales: {deadCount} / {deadNumber}");

            if (deadCount == deadNumber)
            {
                AdShowDead();
            }

            SaveGameData(); // Guarda los datos al morir el jugador
        }
    }

    //Funcion para controlar cuando mostrar el anuncio
    private void AdShowDead()
    {
        // AdManager.instance.ShowAd();
        deadCount = 0;
        GenerateRandomDeathNumber();
        SaveGameData(); // Guarda los datos después de reiniciar el contador
        Debug.Log("Nuevo número de muertes necesarias para mostrar anuncio: " + deadNumber);
    }

    //Funcion para generar el numero random entre 3 y 5 para mostrar el anuncio tras ese numero de muertes
    private void GenerateRandomDeathNumber()
    {
        deadNumber = UnityEngine.Random.Range(3, 6);
    }
    //Funcion para guardar la informacion del juego y controlar el contador de muerte para los anuncios
    private void SaveGameData()
    {
        PlayerPrefs.SetInt("DeadCount", deadCount);
        PlayerPrefs.SetInt("DeadNumber", deadNumber);
        PlayerPrefs.Save();
    }

    //Funcion para llevar los contadores de las muertes aunque se salga del juego
    private void LoadGameData()
    {
        deadCount = PlayerPrefs.GetInt("DeadCount", 0);
        deadNumber = PlayerPrefs.GetInt("DeadNumber", UnityEngine.Random.Range(3, 6));
    }

    public void ResetDeathState()
    {
        isDead = false;
    }
}
