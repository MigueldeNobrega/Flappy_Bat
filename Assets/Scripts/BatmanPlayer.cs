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
    public AudioClip bounceAudioClip;
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
        if (Input.GetMouseButtonDown(0) && !isDead)
        {
            Flap();
        }
    }

    private void Flap()
    {
        batmanRb.velocity = Vector2.zero;
        batmanRb.AddForce(Vector2.up * upVel);
        batmanAnimation.SetTrigger("Flap");
        AudioManager.instance.PlayAudio(flapAudioClip, "FlapSound");
    }

    private void OnCollisionEnter2D()
    {
        if (!isDead)
        {
            AudioManager.instance.PlayAudio(bounceAudioClip, "DeadSound");
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

    private void AdShowDead()
    {
        AdManager.instance.ShowAd();
        deadCount = 0;
        GenerateRandomDeathNumber();
        SaveGameData(); // Guarda los datos después de reiniciar el contador
        Debug.Log("Nuevo número de muertes necesarias para mostrar anuncio: " + deadNumber);
    }

    private void GenerateRandomDeathNumber()
    {
        deadNumber = UnityEngine.Random.Range(3, 6);
    }

    private void SaveGameData()
    {
        PlayerPrefs.SetInt("DeadCount", deadCount);
        PlayerPrefs.SetInt("DeadNumber", deadNumber);
        PlayerPrefs.Save();
    }

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
